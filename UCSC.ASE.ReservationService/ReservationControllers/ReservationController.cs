using Microsoft.AspNetCore.Mvc;
using UCSC.ASE.EbillService.EbillApplicationServices;
using UCSC.ASE.EbillService.EbillModules;
using UCSC.ASE.ReservationService.ReservationApplicationService;
using UCSC.ASE.ReservationService.ReservationModules;

namespace UCSC.ASE.ReservationService.ReservationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationApplicationService _reservationService;
        private readonly IEbillApplicationService _ebillService;

        public ReservationController(IReservationApplicationService reservationService, IEbillApplicationService ebillService)
        {
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            _ebillService = ebillService ?? throw new ArgumentNullException(nameof(ebillService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_reservationService.GetReservations());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return _reservationService.GetReservation(id) != null ? Ok(_reservationService.GetReservation(id)) : NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Reservation reservation)
        {
            try
            {
                InvoiceDetails? Result = _reservationService.AddReservation(reservation);
                if(Result != null)
                {
                    Ebill emailMessage = new Ebill();
                    emailMessage.StudentID = Result.StudentID;
                    emailMessage.InvoiceNumber = Result.InvoiceNumber;
                    emailMessage.InvoiceNumber = Result.InvoiceNumber;
                    emailMessage.FoodItem1 = Result.FoodItem1;
                    emailMessage.FoodItem2 = Result.FoodItem2;
                    emailMessage.Item1Qty = Result.Item1Qty;
                    emailMessage.Item2Qty = Result.Item2Qty;   
                    emailMessage.OrderPlaceDate = Result.OrderPlaceDate;
                    emailMessage.SubTotal = Result.SubTotal;
                    emailMessage.TaxAmount = Result.TaxAmount;
                    emailMessage.TotalAmount = Result.TotalAmount;
                    emailMessage.StudentName = Result.StudentName;
                    emailMessage.StudentAddress = Result.SudentAddress;
                    emailMessage.EmailTo = Result.StudentEmail;
                    emailMessage.MobileNumber = Result.StudentMobileNo;

                    _ebillService.SendEbillEmail(emailMessage);
                }
                
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Reservation reservation)
        {
            try
            {
                return Ok(_reservationService.UpdateReservation(reservation));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _reservationService.DeleteReservation(id);

                return result.HasValue & result == true ? Ok($"reservation with ID:{id} got deleted successfully.")
                    : BadRequest($"Unable to delete the reservation with ID:{id}.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
