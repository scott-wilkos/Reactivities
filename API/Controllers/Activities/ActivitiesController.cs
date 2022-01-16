using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Activities
{
    public partial class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities() => await Mediator.Send(new List.Query());

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id) => await Mediator.Send(new Details.Query { Id = id });

        [HttpPost]
        public async Task<IActionResult> AddActivity(Activity activity) => Ok(await Mediator.Send(new Create.Command { Activity = activity }));

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(Guid id) => Ok(await Mediator.Send(new Delete.Command { Id = id }));
    }
}