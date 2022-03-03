namespace BlazorApp.Shared
{
    public static class TimePeriodExtensions
    {
        public static int InDays(this TimePeriod timePeriod)
        {
            switch (timePeriod)
            {
                case TimePeriod.OneToThreeDays: return 3;
                case TimePeriod.ThreeDaysToAWeek: return 7;
                case TimePeriod.OneToTwoWeeks: return 2 * 7;
                case TimePeriod.ThreeToFourWeeks: return 4 * 7;
                case TimePeriod.OneToTwoMonths: return 2 * 4 * 7;
                case TimePeriod.Indefinite: return 1000;
                default: return 0;
            }
        }
    }
}
