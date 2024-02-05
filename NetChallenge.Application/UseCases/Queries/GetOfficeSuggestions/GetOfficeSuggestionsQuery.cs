using MediatR;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Queries.GetOfficeSuggestions
{
    public record struct GetOfficeSuggestionsQuery(int CapacityNeeded, string PreferedNeigborHood, IEnumerable<string> ResourcesNeeded) : IRequest<GetOfficeSuggestionsResponse>;
}
