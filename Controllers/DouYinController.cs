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
    public class DouYinController : ControllerBase
    {
        public Object Get(string url)
        {
            url = HttpHelper.HttpGet(url);
            string vid = Regex.Matches(url, "/(.*?)/")[2].Value.Split('/')[1];
            var html_302 = HttpHelper.HttpGet(url);
            var dytk = Regex.Match(Regex.Match(html_302, "dytk(.*?)}").Value, "\\w+(?=\")").Value;
            var result = HttpHelper.HttpGet("https://www.iesdouyin.com/web/api/v2/aweme/iteminfo/?item_ids=" + vid + "&dytk=" + dytk);
            //返回地址已是有水印地址
            //例如：https://aweme.snssdk.com/aweme/v1/playwm/?video_id=v0200ff40000bp30umcttc5i66m6n4vg&ratio=720p&line=0
            //只需要把vm去掉即可 就是无水印地址了 https://aweme.snssdk.com/aweme/v1/play/?video_id=v0200ff40000bp30umcttc5i66m6n4vg&ratio=720p&line=0
            return result;
        }
    }
}