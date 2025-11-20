namespace Project.EF.Api.Models;

public class Tarea
{
    public Guid TareaId { get; set; }
    public Guid CategoryId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Priority TareaPriority { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual Category? Category { get; set; } 

}

public enum Priority
{
    Low,
    Medium,
    High
}