using Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Train : IBaseEntity
    {
        [Key]
        public int TrainId { get; set; }

        public string? Name { get; set; }


        //Navigation Props

        public virtual IEnumerable<Carriage>? Carriages { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
