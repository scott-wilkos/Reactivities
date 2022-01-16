using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers.Activities;

public partial class ActivitiesController : BaseApiController
{
    public class List
    {
        public class Query : IRequest<List<Activity>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await this._context.Activities.OrderBy(_ => _.Title).ToListAsync(cancellationToken);
            }
        }
    }
}
