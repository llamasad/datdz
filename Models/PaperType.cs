using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class PaperType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string TypeName { get; set; }

    public ICollection<PaperDetail> PaperDetails { get; set; }
}
