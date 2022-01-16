using API.Controllers;
using Domain;
using MediatR;
using Persistence;

namespace API.Controllers.Activities;

public partial class ActivitiesController : BaseApiController
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            async Task<Activity> IRequestHandler<Query, Activity>.Handle(Query request, CancellationToken cancellationToken) => await this.context.Activities.FindAsync(request.Id);
        }
    }
}
