using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Domain
{
    public class Image
    {
        public Guid ImageId { get; set; }
        public Guid VideoId { get; set; }
        public Video Video { get; set; }
        public string NameImage { get; set; }
        public string PathImage { get; set; } = "";
        public DateTime CreateAt { get; private set; }
    }
}
