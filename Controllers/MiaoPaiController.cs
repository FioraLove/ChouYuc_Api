using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChouYuc_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MiaoPaiController : ControllerBase
    {
        public Object Get(string url)
        {
            var urls = url.Split('/');
            var mids = urls[urls.Length - 1].Split('.')[0];
            WebHeaderCollection header = new WebHeaderCollection();
            header.Add("Referer", "https://n.miaopai.com");
            return HttpHelper.HttpGet("https://n.miaopai.com/api/aj_media/info.json?smid=" + mids + "&appid=530&_cb=_jsonpq0ullomumni", header);
        }
    }
}