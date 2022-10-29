using Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Carriage :  Train
    {
        [Key]
        public int Id { get; set; }

        public int Capacity { get; set; }

        public int Occupancy { get; set; }
        
        [ForeignKey("TrainId")]
        public int TrainId { get; set; }

        public virtual Train? Train { get; set; }


        public int CalculateRightCapacity()
        {
            var result = Capacity * 0.70;
            return (int)result;
        }


    }
}
