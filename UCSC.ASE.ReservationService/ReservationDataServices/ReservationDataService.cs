using UCSC.ASE.ReservationService.DatabaseModules;
using UCSC.ASE.ReservationService.ReservationModules;
using UCSC.ASE.StudentService.StudentModules;

namespace UCSC.ASE.ReservationService.ReservationDataServices
{
    public static class ReservationDataService
    {
        public static List<OrderDetails> GetReservations(DatabaseContext _db)
        {
            List<Reservation> reservations = _db.Reservations.ToList();

            List <OrderDetails> orderDetails = new List<OrderDetails>();
            foreach (Reservation order in reservations)
            {
                OrderDetails orderDetails_ = new OrderDetails();
                Item FirstItem = _db.Items.First(FirstItem => FirstItem.ItemCode == order.FoodItem1);
                Item SecondItem = _db.Items.First(SecondItem => SecondItem.ItemCode == order.FoodItem2);

                orderDetails_.OrderId = order.Id;
                orderDetails_.OrderNumber = order.OrderNumber;
                orderDetails_.OrderPlaceDate = order.OrderPlaceDate.ToString("yyyy-MM-dd");
                orderDetails_.OrderedItems = FirstItem.ItemDescription + " , " + SecondItem.ItemDescription;

                decimal SubTotal_ = ((FirstItem.Price * order.Item1Qty) + (SecondItem.Price * order.Item2Qty));
                decimal TaxAmount_ = (SubTotal_ * 10) / 100;
                decimal TotalAmount_ = SubTotal_ + TaxAmount_;

                orderDetails_.SubTotal = SubTotal_;
                orderDetails_.TotalAmount = TotalAmount_;
                orderDetails_.TaxAmount = TaxAmount_;
                orderDetails.Add(orderDetails_);
            }
            return orderDetails;
        }

        public static List<Item> GetItems(DatabaseContext _db)
        {
            return _db.Items.ToList();
        }
        
        public static Reservation GetReservation(DatabaseContext _db, int id)
        {
            return _db.Reservations.First(reservation => reservation.Id == id);
        }

        public static InvoiceDetails AddReservation(DatabaseContext _db, Reservation reservation)
        {
            var maxValue = _db.Reservations.Max(x => x.Id);
            var OrderNumber = "ASE00" + (maxValue + 1);
            reservation.OrderNumber = OrderNumber;
            reservation.OrderPlaceDate = DateTime.Now;

            _db.Reservations.Add(reservation);
            _db.SaveChanges();

            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.StudentID = reservation.StudentId;
            invoiceDetails.InvoiceID = maxValue;
            invoiceDetails.InvoiceNumber = OrderNumber;

            Item FirstItem = _db.Items.First(FirstItem => FirstItem.ItemCode == reservation.FoodItem1);
            Item SecondItem = _db.Items.First(SecondItem => SecondItem.ItemCode == reservation.FoodItem2);

            invoiceDetails.FoodItem1 = FirstItem.ItemDescription;
            invoiceDetails.FoodItem2 = SecondItem.ItemDescription; 
            invoiceDetails.Item1Qty = reservation.Item1Qty;
            invoiceDetails.Item2Qty = reservation.Item2Qty;
            invoiceDetails.OrderPlaceDate = reservation.OrderPlaceDate;


            decimal SubTotal_ = ((FirstItem.Price * reservation.Item1Qty) + (SecondItem.Price * reservation.Item2Qty));
            decimal TaxAmount_ = (SubTotal_ * 10)/100;
            decimal TotalAmount_ = SubTotal_ + TaxAmount_;

            invoiceDetails.SubTotal = SubTotal_;
            invoiceDetails.TaxAmount = TaxAmount_;
            invoiceDetails.TotalAmount = TotalAmount_;            

            Student student = _db.Students.First(student => student.Id == reservation.StudentId);

            invoiceDetails.StudentName = student.Name;
            invoiceDetails.StudentEmail = student.Email;
            invoiceDetails.SudentAddress = student.Address;
            invoiceDetails.StudentMobileNo = student.MobileNo;

            return invoiceDetails;
        }

        public static Reservation UpdateReservation(DatabaseContext _db, Reservation reservation)
        {
            Reservation? reservation_ = _db.Reservations.FirstOrDefault(x => x.Id == reservation.Id);
            if (reservation_ != null)
            {
                reservation_.FoodItem1 = reservation.FoodItem1;
                reservation_.FoodItem2 = reservation.FoodItem2;
                reservation_.Item1Qty = reservation.Item1Qty;
                reservation_.Item2Qty = reservation.Item2Qty;
                reservation_.OrderPlaceDate = reservation.OrderPlaceDate;
                _db.SaveChanges();
            }
            return reservation;
        }

        public static bool? DeleteReservation(DatabaseContext _db, int id)
        {
            Reservation? selectedReservation = _db.Reservations.FirstOrDefault(x => x.Id == id);
            if (selectedReservation != null)
            {
                _db.Reservations.Remove(selectedReservation);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
