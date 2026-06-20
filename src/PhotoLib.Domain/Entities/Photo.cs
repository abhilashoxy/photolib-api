namespace PhotoLib.Domain.Entities;

public class Photo
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string FileName { get; set; } = string.Empty;

    public DateTime DateTaken { get; set; }
}