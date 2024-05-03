using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
