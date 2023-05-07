namespace UCSC.ASE.CampaignService.CampaignModules
{
    public class PromotionsDetail
    {
        public int Id { get; set; }
        public string? PromoEmail { get; set; }
        public string? PromotionHeader { get; set; }
        public string? PromotionDescription { get; set; }
        public int PromoStatus { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
