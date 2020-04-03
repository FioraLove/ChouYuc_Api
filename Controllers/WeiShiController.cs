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
    [Route("[controller]")]
    [ApiController]
    public class WeiShiController : ControllerBase
    {

        public Object Get(string url)
        {
            var feedid = Regex.Match(url, "feed/(.*?)/").Value.Split('/')[1];
            WebHeaderCollection header = new WebHeaderCollection();
            header.Add("referer", url);
            var data = "{\"feedid\":\"" + feedid + "\",\"recommendtype\":0,\"datalvl\":\"all\",\"_weishi_mapExt\":{}}";
            return HttpHelper.HttpPost("https://h5.weishi.qq.com/webapp/json/weishi/WSH5GetPlayPage?t=0.5261416173604099&g_tk=", data, "application/json", header);

        }
      
    }
}