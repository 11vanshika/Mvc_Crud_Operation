using System.ComponentModel.DataAnnotations;

namespace Crud_operation.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int age { get; set; }  
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
