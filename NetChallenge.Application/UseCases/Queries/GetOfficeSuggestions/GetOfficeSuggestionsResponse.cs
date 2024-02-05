﻿using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Queries.GetOfficeSuggestions
{
    public record struct GetOfficeSuggestionsResponse(string Message, IEnumerable<OfficeDto> Offices);
}
