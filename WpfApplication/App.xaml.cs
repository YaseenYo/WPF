using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;
using WpfApplication.Services;
using WpfApplication.State;
using WpfApplication.ViewModels;
using WpfApplication.ViewModels.Factories;

namespace WpfApplication
{
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureLogging( builder =>
                {
                    builder.AddDebug();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<MainViewModel>();
                    
                    services.AddSingleton<INavigator, Navigator>();

                    services.AddSingleton<MainWindow>(sp => new MainWindow()
                    {
                        DataContext = sp.GetRequiredService<MainViewModel>()
                    });

                    services.AddScoped<ICustomersRepository, CustomersRepository>();
                    services.AddScoped<ITransactionRepository,TransactionRepository >();
                    services.AddScoped<IProductRepository, ProductRepository>();
                    services.AddScoped<ICartRepository, CartRepository>();

                    services.AddTransient<IViewModelAbstractFactory, ViewModelAbstractFactory>();
                    services.AddTransient<IViewModelFactory<ProductListViewModel>,ProductListViewModelFactory>();
                    services.AddTransient<IViewModelFactory<CustomerListViewModel>,CustomerListViewModelFactory>();
                    services.AddTransient<IViewModelFactory<CustomerRegistrationViewModel>,CustomerRegistrationViewModelFactory>();
                    services.AddTransient<IViewModelFactory<CartViewModel>,CartViewModelFactory>();
                    services.AddTransient<IViewModelFactory<TransactionViewModel>,TransactionViewModelFactory>();
                    services.AddTransient<IViewModelFactory<AddProductViewModel>,AddProductViewModelFactory>();
                    services.AddTransient<IViewModelFactory<SearchTransactionViewModel>,SearchTransactionViewModelFactory>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            MainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }
}
