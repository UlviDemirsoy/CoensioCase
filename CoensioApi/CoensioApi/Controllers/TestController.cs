using CoensioApi.Data;
using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;
using CoensioApi.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoensioApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ILogger _logger;


        public TestController( ITestService testService, ILogger<Exception> logger)
        {
            _testService = testService;
            _logger = logger;
        }

        [HttpPost("Generate"), Authorize(Roles = "admin")]
        public IActionResult GenerateTest([FromBody] dtoCreateTest test)
        {
            try
            {
                var newTest = _testService.GenerateTest(test);
                return CreatedAtAction(nameof(GenerateTest), new { id = newTest.Id }, newTest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet, Authorize(Roles = "admin")]
        public IActionResult ListTests()
        {
            try
            {
                return Ok(_testService.ListTests());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
