using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOEAnalyzer.Models;
using System;
using System.Collections.Generic;

namespace SOEAnalyzer.Process.Tests
{
    [TestClass()]
    public class UpdateTests
    {
        private IUpdate _update;
        public UpdateTests()
        {
            _update = new Update();
        }

        [TestMethod()]
        public void UpdateCountTest()
        {
            try
            {
                List<Model> models = new List<Model>();
                models.Add(new Model { Keyword = "soe", Occurence = 1, Id = 1 });
                models.Add(new Model { Keyword = "sitecore", Occurence = 2, Id = 2 });

                string search = "soe";

                List<Model> result = _update.UpdateCount(ref models, search);

                CollectionAssert.AllItemsAreNotNull(result);
                CollectionAssert.AreNotEqual(models, result);

                //Assert.IsNotNull(actualId, string.Format("{0} - {1}", "BlackListEntry", "Success"));

                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0}{1} - {2}", "Failed Test - Create", "Add", ex.Message));
            }
        }

        [TestMethod()]
        public void UpdateMetaCountTest()
        {
            try
            {
                List<Model> models = new List<Model>();
                models.Add(new Model { Keyword = "soe", Occurence = 1, Id = 1 });
                models.Add(new Model { Keyword = "sitecore", Occurence = 2, Id = 2 });

                string search = "soe";

                List<Model> result = _update.UpdateMetaCount(ref models, search);

                CollectionAssert.AllItemsAreNotNull(result);
                CollectionAssert.AreNotEqual(models, result);

                //Assert.IsNotNull(actualId, string.Format("{0} - {1}", "BlackListEntry", "Success"));

                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0}{1} - {2}", "Failed Test - Create", "Add", ex.Message));
            }
        }
    }
}