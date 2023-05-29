
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QUANLYTHUVIEN.Models
{
[Table("Book")]
    public class Book
{
    [Key]
    public string BookID{get;set;}

    public string BookName{get;set;}
    
    public string NamXuatBan {get;set;}

    public string NXBID{get;set;}
    [ForeignKey("NXBID")]
    public Nhaxuatban? Nhaxuatban{get;set;}

    public string CategoryID{get; set;}
    [ForeignKey("CategoryID")]
    public Category? Category{get; set;}

    public string AuthorID{get;set;}
    [ForeignKey("AuthorID")]
    public Author? Author{get; set;}
    
}
}

