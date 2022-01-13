using Autofac;
using DataAccess.Repositories;

namespace DataAccess.Config
{
    /// <summary>
    /// Class for layer dependency injection
    /// </summary>
    public class DependencyInjection : Module
    {
        private readonly string _connectionString;
        public DependencyInjection(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorsRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<BooksInOrdersRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<BooksRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<OrdersRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<SubscribersRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
