using UCSC.ASE.CampaignService.CampaignModules;
using UCSC.ASE.CampaignService.DatabaseModules;

namespace UCSC.ASE.CampaignService.CampaignDataServices
{
    public class CampaignDataService
    {
        public static bool AddPromotion(DatabaseContext _db, PromotionsDetail promotion)
        {
            _db.PromotionsDetails.Add(promotion);
            _db.SaveChanges();
            return true;
        }

        public static List<PromotionsDetail> GetAllPromoCampaign(DatabaseContext _db)
        {
            return _db.PromotionsDetails.ToList();
        }

        internal static bool? DeletePromotionCampaign(DatabaseContext _db, int id)
        {
            PromotionsDetail? selectedPromotionsDetail = _db.PromotionsDetails.FirstOrDefault(x => x.Id == id);
            if (selectedPromotionsDetail != null)
            {
                _db.PromotionsDetails.Remove(selectedPromotionsDetail);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
