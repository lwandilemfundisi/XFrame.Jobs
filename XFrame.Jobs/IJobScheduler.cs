namespace XFrame.Jobs
{
    public interface IJobScheduler
    {
        Task<IJobId> ScheduleNowAsync(
            IJob job,
            CancellationToken cancellationToken);

        Task<IJobId> ScheduleAsync(
            IJob job, 
            DateTimeOffset runAt, 
            CancellationToken cancellationToken);

        Task<IJobId> ScheduleAsync(
            IJob job, 
            TimeSpan delay, 
            CancellationToken cancellationToken);
    }
}
