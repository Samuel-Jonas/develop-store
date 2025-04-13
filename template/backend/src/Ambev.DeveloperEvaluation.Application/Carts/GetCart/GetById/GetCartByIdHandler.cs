using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart.GetById;

public class GetCartByIdHandler : IRequestHandler<GetCartByIdCommand, GetCartByIdResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public GetCartByIdHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }
    
    public async Task<GetCartByIdResult> Handle(GetCartByIdCommand request, CancellationToken cancellationToken)
    {
        Cart? cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return _mapper.Map<GetCartByIdResult>(cart);
    }
}