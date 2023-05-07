using System.Net;
using System.Net.Mail;
using UCSC.ASE.CampaignService.CampaignDataServices;
using UCSC.ASE.CampaignService.CampaignModules;
using UCSC.ASE.CampaignService.DatabaseModules;

namespace UCSC.ASE.CampaignService.CampaignApplicationServices
{
    public class CampaignApplicationService : ICampaignApplicationService
    {
        DatabaseContext _db;
        public CampaignApplicationService(DatabaseContext db)
        {
            _db = db;
        }

        public bool SendPromotionEmail(Promotion promotionEmail)
        {
            try
            {
                if (promotionEmail.EmailList != null)
                {
                    foreach (var EmailTo in promotionEmail.EmailList.Split(','))
                    {
                        MailMessage message = new MailMessage();
                        message.To.Add(EmailTo);

                        string emailBody = string.Empty;

                        if (promotionEmail != null)
                        {
                            emailBody = File.ReadAllText("./PromotionResources/PromotionEmail.html");
                            emailBody = emailBody.Replace("{PromotionHeader}", promotionEmail.PromotionHeader)
                                .Replace("{PromotionDescription}", promotionEmail.PromotionDescription);
                        }

                        message.Body = emailBody;
                        message.IsBodyHtml = true;

                        message.From = new MailAddress("email.janakaprasad@gmail.com", "Auto Generated Mail");

                        message.Subject = promotionEmail.PromotionHeader;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("email.janakaprasad@gmail.com", "maipwqowqtgbvuyy");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(message);

                        PromotionsDetail promotion = new PromotionsDetail();
                        promotion.PromoEmail = EmailTo;
                        promotion.PromotionHeader = promotionEmail.PromotionHeader;
                        promotion.PromotionDescription = promotionEmail.PromotionDescription;
                        promotion.PromoStatus = 2;
                        promotion.CreateOn = DateTime.Now;
                        AddPromotion(promotion);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                PromotionsDetail promotion = new PromotionsDetail();
                promotion.PromoEmail = promotionEmail.EmailList;
                promotion.PromotionHeader = promotionEmail.PromotionHeader;
                promotion.PromotionDescription = promotionEmail.PromotionDescription;
                promotion.PromoStatus = 1;
                promotion.CreateOn = DateTime.Now;
                AddPromotion(promotion);
                throw;
            }
        }

        public bool AddPromotion(PromotionsDetail promotion)
        {
            return CampaignDataService.AddPromotion(_db, promotion);
        }

        public List<PromotionsDetail> GetAllPromoCampaign()
        {
            return CampaignDataService.GetAllPromoCampaign(_db);
        }

        public bool? DeletePromotionCampaign(int id)
        {
            return CampaignDataService.DeletePromotionCampaign(_db, id);
        }
    }
}
