using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnConfiguring_DBContext_Setup.Models
{
    public class Classes
    {
        [Key]
        public int ClassId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public int Standard { get; set; }
    }
}
