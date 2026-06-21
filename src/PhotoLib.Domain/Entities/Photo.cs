namespace PhotoLib.Domain.Entities;

public class Photo
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string OriginalFileName { get; set; } = string.Empty;

    public string StoragePath { get; set; } = string.Empty;

    public long FileSizeBytes { get; set; }

    public string ContentType { get; set; } = string.Empty;

    public DateTime UploadedAt { get; set; }

    public User User { get; set; } = null!;
}