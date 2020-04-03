using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChouYuc_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ZuiYouController : ControllerBase
    {
        public Object Get(string url)
        {
            var pid = HttpHelper.GetUrlParameterValue(url, "pid");
            if (url.Contains("?id="))
            {
                pid = HttpHelper.GetUrlParameterValue(url, "id");
            }
            var html = HttpHelper.HttpGet("https://share.izuiyou.com/hybrid/share/post?pid=" + pid);
            var ids = Regex.Match(html, "poster=\"(.*?)\"").Value.Split('"')[1].Split("/")[6];
            return JsonConvert.DeserializeObject<JObject>(Regex.Match(html, "\"videos\":{\"" + ids + "\"(.*?)\",").Value.Replace("\"videos\":{\"" + ids + "\":", "").Trim(',') + "}");

        }
    }
}