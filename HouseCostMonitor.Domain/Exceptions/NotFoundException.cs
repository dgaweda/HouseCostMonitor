namespace HouseCostMonitor.Domain.Exceptions;

public class NotFoundException(string resourceType, string? resourceId = null) 
    : Exception(resourceId == null ? 
        $"{resourceType} doesn't exist" :
        $"{resourceType} with id: {resourceId} doesn't exist");