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
    public class AddTests
    {
        private IAdd _add;
        public AddTests()
        {
            _add = new Add();
        }

        [TestMethod()]
        public void AddWordTest()
        {
            try
            {
                List<Model> models = new List<Model>();
                models.Add(new Model { Keyword = "soe", Occurence = 1, Id = 1 });
                models.Add(new Model { Keyword = "sitecore", Occurence = 2, Id = 2 });

                string search = "soe";

                List<Model> result = _add.AddWord(ref models, search);

                //Assert.IsNotNull(actualId, string.Format("{0} - {1}", "BlackListEntry", "Success"));

                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0}{1} - {2}", "Failed Test - Create", "Add", ex.Message));
            }
        }

        [TestMethod()]
        public void AddMetaTest()
        {
            try
            {
                string url = "soe";
                string search = "soe sitecore";

                _add.AddMeta(url, search);

                //Assert.IsNotNull(actualId, string.Format("{0} - {1}", "BlackListEntry", "Success"));

            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0}{1} - {2}", "Failed Test - Create", "Add", ex.Message));
            }
        }
    }
}