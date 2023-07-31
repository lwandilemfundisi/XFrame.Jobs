using XFrame.VersionTypes;

namespace XFrame.Jobs
{
    public class JobDefinition : VersionedTypeDefinition
    {
        public JobDefinition(
            int version,
            Type type,
            string name)
            : base(version, type, name)
        {
        }
    }
}
