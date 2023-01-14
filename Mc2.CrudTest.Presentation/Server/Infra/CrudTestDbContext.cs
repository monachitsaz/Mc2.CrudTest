using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Infra
{
    public class CrudTestDbContext : DbContext
    {

        public CrudTestDbContext(DbContextOptions<CrudTestDbContext> options)
           : base(options)
        {
        }
    }
}
