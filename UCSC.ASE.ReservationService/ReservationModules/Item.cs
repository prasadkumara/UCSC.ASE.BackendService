namespace UCSC.ASE.ReservationService.ReservationModules
{
    public class Item
    {
        public int Id { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemDescription { get; set; }
        public decimal Price { get; set; }
    }
}
