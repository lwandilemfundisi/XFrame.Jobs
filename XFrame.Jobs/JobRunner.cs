using XFrame.Common;
using XFrame.Common.JsonSerializer;
using XFrame.Jobs.Exceptions;

namespace XFrame.Jobs
{
    public class JobRunner : IJobRunner
    {
        private readonly IJobDefinitionService _jobDefinitionService;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IServiceProvider _serviceProvider;

        public JobRunner(
            IServiceProvider serviceProvider,
            IJobDefinitionService jobDefinitionService,
            IJsonSerializer jsonSerializer)
        {
            _serviceProvider = serviceProvider;
            _jobDefinitionService = jobDefinitionService;
            _jsonSerializer = jsonSerializer;
        }

        public void Execute(string jobName, int version, string job)
        {
            Execute(jobName, version, job, CancellationToken.None);
        }

        public void Execute(string jobName, int version, string json, CancellationToken cancellationToken)
        {
            using (var a = AsyncHelper.Wait)
            {
                a.Run(ExecuteAsync(jobName, version, json, cancellationToken));
            }
        }

        public Task ExecuteAsync(string jobName, int version, string json, CancellationToken cancellationToken)
        {
            JobDefinition jobDefinition;
            if (!_jobDefinitionService.TryGetDefinition(jobName, version, out jobDefinition))
            {
                throw UnknownJobException.With(jobName, version);
            }

            var executeCommandJob = (IJob)_jsonSerializer.Deserialize(json, jobDefinition.Type);
            return executeCommandJob.ExecuteAsync(_serviceProvider, cancellationToken);
        }
    }
}
