using System;
using System.Collections.Generic;
using System.Linq;
using IntegrationTests.Models;
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
        //option.AddArguments("--headless");
        option.AddArguments("--window-size=1920,1080");
        new DriverManager().SetUpDriver(new ChromeConfig());
        Console.WriteLine("Setup");
        Driver = new ChromeDriver(option);

        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
    }

    public void Quit()
    {
        Driver.Close();
        Driver.Quit();
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
        //Driver.Url = url;
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
        IWebElement dropDown = this.WaitForElement(By.CssSelector("mat-select"));

        this.SelectDropDownValue(dropDown, regionName);

        this.FillTextBox(nameInput, name);
        this.FillTextBox(addressInput, address);
        this.FillTextBox(descriptionInput, description);

        IWebElement createButton = this.WaitForElement(By.Id("create-charging-spot-button"));
        this.Click(createButton);
    }

    public void SelectDropDownValue(IWebElement dropDown, string value)
    {
        dropDown.Click();

        IList<IWebElement> options = this.WaitForElements(By.CssSelector("mat-option"));

        options.First(element => element.Text == value).Click();
    }

    public void Click(IWebElement webElement)
    {
        webElement.Click();
    }

    public string GetAlertText()
    {
        Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

        return Driver.SwitchTo().Alert().Text;
    }

    public void Setup()
    {

    }

    public List<ChargingSpot> GetChargingSpotsFromTable()
    {
        IWebElement table = this.WaitForElement(By.Id("charging-spot-table"));
        IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

        List<ChargingSpot> foundChargingSpots = new List<ChargingSpot>();

        for (int i = 1; i < rows.Count; i++)
        {
            IWebElement row = rows[i];
            IList<IWebElement> columns = row.FindElements(By.TagName("td"));
            int count = columns.Count;
            string test = columns[0].Text;
            int idCell = columns[0].Text == "" ? 0 : int.Parse(columns[0].Text);
            string name = columns[1].Text;
            string description = columns[2].Text;
            string address = columns[3].Text;
            string regionName = columns[4].Text;

            foundChargingSpots.Add(new ChargingSpot
            {
                Id = idCell,
                Name = name,
                Address = address,
                Description = description,
                RegionName = regionName
            });
        }

        return foundChargingSpots;
    }

    public void DeleteAllChargingSpots(bool loginStatus)
    {
        if (!loginStatus)
        {
            this.LoginWithCredentials();
        }

        this.Url("http://localhost:4200/explore/charging-spots");

        bool found = false;
        try
        {
            IList<IWebElement> errorMessages = this.WaitForElements(By.Name("error"));
            foreach (IWebElement errorMessage in errorMessages)
            {
                if (errorMessage.Text == "No charging spots in system")
                {
                    found = true;
                }
            }
        }
        catch (Exception)
        {
        }

        if (!found)
        {
            IList<IWebElement> buttons = this.WaitForElements(By.Name("delete"));
            foreach (IWebElement button in buttons)
            {
                this.Click(button);
            }
        }
    }
}
