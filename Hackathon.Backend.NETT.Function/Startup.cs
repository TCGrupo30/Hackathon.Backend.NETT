using Hackathon.Backend.NETT.Core.Services;
using Hackathon.Backend.NETT.Core.Services.Interfaces;
using Hackathon.Backend.NETT.Function.Services;
using Hackathon.Backend.NETT.Function.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(Hackathon.Backend.NETT.Function.Startup))]

namespace Hackathon.Backend.NETT.Function;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<IProcessamentoVideoService, ProcessamentoVideoService>();
        builder.Services.AddSingleton<IStorageService, StorageService>();
    }
}