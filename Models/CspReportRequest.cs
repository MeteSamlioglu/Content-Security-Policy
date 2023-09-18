using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Text.Json;
namespace RunGroopWebApp.Models
{

public class CspReport
{
    [JsonProperty(PropertyName = "csp-report")]
    public CspReportData CspReportData { get; set; }
}
public class CspReportData
{
    
    [JsonProperty(PropertyName = "referrer")]
    public string Referrer { get; set; }
    
    [JsonProperty(PropertyName = "blocked-uri")]
    public string BlockedUri { get; set; }

    [JsonProperty(PropertyName = "line-number")]
    public string LineNumber { get; set; }
    
    [JsonProperty(PropertyName = "source-file")]
    public string SourceFile { get; set; }
    
    [JsonProperty(PropertyName = "status-code")]
    public string StatusCode { get; set; }

    [JsonProperty(PropertyName = "disposition")]
    public string Disposition { get; set; }

    [JsonProperty(PropertyName = "document-uri")]
    public string DocumentUri { get; set; }
    
    [JsonProperty(PropertyName = "script-sample")]
    public string ScriptSample { get; set; }
    
    [JsonProperty(PropertyName = "original-policy")]
    public string OriginalPolicy { get; set; }
    
    [JsonProperty(PropertyName = "violated-directive")]
    public string ViolatedDirective { get; set; }

    [JsonProperty(PropertyName = "effective-directive")]
    public string EffectiveDirective { get; set; }
}


}
