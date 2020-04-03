using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChouYuc_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KuaiShouController : ControllerBase
    {
        public Object Get(string url)
        {
            //快手新域名 kuaishou.com
            if(url.ToLower().Contains("kuaishou.com"))
            {
                WebHeaderCollection header = new WebHeaderCollection();
                header.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36");
                var html_302 = HttpHelper.HttpGet(url, header, false);
                html_302 = HttpHelper.HttpGet(html_302, header, false);
                var html = HttpHelper.HttpGet("https:"+html_302, header, false);
                var resUrl = Regex.Match(html, "\"playUrl\":\"(.*?).mp4").Value.Replace("\"playUrl\":\"", "");
                return resUrl.Replace("\\u002F","\\");
            }
            else
            {
                var sig = HttpHelper.StringToMD5Hash("client_key=56c3713cshareText=" + url + System.Text.Encoding.ASCII.GetString(new byte[] { 50, 51, 99, 97, 97, 98, 48, 48, 51, 53, 54, 99 }));
                var data = "client_key=56c3713c&shareText=" + url + "&sig=" + sig;
                var result = HttpHelper.HttpGet("http://api.gifshow.com/rest/n/tokenShare/info/byText?" + data);
                return result;
            }



           
        }
    }
}