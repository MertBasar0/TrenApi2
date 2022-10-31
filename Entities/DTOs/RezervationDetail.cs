using Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    [Keyless]
    public class RezervationDetail : IBaseEntity
    {

        public bool RezCheck { get; set; } = false;

        public List<Detail> Details { get; set; } = new List<Detail>();

    }
}
