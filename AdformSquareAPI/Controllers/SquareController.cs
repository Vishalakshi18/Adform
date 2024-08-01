using AdformSquareAPI.Core.Business;
using AdformSquareAPI.Persistence.UOW;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace AdformSquareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SquareController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SquareController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieves all the points from the database and returns the count of possible squares that can be drawn.
        /// </summary>
        /// <returns>The count of possible squares.</returns>
        /// <response code="200">Returns the count of possible squares</response>
        /// <response code="400">If there is an error in retrieving the points</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("GetAllSquares")]
        [SwaggerOperation("Retrieves all the points from the database and returns the count of possible squares.")]
        [SwaggerResponse(200, "Returns the count of possible squares")]
        [SwaggerResponse(400, "Error in retrieving the points")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAllSquares()
        {
            try
            {
                // Get Points
                var points = await _unitOfWork.PointService.GetAllAsync();

                // Ask Manager to build squares
                var manager = new SquareManager();
                var squares = manager.IdentifySquares(points.ToList());

                // Return count
                return Ok(squares.ToList().Count);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
