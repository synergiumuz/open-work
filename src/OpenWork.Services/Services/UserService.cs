using OpenWork.DataAccess.Interfaces;
using OpenWork.Domain.Entities;
using OpenWork.Services.Common.Exceptions;
using OpenWork.Services.Dtos;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Security;

namespace OpenWork.Services.Services
{
	public class UserService : IUserService
	{
		private readonly IHasher _hasher;
		private readonly IUnitOfWork _repository;
		private readonly UserLoginDto _userLoginDto;
		private readonly UserRegisterDto _userRegisterDto;
		private readonly IAuthManager _authManager;

		public UserService(IUnitOfWork repository, IHasher hasher, UserLoginDto userLoginDto, UserRegisterDto userRegisterDto, IAuthManager authManager)
		{
			_hasher = hasher;
			_repository = repository;
			_userLoginDto = userLoginDto;
			_userRegisterDto = userRegisterDto;
			_authManager = authManager;
		}

		public async Task<string> LoginAsync(UserLoginDto dto)
		{

			User? user = await _repository.Users.GetAsync(dto.Email);
			if (user is null)
				throw new ModelErrorException(nameof(dto.Email), "Bunday email bilan foydalanuvchi mavjud emas!");
			bool hashResult = _hasher.Verify(user.Password, dto.Password, user.Email);
			if (hashResult)
			{
				return _authManager.GenerateToken(user);
			}
			else
				throw new ModelErrorException(nameof(dto.Password), "Parol xato terildi");
		}



		public async Task<bool> RegisterAsync(UserRegisterDto dto)
		{
			try
			{
				if (_repository.Users.GetAll().Any(x => x.Email == dto.Email))
				{
					throw new Exception();
				}
				User entity = _userRegisterDto;
				_repository.Users.Add(entity);
				return await _repository.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}
	}
}
