using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartItemHandler : IRequestHandler<CreateCartItemCommand, CreateCartItemResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateCartItemHandler(ICartRepository cartRepository, 
        IUserRepository userRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }
    
    public async Task<CreateCartItemResult> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartItemCommandValidator();
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.Errors);
        }
        
        User? user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found.");
        }
        
        Cart cart = _mapper.Map<Cart>(request);
        List<CartItem> cartItemsNotFound = new List<CartItem>();

        foreach (CartItem cartItem in cart.Items)
        {
            var product = await _productRepository.GetByIdAsync(cartItem.ProductId, cancellationToken);

            if (product == null)
            {
                cartItemsNotFound.Add(cartItem);
                cart.Items.Remove(cartItem);
                continue;
            }
            
            cartItem.ProductId = product.Id;
            cartItem.PriceAtAddition = product.Price * cartItem.Quantity;
        }
        
        Cart createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
        
        return _mapper.Map<CreateCartItemResult>((createdCart, cartItemsNotFound));
    }
}