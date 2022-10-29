using Core.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class RezervationDetailDal : GenericRepository<RezervationDetail,TrenApiDbContext>, IRezervationDetailDal
    {
    }
}
