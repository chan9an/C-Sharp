using System.ComponentModel.DataAnnotations;

namespace MVC_Core_WebApp1.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Name Can't Be Left Blank.")]
        [StringLength(15,MinimumLength=2,ErrorMessage ="Name Minimum length is 2 and Maximum Length 15")]
        public string Name { get; set; }

        [Required(ErrorMessage = "RollNo Can't Be Left Blank")]
        public int RollNo { get; set; }
        [Range(18,60,ErrorMessage ="Age Is Invalid")]
        public int Age { get; set; }
        public string Address {  get; set; }
    }
}
