using SOEAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEAnalyzer.Process
{
    public interface IAnalyze
    {
        bool CheckOccurence(List<Model> models, string word);
        bool CheckMetaOccurence(string source, string word);
        string[] SeparateKeyWord(string word);
        string[] Filter(string[] strArry);
        string[] Filter(string str);
    }
}
