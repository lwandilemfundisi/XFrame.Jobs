﻿using XFrame.Ids;

namespace XFrame.Jobs
{
    public class JobId : Identity<JobId>, IJobId
    {
        public JobId(string value) : base(value)
        {
        }
    }
}
