using System.Globalization;
using OpenQA.Selenium;

namespace Extracao_Selenium_CSV.Entities.PageObjects
{
    internal class Unemployees
    {
        public string HomeUrl = "https://pt.tradingeconomics.com/country-list/unemployment-rate?continent=g20";

        public Unemployees(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebDriver WebDriver { get; set; }

        public string GetCountry(int line)
        {
            var country = WebDriver.FindElement(By.XPath(
                string.Format(
                    "//*[@id='ctl00_ContentPlaceHolder1_ctl01_UpdatePanel1']/div/div[2]/table/tbody/tr[{0}]/td[1]",
                    line))).Text;

            return country;
        }

        public double GetPercentual(int line)
        {
            var percentual = WebDriver.FindElement(By.XPath(
                string.Format(
                    "//*[@id='ctl00_ContentPlaceHolder1_ctl01_UpdatePanel1']/div/div[2]/table/tbody/tr[{0}]/td[2]",
                    line))).Text;
     
            return double.Parse(percentual,CultureInfo.InvariantCulture);
        }
    }
}