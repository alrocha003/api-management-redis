using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_management_redis.Models.Dto;
using api_management_redis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_management_redis.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DataBaseController : ControllerBase
    {

        #region Properties
        private ILogger _logger;
        private int _eventId;
        private readonly RedisService _redis;
        #endregion

        public DataBaseController()
        {
            LoggerFactory factory = new LoggerFactory();
            _logger = new Logger<DataBaseController>(factory);
            _redis = new RedisService("", "", "");
        }

        [HttpGet("{key}")]
        public ActionResult Get(string key)
        {
            try
            {
                _logger.LogInformation(_eventId, null, $"Access Get Method with key: {key}");

                return Ok(key);
            }
            catch (Exception exception)
            {
                string errorMessage = string.Concat(exception.Message, Environment.NewLine, exception.InnerException);
                _logger.LogError(_eventId, null, errorMessage);
                return BadRequest(errorMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] RequestDto request)
        {
            try
            {
                _logger.LogInformation(_eventId, null, $"Access Get Method with key: {request}");

                await Task.Delay(3);

                return Ok(request);
            }
            catch (Exception exception)
            {
                string errorMessage = string.Concat(exception.Message, Environment.NewLine, exception.InnerException);
                _logger.LogError(_eventId, null, errorMessage);
                return BadRequest(errorMessage);
            }
        }

        [HttpPut("/{key}")]
        public async Task<ActionResult> PutAsync(string key, [FromBody] string request)
        {
            try
            {
                _logger.LogInformation(_eventId, null, $"Access Put Async Method with key: {key} - request: {request}");

                await Task.Delay(3);

                return Ok(request);
            }
            catch (Exception exception)
            {
                string errorMessage = string.Concat(exception.Message, Environment.NewLine, exception.InnerException);
                _logger.LogError(_eventId, null, errorMessage);
                return BadRequest(errorMessage);
            }
        }
    }

}