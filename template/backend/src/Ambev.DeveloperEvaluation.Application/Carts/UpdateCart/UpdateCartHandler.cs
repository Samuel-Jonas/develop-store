using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public UpdateCartHandler(ICartRepository cartRepository, 
        IMapper mapper,
        ICartItemRepository cartItemRepository)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
    }
    
    public async Task<UpdateCartResult> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var validation = new UpdateCartCommandValidator();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        Cart cart = _mapper.Map<Cart>(request);
        
        Cart? existingCart = await _cartRepository.GetByIdAsync(cart.Id, cancellationToken);

        if (existingCart == null)
        {
            throw new Exception("Cart not found");
        }
        
        foreach (CartItem item in cart.Items)
        {
            item.Id = existingCart.Items.FirstOrDefault(o => o.ProductId == item.ProductId)?.Id ?? item.Id;
            item.PriceAtAddition = existingCart.Items.FirstOrDefault(o => o.ProductId == item.ProductId)?.Product.Price * item.Quantity ?? item.PriceAtAddition;
            
            await _cartItemRepository.UpdateAsync(item, cancellationToken);
        }
        
        Cart exitingCart = await _cartRepository.UpdateCartAsync(cart, cancellationToken);
        
        return _mapper.Map<UpdateCartResult>(exitingCart);
    }
}