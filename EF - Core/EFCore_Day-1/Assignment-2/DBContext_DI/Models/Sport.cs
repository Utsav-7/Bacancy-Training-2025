using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBContext_DI.Models
{
    public class Sport
    {
        [Key]
        public int SportId { get; set; }
        [ForeignKey("Studens")]
        public int StudentId { get; set; }
        public string SportName { get; set; }
    }
}
