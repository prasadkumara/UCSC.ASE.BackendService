namespace UCSC.ASE.ReservationService.ReservationModules
{
    public class Reservation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string? OrderNumber { get; set; }
        public string? FoodItem1 { get; set; }
        public string? FoodItem2 { get; set; }
        public int Item1Qty { get; set; }
        public int Item2Qty { get; set; }
        public  DateTime OrderPlaceDate { get; set; }
    }
}
