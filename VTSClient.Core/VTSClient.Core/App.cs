using System;
using AutoMapper;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using VTSClient.Bll.Services;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.DAL.Interfaces;
using VTSClient.DAL.Repositories;

namespace VTSClient.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

			AutoMapperCoreConfiguration.Configure();

            Mvx.RegisterSingleton<IMvxAppStart>(new CustomAppStart());
            			
			Mvx.RegisterType<ISqlVacationService,SqlVacationService>();

			Mvx.RegisterType<IApiVacationService, ApiVacationService>();

			Mvx.RegisterType<IApiRepository, CommonApiRepository>();

			Mvx.RegisterType<IUserRepository, UserRepository>();

			Mvx.RegisterType<IAccountService, AccountService>();
		}
    }
}

