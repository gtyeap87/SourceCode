using SOEAnalyzer.Models;
using SOEAnalyzer.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOEAnalyzer.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult SOE()
        {
            List<Model> models = new List<Model>();
            models.Add(new Model { Keyword = "soe", Occurence = 1, Id = 1 });
            models.Add(new Model { Keyword = "sitecore", Occurence = 2, Id = 2 });

            return View(models);
        }

        public JsonResult Sort(SortModel vm)
        {
            List<Model> models = vm.List;
            ViewBag.Keyword = string.IsNullOrEmpty(vm.SortOrder) ? "Keyword_desc" : "Keyword";
            ViewBag.Occurence = vm.SortOrder == "Occurence" ? "Occurence_desc" : "Occurence";
            ViewBag.MetaOccurence = vm.SortOrder == "MetaOccr" ? "MetaOccr_desc" : "MetaOccr";

            var emp = from s in models.AsQueryable()
                      select s;

            string sortOrder = string.Empty;

            if (vm.SortOrder.Contains("desc"))
                sortOrder = string.Format("{0}", vm.SortOrder);
            else
                sortOrder = string.Format("{0}_{1}", vm.SortOrder, "desc");

            switch (sortOrder)
            {
                case "Keyword_desc":
                    emp = emp.OrderByDescending(s => s.Keyword);
                    break;
                case "Occurence":
                    emp = emp.OrderBy(s => s.Occurence);
                    break;
                case "Occurence_desc":
                    emp = emp.OrderByDescending(s => s.Occurence);
                    break;
                case "MetaOccurence":
                    emp = emp.OrderBy(s => s.MetaOccurence);
                    break;
                case "MetaOccurence_desc":
                    emp = emp.OrderByDescending(s => s.MetaOccurence);
                    break;
                default:
                    emp = emp.OrderBy(s => s.Keyword);
                    break;
            }

            string str = Helper.Helper.GenerateHTMLString(emp.ToList(), ViewBag);

            ResponseModel response = new ResponseModel
            {
                Html = str,
                SelectedField = vm.SortOrder,
                SortType = sortOrder.Contains("desc") ? "DESC" : "ASC"
            };
            return Json(response, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult Analyze(ViewModel vm)
        {
            List<Model> models = new List<Model>();
            string word = string.Empty;
            IAnalyze analyze = new Analyze();
            IAdd add = new Add();
            IUpdate update = new Update();

            string[] searchArry = analyze.SeparateKeyWord(vm.SearchText);
            string[] filterArry;
            if (vm.SearchText.Contains("."))
            {
                filterArry = analyze.Filter(vm.SearchText);
            }
            else
            {
                filterArry = analyze.Filter(searchArry);
            }


            foreach (string str in filterArry)
            {
                if (vm.Models == null)
                {
                    vm.Models = new List<Model>();
                }

                bool isExists = analyze.CheckOccurence(vm.Models, str);

                if (isExists)
                {
                    try
                    {
                        models = vm.Models;
                        models = update.UpdateCount(ref models, str);
                        //add.AddMeta(Request.Headers, word);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                else
                {
                    try
                    {
                        models = vm.Models;
                        models = add.AddWord(ref models, str);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                bool isMetaExists = analyze.CheckMetaOccurence(vm.Meta, str);

                if (isMetaExists)
                {
                    try
                    {
                        models = vm.Models;
                        models = update.UpdateMetaCount(ref models, str);
                        //add.AddMeta(Request.Headers, word);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                //else
                //{
                //    try
                //    {
                //        models = vm.Models;
                //        models = add.AddWord(ref models, str);
                //        add.AddMeta(vm.Meta, str);
                //    }
                //    catch (Exception ex)
                //    {
                //        throw ex;
                //    }
                //}

            }

            ViewData.Model = models;
            return View("SOE", models);
        }

    }
}