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
            var report = cspReportRequest.CspReportData;
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

            string blockedUri = report.BlockedUri;
            string disposition = report.Disposition;
            string documenturi = report.DocumentUri;
            string referrer = report.Referrer;
            string effectiveDirective = report.EffectiveDirective;
            string lineNumber = report.LineNumber;
            string originalpolicy = report.OriginalPolicy;
            string scriptSample = report.ScriptSample;
            string sourceFile = report.SourceFile;
            string statusCode = report.StatusCode;
            string violatedDirective = report.ViolatedDirective;

            Console.WriteLine("Received CSP Violation Report:\n");
            Console.WriteLine("blocked-uri: {0}\n", blockedUri);
            Console.WriteLine("disposition: {0}\n", disposition);
            Console.WriteLine("document-uri: {0}\n", documenturi);
            Console.WriteLine("effective-directive: {0}\n", effectiveDirective);
            Console.WriteLine("line-number: {0}\n", lineNumber);
            Console.WriteLine("original-policy: {0}\n", originalpolicy);
            Console.WriteLine("referrer: {0}\n", referrer);
            Console.WriteLine("script-sample: {0}\n", scriptSample);
            Console.WriteLine("source-file: {0}\n", sourceFile);
            Console.WriteLine("status-code: {0}\n", statusCode);
            Console.WriteLine("violated-directive: {0}\n", violatedDirective);
            CspViolationModel cspModel = new CspViolationModel
            {
                BlockedUri = blockedUri,
                Disposition = disposition,
                DocumentUri = documenturi,
                EffectiveDirective = effectiveDirective,
                LineNumber = lineNumber,
                OriginalPolicy = originalpolicy,
                Referrer = referrer,
                ScriptSample = scriptSample,
                SourceFile = sourceFile,
                StatusCode = statusCode,
                ViolatedDirective = violatedDirective,
            };
            _cspRepository.Add(cspModel);
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