using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEAnalyzer.Models
{
    public class ViewModel
    {
        public List<Model> Models { get; set; }
        public string SearchText { get; set; }
        public string Meta { get; set; }
        public string SortOrder { get; set; }
    }
}