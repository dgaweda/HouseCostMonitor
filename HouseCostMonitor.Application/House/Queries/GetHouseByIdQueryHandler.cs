namespace HouseCostMonitor.Application.Extensions.House.Queries;

using AutoMapper;
using HouseCostMonitor.Application.House.Dtos;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record GetHouseByIdQuery(Guid HouseId) : IRequest<HouseDto>;

public class GetHouseByIdQueryHandler(IHouseRepository houseRepository, IMapper mapper) : IRequestHandler<GetHouseByIdQuery, HouseDto>
{
    public async Task<HouseDto> Handle(GetHouseByIdQuery request, CancellationToken cancellationToken)
    {
        var houseFromDb = await houseRepository.GetByIdAsync(request.HouseId, cancellationToken);
        var dto = mapper.Map<HouseDto>(houseFromDb);

        return dto;
    }
}