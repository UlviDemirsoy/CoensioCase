using CoensioEvulatorApi.Data.Models;
using CoensioEvulatorApi.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace CoensioEvulatorApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EvaluationsController : ControllerBase
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationsController(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }


        [HttpGet("/list")]
        public IActionResult GetResults()
        {
            var list = _evaluationRepository.GetEvaluations();

            return Ok(list);
        }
       
    }
}
