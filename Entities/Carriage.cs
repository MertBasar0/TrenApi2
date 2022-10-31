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
            return Convert.ToInt32(Capacity * 0.70);
        }


        public int CalculateEmptySeat()
        {
            var empty = Convert.ToInt32(Capacity * 0.70) - Occupancy;
            
            return empty > 0 ? empty : 0;
        }


    }
}
