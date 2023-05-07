using UCSC.ASE.CampaignService.CampaignModules;

namespace UCSC.ASE.CampaignService.CampaignApplicationServices
{
    public interface ICampaignApplicationService
    {
        bool SendPromotionEmail(Promotion promotionEmail);
        bool AddPromotion(PromotionsDetail promotion);
        List<PromotionsDetail> GetAllPromoCampaign();
        bool? DeletePromotionCampaign(int id);
    }
}
