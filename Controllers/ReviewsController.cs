using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using One_City_One_Pay.Data;

namespace One_City_One_Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        public readonly ReviewRepository _reviewRepository;
        public ReviewsController(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet("GetUserReviewsComments")]
        public IActionResult GetAllUserReviewsComments()
        {
            try
            {
                var review = _reviewRepository.GetReviewComments();
                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("AddUserReviewComments")]

        public IActionResult AddUserReviewComments(string name, string reviewComments)
        {
            try
            {
                _reviewRepository.AddReview(name, reviewComments);
                return Ok("Review added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
