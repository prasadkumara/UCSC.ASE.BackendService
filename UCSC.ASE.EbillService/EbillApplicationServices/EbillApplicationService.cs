using System.Net;
using System.Net.Mail;
using UCSC.ASE.EbillService.EbillModules;

namespace UCSC.ASE.EbillService.EbillApplicationServices
{
    public class EbillApplicationService: IEbillApplicationService
    {
        public bool SendEbillEmail(Ebill emailMessage)
        {
            MailMessage message = new MailMessage();
            message.To.Add(emailMessage.EmailTo);

            if (emailMessage.EmailCc != null && emailMessage.EmailCc != "")
            {
                emailMessage.EmailCc = emailMessage.EmailCc.TrimEnd(',');
                message.CC.Add(emailMessage.EmailCc);
            }

            if (emailMessage.EmailBcc != null && emailMessage.EmailBcc != "")
            {
                emailMessage.EmailBcc = emailMessage.EmailBcc.TrimEnd(',');
                message.Bcc.Add(emailMessage.EmailBcc);
            }

            string emailBody = string.Empty;

            if (emailMessage != null)
            {
                emailBody = File.ReadAllText("./ReservationResources/ReservationInvoice.html");
                emailBody = emailBody.Replace("{CustomerName}", emailMessage.StudentName)
                    .Replace("{CustomerAddress}", emailMessage.StudentAddress)
                    .Replace("{CustomerEmail}", emailMessage.EmailTo)
                    .Replace("{CustomerPhoneNumber}", emailMessage.MobileNumber.ToString())

                    .Replace("{InvoiceNumber}", emailMessage.InvoiceNumber)
                    .Replace("{InvoiceDate}", emailMessage.OrderPlaceDate.ToString())

                    .Replace("{ReservationItem1}", emailMessage.FoodItem1)
                    .Replace("{ReservationQty1}", emailMessage.Item1Qty.ToString())
                    .Replace("{ReservationItem2}", emailMessage.FoodItem2)
                    .Replace("{ReservationQty2}", emailMessage.Item2Qty.ToString())

                    .Replace("{SubtotalAmount}", emailMessage.SubTotal.ToString())
                    .Replace("{TaxAmount}", emailMessage.TaxAmount.ToString())
                    .Replace("{TotalAmount}", emailMessage.TotalAmount.ToString());
            }

            message.Body = emailBody;
            message.IsBodyHtml = true;

            message.From = new MailAddress("email.janakaprasad@gmail.com", "Auto Generated Mail");

            message.Subject = "Invoice for Reservation | Order Number: " + emailMessage.InvoiceNumber;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("email.janakaprasad@gmail.com", "maipwqowqtgbvuyy");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);

            return true;
        }
    }
}
