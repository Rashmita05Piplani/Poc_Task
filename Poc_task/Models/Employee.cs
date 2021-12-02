using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Poc_task.Models
{
    public class Employee
    { [Required (ErrorMessage ="Firstname is required")]
      public string FirstName { get; set; }

        [Required (ErrorMessage ="Employee Code is Required")]
        public string EmpCode { get; set; }
        [Required (ErrorMessage ="LastName is required")]
      public string LastName { get; set; }
        [Required,Range(1,100 ,ErrorMessage ="Enter valid age")]
      public int Age { get; set; }
      [Required ]
      [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]  

     public string Email { get; set; }
     public string Sex { get; set; }
    }
}