using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Daxus_ClubManagement.DAL.DbContext
{
    public class DaxusContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DaxusContext(DbContextOptions<DaxusContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Guest> Guest { get; set; }
    }
}
