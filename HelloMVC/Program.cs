using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using HelloMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            var dbContext = new sakilaContext();
            var records = dbContext.Film.Include(f => f.FilmActor).ThenInclude(r => r.Actor).ToList();
            foreach (var record in records)
            {
                System.Console.WriteLine($"Film: {record.Title}");
                var counter = 1;
                foreach (var fa in record.FilmActor)
                {
                    System.Console.WriteLine($"\tActor {counter++}: {fa.Actor.FirstName} {fa.Actor.LastName}");
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
