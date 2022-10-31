using Business.Abstract;
using Core.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RezervationDetailManager : IRezervationDetailService
    {

        public RezervationDetail RezervationCheck(Mod template)
        {
            RezervationDetail _rezervationDetail = new();
            if (template.Train is not null && template.Train.Carriages is not null)
            {
                if (template.Separately is false)
                {
                    var result = template.Train.Carriages.ToList().FirstOrDefault<Carriage>(carriage => carriage.CalculateRightCapacity() >= (carriage.Occupancy + template.People));
                    if (result is not null)
                    {
                        _rezervationDetail.RezCheck = true;
                        _rezervationDetail.Details.Add(new Detail() { CarriageName = result.Name, PersonCount = template.People });
                    }
                    else
                        return _rezervationDetail;
                }
                else
                {
                    _rezervationDetail.RezCheck = true;
                    var unSettled = template.People;
                    foreach (var item in template.Train.Carriages)
                    {
                        if (item.CalculateRightCapacity() > item.Occupancy && unSettled > 0)
                        {
                            var empty = item.CalculateEmptySeat();
                            _rezervationDetail.Details.Add(new Detail() { CarriageName = item.Name, PersonCount = empty > unSettled ? unSettled : unSettled - (unSettled - empty) } );
                            unSettled = empty > unSettled ? 0 : unSettled -= empty;
                        }
                    }
                    if(unSettled > 0)
                    {
                        _rezervationDetail.RezCheck = false;
                        _rezervationDetail.Details.Clear();
                    }
                }
            }
            
           
            return _rezervationDetail;
        }


    }
}
