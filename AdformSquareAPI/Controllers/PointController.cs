using AdformSquareAPI.Core.Dto;
using AdformSquareAPI.Core.Model;
using AdformSquareAPI.Persistence.UOW;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace AdformSquareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PointController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds points to the database.
        /// </summary>
        /// <param name="points">List of points to add.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        /// <response code="201">Points were successfully added.</response>
        /// <response code="400">Invalid input received.</response>
        [HttpPost("AddPoints")]
        [SwaggerOperation("Adds points to the database operation.")]
        [SwaggerResponse(201, "Points were successfully added")]
        [SwaggerResponse(400, "Invalid input received")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> AddPoints(IEnumerable<PointDto> points)
        {
            if (points == null || !points.Any())
            {
                return BadRequest("Points list is null or empty.");
            }

            try
            {
                foreach (var point in points)
                {
                    await _unitOfWork.PointService.AddAsync(new Point
                    {
                        X = point.X,
                        Y = point.Y
                    });
                }

                _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(GetAllPoints), null);
            }
            catch
            {
                return StatusCode(500, "An error occurred while adding points.");
            }
        }

        /// <summary>
        /// Deletes a point from the database.
        /// </summary>
        /// <param name="id">ID of the point to delete.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        /// <response code="200">Point was successfully deleted.</response>
        /// <response code="404">Point with the specified ID was not found.</response>
        [HttpDelete("DeletePoint/{id:int}")]
        [SwaggerResponse(200, "Point was successfully deleted.")]
        [SwaggerResponse(404, "Point with the specified ID was not found.")]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> DeletePoint(int id)
        {
            try
            {
                var result = await _unitOfWork.PointService.DeleteAsync(id);

                if (!result)
                {
                    return NotFound($"Point with ID {id} not found.");
                }

                _unitOfWork.CommitAsync();
                return Ok("Point Deleted");
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting the point.");
            }
        }

        /// <summary>
        /// Retrieves all points from the database.
        /// </summary>
        /// <returns>List of points.</returns>
        /// <response code="200">Successfully retrieved points.</response>
        /// <response code="400">An error occurred while retrieving points.</response>
        [HttpGet("GetAllPoints")]
        [SwaggerResponse(200, "Successfully retrieved points.")]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<ActionResult<List<Point>>> GetAllPoints()
        {
            try
            {
                var result = await _unitOfWork.PointService.GetAllAsync();
                return Ok(result.ToList());
            }
            catch
            {
                return StatusCode(500, "An error occurred while retrieving points.");
            }
        }

        /// <summary>
        /// Deletes all points from the database.
        /// </summary>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        /// <response code="200">All points were successfully deleted.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("DeleteAllPoints")]
        [SwaggerResponse(200, "All points were successfully deleted.")]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> DeleteAllPoints()
        {
            try
            {
                var result = await _unitOfWork.PointService.DeleteAllAsync();

                if (!result)
                {
                    return NotFound("No points found to delete.");
                }

                _unitOfWork.CommitAsync();
                return Ok("All Points Deleted");
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting all points.");
            }
        }
    }
}
