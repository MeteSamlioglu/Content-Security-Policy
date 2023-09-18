
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RunGroopWebApp.Models
{
    public class CspViolationModel
    {
        [DataMember()]
        [Key]
        public int Id {get; set;} 
        [DataMember()]
        public string BlockedUri { get; set; }
        
        [DataMember()]
        public string Disposition{get; set; }

        [DataMember()]
        public string DocumentUri { get; set; }

        [DataMember()]
        public string EffectiveDirective{get; set;}

        [DataMember()]
        public string LineNumber{get; set;}

        [DataMember()]
        public string OriginalPolicy { get; set; }   


        [DataMember()]
        public string Referrer { get; set; }

        [DataMember()]
        public string ScriptSample{get; set;}

        [DataMember()]
        public string SourceFile{get; set;}

        [DataMember()]
        public string StatusCode{get; set;}

        [DataMember()]
        public string ViolatedDirective {get; set;} 
    }

}