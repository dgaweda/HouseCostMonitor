namespace HouseCostMonitor.Application.Services.Job.Profiles;

using AutoMapper;
using HouseCostMonitor.Application.Services.Job.Queries;
using HouseCostMonitor.Domain.Entities;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Job, GetJobsQuery>();
    }
}