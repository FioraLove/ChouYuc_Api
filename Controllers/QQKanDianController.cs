using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChouYuc_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QQKanDianController : ControllerBase
    {
        public Object Get(string url)
        {
            var rowkey = HttpHelper.GetQueryString("rowkey", url);
            return HttpHelper.HttpGet("https://kandian.qq.com/cgi-bin/kva/share/video?rowkey=" + rowkey + "&rcm_video_num=1");
        }
    }
}