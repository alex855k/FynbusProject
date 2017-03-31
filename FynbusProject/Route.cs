using System.Collections.Generic;
using System.Linq;

namespace FynbusProject
{
    public class Route
    {
        public int RouteNumber { get; private set; }
        public int VehicleType { get; private set; }

        public List<Offer> ListOfOffers { get; private set; }
        public Route(int routeNb, int vehType)
        {
            RouteNumber = routeNb;
            VehicleType = vehType;
            ListOfOffers = new List<Offer>();
        }

        public void AddToList(Offer o)
        {
            ListOfOffers.Add(o);
        }
        public void SortListOfOffers()
        {
            List<Offer> sorted = ListOfOffers.OrderBy(o => o.Price).ThenBy(p => p.Priority).ToList();
            ListOfOffers = sorted;
        }

        public double GetDifference()
        {
            double difference = 0;
            if (ListOfOffers.Count > 1)
            {
                difference = ListOfOffers[1].Price - ListOfOffers[0].Price;
            }

            return difference;
        }


        public override bool Equals(object obj)
        {
            Route r = (Route)obj;
            return (r.RouteNumber == this.RouteNumber &&
                r.VehicleType == this.VehicleType);
        }
    }
}
