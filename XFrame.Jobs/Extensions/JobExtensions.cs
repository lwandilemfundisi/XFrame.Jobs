using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using XFrame.Common.Extensions;

namespace XFrame.Jobs.Extensions
{
    public static class JobExtensions
    {
        public static void AddInstantJobScheduler(
            this IServiceCollection services)
        {
            services.TryAddTransient<IJobScheduler, InstantJobScheduler>();
        }

        public static void AddJobRunner(
            this IServiceCollection services)
        {
            services.TryAddSingleton<IJobDefinitionService, JobDefinitionService>();
            services.TryAddTransient<IJobRunner, JobRunner>();
        }

        public static IEnumerable<Type> GetJobs(
            this Assembly assembly,
            Predicate<Type> predicate = null)
        {
            predicate = predicate ?? (t => true);
            var jobTypes = assembly
                .GetTypes()
                .Where(type => !type.GetTypeInfo().IsAbstract && type.IsAssignableTo<IJob>())
                .Where(t => !t.HasConstructorParameterOfType(i => i.IsAssignableTo<IJob>()))
                .Where(t => predicate(t));
            return jobTypes;
        }
    }
}
