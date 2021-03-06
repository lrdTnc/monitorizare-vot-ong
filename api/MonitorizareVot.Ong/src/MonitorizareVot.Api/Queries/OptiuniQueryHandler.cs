﻿using MediatR;
using MonitorizareVot.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MonitorizareVot.Domain.Ong.Models;

namespace MonitorizareVot.Api.Queries
{
    public class OptionsQueryHandler : IRequestHandler<OptionsQuery, List<OptiuneModel>>
    {
        private VoteMonitorContext _context;

        public OptionsQueryHandler(VoteMonitorContext context)
        {
            _context = context;
        }
        public async Task<List<OptiuneModel>> Handle(OptionsQuery request, CancellationToken cancellationToken)
        {
            return _context.Options.Select(o => new OptiuneModel
            {
                Id = o.Id,
                SeIntroduceText = o.IsFreeText,
                Text = o.Text,
                Hint = o.Hint
            }).ToList();
        }
    }
}
