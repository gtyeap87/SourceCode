using SOEAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SOEAnalyzer.Process
{
    public class Analyze : IAnalyze
    {
        public bool CheckOccurence(List<Model> models, string search)
        {
            var query = models.Exists(x => x.Keyword == search);

            return query;
        }

        public bool CheckMetaOccurence(string source, string search)
        {

            bool isExist = false;
            isExist = source.Contains(search);

            return isExist;
        }

        public string[] SeparateKeyWord(string search)
        {
            string[] arr;

            if (search.IndexOf('.') != -1)
            {
                arr = search.Split('.');
            }
            else
            {
                arr = search.Split(' ');
            }


            return arr;
        }

        public string[] Filter(string[] search)
        {
            string[] arr = new string[] { };
            List<string> newLst = search.ToList();

            string stopWords = "or and how to the";
            var list = stopWords.Split(' ').ToList();

            int i = -1;
            foreach (var str in search.ToList())
            {
                i++;

                foreach (var item in list)
                {
                    if (item == str)
                    {
                        newLst.Remove(item);
                    }
                }
            }

            arr = newLst.ToArray();

            return arr;
        }

        public string[] Filter(string search)
        {
            string[] arr = new string[] { };
           
            string input = "www.soe.com.my";
            Regex regex = new Regex(@"www.[A-Za-z0-9\-]+.[A-Za-z0-9\-]+.[A-Za-z0-9\-]+$");
            Regex regex2 = new Regex(@"www.[A-Za-z0-9\-]+.[A-Za-z0-9\-]+$");
            if (regex.IsMatch(input))
            {
                var v = search.ToList().ElementAt(1);
            }

            if (regex2.IsMatch(input))
            {
                var v = search.ToList().ElementAt(1);
                arr[0] = v.ToString();
            }

            
            //arr = query.ToArray();

            return arr;
        }
    }
}