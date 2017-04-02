namespace FynbusProject
{
    public class RouteAvaliableHours
    {
        //Amount of hours that the flex vehicle is avaliable during a week day
        public int AvaliabilityPeriodWeekDays { get; set; }
        //Amount of hours that the flex vehicle is avaliable during a weekend day
        public int AvaliabilityPeriodWeekends { get; set; }
        //Amount of hours that the flex vehicle is avaliable during a holiday
        public int AvaliabilityPeriodHolidays { get; set; }

        private static int AmountOfHolidays = 14 * 2;
        private static int AmountOfWeekDays = 261 * 2;
        private static int AmountOfWeekendsDays = 100 * 2;

        public int amountOfHoursContractPeriod()
        {
            return (AvaliabilityPeriodWeekDays * AmountOfWeekDays) +
                   (AvaliabilityPeriodHolidays * AmountOfHolidays) +
                   (AvaliabilityPeriodWeekends * AmountOfWeekendsDays);
        }

    }
}
