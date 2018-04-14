using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ModelService.Features.FeaturedModels
{
    public class GetFeaturedModelsQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public IEnumerable<FeaturedModelApiModel> FeaturedModels { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    FeaturedModels = await _context.FeaturedModels.Select(x => FeaturedModelApiModel.FromFeaturedModel(x)).ToListAsync()
                };
        }
    }
}
