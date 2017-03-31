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
            return RoutesList[index];
        }

        public void SortRoutesByPriceDifference()
        {

            List<Route> sortedRoutesList = RoutesList.OrderByDescending(r => r.GetDifference()).ToList();
            RoutesList = sortedRoutesList;

            foreach (Route r in RoutesList)
            {
                Console.WriteLine(r.RouteNumber);
            }
        }
    }
}
