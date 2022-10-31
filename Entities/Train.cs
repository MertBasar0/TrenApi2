using Core.Abstract;
using Entities.DTOs;
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

        public virtual List<Carriage>? Carriages { get; set; }



        public List<Detail> CheckCarriageDetail(int people, out bool ok)
        {
            List<Detail> Details = new();
            int unSettled = people;

            if (Carriages is not null)
            {
                foreach (var item in Carriages)
                {
                    if (item.CalculateEmptySeat() > 0 && unSettled > 0)
                    {
                        var empty = item.CalculateEmptySeat();
                        Details.Add(new Detail() { CarriageName = item.Name, PersonCount = empty > unSettled ? unSettled : unSettled - (unSettled - empty) });
                        unSettled = empty > unSettled ? 0 : unSettled -= empty;
                    }
                }
                
            }

            ok = unSettled > 0 ? false : true;
            return Details;
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
