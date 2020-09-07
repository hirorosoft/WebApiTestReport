using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Document;

using Microsoft.VisualBasic.Logging;
using System.Web.Http.ExceptionHandling;

using System.IO;

namespace WebAPITest.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string id)
        {
            var fileName = "BarCode.rdlx";
            try
            {
                //GrapeCity.ActiveReports.Viewer.Win.Viewer arvMain = new GrapeCity.ActiveReports.Viewer.Win.Viewer();

                var reportFile = new FileInfo(HttpContext.Current.Server.MapPath("~/") + fileName);

                PageReport report = new PageReport(reportFile);

                var doc = new PageDocument(report);


                doc.Parameters["ReportParameter1"].CurrentValue = id;

                doc.Print(false, false, false);

                return "value = " + id;


            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        // 実行時にLocateDataSourceイベントと共に、データセットプロバイダを使用し、アンバウンドデータソースと接続できます。LocateDataSourceイベントがデータの入力が必要な場合は、レポートエンジンにより発生されます。
        void OnLocateDataSource(object sender, LocateDataSourceEventArgs args)
        {
            //args.Data = LoadData();
            var a = args;




        }



        // POST api/values
        public void Post([FromBody] string value)
        {
            //try
            //{
            //    var reportFile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("/") + "BarCode.rdlx");
            //    PageReport report = new PageReport(reportFile);
            //    var doc = new GrapeCity.ActiveReports.Document.PageDocument(report);

            //   doc.Print(false, false, false);

            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
