namespace XFrame.Jobs
{
    public interface IJobRunner
    {
        void Execute(
            string jobName,
            int version,
            string job);

        void Execute(
            string jobName,
            int version,
            string json,
            CancellationToken cancellationToken);

        Task ExecuteAsync(
            string jobName,
            int version,
            string json,
            CancellationToken cancellationToken);
    }
}
