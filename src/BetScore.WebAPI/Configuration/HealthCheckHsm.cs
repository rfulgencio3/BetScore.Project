using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace Characteristics.WebAPI.Configuration
{
    public class HealthCheckHsm : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            // TODO: Validação de conexao com hsm
            return Task.Run(() => HealthCheckResult.Healthy());
        }
    }
}
