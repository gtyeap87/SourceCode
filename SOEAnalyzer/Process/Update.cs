using SOEAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEAnalyzer.Process
{
    public class Update : IUpdate
    {

        public List<Model> UpdateCount(ref List<Model> models, string search)
        {
            foreach (var item in models)
            {
                if (item.Keyword == search)
                {
                    item.Occurence = item.Occurence + 1;
                }

            }
            return models;
        }

        public List<Model> UpdateMetaCount(ref List<Model> models,string search)
        {
            foreach (var item in models)
            {
                if (item.Keyword == search)
                {
                    item.MetaOccurence = item.MetaOccurence + 1;
                }

            }
            return models;
        }

    }
}