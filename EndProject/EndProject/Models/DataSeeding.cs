//using EndProject.DAL;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;

//namespace EndProject.Models
//{
//    public static class DataSeeding
//    {
//        public static void Seed(IApplicationBuilder app)
//        {

//            var scope = app.ApplicationServices.CreateScope();
//            var context = scope.ServiceProvider.GetService<AppDbContext>();
//            context.Database.Migrate();
//        }
//    }
//}
