using System;
using System.Collections.Generic;
using System.Linq;
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

    public void Login(string email, string password)
    {
        this.Url("http://localhost:4200/");
        IWebElement loginNavbar = this.WaitForElement(By.Id("login-navbar"));
        loginNavbar.Click();

        IWebElement emailInput = this.WaitForElement(By.Id("email"));
        emailInput.SendKeys(email);
        IWebElement passwordInput = this.WaitForElement(By.Id("password"));
        passwordInput.SendKeys(password);
        IWebElement loginButton = this.WaitForElement(By.Id("login-button"));
        loginButton.Click();
        IWebElement logoutNavbar = this.WaitForElement(By.Id("logout-navbar"));
    }

    public void LoginWithCredentials()
    {
        string email = "matias@admin.com";
        string password = "admin";
        this.Login(email, password);
    }

    public void Logout()
    {
        IWebElement logoutNavbar = this.WaitForElement(By.Id("logout-navbar"));
        logoutNavbar.Click();
    }

    public void MaximizeWindow()
    {
        //Driver.Manage().Window.Maximize();
    }

    public void Url(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public void FillTextBox(IWebElement textBox, string data)
    {
        textBox.SendKeys(data);
    }

    public void CreateChargingSpotInForm(string name, string address, string description, string regionName)
    {
        IWebElement nameInput = this.WaitForElement(By.Id("name"));
        IWebElement addressInput = this.WaitForElement(By.Id("address"));
        IWebElement descriptionInput = this.WaitForElement(By.Id("description"));
        IWebElement regionsInput = this.WaitForElement(By.Id("regions"));

        IWebElement field = this.WaitForElement(By.CssSelector("mat-select"));

        // Click to open the dropdown.
        field.Click();

        // Query for options in the DOM. These exist outside of the mat-select component.
        IList<IWebElement> options = this.WaitForElements(By.CssSelector("mat-option"));

        // Find the option with the text that matches the one you are looking for.
        options.First(element => element.Text == regionName)
            // Click it to select it.
            .Click();

        this.FillTextBox(nameInput, name);
        this.FillTextBox(addressInput, address);
        this.FillTextBox(descriptionInput, description);
        //this.SelectDropDownValue(regionsInput, "region-" + regionId.ToString());

        IWebElement createButton = this.WaitForElement(By.Id("create-charging-spot-button"));
        this.Click(createButton);
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
