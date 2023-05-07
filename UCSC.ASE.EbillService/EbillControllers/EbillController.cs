using Microsoft.AspNetCore.Mvc;
using UCSC.ASE.EbillService.EbillApplicationServices;
using UCSC.ASE.EbillService.EbillModules;

namespace UCSC.ASE.EbillService.EbillControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EbillController : Controller
    {
        private readonly IEbillApplicationService _reservationService;

        public EbillController(IEbillApplicationService ebillService)
        {
            _reservationService = ebillService ?? throw new ArgumentNullException(nameof(ebillService));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ebill emailMessage)
        {
            try
            {
                return Ok(_reservationService.SendEbillEmail(emailMessage));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
