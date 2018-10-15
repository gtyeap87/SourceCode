using SOEAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEAnalyzer.Process
{
    public interface IUpdate
    {
        List<Model> UpdateCount(ref List<Model> models, string word);
        List<Model> UpdateMetaCount(ref List<Model> models,string word);
    }
}
