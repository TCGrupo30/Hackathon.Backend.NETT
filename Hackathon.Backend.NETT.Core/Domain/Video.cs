using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Backend.NETT.Core.Domain
{
    public class Video
    {
        public Guid VideoId { get; set; }
        public string NameZip { get; set; }
        public string PathZip { get; set; }
        public DateTime CreateAt { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
