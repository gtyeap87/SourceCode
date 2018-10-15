using SOEAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEAnalyzer.Helper
{
    public static class Helper
    {

        public static string GenerateHTMLString(List<Model> models, dynamic viewbag)
        {
            string html = string.Empty;
            string header = "<tr>" +
                            "<th hidden=''>Id</th><th><a href='#' id='" + viewbag.Keyword + "'>Keyword<span class=''></span></a></th><th>" +
                            "<a href='#' id='" + viewbag.Occurence + "' > Occurence<span class=''></span></a></th><th>" +
                            "<a href='#' id='" + viewbag.MetaOccurence + "'>MetaOccr<span class=''></span></a></th><th></th></tr>";


            string body = string.Empty;
            foreach (var item in models)
            {
                body += "<tr data-id='" + item.Id + "' class='data'>" +
                "<td hidden=''>" + item.Id + "</td>" +
                "<td >" + item.Keyword + "</td>" +
                "<td >" + item.Occurence + "</td>" +
                "<td >" + item.MetaOccurence + "</td>" +
                "</tr>";
            }

            html = string.Format("{0}{1}", header, body);

            return html;
        }
    }
}