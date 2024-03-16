using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Application.GetVideo
{
    public class GetVideoResponse
    {
        public Guid VideoId { get; set; }
        public string NameZip { get; set; }
        public string PathZip { get; set; }
    }
}
