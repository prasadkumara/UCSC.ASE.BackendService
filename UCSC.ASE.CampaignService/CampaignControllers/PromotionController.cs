using Microsoft.AspNetCore.Mvc;
using UCSC.ASE.CampaignService.CampaignApplicationServices;
using UCSC.ASE.CampaignService.CampaignModules;

namespace UCSC.ASE.CampaignService.CampaignControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : Controller
    {
        private readonly ICampaignApplicationService _promotionService;

        public PromotionController(ICampaignApplicationService promotionService)
        {
            _promotionService = promotionService ?? throw new ArgumentNullException(nameof(promotionService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_promotionService.GetAllPromoCampaign());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Promotion promotionEmail)
        {
            try
            {
                return Ok(_promotionService.SendPromotionEmail(promotionEmail));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _promotionService.DeletePromotionCampaign(id);

                return result.HasValue & result == true ? Ok($"Promotion campaign with ID:{id} got deleted successfully.")
                    : BadRequest($"Unable to delete the promotion campaign with ID:{id}.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
