<%@ WebHandler Language="C#" Class="data" %>

using System;
using System.Web;
using Newtonsoft.Json;

public class data : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        System.Data.DataTable dt = BDMapWeb.SQLHelper.GetDataTable("select 箱体编号 as boxid,容积 as rj,经度 as lon,纬度 as lat from Box_GPS");
        context.Response.Write(JsonConvert.SerializeObject(dt));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}