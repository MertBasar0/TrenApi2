using Business.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrenApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly IRezervationDetailService _rezervationDetailService;

        public TrainController(IRezervationDetailService rezervationDetailService )
        {
            _rezervationDetailService = rezervationDetailService;
        }



        [HttpGet]
        public ActionResult<RezervationDetail> RezervationCheck(Mod request)
        {
            RezervationDetail result = _rezervationDetailService.RezervationCheck(request);

            return Ok(result);
        }


    }
}
