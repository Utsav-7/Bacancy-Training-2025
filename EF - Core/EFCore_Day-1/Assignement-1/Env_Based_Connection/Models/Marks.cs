using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Env_Based_Connection.Models
{
    public class Marks
    {
        [Key]
        public int MarksId { get; set; }
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public int Mark { get; set; }
    }
}
