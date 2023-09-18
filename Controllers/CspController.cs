using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace RunGroopWebApp.Controllers
{
    //[ApiController]
    [Route("csp-report-endpoint")]
    public class CspController : Controller
    {
        private readonly ICspRepository _cspRepository;
        public CspController (ICspRepository cspRepository) /* ApplicationDbContext is our Database */
        {
            _cspRepository = cspRepository;
        }
        
        //[Consumes("application/json")]
        [HttpPost]
        public async Task<IActionResult> CspViolationReport([FromBody] CspReport cspReportRequest)
        {
        
            Console.WriteLine("Hello ! ");
            //var report = cspReportRequest.cspReport;
            using (StreamReader reader = new StreamReader(HttpContext.Request.Body))
            {
                var json = await reader.ReadToEndAsync();
                var cspReport = JsonConvert.DeserializeObject<CspReport>(json);
                // Log or print the JSON to inspect it
                Console.WriteLine("Received JSON Data:");
                Console.WriteLine(json);
            }
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
                // If model validation fails (e.g., missing or incorrect data), return a BadRequest
                return BadRequest(ModelState);
            }

            // Log or process the violation report details as needed
            // string documenturi = report.DocumentUri;
            // string referrer = report.Referrer;
            // string blockeduri = report.BlockedUri;
            // string originalpolicy = report.OriginalPolicy;
            // Console.WriteLine("Received CSP Violation Report:");
            // Console.WriteLine("Document URI: {0}", documenturi);
            // Console.WriteLine("Referrer: {0}", referrer);
            // Console.WriteLine("Blocked URI: {0}", blockeduri);
            // Console.WriteLine("Original Policy: {0}", originalpolicy);
            // Console.WriteLine("I'm Here !");
            return Ok();
        }        

        // [HttpGet]
        // public IActionResult CspViolationReport() 
        // {
        //     var report = new CspReportData
        //     {
        //         DocumentUri ="Mete",
        //         BlockedUri = "Default",
        //         Referrer = "Default",
        //     };
        //     return Ok(report);
        // }
    
    }
}