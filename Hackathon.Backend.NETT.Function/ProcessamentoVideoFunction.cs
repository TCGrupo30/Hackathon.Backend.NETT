using System;
using System.Threading.Tasks;
using Hackathon.Backend.NETT.Function.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

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
        public async Task RunAsync([ServiceBusTrigger("hackafiapnett", Connection = "ServiceBusConnection")]string myQueueItem)
        {
            await _processamentoService.Processar(myQueueItem);
        }
    }
}
