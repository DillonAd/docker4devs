using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string[]> Get()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ValueContext>()
                .UseSqlServer(@"Server=db;Database=Express;User ID=sa; Password=correctHorseBatteryStaple1;");
            
            using(var context = new ValueContext(optionsBuilder.Options))
            {
                return context.Values.Select(v => v.Name).ToArray();
            }
        }
    }
}
