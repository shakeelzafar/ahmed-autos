using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Web.Mvc;
using dreport.Models;
using System.Data.Entity;

namespace Delivery_Report.Controllers
{

    public class HomeController : Controller
    {
        autosEntities ctx = new autosEntities();
        public ActionResult calculator()
        {

            return View();
        }
        public ActionResult products()
        {

            return View();
        }
        public ActionResult factors()
        {

            return View();
        }
        public ActionResult deleteproduct(int id, string product, float value)
        {
            try
            {
                if (id > 0)
                {
                    autoData data = ctx.autoDatas.Find(id);
                    ctx.autoDatas.Remove(data);
                    ctx.SaveChanges();
                }
                else
                {

                }
            }
            catch (Exception e) { }
            return RedirectToAction("products");
        }
        public ActionResult deletefactor(int id, string product, float value)
        {
            try
            {
                if (id > 0)
                {
                    autoData data = ctx.autoDatas.Find(id);
                    ctx.autoDatas.Remove(data);
                    ctx.SaveChanges();
                }
                else
                {

                }
            }
            catch (Exception e) { }
            return RedirectToAction("factors");
        }
        public ActionResult savefactor(string factor, float value, int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    autoData data = ctx.autoDatas.Find(id);
                    if (factor != "")
                        data.Key = factor;
                    if (value >= 0)
                        data.Value = value;
                    ctx.Entry(data).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                else
                {
                    autoData data = new autoData();
                    data.Key = factor;
                    data.Value = value;
                    data.Type = 0;
                    ctx.autoDatas.Add(data);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e) { }
            return RedirectToAction("factors");
        }
        public ActionResult saveproduct(string product, float value, int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    autoData data = ctx.autoDatas.Find(id);
                    if (product != "")
                        data.Key = product;
                    if (value >= 0)
                        data.Value = value;
                    ctx.Entry(data).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                else
                {
                    autoData data = new autoData();
                    data.Key = product;
                    data.Value = value;
                    data.Type = 1;
                    ctx.autoDatas.Add(data);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e) { }
            return RedirectToAction("products");
        }

    }

    //public class HomeController : Controller
    //{
    //    public List<Dictionary<string, object>> SalesOrders = new List<Dictionary<string,object>>();
    //    public List<Dictionary<string, object>> PurchaseOrders = new List<Dictionary<string, object>>();
    //    public List<Dictionary<string, object>> WorkOrders = new List<Dictionary<string, object>>();
    //    //public List<Dictionary<string, object>> Products = new List<Dictionary<string, object>>();
    //    public List<Dictionary<string, object>> SupplierClients = new List<Dictionary<string, object>>();

     

    //    public object [] GetDictionaryObjects(string url)
    //    {
    //        HttpClient client = new HttpClient();

    //        ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
    //        HttpWebRequest request = this.GetRequest(url);
    //        WebResponse webResponse = request.GetResponse();
    //        string responseText = new StreamReader(webResponse.GetResponseStream()).ReadToEnd().ToString();

    //        var json = new JavaScriptSerializer().DeserializeObject(responseText);
    //        Dictionary<string, object> obj2 = (Dictionary<string, object>)json;

    //        object[] obj3 = (object[])obj2.Select(x => x.Value).ToList<object>().ElementAt(0);
    //        return obj3;

    //    }
    //    public void WorkOrderGet(string url)
    //    {

    //        foreach (object ob in GetDictionaryObjects(url))
    //        {
    //            Dictionary<string, object> ob4 = (Dictionary<string, object>)ob;
    //            WorkOrders.Add(ob4);
    //        }
    //    }
    //    public void SalesOrderGet(string url)
    //    {
    //        foreach (object ob in GetDictionaryObjects(url))
    //        {
    //            Dictionary<string, object> ob4 = (Dictionary<string, object>)ob;
    //              SalesOrders.Add(ob4);  
    //        }
    //    }
    //    public void PurchaseOrderGet(string url)
    //    {
    //        foreach (object ob in GetDictionaryObjects(url))
    //        {
    //            Dictionary<string, object> ob4 = (Dictionary<string, object>)ob;
    //            PurchaseOrders.Add(ob4);
    //        }
    //    }
    //    //public void ProductGet(string url)
    //    //{
    //    //    foreach (object ob in GetDictionaryObjects(url))
    //    //    {
    //    //        Dictionary<string, object> ob4 = (Dictionary<string, object>)ob;
    //    //        Products.Add(ob4);
    //    //    }
    //    //}
    //    public void SupplierClientGet(string url)
    //    {
    //        foreach (object ob in GetDictionaryObjects(url))
    //        {
    //            Dictionary<string, object> ob4 = (Dictionary<string, object>)ob;
    //            SupplierClients.Add(ob4);
    //        }
    //    }
    //    //SupplierClientGet
    //    public ActionResult Index()
    //    { 
    //        return View();
    //    }
    //    private HttpWebRequest GetRequest(string url, string httpMethod = "GET", bool allowAutoRedirect = true)
    //    {
    //        Uri uri = new Uri(url);
    //        HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
    //        request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";

    //        request.Timeout = Convert.ToInt32(new TimeSpan(0, 5, 0).TotalMilliseconds);
    //        request.Method = httpMethod;
    //        return request;
    //    }
    //    public ActionResult report(string APIKEY)
    //    {
    //        SalesOrderGet("https://api.megaventory.com/v2017a/json/reply/SalesOrderGet?APIKEY=" + APIKEY);
    //        WorkOrderGet("https://api.megaventory.com/v2017a/json/reply/WorkOrderGet?APIKEY=" + APIKEY);
    //        PurchaseOrderGet("https://api.megaventory.com/v2017a/json/reply/PurchaseOrderGet?APIKEY=" + APIKEY);
    //        //ProductGet("https://api.megaventory.com/v2017a/json/reply/ProductGet?APIKEY=" + APIKEY);
    //        SupplierClientGet("https://api.megaventory.com/v2017a/json/reply/SupplierClientGet?APIKEY=" + APIKEY);

    //        Session["SalesOrders"] = SalesOrders;
    //        Session["PurchaseOrders"] = PurchaseOrders;
    //        Session["WorkOrders"] = WorkOrders;
    //        //Session["Products"] = Products;
    //        Session["SupplierClients"] = SupplierClients;
    //        return View();
    //    }
    
    //    public ActionResult ProductionReport()
    //    {

    //        return View();
    //    }

    //    public ActionResult Contact()
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        return View();
    //    }
    //    public ActionResult About()
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        return View();
    //    }
    //}
}
