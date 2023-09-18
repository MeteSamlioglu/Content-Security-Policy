// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Mvc.Formatters;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

// public class Startup
// {
//     public Startup(IConfiguration configuration)
//     {
//         Configuration = configuration;
//     }

//     public IConfiguration Configuration { get; }
    
//     public void ConfigureServices(IServiceCollection services)
//     {
        
//         services.AddControllers(options =>
//         {
//             var jsonInputFormatter = options.InputFormatters
//                 .OfType<NewtonsoftJsonInputFormatter>()
//                 .Last();

//             jsonInputFormatter.SupportedMediaTypes.Add("application/csp-report-endpoint");

//         });
//         // .AddJsonOptions(options =>
//         // {
//         //     options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//         //     options.JsonSerializerOptions.PropertyNamingPolicy = null;
//         // });
//     }
   

// }
