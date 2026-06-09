using Microsoft.EntityFrameworkCore;
using BlazorApp2.Data;
using BlazorApp2.Data.Models;

namespace ModuleReview.Services
{
    public class ModuleService
    {
        IDbContextFactory<ApplicationDbContext> contextFactory;

        public ModuleService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Add(BlazorApp2.Data.Models.Module module)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                //Add module to the dataset
                context.Modules.Add(module);

                //Cascade changes to the database
                context.SaveChanges();
            }
        }
    }
}