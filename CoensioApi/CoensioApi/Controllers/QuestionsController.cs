using CoensioApi.Data;
using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using CoensioApi.Services.Abstracts;
using CoensioApi.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoensioApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionsController : ControllerBase
    {


        private readonly ICodingQuestionService _codingQuestionService;
        private readonly IFreeTextQuestionService _freeTextQuestionService;
        private readonly IMultipleChoiceQuestionService _multipleChoiceQuestionService;
        private readonly ILogger _logger;

        public QuestionsController(ICodingQuestionService codingQuestionService, IFreeTextQuestionService freeTextQuestionService, IMultipleChoiceQuestionService multipleChoiceQuestionService, ILogger<Exception> logger)
        {
            _codingQuestionService = codingQuestionService;
            _freeTextQuestionService = freeTextQuestionService;
            _multipleChoiceQuestionService = multipleChoiceQuestionService;
            _logger = logger;
        }

        [HttpGet("MultipleChoice"), Authorize(Roles = "admin")]
        public IActionResult GetMultipleChoiceQuestions()
        {
            try
            {
                var questions = _multipleChoiceQuestionService.GetAllMultipleChoiceQuestions();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("MultipleChoice"), Authorize(Roles = "admin")]
        public IActionResult InsertMultipleChoiceQuestion([FromBody] dtoCreateMultipleChoiceQuestion question)
        {
            try
            {
                var newQuestion = _multipleChoiceQuestionService.InsertMultipleChoiceQuestion(question);
                return CreatedAtAction(nameof(GetMultipleChoiceQuestionById), new { id = newQuestion.Id }, newQuestion);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("MultipleChoice/{id:int}"), Authorize(Roles = "admin")]
        public IActionResult GetMultipleChoiceQuestionById(int id)
        {
            try
            {
                var question = _multipleChoiceQuestionService.GetMultipleChoiceQuestionById(id);
                return Ok(question);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
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

        [HttpPut("MultipleChoice/{id:int}"), Authorize(Roles = "admin")]
        public IActionResult UpdateMultipleChoiceQuestionById(int id, [FromBody] dtoUpdateMultipleChoiceQuestion question)
        {
            try
            {
                var q = _multipleChoiceQuestionService.UpdateMultipleChoiceQuestionById(id, question);
                return Ok(q);
            }
            catch (ArgumentException ex)
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

        [HttpDelete("MultipleChoice/{id:int}"), Authorize(Roles = "admin")]
        public IActionResult DeleteMultipleChoiceQuestionById(int id)
        {
            try
            {
                _multipleChoiceQuestionService.DeleteMultipleChoiceQuestionById(id);
                return Ok("Question deleted successfully");
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

        [HttpGet("FreeText"), Authorize(Roles = "admin")]
        public IActionResult GetFreeTextQuestions()
        {
            try
            {
                var questions = _freeTextQuestionService.GetAllFreeTextQuestions();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("FreeText"), Authorize(Roles = "admin")]
        public IActionResult InsertFreeTextQuestion([FromBody] dtoCreateFreeTextQuestion question)
        {
            try
            {
                var newQuestion = _freeTextQuestionService.InsertFreeTextQuestion(question);
                return CreatedAtAction(nameof(GetFreeTextQuestionById), new { id = newQuestion.Id }, newQuestion);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("FreeText/{id:int}"), Authorize(Roles = "admin")]
        public IActionResult GetFreeTextQuestionById(int id)
        {
            try
            {
                var question = _freeTextQuestionService.GetFreeTextQuestionById(id);
                return Ok(question);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
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

        [HttpPut("FreeText/{id:int}"), Authorize(Roles = "admin")]
        public IActionResult UpdateFreeTextQuestionById(int id, [FromBody] dtoUpdateFreeTextQuestion question)
        {
            try
            {
                var q = _freeTextQuestionService.UpdateFreeTextQuestionById(id, question);
                return Ok(q);
            }
            catch (ArgumentException ex)
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

        [HttpDelete("FreeText/{id:int}"), Authorize(Roles = "admin")]
        public IActionResult DeleteFreeTextQuestionById(int id)
        {
            try
            {
                _freeTextQuestionService.DeleteFreeTextQuestionById(id);
                return Ok("Question deleted successfully");
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

        [HttpGet("Coding"), Authorize(Roles = "admin")]
        public IActionResult GetCodingQuestions()
        {
            try
            {
                var questions = _codingQuestionService.GetAllCodingQuestions();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Coding"), Authorize(Roles = "admin")]
        public IActionResult InsertCodingQuestion([FromBody] dtoCreateCodingQuestion question)
        {
            try
            {
                var newQuestion = _codingQuestionService.InsertCodingQuestion(question);
                return CreatedAtAction(nameof(GetCodingQuestionById), new { id = newQuestion.Id }, newQuestion);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Coding/{id:int}"), Authorize(Roles = "admin")]
        public IActionResult GetCodingQuestionById(int id)
        {
            try
            {
                var question = _codingQuestionService.GetCodingQuestionById(id);
                return Ok(question);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
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

        [HttpPut("Coding/{id:int}"), Authorize(Roles = "admin")]
        public IActionResult UpdateCodingQuestionById(int id, [FromBody] dtoUpdateCodingQuestion question)
        {
            try
            {
                var q = _codingQuestionService.UpdateCodingQuestionById(id, question);
                return Ok(q);
            }
            catch (ArgumentException ex)
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

        [HttpDelete("Coding/{id:int}"), Authorize(Roles = "admin")]
        public IActionResult DeleteCodingQuestionById(int id)
        {
            try
            {
                _codingQuestionService.DeleteCodingQuestionById(id);
                return Ok("Question deleted successfully");
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
