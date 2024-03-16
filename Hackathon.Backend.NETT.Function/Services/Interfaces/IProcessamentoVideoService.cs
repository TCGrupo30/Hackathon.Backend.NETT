using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Function.Services.Interfaces
{
    public interface IProcessamentoVideoService
    {
        Task Processar(string filePath);
    }
}
