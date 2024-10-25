using HouseCostMonitor.Application.Services.Job.Dtos;

namespace HouseCostMonitor.Application.Services.Job;

public interface IJobService
{
    Task<IEnumerable<JobDto>> GetAll();
}