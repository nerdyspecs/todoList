using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TodoId
        {
            get; set;
        }
        public string Activity
        {
            get; set;
        }
        public decimal Price
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public bool BookingRequired
        {
            get; set;
        }
        public double Accessibility
        {
            get; set;
        }
    }
}
