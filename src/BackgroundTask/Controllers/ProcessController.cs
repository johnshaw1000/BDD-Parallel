namespace BackgroundTask.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    public class ProcessController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPause(int duration)
        {
            GetPauseAsync(duration);

            return Ok();
        }

        private async void GetPauseAsync(int duration)
        {
            var task = PutTaskDelay(duration);
            task.Wait();
            await task;
        }

        async Task PutTaskDelay(int delay)
        {
            await Task.Delay(delay);
        }
    }
}
