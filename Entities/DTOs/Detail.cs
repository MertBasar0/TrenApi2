using Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    [Keyless]
    public class Detail : IBaseEntity
    {

        public string CarriageName { get; set; }

        public int PersonCount { get; set; }

    }
}
