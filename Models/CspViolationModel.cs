
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RunGroopWebApp.Models
{
    public class CspViolationModel
    {
        [Key]
        public int Id {get; set;} 
        public string BlockedUri { get; set; }
        public string Disposition{get; set; }
        public string DocumentUri { get; set; }
        public string EffectiveDirective{get; set;}
        public string LineNumber{get; set;}
        public string OriginalPolicy { get; set; }   
        public string Referrer { get; set; }
        public string ScriptSample{get; set;}
        public string SourceFile{get; set;}
        public string StatusCode{get; set;}
        public string ViolatedDirective {get; set;} 
    }

}