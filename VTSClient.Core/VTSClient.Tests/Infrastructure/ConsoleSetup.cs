using Autofac;
using VTSClient.Core.Infrastructure.DI;
using VTSClient.DAL.Infrastructure;
using VTSClient.DAL.Infrastructure.Interfaces;

namespace VTSClient.Tests.Infrastructure
{
    public static class ConsoleSetup
    {
        public static IContainer Container { get; set; }

        public static void Initialize()
        {
            var builder = new ContainerBuilder();


            builder.RegisterInstance(new DbLocation())
                .As<IDbLocation>();

            CoreSetup.Init(builder);

            Container = builder.Build();
        }
    }
}
