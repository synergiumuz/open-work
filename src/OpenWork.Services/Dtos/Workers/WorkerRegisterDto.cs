using OpenWork.Domain.Entities;
using OpenWork.Services.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OpenWork.Services.Dtos.Worker;

public class WorkerRegisterDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Surname { get; set; } = string.Empty;

    [Required, Email]
    public string Email { get; set; } = string.Empty;

    [Required, PhoneNumber]
    public string Phone { get; set; } = string.Empty;

    [Required, MaxLength(16, ErrorMessage = "Max Length 16"), MinLength(8, ErrorMessage = "Min Length 8")]
    public string Password { get; set; } = string.Empty;

    public static implicit operator Worker(WorkerRegisterDto workerDto)
    {
        return new Worker()
        {
            Email = workerDto.Email,
            Phone = workerDto.Phone,
            Password = workerDto.Password,
            Name = workerDto.Name,
            Surname = workerDto.Surname,
            EmailVerified = false,
        };
    }
}

