﻿using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
 using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;

namespace VTSClient.Core.ViewModels
{
	public class LoginPageViewModel : MvxViewModel
	{
		private readonly IAccountService _loginService;

		private IMvxCommand _signInCommand;

		private const string ErrorMessage =
			"Please, retry your login and password pair. Check current Caps Lock and input language settings.";

		public string LoginTextValue { get; set; }

		public string PasswordTextValue { get; set; }
       		
		private string _errorTextValue = string.Empty;

		public string ErrorTextValue
		{
			get { return _errorTextValue; }
			set
			{
				_errorTextValue = value;
				RaisePropertyChanged(() => ErrorTextValue);
			}
		}

		private bool _isHidden = true;

		public bool IsHidden
		{
			get { return _isHidden; }
			set
			{
				_isHidden = value;
				RaisePropertyChanged(() => IsHidden);
			}
		}

		public LoginPageViewModel(IAccountService service)
		{
			_loginService = service;
		}

		public IMvxCommand SignInCommand => _signInCommand ??
		                                    (_signInCommand = new MvxCommand(
			                                    () =>
			                                    {
				                                    if (!IsFieldsCorrect()) return;

				                                    var status = LoginUser().Result;

				                                    if (!status) return;

				                                   ShowViewModel<MenuViewModel>();
			                                    }));

		private bool IsFieldsCorrect()
		{
			if (string.IsNullOrEmpty(LoginTextValue) || string.IsNullOrEmpty(PasswordTextValue))
			{
				ErrorTextValue = ErrorMessage;

				IsHidden = false;

				return false;
			}
			return true;
		}

		private async Task<bool> LoginUser()
		{
			var loginDto = new LoginDto
			{
				Login = LoginTextValue,
				Password = PasswordTextValue
			};
			var token = await _loginService.Login(loginDto);

			if (string.IsNullOrEmpty(token))
			{
				ErrorTextValue = ErrorMessage;

				IsHidden = false;

				return false;
			}

			return true;
		}
	}
}
