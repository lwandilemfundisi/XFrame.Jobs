using XFrame.VersionTypes;

namespace XFrame.Jobs
{
    public interface IJobDefinitionService 
        : IVersionedTypeDefinitionService<JobVersionAttribute, JobDefinition>
    {
    }
}
