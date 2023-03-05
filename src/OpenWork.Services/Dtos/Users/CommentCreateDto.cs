namespace OpenWork.Services.Dtos.Users;

public class CommentCreateDto
{
	public string Content { get; set; } = string.Empty;
	public bool Satisfied { get; set; }
	public long WorkerId { get; set; }
}
