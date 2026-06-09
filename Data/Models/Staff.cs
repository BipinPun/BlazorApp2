using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Data.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public ICollection<Programme> ProgrammeLeaderships { get; set; } = new List<Programme>();
    }
}