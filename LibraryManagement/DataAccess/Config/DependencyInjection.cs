using Autofac;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
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
