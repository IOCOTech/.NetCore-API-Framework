using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.UnitTests.Data.Helpers
{
    // IMPLEMENT IF YOU'RE USING ENTITY FRAMEWORK

    //public static class DBHelper
    //{
    //    public static APIFrameworkContext GetDBContext()
    //    {
    //        DbContextOptions<APIFrameworkContext> options;
    //        if (AppSettings.UseInMemoryDatabase)
    //        {
    //            options = new DbContextOptionsBuilder<APIFrameworkContext>()
    //               .UseInMemoryDatabase(AppSettings.CosmosDBName)
    //               .EnableDetailedErrors()
    //               .EnableSensitiveDataLogging()
    //               .Options;

    //        }
    //        else
    //        {
    //            options = new DbContextOptionsBuilder<MyPlaasContext>()
    //                .UseCosmos(
    //                AppSettings.CosmosEndpoint,
    //                AppSettings.CosmosPrimaryKey,
    //                AppSettings.CosmosDBName
    //                )
    //                .EnableDetailedErrors()
    //                .EnableSensitiveDataLogging()
    //                .Options;
    //        }

    //        return new MyPlaasContext(options);
    //    }

    //    public static void SeedDB(MyPlaasContext context)
    //    {
    //        if (AppSettings.SeedCosmosDBData)
    //        {
    //            context.Database.EnsureDeleted();
    //            context.Database.EnsureCreated();
    //            context.Devices.AddRange(Mock.MockData.Devices.DeviceData.ListDevices);
    //            context.Farms.AddRange(Mock.MockData.Farms.FarmData.ListFarms);
    //            context.ResourcesTemplates.AddRange(Mock.MockData.ResourceTemplates.ResourceTemplateData.ListResourceTemplates);
    //            context.Users.AddRange(Mock.MockData.Users.UserData.ListUsers);
    //            context.SaveChanges();
    //        }
    //    }
    //}
}
