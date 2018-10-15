using SOEAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEAnalyzer.Process
{
    public interface IAdd
    {
        List<Model> AddWord(ref List<Model> models, string word);
        void AddMeta(string meta, string word);
    }
}
