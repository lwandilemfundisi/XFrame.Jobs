using XFrame.VersionTypes;

namespace XFrame.Jobs
{
    public interface IJob : IVersionedType
    {
        Task ExecuteAsync(
            IServiceProvider serviceProvider,
            CancellationToken cancellationToken);
    }
}
