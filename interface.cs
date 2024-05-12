public interface IScheduleEventRepository
{
    Task AddAsync(ScheduleEvent scheduleEvent);
    Task<ScheduleEvent> GetByIdAsync(string id);
    Task UpdateAsync(ScheduleEvent scheduleEvent);
    Task DeleteAsync(string id);
    Task<IEnumerable<ScheduleEvent>> GetItemsAsync(Expression<Func<ScheduleEvent, bool>> predicate);
}

public interface IEventLogRepository
{
    Task AddAsync(EventLog eventLog);
    Task<EventLog> GetByIdAsync(string eventId, DateOnly logDate);
    Task UpdateAsync(EventLog eventLog);
    Task DeleteAsync(string eventId, DateOnly logDate);
    Task<IEnumerable<EventLog>> GetItemsAsync(Expression<Func<EventLog, bool>> predicate);
}
