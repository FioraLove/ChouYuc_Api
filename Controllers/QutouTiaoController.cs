using System;
using System.Collections.Generic;
using System.Linq;
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
    public class QutouTiaoController : ControllerBase
    {
        public Object Get(string url)
        {
            var url_302 = HttpHelper.HttpGet(url);

            var js = HttpUtility.UrlDecode("http:%2F%2Fhtml2.qktoutiao.com%2Fdetail%2Fjsonp%2F1437840%2F14378393%2F143783926%2F1437839259.js");
            var html = HttpHelper.HttpGet(js);
            var file_id = JsonConvert.DeserializeObject<JObject>(JsonConvert.DeserializeObject<JObject>(html.Replace(")", "").Replace("cb(", ""))["detail"].ToString().Replace("\\\"", "\""))["value"].ToString();
            return HttpHelper.HttpGet("http://mpapi.qutoutiao.net/video/getAddressByFileId?file_id=" + file_id);
        }
    }
}