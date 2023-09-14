using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.google.no/");

        // Click on the "I agree" button if it's present
        try
        {
            var agreeButton = driver.FindElement(By.XPath("//*[@id=\"L2AGLb\"]/div"));
            if (agreeButton.Displayed && agreeButton.Enabled)
            {
                agreeButton.Click();
            }
        }
        catch (NoSuchElementException)
        {
            // Handle the case where the "I agree" button is not present
        }

        var element = driver.FindElement(By.XPath("//*[@id=\"APjFqb\"]"));
        element.SendKeys("Sko");
        element.Submit();

        var titles = driver.FindElements(By.XPath("//*[@id=\"rso\"]/div/div/div/div[1]/div/div/span/a/h3"));

        foreach (var item in titles)
        {
            Thread.Sleep(2000);
            Console.WriteLine(item.Text);
        }

        // Close the WebDriver
        driver.Quit();
    }
}
