namespace HouseCostMonitor.Application.Job.Profiles;

using AutoMapper;
using HouseCostMonitor.Application.Job.Commands.CreateJob;
using HouseCostMonitor.Application.Job.Commands.EditJob;
using HouseCostMonitor.Application.Job.Dtos;
using HouseCostMonitor.Domain.Entities;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Job, JobDto>();
        
        CreateMap<CreateJobCommand, Job>();
        
        CreateMap<EditJobCommand, Job>();
    }
}