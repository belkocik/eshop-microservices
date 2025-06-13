using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public static class Extentions
{
  public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
  {
    using var scope = app.ApplicationServices.CreateAsyncScope();
    using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
    dbContext.Database.MigrateAsync();
    return app;
  }
}