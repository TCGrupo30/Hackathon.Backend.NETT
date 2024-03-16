using System;
using System.Threading.Tasks;
using Hackathon.Backend.NETT.Function.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Hackathon.Backend.NETT.Function
{
    public class ProcessamentoVideoFunction
    {
        private readonly IProcessamentoVideoService _processamentoService;

        public ProcessamentoVideoFunction(IProcessamentoVideoService processamentoService)
        {
            _processamentoService = processamentoService;
        }

        [FunctionName("ProcessamentoVideo")]
        public async Task RunAsync([ServiceBusTrigger("hackafiapnett", Connection = "ServiceBusConnection")]string myQueueItem, ILogger log)
        {
            await _processamentoService.Processar(myQueueItem);

            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
