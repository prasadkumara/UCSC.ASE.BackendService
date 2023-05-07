using Microsoft.AspNetCore.Mvc;
using UCSC.ASE.ReservationService.ReservationApplicationService;

namespace UCSC.ASE.ReservationService.ReservationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IReservationApplicationService _reservationService;

        public ItemController(IReservationApplicationService reservationService)
        {
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_reservationService.GetItems());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
