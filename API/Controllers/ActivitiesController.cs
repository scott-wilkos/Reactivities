using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Domain.Activity>>> GetActivities() => await this._context.Activities.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Activity>> GetActivity(Guid id) => await this._context.Activities.FirstAsync(_ => _.Id.Equals(id));
    }
}