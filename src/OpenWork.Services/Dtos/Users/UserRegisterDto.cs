using OpenWork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Dtos.User
{
    public class UserRegisterDto
    {

        [Required(ErrorMessage = "Enter your Name")]

        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter your Surname")]

        public string SurName { get; set; } = string.Empty;

        [Required, EmailAddress]

        public string Email { get; set; } = string.Empty;

        [Required]

        public string Password { get; set; } = string.Empty;

        public static implicit operator User(UserRegisterDto userDto)
        {
            return new User()
            {
                Email = userDto.Email,
                Surname = userDto.SurName,
                Name = userDto.Name,
                EmailVerified = false
            };
        }
    }
}
