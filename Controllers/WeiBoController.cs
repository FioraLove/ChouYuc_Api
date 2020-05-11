using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChouYuc_Api.Controllers
{
    /// <summary>
    /// 微博小视频
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WeiBoController : ControllerBase
    {
        public Object Get(string url)
        {
            var url_302 = HttpHelper.HttpGet(url);
            var split = url_302.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var object_id = split[2];
            var mid = split[3];
            var json =HttpHelper.HttpGet("https://video.h5.weibo.cn/s/video/object?object_id=" + object_id + "&mid=" + mid);
            return json;
        }
    }
}