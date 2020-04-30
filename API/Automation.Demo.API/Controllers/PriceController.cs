using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Automation.Demo.API.Controllers
{
    [Route("api/[controller]")]
    public class PriceController : Controller
    {
        [HttpGet("{product}")]
        public IEnumerable<dynamic> Get(string product)
        {
            var driver = Automation.Init();
            driver.Navigate().GoToUrl("http://www.amazon.com");
            driver.FindElementById("twotabsearchtextbox").SendKeys(product);
            driver.FindElementByClassName("nav-search-submit").Click();
            string price;

            try
            {
                price = (int.Parse(driver.FindElementByClassName("a-price-whole").Text) + 1).ToString();
            } catch(Exception)
            {
                price = driver.FindElementByClassName("a-price-whole").Text;
            }

            driver.Close();
            driver.Dispose();

            return new dynamic[] {
                price
            };
        }
    }
}
