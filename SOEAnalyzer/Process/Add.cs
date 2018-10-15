using SOEAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SOEAnalyzer.Process
{
    public class Add : IAdd
    {
        public List<Model> AddWord(ref List<Model> models, string word)
        {
            Model model = new Model
            {
                Id = models.Count +1,
                Keyword = word,
                Occurence = 1
            };

            models.Add(model);
            return models;
        }

        public void AddMeta(string url, string word)
        {

            HtmlHead objHeader = new HtmlHead();
            //we add meta keywords
            HtmlMeta objMetaKeywords = new HtmlMeta
            {
                Name = "keywords",
                Content = word
            };

            //This will add it to the header object
            objHeader.Controls.Add(objMetaKeywords);
        }
    }
}