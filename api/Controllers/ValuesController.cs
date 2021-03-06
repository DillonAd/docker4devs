﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase, IDisposable
    {
        private readonly ValueContext _context;

        public ValuesController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ValueContext>()
                .UseSqlServer(@"Server=db;Database=docker4devDB;User Id=sa; Password=correctHorseBatteryStaple1;");
            
            _context = new ValueContext(optionsBuilder.Options);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<Value[]> Get()
        {
            return _context.Values.ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Value value)
        {
            _context.Values.Add(value);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
            }
        }
    }
}
