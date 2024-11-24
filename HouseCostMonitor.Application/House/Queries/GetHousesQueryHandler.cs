namespace HouseCostMonitor.Application.House.Queries;

using System.Collections;
using AutoMapper;
using HouseCostMonitor.Application.House.Dtos;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Exceptions;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record GetHousesQuery : IRequest<IEnumerable<HouseDto>>;

public class GetHousesQueryHandler(IHouseRepository houseRepository, IMapper mapper) : IRequestHandler<GetHousesQuery, IEnumerable<HouseDto>>
{
    public async Task<IEnumerable<HouseDto>> Handle(GetHousesQuery request, CancellationToken cancellationToken)
    {
        var houses = await houseRepository.GetAllAsync(cancellationToken: cancellationToken);
        if (!houses.Any())
            throw new NotFoundException(nameof(House));
            
        var dto = mapper.Map<IEnumerable<HouseDto>>(houses);
        return dto;
    }
}