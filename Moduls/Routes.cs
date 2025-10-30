namespace One_City_One_Pay.Moduls
{
    public class BikeRoute : BaseRoute { }
    public class AutoRoute : BaseRoute { }
    public class CarRoute : BaseRoute { }
    public class BusRoute : BaseRoute { }
    public class MetroRoute : BaseRoute { }
    public class LocalTrainRoute : BaseRoute { }

    public class BaseRoute
    {
        public int RouteId { get; set; }
        public string FromLocation { get; set; } = "";
        public string ToLocation { get; set; } = "";
        public decimal Price { get; set; }
    }
}
