using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PaperDetail
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    [ForeignKey("PaperType")]
    public int PaperTypeId { get; set; }

    public PaperType PaperType { get; set; }

    public DateTime PublishedDate { get; set; }

    public string Abstract { get; set; }
}
