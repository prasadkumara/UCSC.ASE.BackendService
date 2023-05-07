using UCSC.ASE.ReservationService.DatabaseModules;
using UCSC.ASE.ReservationService.ReservationDataServices;
using UCSC.ASE.ReservationService.ReservationModules;

namespace UCSC.ASE.ReservationService.ReservationApplicationService
{
    public class ReservationApplicationService : IReservationApplicationService
    {
        DatabaseContext _db;
        public ReservationApplicationService(DatabaseContext db)
        {
            _db = db;
        }

        public List<OrderDetails> GetReservations()
        {
            return ReservationDataService.GetReservations(_db);
        }

        public List<Item> GetItems()
        {
            return ReservationDataService.GetItems(_db);
        } 

        public Reservation? GetReservation(int id)
        {
            return ReservationDataService.GetReservation(_db, id);
        }
        public InvoiceDetails? AddReservation(Reservation reservation)
        {
            return ReservationDataService.AddReservation(_db, reservation);
        }

        public Reservation? UpdateReservation(Reservation reservation)
        {
            return ReservationDataService.UpdateReservation(_db, reservation);
        }

        public bool? DeleteReservation(int id)
        {
            return ReservationDataService.DeleteReservation(_db, id);
        }
    }
}
