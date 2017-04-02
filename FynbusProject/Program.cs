using System;

namespace FynbusProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            new FynbusProject.Program().Run();
        }

        private void Run()
        {
            string filepathRoutes = @"C:\Users\Kast\Desktop\Fynbus\Flexcel_Fynbus\Flex-Sortering 1.02\RouteNumbers.csv";
            string filepathOffers = @"C:\Users\Kast\Desktop\Fynbus\Flexcel_Fynbus\FakeData_Tests\Test med 3 bud til samme rute\Tilbud_FakeData.csv";
            string filepathContractors = @"C:\Users\Kast\Desktop\Fynbus\Flexcel_Fynbus\FakeData_Tests\Test med 3 bud til samme rute\Stamoplysninger_FakeData.csv";


            CSVImport.Instance.Import(filepathRoutes, fileType.ROUTES);
            CSVImport.Instance.Import(filepathContractors, fileType.CONTRACTORS);
            CSVImport.Instance.Import(filepathOffers, fileType.OFFERS);

            Route route = CSVImport.Instance.ListOfRoutes[1];

            CalculateWinner cw = new CalculateWinner();
            cw.SetWinners();
            cw.PrintWinners();
            Console.ReadKey();
        }
    }
}
