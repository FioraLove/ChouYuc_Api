using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChouYuc_Api.Controllers
{
    /// <summary>
    /// 皮皮搞笑
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PiPiGaoXiaoController : ControllerBase
    {
        public Object Get(string url)
        {
            //获取item
            var pid = Regex.Match(url + "/", "post/(.*?)/").Value.Split('/')[1];
            WebHeaderCollection header = new WebHeaderCollection();
            header.Add("Origin", "http://h5.ippzone.com");
            header.Add("Referer", url);
            return HttpHelper.HttpPost("http://share.ippzone.com/ppapi/share/fetch_content", "{\"pid\":" + pid + ",\"type\":\"post\"}", "application/json;charset=utf-8", header);

        }
    }
}