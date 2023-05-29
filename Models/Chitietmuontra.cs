
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QUANLYTHUVIEN.Models
{
 [Table("Chitietmuontra")]
public class Chitietmuontra 
   {
    [Key]
   
    public string Maphieu{get;set;}
    [ForeignKey("Maphieu")]
    public Phieumuonsach? Phieumuonsach{get;set;}

    public string BookID{get;set;}
    [ForeignKey("BookID")]
    public Book? Book{get;set;}

    public string Ngaymuon{get;set;}

    public string ngaytra{get;set;}

   }
   
}
