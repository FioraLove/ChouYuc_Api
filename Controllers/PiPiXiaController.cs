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
    /// 皮皮虾
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PiPiXiaController : ControllerBase
    {
        public Object Get(string url)
        {
            if (!url.Contains("item"))
            {
                url = HttpHelper.HttpGet(url);
            }
            if (url.IndexOf('?') > -1)
            {
                url = url.Replace(url.Substring(url.IndexOf('?')), "");
            }
            //获取item
            var itemId = Regex.Match(url + "/", "item/(.*?)/").Value.Split('/')[1];
            return HttpHelper.HttpGet("https://h5.pipix.com/bds/webapi/item/detail/?item_id=" + itemId);
        }
    }
}