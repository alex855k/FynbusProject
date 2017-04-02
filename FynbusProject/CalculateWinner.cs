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
                RoutesList.Add(r);
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

            foreach (Route r in RoutesList)
            {
                Console.WriteLine(r.RouteNumber);
            }
        }

        public void GetWinners()
        {
                
        }
    }
}
