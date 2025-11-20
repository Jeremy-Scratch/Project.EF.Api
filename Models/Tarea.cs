using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.EF.Api.Models;

public class Tarea
{
    [Key]
    public Guid TareaId { get; set; }
    [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    [Required]
    [MaxLength(200)]
    public string? Title { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    public Priority TareaPriority { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual Category? Category { get; set; }
    [NotMapped] 
    public string? Resume{ get; set; }
}

public enum Priority
{
    Low,
    Medium,
    High
}