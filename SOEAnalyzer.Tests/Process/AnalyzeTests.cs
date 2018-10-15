using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOEAnalyzer.Models;
using SOEAnalyzer.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEAnalyzer.Process.Tests
{
    [TestClass()]
    public class AnalyzeTests
    {
        private IAnalyze _analyze;
        public AnalyzeTests()
        {
            _analyze = new Analyze();
        }

        [TestMethod()]
        public void CheckOccurenceTest()
        {
            try
            {
                List<Model> models = new List<Model>();
                models.Add(new Model { Keyword = "soe", Occurence = 1, Id = 1 });
                models.Add(new Model { Keyword = "sitecore", Occurence = 2, Id = 2 });

                string search = "soe";

                bool result = _analyze.CheckOccurence(models, search);

                //Assert.IsNotNull(actualId, string.Format("{0} - {1}", "BlackListEntry", "Success"));

                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
                Assert.AreEqual(false, result);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0}{1} - {2}", "Failed Test - Create", "BlackListEntry", ex.Message));
            }

        }

    }
}