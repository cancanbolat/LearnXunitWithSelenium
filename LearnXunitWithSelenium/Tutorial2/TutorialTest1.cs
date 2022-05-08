using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearnXunitWithSelenium.Tutorial2
{
    public class TutorialTest1
    {
        String test_url = "https://lambdatest.github.io/sample-todo-app/";
        String itemName = "Yey, Let's add it to list";

        [Fact]
        public void NavigateTodoApp()
        {
            using (var driver = WebDriverInfra.Create_Browser(BrowserType.Chrome))
            {
                driver.Navigate().GoToUrl(test_url);
                driver.Manage().Window.Maximize();

                Assert.Equal("Sample page - lambdatest.com", driver.Title);

                //Clieck on First Check Box
                IWebElement firstCheckBox = driver.FindElement(By.Name("li1"));
                firstCheckBox.Click();

                // Click on Second Check box
                IWebElement secondCheckBox = driver.FindElement(By.Name("li2"));
                secondCheckBox.Click();

                //Enter Item Name
                IWebElement textField = driver.FindElement(By.Id("sampletodotext"));
                textField.SendKeys(itemName);

                //Click on Add Button
                IWebElement addButton = driver.FindElement(By.Id("addbutton"));
                addButton.Click();

                //Verified Added Item Name
                IWebElement itemtext = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));
                string getText = itemtext.Text;
                Assert.True(itemName.Contains(getText));

                driver.Quit();
            }
        }
    }
}
