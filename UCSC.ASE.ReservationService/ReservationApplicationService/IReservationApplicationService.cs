using UCSC.ASE.ReservationService.ReservationModules;

namespace UCSC.ASE.ReservationService.ReservationApplicationService
{
    public interface IReservationApplicationService
    {
        List<OrderDetails> GetReservations();
        Reservation? GetReservation(int id);
        InvoiceDetails? AddReservation(Reservation reservation);
        Reservation? UpdateReservation(Reservation reservation);
        bool? DeleteReservation(int id);
        List<Item> GetItems();
    }
}
