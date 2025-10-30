namespace One_City_One_Pay.Moduls
{
    public class BaseBookingCountAndAmount
    {
        public int Id { get; set; }
        public decimal BookingAmount { get; set; }
        public DateTime? BookingDate { get; set; } = DateTime.Now;
        public string VehicleType { get; set; }
        public required string UserName { get; set; }
    }

    public class BikeBookingCountAndAmount : BaseBookingCountAndAmount { }
    public class AutoBookingCountAndAmount : BaseBookingCountAndAmount { }
    public class CarBookingCountAndAmount : BaseBookingCountAndAmount { }
    public class BusBookingCountAndAmount : BaseBookingCountAndAmount { }
    public class MetroBookingCountAndAmount : BaseBookingCountAndAmount { }
    public class LocalTrainBookingCountAndAmount : BaseBookingCountAndAmount { }

}
