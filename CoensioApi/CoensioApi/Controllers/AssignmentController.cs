using CoensioApi.Data;
using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;
using CoensioApi.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoensioApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private readonly ILogger _logger;

        public AssignmentController(IAssignmentService assignmentService, ILogger<Exception> logger)
        {
            _assignmentService = assignmentService;
            _logger = logger;
        }

        [HttpPost, Authorize(Roles = "admin")]
        public IActionResult CreateTestAssignment(dtoCreateTestAssignment dto)
        {
            try
            {
                var assign = _assignmentService.CreateTestAssignment(dto);
                return CreatedAtAction(nameof(CreateTestAssignment), new { id = assign.Id }, assign);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet, Authorize(Roles = "admin, user")]
        public IActionResult GetMyAssignments()
        {
            try
            {
                var assignmentList = _assignmentService.GetCurrentUserAssignments();
                return Ok(assignmentList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Submission"), Authorize(Roles = "admin, user")]
        public IActionResult CreateSubmission(dtoCreateSubmission dto)
        {
            try
            {
                _assignmentService.CreateSubmission(dto);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }




    }
}
