using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOEAnalyzer.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Keyword { get; set; }

        public int Occurence { get; set; }

        public int MetaOccurence { get; set; }
    }
}