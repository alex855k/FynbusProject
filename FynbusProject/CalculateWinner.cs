using System;
using System.Collections.Generic;
using System.Linq;

namespace FynbusProject
{
    public class CalculateWinner
    {
        private List<Route> RoutesList;

        public CalculateWinner()
        {
            RoutesList = new List<Route>();
            // Adding route objects from the import class in the RoutesList
            foreach (Route r in CSVImport.Instance.ListOfRoutes.Values)
            {
                AddToRouteList(r);
            }
        }

        public void SortOffersInRoutesByPriceAscending()
        {
            foreach (Route r in RoutesList)
            {
                r.SortListOfOffers();
            }
        }

        public void AddToRouteList(Route r)
        {
            RoutesList.Add(r);
        }

        public Route GetRouteInIndex(int index)
        {
            //Getting a route object from an index in the list
            return RoutesList[index];
        }

        public void SortRoutesByPriceDifference()
        {
            List<Route> sortedRoutesList = RoutesList.OrderByDescending(r => r.GetDifference()).ToList();
            //Updating the RoutesList with sorted values
            RoutesList = sortedRoutesList;
        }

        public void PrintWinners()
        {
            foreach (Route r in RoutesList)
            {
                Console.WriteLine("Route #" + r.RouteNumber);
                Console.WriteLine(
                    "Contractor: " + r.WinningOffer.OfferContractor.CompanyName +
                    "\n Contract value: " + r.WinningOffer.ContractValue);
            }
        }

        public bool SetWinners()
        {
            SortOffersInRoutesByPriceAscending();
            SortRoutesByPriceDifference();
            int routeIndex = 0;
            bool hasFoundAllWinners = false;
            while (!hasFoundAllWinners)
            {
                if (RoutesList[routeIndex].HasValidOffer(RoutesList[routeIndex].VehicleType))
                {
                    SetWinnerForRoute(RoutesList[routeIndex]);
                }
                else
                {
                    SortRoutesByPriceDifference();
                    routeIndex = 0;
                }
                if (routeIndex == (RoutesList.Count() - 1))
                {
                    hasFoundAllWinners = true;
                }
                routeIndex++;
            }
            return true;
        }

        private void SetWinnerForRoute(Route r)
        {
            r.WinningOffer.OfferContractor.DecrementAmountOfVehicleOfType(r.VehicleType);
            r.WinningOffer = r.ListOfOffers[0];
        }


    }
}
