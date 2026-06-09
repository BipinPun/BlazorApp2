using System.ComponentModel.DataAnnotations;
using BlazorApp2.Services;

namespace BlazorApp2.Data.Models
{
    public class Programme
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public DateTime Created { get; set; }

        public Staff? ProgrammeLeader { get; set; }

        public int ProgrammeLeaderId { get; set; }
    }
}