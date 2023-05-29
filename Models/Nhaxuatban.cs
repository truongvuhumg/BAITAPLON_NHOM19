using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QUANLYTHUVIEN.Models;
public class Nhaxuatban
{
    
    [Key]
    public string NXBID{get;set;}

    public string NXBName{get;set;}

    public string NXBAddress{get;set;}

    public int Phone{get;set;}

}
