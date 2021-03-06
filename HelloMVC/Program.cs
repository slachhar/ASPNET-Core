﻿using System;
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
            // var records = dbContext.Film.Include(f => f.FilmActor).ThenInclude(r => r.Actor).ToList();
            // foreach (var record in records)
            // {
            //     System.Console.WriteLine($"Film: {record.Title}");
            //     var counter = 1;
            //     foreach (var fa in record.FilmActor)
            //     {
            //         System.Console.WriteLine($"\tActor {counter++}: {fa.Actor.FirstName} {fa.Actor.LastName}");
            //     }
            // }

            // var city = new City() { City1 = "Redmond", CountryId = 103 };
            // dbContext.Add(city);
            // dbContext.SaveChanges();

            // var uTarget = dbContext.City.SingleOrDefault(c => c.CityId == 1001);
            // if (uTarget != null)
            // {
            //     uTarget.City1 = "Kirkland";
            //     dbContext.Update(uTarget);
            //     dbContext.SaveChanges();
            // }

            var dTarget = dbContext.City.SingleOrDefault(c => c.CityId == 1001);
            if (dTarget != null)
            {
                dbContext.Remove(dTarget);
                dbContext.SaveChanges();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
