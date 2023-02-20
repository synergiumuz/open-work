//using OpenWork.Domain.Entities;
//using OpenWork.Services.Common.Exceptions;
//using OpenWork.Services.Common.Security;
//using OpenWork.Services.Dtos;
//using OpenWork.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OpenWork.Services.Services
//{
//	public class UserService : IUserService
//	{
//		private readonly IHasher _hasher;
//		private readonly IUnitOfWork _repository;
//		private readonly UserLoginDto _userLoginDto;
//		private readonly UserRegisterDto _userRegisterDto;

//		public UserService(IUnitOfWork repository, IHasher hasher, UserLoginDto userLoginDto, UserRegisterDto userRegisterDto)	
//		{
//			_hasher = hasher;
//			_repository = repository;
//			_userLoginDto = userLoginDto;
//			_userRegisterDto = userRegisterDto;
//		}

//		public async Task<string> LoginAsync(UserLoginDto dto)
//		{
			
//			User? employee = await _repository.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
//			if (employee is null)
//				throw new ModelErrorException(nameof(dto.Email), "Bunday email bilan foydalanuchi mavjud emas!");
//			bool hashResult = _hasher.Verify(employee.Password, dto.Password, employee.Email);
//			if (hashResult)
//			{
//				return "Login Genrate Samandar aka";
//			}
//			else
//				throw new ModelErrorException(nameof(dto.Password), "Parol xato terildi");
//		}



//		public async Task<bool> RegisterAsync(UserRegisterDto dto)
//		{
//			try
//			{
//				if (_repository.Users.GetAll().Any(x => x.Email == dto.Email))
//			{
//				throw new Exception();
//			}
//			User entity = _userRegisterDto;
//			_repository.Users.Add(entity);
//			return await _repository.SaveChanges() > 0;
//			}
//			catch
//			{
//				return false;
//			}
//		}
//	}
//}
