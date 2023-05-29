
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QUANLYTHUVIEN.Models
{
 [Table("Phieumuonsach")]
public class Phieumuonsach
   {
    [Key]
   
    public string Maphieu{get;set;}

    public string ReaderName{get;set;}
    [ForeignKey("ReaderName")]
    public Readers? Readers{get;set;}
    
    public string EmployeeName{get;set;}
    [ForeignKey("EmployeeName")]
    public Employee? Employee {get;set;}

   }
   
}
