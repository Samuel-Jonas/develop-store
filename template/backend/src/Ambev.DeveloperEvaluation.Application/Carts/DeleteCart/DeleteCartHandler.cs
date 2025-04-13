using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResponse>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;

    public DeleteCartHandler(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
    }

    public async Task<DeleteCartResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.Errors);
        }
        
        Cart? cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);

        if (cart == null)
        {
            throw new KeyNotFoundException($"Cart with id: {request.Id} not found.");
        }

        foreach (var item in cart.Items)
        {
            bool itemSuccess = await _cartItemRepository.DeleteAsync(item.Id, cancellationToken);

            if (!itemSuccess)
            {
                throw new KeyNotFoundException($"Cart item with id: {item.Id} not found.");
            }
        }
        
        bool _ = await _cartRepository.DeleteAsync(request.Id, cancellationToken);

        return new DeleteCartResponse { Success = true };
    }
}