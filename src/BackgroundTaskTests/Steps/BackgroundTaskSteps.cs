namespace BackgroundTaskTests.Steps
{
    using System;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class BackgroundTaskSteps
    {
        [Given(@"A background task")]
        public async Task GivenABackgroundTask()
        {
            var backgroundTask = new BackgroundTaskAsync();

            var backgroundTaskKey = FeatureContext.Current.FeatureInfo.Title + "-BackgroundTask";

            if (FeatureContext.Current.ContainsKey(backgroundTaskKey))
            {
                FeatureContext.Current[backgroundTaskKey] = backgroundTask;
            }
            else
            {
                FeatureContext.Current.Add(backgroundTaskKey, backgroundTask);
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
            var backgroundTaskKey = FeatureContext.Current.FeatureInfo.Title + "-BackgroundTask";

            try
            {
                var task = PutTaskDelay(delaySeconds*1000);
                task.Wait();
                await task;

                var backgroundTask = (BackgroundTaskAsync)FeatureContext.Current[backgroundTaskKey];

                if (backgroundTask != null)
                {
                    var x = backgroundTask.Result;
                }

                //Assert.IsTrue(backgroundTask.Result);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        async Task PutTaskDelay(int delay)
        {
            await Task.Delay(delay);
        } 
    }
}
