using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using timestampMicroservices.src.Models;

namespace timestampMicroservices.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TimeStampController : ControllerBase
    {
        
        [HttpGet("{date?}")]
        public string Get(string? date)
        {
            try{
            TimeStamp dateTime2 = new TimeStamp(date: date);
            return JsonSerializer.Serialize(dateTime2);
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(
                    new{error = ex.Message});
            }
        }

    }
}