using FeedbackManagement.Application.Contracts.Feedbacks;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackRating.Api.Controllers
{

    [Route("[Controller]/[Action]")]

    public class FeedbackController : Controller
    {
        private readonly IFeedbackApplication _feedbackApplication;

        public FeedbackController(IFeedbackApplication feedbackApplication)
        {
            _feedbackApplication = feedbackApplication;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateFeedback command)
        {
            var result = _feedbackApplication.Create(command);
            return Ok(result);
        }
    }
}
