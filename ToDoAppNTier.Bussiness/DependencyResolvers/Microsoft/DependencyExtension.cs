using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.Bussiness.Interfaces;
using ToDoAppNTier.Bussiness.Services;
using ToDoAppNTier.DataAccess.Contexts;
using ToDoAppNTier.DataAccess.UnitOfWork;

namespace ToDoAppNTier.Bussiness.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddDbContext<ToDoContext>(opt =>
            {
                opt.UseSqlServer("server=coinodb-dev.cjq6i1xxy6zz.eu-central-1.rds.amazonaws.com;database=TodoDbHalil;Uid=sa;Password=DtzsCI3HF9n4WIX7O3dj6SSdC43PdpwpMtcaXtDlj8TJy3KDSJ");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });
        }

    }
}
