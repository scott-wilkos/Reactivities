using API.Controllers;
using Domain;
using MediatR;
using Persistence;

namespace API.Controllers.Activities
{
    public partial class ActivitiesController : BaseApiController
    {
        public class Create
        {
            public class Command : IRequest
            {
                public Activity Activity { get; set; }
            }

            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext context;

                public Handler(DataContext context)
                {
                    this.context = context;
                }

                async Task<Unit> IRequestHandler<Command, Unit>.Handle(Command request, CancellationToken cancellationToken)
                {
                    context.Add(request.Activity);
                    await context.SaveChangesAsync(cancellationToken);

                    return Unit.Value;
                }
            }
        }
    }
}