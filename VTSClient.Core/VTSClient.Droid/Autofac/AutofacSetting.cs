using Autofac;
using AutoMapper;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.Infrastructure.Automapper.Profiles;
using VTSClient.DAL.Interfaces;
using VTSClient.DAL.Repositories;

namespace VTSClient.Droid.Autofac
{
	public static class AutofacSetting
	{
		public static IContainer Container { get; private set; }
		public static void Initialize()
		{
			var containerBuilder = new ContainerBuilder();

			containerBuilder.Register(
								c => new MapperConfiguration(cfg =>
								{
									cfg.AddProfile(new DtoToEntityProfile());
									cfg.AddProfile(new EntityToDtoProfile());
								}))
							.AsSelf()
							.SingleInstance();

			containerBuilder.Register(
					c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
				.As<IMapper>()
				.InstancePerLifetimeScope();

			containerBuilder.RegisterType<SqlVacationService>().As<ISqlVacationService>();

			containerBuilder.RegisterType<ApiVacationService>().As<IApiVacationService>();

			containerBuilder.RegisterType<CommonApiRepository>().As<IApiRepository>();

			containerBuilder.RegisterGeneric(typeof(CommonSqlRepository<>))
				.As(typeof(ISqlRepository<>))
				.InstancePerDependency();


			AutoMapperCoreConfiguration.Configure();

			Container = containerBuilder.Build();
		}
	}
}