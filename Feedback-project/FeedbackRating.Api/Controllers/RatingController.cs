using FeedbackManagement.Application.Contracts.Ratings;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackRating.Api.Controllers
{



    [Route("[controller]/[action]")]
    public class RatingController : Controller
    {
        private readonly IRatingApplication _ratingApplication;

        public RatingController(IRatingApplication ratingApplication)
        {
            _ratingApplication = ratingApplication;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterRating command)
        {
            var result = _ratingApplication.Register(command);
            return Ok(result);
        }

        [HttpGet("Average/{targetId}/{targetType}")]
        public IActionResult GetAverage(long targetId, int targetType)
        {
            var result = _ratingApplication.GetAverage(targetId, targetType);
            return Ok(result);
        }

        [HttpGet("ByTarget/{targetId}/{targetType}")]
        public IActionResult GetByTarget(long targetId, int targetType)
        {
            var list = _ratingApplication.GetByTarget(targetId, targetType);
            return Ok(list);
        }
    }

}
