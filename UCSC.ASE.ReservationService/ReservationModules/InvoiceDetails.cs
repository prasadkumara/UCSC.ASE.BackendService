namespace UCSC.ASE.ReservationService.ReservationModules
{
    public class InvoiceDetails
    {
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public string? SudentAddress { get; set; }
        public string StudentEmail { get; set; }
        public int? StudentMobileNo { get; set; }
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
