namespace UCSC.ASE.ReservationService.ReservationModules
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public string? OrderPlaceDate { get; set; }
        public string? OrderedItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
