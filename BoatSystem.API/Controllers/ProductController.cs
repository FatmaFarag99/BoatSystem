namespace BoatSystem.API.Controllers
{
    using Hangfire;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("Enqueue")]
        public string Enqueue()
        {
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Only Once Immediately"));
            return $"JobId : {jobId}. in Enqueue Method";
        }

        [HttpGet("Schedule")]
        public string Schedule()
        {
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Only Schedule"), TimeSpan.FromMinutes(1));
            return $"JobId : {jobId}. in Schedule Method";
        }

        [HttpGet("Continuation")]
        public string Continuation()
        {   
            var parentJobId = BackgroundJob.Enqueue(() => Console.WriteLine("parent is Success"));
            BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("Continuation is success"));

            return "the Continuation action is success";
        }


        [HttpGet("Recuring")]
        public string Recuring()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("in Recuring job"), Cron.Minutely);

            return "Recuring is Success";
        }

    }
}
