using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdformSquareAPI.Core.Model;

namespace AdformSquareAPI.Persitence
{
    public class SquareApiContext : DbContext
    {
        public SquareApiContext (DbContextOptions<SquareApiContext> options)
            : base(options)
        {
        }

        public DbSet<AdformSquareAPI.Core.Model.Square> Square { get; set; } = default!;
        public DbSet<AdformSquareAPI.Core.Model.Point> Point { get; set; } = default!;
    }
}
