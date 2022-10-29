using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class Mod
    {
        public Train Train { get; set; }

        public int People { get; set; }

        public bool Separately { get; set; }
    }
}
