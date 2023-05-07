namespace UCSC.ASE.EbillService.EbillModules
{
    public class Ebill
    {
        public string EmailTo { get; set; }
        public string? EmailCc { get; set; }
        public string? EmailBcc { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public string? StudentAddress { get; set; }
        public int? MobileNumber { get; set; }
        public int InvoiceID { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? FoodItem1 { get; set; }
        public string? FoodItem2 { get; set; }
        public int Item1Qty { get; set; }
        public int Item2Qty { get; set; }
        public DateTime OrderPlaceDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
