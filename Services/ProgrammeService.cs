using Microsoft.EntityFrameworkCore;
using BlazorApp2.Data;
using BlazorApp2.Data.Models;

namespace BlazorApp2.Services
{
    public class ProgrammeService
    {
        IDbContextFactory<ApplicationDbContext> contextFactory;

        public ProgrammeService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Add(Programme record)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                //Add record to the dataset
                context.Programmes.Add(record);

                //Cascade changes to the database
                context.SaveChanges();
            }
        }

        public Programme GetById(int id)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                // This is a Lambda expression: m => m.Id == id
                var record = context.Programmes.SingleOrDefault(m => m.Id == id);
                return record;
            }
        }

        public Programme GetByCode(string code)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var record = context.Programmes.SingleOrDefault(m => m.Code == code);
                return record;
            }
        }

        public void Update(int id, string code, string title, int credits)
        {
            var record = GetById(id);
            if (record == null)
            {
                throw new Exception("Record does not exist. Nothing to Update");
            }

            record.Code = code;
            record.Title = title;
            record.Credits = credits;

            using (var context = contextFactory.CreateDbContext())
            {
                context.Update(record);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var record = GetById(id);
            if (record == null)
            {
                throw new Exception("Record does not exist. Nothing to Delete");
            }

            using (var context = contextFactory.CreateDbContext())
            {
                context.Remove(record);
                context.SaveChanges();
            }
        }

        public List<Programme> GetList()
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var records = context.Programmes.ToList();
                return records;
            }
        }

        public List<Programme> GetFilteredList(string searchText)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var records = context.Programmes.Where(
                    r => r.Code.ToLower().Contains(searchText.ToLower()) ||
                         r.Title.ToLower().Contains(searchText.ToLower())
                ).ToList();
                return records;
            }
        }

        // NEW METHOD ADDED FOR STEP 9 (STAFF RELATIONS FILTER)
        public List<Programme> GetListByProgrammeLeaderId(int programmeLeaderId)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var records = context.Programmes.Where(
                    r => r.ProgrammeLeaderId.Equals(programmeLeaderId)
                ).ToList();
                return records;
            }
        }
    }
}