using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetAll;

public class GetAllCartsHandler : IRequestHandler<GetAllCartsCommand, List<GetAllCartsResult>>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public GetAllCartsHandler(ICartRepository cartRepository, ICartItemRepository cartItemRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GetAllCartsResult>> Handle(GetAllCartsCommand request, CancellationToken cancellationToken)
    {
        ICollection<Cart> carts = await _cartRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<List<GetAllCartsResult>>(carts);
    }
}