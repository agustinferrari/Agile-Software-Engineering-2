using System;
using System.Collections.Generic;
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

        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement WaitForElement(By locator)
    {
        return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public IList<IWebElement> WaitForElements(By locator)
    {
        Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        IList<IWebElement> all = Driver.FindElements(locator);
        return all;
    }

    public void MaximizeWindow()
    {
        //Driver.Manage().Window.Maximize();
    }

    public void Url(string url)
    {
        Driver.Url = url;
    }

    public void FillTextBox(IWebElement textBox, string data)
    {
        textBox.SendKeys(data);
    }

    public void SelectDropDownValue(IWebElement dropDown, string id)
    {
        Click(dropDown);
        var selectElement = new SelectElement(Driver.FindElement(By.Id(id)));
    }

    public void Click(IWebElement webElement)
    {
        webElement.Click();
    }

    public void Setup()
    {

    }
}
