namespace FynbusProject
{
    public class Offer
    {
        public string Id { get; private set; }
        public Route Route { get; private set; }
        public double Price { get; private set; }
        public Contractor OfferContractor { get; private set; }
        public int Priority { get; private set; }

        public double ContractValue
        {
            get
            {
                return AvaliableHours.GetAvaliableHours(this.Route.RouteNumber) * Price;
            }
        }


        public Offer(string id, Route routeNumber, double price, Contractor cont, int contPriority)
        {
            Id = id;
            Route = routeNumber;
            Price = price;
            OfferContractor = cont;
            Priority = contPriority;
        }
    }
}