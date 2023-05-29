using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QUANLYTHUVIEN.Models;
 [Table("Readers")]
public class Readers

{
    [Key]

   public string ReaderID{get;set;}

    public string ReaderName{get;set;}
    
    public string Ngaysinh {get;set;}
    
    public string Gender {get;set;}
    
    public string  Class {get;set;}

}