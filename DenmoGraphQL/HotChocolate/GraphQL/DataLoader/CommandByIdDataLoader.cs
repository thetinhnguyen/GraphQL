using HotChocolate.DataLoader;
using HotChocolate.Fetching;
using HotChocolateDemo.Data;
using HotChocolateDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateDemo.GraphQL.DataLoader
{
    public class CommandByIdDataLoader : BatchDataLoader<int, List<Command>>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public CommandByIdDataLoader(IDbContextFactory<AppDbContext> dbContextFactory,
        BatchScheduler batchScheduler) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory;
        }
        protected override async Task<IReadOnlyDictionary<int, List<Command>>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using (AppDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                var command = await dbContext.Commands
                .Where(g => keys.Contains(g.Id)).ToListAsync(cancellationToken);
                var result = command.GroupBy(_ => _.Id)
                            .Select(_ => new {
                                         key = _.Key,
                                         commands = _.ToList()
                                        }).ToDictionary(_ => _.key, _ => _.commands);
                return result;
            };
        }
    }
}
