using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyEmployee.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        
        public WeatherForecastController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // _repositoryManager.Company.FindAll();
            // _repositoryManager.Employee.FindAll();
            
            return new string[] { "value1", "value2" };
        }
    }
}