using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Data.Models
{
    public class Module
    {
        [Key]
        public int ID { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
    }
}