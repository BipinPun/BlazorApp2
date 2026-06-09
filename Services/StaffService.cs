using Microsoft.EntityFrameworkCore;
using BlazorApp2.Data;
using BlazorApp2.Data.Models;

namespace BlazorApp2.Services
{
    public class StaffService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public StaffService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Future database methods for Staff (Add, Get, Delete) will go here later!
        public Staff GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var record = context.Staffing.SingleOrDefault(m => m.Id == id);
                return record;
            }
        }
    }
}