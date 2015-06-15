namespace BackgroundTaskTests.PageObjects  
{
    using System.Net.Http;

    public class BackgroundTaskAsync
    {

        public bool Result { get; private set; }

        public bool Started { get; private set; }

        private const string PageTemplate = @"http://localhost:59668/api/process/pause?duration={0}";

        public BackgroundTaskAsync()
        {
            Started = false;
            Result = false;
        }

        public async void StartAsync(int duration)
        {
            Started = true;
            
            await new HttpClient().GetAsync(string.Format(PageTemplate, duration));

            Result = true;
        }
    }
}
