using XFrame.VersionTypes;

namespace XFrame.Jobs
{
    [AttributeUsage(AttributeTargets.Class)]
    public class JobVersionAttribute : VersionedTypeAttribute
    {
        public JobVersionAttribute(
            string name,
            int version)
            : base(name, version)
        {
        }
    }
}
