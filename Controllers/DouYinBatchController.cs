using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.IE;

namespace ChouYuc_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DouYinBatchController : ControllerBase
    {
        private readonly INodeServices _services;

        public DouYinBatchController(INodeServices services)
        {
            _services = services;
        }
    //    public  object Get()
    //    {
    //       //公众号查看
    //    }
    //}
}