namespace BlazorApp.Shared
{
    public class TimePeriodModel
    {
        public TimePeriodModel(TimePeriod period, string text)
        {
            Period = period;
            Text = text;
        }

        public TimePeriod Period { get; set; }

        public string Text { get; set; }
    }
}
