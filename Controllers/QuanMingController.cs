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
    public class QuanMingController : ControllerBase
    {
        public Object Get(string url)
        {
            var vid = HttpHelper.GetUrlParameterValue(url, "vid");
            return HttpHelper.HttpGet("https://quanmin.hao222.com/wise/growth/api/sv/immerse?source=share-h5&pd=qm_share_mvideo&vid=" + vid);
        }
    }
}