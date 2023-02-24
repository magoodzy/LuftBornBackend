using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarbellaMS.Services.ScheduleTasks
{
    public interface IHostedervice
    {
        public System.Threading.Tasks.Task StartAsync(System.Threading.CancellationToken cancellationToken);
        public System.Threading.Tasks.Task StopAsync(System.Threading.CancellationToken cancellationToken);
    }
}
