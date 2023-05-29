using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QUANLYTHUVIEN.Models;
 [Table("Employee")]
public class Employee

   
{
    [Key]

    public string EmployeeID{get;set;}

    public string EmployeeName{get;set;}

    public string EmployeeAddress{get;set;}

    public string Phone{get;set;}

    public string Gender{get;set;}

}