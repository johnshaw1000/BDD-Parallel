namespace BackgroundTaskTests.Steps
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class BackgroundTaskSteps
    {
        private const string BackgroundTaskKey = "BackgroundTask";

        [Given(@"A background task")]
        public async Task GivenABackgroundTask()
        {
            var backgroundTask = new BackgroundTaskAsync();
            
            if (FeatureContext.Current.ContainsKey(BackgroundTaskKey))
            {
                FeatureContext.Current[BackgroundTaskKey] = backgroundTask;
            }
            else
            {
                FeatureContext.Current.Add(BackgroundTaskKey, backgroundTask);
            }

            await Task.Yield();
        }

        [When(@"Delay action (.*) seconds")]
        public async Task WhenValidActionIsPassed(int delaySeconds)
        {
            var backgroundTaskKey = FeatureContext.Current.FeatureInfo.Title + "-BackgroundTask";
            var backgroundTask = (BackgroundTaskAsync)FeatureContext.Current[backgroundTaskKey];
            backgroundTask.StartAsync(delaySeconds * 1000);
            Assert.IsTrue(backgroundTask.Started);
            Assert.IsFalse(backgroundTask.Result);
            await Task.Yield();
        }

        [Then(@"A valid response is detected after (.*) seconds")]
        public async Task ThenAValidResponseIsDetectedTask_Delay(int delaySeconds)
        {
            var task = PutTaskDelay(delaySeconds*1000);
            task.Wait();
            await task;

            var backgroundTask = (BackgroundTaskAsync) FeatureContext.Current[BackgroundTaskKey];

            Assert.NotNull(backgroundTask);
            Assert.IsTrue(backgroundTask.Result);
        }

        async Task PutTaskDelay(int delay)
        {
            await Task.Delay(delay);
        } 
    }
}
