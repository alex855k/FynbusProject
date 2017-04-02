using System.Collections.Generic;
using System.Linq;

namespace FynbusProject
{
    public class Route
    {
        public int RouteNumber { get; private set; }
        public int VehicleType { get; private set; }
        // Will store winning offer once it's been calculated
        public Offer WinningOffer { get; set; }

        public List<Offer> ListOfOffers { get; private set; }
        public Route(int routeNb, int vehType)
        {
            RouteNumber = routeNb;
            VehicleType = vehType;
            ListOfOffers = new List<Offer>();
        }

        public bool HasWinner()
        {
            // If the winning offer is null will return false
            return WinningOffer != null;
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

                Offer first = null;
                Offer second = null;

                foreach (Offer o in ListOfOffers)
                {
                    if (o.HasVehicleOfVehType(VehicleType))
                    {

                    }
                }

                difference = ListOfOffers[1].Price - ListOfOffers[0].Price;
            }

            return difference;
        }


        public override bool Equals(object obj)
        {
            Route r = (Route)obj;
            // Returns true if both RouteNumber and VehicleType of the object we are passing and the this. route object are the same 
            return (r.RouteNumber == this.RouteNumber &&
                r.VehicleType == this.VehicleType);
        }
        public override string ToString()
        {
            return RouteNumber + " " + VehicleType;
        }
    }
}
