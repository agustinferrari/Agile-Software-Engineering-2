using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace IntegrationTests.Utils;

public class SeleniumTestHelper
{
    public IWebDriver Driver { get; set; }
    public WebDriverWait Wait { get; set; }
    public SeleniumTestHelper()
    {
        ChromeOptions option = new ChromeOptions();
        option.AddArguments("--headless");
        option.AddArguments("--window-size=1920,1080");
        new DriverManager().SetUpDriver(new ChromeConfig());
        Console.WriteLine("Setup");
        Driver = new ChromeDriver(option);

        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
    }

    public IWebElement WaitForElement(By locator)
    {
        return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
    } 

    public void MaximizeWindow(){
        Driver.Manage.Window.Maximize();
    }


    public void Setup()
    {

    }
}
