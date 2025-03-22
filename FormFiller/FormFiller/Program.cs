/*
    Use this as a template to fill out surveys automatically.
    This code is written in C# and uses the Selenium WebDriver library.
    You will need to install the Selenium.WebDriver and Selenium.WebDriver.ChromeDriver NuGet packages.
    You will also need to download the ChromeDriver executable and add it to your PATH.
    Replace the URL and element IDs with the ones from your survey.
    You can also change the number of submissions by changing the loop count.

    Tools>NuGet Package Manager> Manage NuGet Packages for Solution> Browse> Selenium.WebDriver> Install

    Tools>NuGet Package Manager> Manage NuGet Packages for Solution> Browse> Selenium.WebDriver.ChromeDriver> Install

    If you are still having trouble, refer to the Selenium WebDriver documentation and the ChromeDriver download page.

    Selenium WebDriver: https://www.selenium.dev/documentation/en/webdriver/

    ChromeDriver: https://sites.google.com/a/chromium.org/chromedriver/

    NuGet Package Manager: https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio

    To run this code:
    1. Install the Selenium.WebDriver and Selenium.WebDriver.ChromeDriver NuGet packages.
    2. Download the ChromeDriver executable and add it to your PATH.
    3. Replace the URL and element IDs with the ones from your survey.
    4. Change the number of submissions by changing the loop count.
    5. Run the code.

    Note: This code is for educational purposes only. Do not use it for malicious purposes or to flood surveys with fake data.

    Signed: imkappy
    3/22/2025
    © 2025 imkappy. All Rights Reserved.  

*/

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using static System.Net.WebRequestMethods;

//This program uses a 7 question survey as an example. Replace the element IDs with the ones from your survey. 
//You can find the element IDs by inspecting the survey page in your browser.
//You can also change the number of submissions by changing the loop count.
//When looking for element IDs, look for the "id" attribute in the HTML code of the survey page.
//You can also use other locators like class name, name, etc., depending on the survey page.
//This may not always be the case, but it is a common way to locate elements in a survey page.
class Program
{
    //replace this with any URL, google is set as default for testing purposes
    public string URL = "https://www.google.com/";
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++) // Loop 5 times. change this number to change the number of submissions
        {
            Console.WriteLine($"Starting survey submission {i + 1}...");

            IWebDriver driver = new ChromeDriver(); // Use Chrome browser
            driver.Navigate().GoToUrl("{URL}"); // Open the survey URL

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Wait up to 10 seconds for elements to appear
            Random rnd = new Random(); // Random number generator

            try // Try to fill out the survey
            {
                // === Q?: *INSTER ELEMENT TOPIC HERE* ) ===
                int randomOption1 = rnd.Next(1, 8); // Random number between 1 and 8
                string labelId1 = $"QID2-{randomOption1}-label"; //example for element id on the survey
                IWebElement label1 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(labelId1))); // Wait for the element to appear
                label1.Click(); // Click the element
                Console.WriteLine($"[#{i + 1}] Selected checkbox: {labelId1}"); // Log the action

                // === Q?: *INSTER ELEMENT TOPIC HERE* ) ===
                int randomOption2 = rnd.Next(1, 3); // Random number between 1 and 3
                string labelId2 = $"QID3-{randomOption2}-label"; //example for element id on the survey
                IWebElement label2 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(labelId2))); // Wait for the element to appear
                label2.Click(); // Click the element
                Console.WriteLine($"[#{i + 1}] Selected radio button: {labelId2}"); // Log the action

                // === Q?: *INSTER ELEMENT TOPIC HERE* ) ===
                int randomOption3 = rnd.Next(1, 3); // Random number between 1 and 3
                string labelId3 = $"QID7-{randomOption3}-label"; //example for element id on the survey
                IWebElement label3 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(labelId3))); // Wait for the element to appear 
                label3.Click(); // Click the element
                Console.WriteLine($"[#{i + 1}] Selected gender: {labelId3}"); // Log the action

                // === Q?: *INSTER ELEMENT TOPIC HERE* ) ===
                int randomOption4 = rnd.Next(1, 3); // Random number between 1 and 3
                string labelId4 = $"QID8-{randomOption4}-label"; //example for element id on the survey
                IWebElement label4 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(labelId4))); // Wait for the element to appear
                label4.Click(); // Click the element
                Console.WriteLine($"[#{i + 1}] Selected yes/no: {labelId4}"); // Log the action

                // === Q?: *INSTER ELEMENT TOPIC HERE* ) ===
                int randomOption5 = rnd.Next(1, 8); // Random number between 1 and 8
                string labelId5 = $"QID4-{randomOption5}-label"; //example for element id on the survey
                IWebElement label5 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(labelId5))); // Wait for the element to appear
                label5.Click(); // Click the element
                Console.WriteLine($"[#{i + 1}] Selected education: {labelId5}"); // Log the action

                // === Q?: *INSTER ELEMENT TOPIC HERE* ) ===
                int randomOption6 = rnd.Next(1, 8); // Random number between 1 and 8
                string labelId6 = $"QID5-{randomOption6}-label"; //example for element id on the survey 
                IWebElement label6 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(labelId6))); // Wait for the element to appear
                label6.Click(); // Click the element 
                Console.WriteLine($"[#{i + 1}] Selected another education option: {labelId6}"); // Log the action

                // === Q?: *INSTER ELEMENT TOPIC HERE* ) ===
                int zipCode = rnd.Next(10000, 99999); // Random 5-digit ZIP code
                IWebElement zipInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("QR~QID6"))); // Wait for the element to appear
                zipInput.SendKeys(zipCode.ToString()); // Enter the ZIP code 
                Console.WriteLine($"[#{i + 1}] Entered ZIP code: {zipCode}"); // Log the action

                // Wait a few seconds before submitting (visual confirmation)
                Thread.Sleep(250); 

                // === Submit the survey ===
                IWebElement submitButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("NextButton"))); // Wait for the element to be clickable
                submitButton.Click(); // Click the element 
                Console.WriteLine($"[#{i + 1}] Submitted the survey."); // Log the action

                // Wait a few seconds before closing (visual confirmation)
                Thread.Sleep(1000); 
            }
            // Catch any timeout exceptions
            catch (WebDriverTimeoutException e) 
            {
                Console.WriteLine($"[#{i + 1}] Timed out: {e.Message}"); // Log the error
            }
            //close the browser
            finally 
            {
                driver.Quit(); // Close the browser
                Console.WriteLine($"[#{i + 1}] Survey submission complete.\n"); // Log the completion
            }

            // Short pause before starting the next iteration
            Thread.Sleep(1000); 
        }
        Console.WriteLine("All 5 submissions completed!"); // Log the completion
    }
}
