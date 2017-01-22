﻿using System;
using Microsoft.Extensions.DependencyInjection;
using NullDesk.Extensions.Mailer.Core;
using SendGrid;

namespace NullDesk.Extensions.Mailer.SendGrid.Tests.Infrastructure
{
    public class StandardMailFixture: IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }

        public StandardMailFixture()
        {

            //setup the dependency injection service
            var services = new ServiceCollection();

            services.AddOptions();
           
            services.Configure<SendGridMailerSettings>(s => s.ApiKey = "abc");
            services.AddTransient<Client>(s => new FakeClient("abc"));
            services.AddTransient<SendGridSimpleMailer>();
            services.AddTransient<IMailer>(s => s.GetService<SendGridSimpleMailer>());


            ServiceProvider = services.BuildServiceProvider();
            
        }

        

        public void Dispose()
        {
            
        }

        
    }
}
