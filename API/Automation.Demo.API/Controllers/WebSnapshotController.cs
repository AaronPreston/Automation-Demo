using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Automation.Demo.API.Controllers
{
    [Route("api/[controller]")]
    public class WebSnapshotController : Controller
    {
        [HttpGet("{url}")]
        public IEnumerable<dynamic> Get(string url)
        {
            var driver = Automation.Init();
            driver.Navigate().GoToUrl("http://" + url);

            string description;

            try
            {
                description = driver.FindElement(By.XPath("//meta[@name='description']")).GetAttribute("content");
            } catch(Exception)
            {
                description = "(No Description)";
            }


            var s = ((ITakesScreenshot)driver).GetScreenshot();

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(s.AsByteArray);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            return new dynamic[] {
                driver.Title,
                description,
                File(s.AsByteArray, "image/png")
            };
        }
    }
}
