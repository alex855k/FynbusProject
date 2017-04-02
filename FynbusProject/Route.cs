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

        private Offer firstOffer = null;
        private Offer secondOffer = null;

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

        public bool HasValidOffer(int vehType)
        {
            // Returns true if both offers has vehicles left of the vehtype
            return firstOffer.HasVehicleOfVehType(vehType) && secondOffer.HasVehicleOfVehType(vehType);
        }

        public void SetFirstAndSecondHighestValidOffer()
        {
            if (ListOfOffers.Count > 1)
            {
                // Finds the first and second highest offers with vehicles left

                foreach (Offer o in ListOfOffers)
                {
                    if (o.HasVehicleOfVehType(VehicleType))
                    {
                        if (firstOffer == null)
                        {
                            firstOffer = o;
                        }
                        else
                        {
                            if (secondOffer == null)
                            {
                                secondOffer = o;
                            }
                        }

                    }
                }
            }
        }

        public double GetDifference()
        {
            SetFirstAndSecondHighestValidOffer();
            double difference = 0;
            if (firstOffer != null && secondOffer == null)
            {
                difference = firstOffer.Price - secondOffer.Price;
            }
            else
            {

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
