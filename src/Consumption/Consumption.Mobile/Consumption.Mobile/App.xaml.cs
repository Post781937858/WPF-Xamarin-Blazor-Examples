﻿using Consumption.Common.Contract;
using Consumption.Core.Interfaces;
using Consumption.Core.Response;
using Consumption.Mobile.View;
using Consumption.Mobile.ViewCenter;
using Consumption.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Consumption.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
        }

        protected override void OnStart()
        {
            
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            NetCoreProvider.RegisterServiceLocator(serviceProvider);
            MainPage = new LoginCenter().GetContentPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient(typeof(MainCenter));
            services.AddScoped<IConsumptionService, ConsumptionService>();
        }
    }
}
