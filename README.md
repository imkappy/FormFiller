# Automated Survey Filler with Selenium WebDriver

This project uses Selenium WebDriver in C# to automate the process of filling out surveys. By running the provided code, you can automatically submit answers to a survey with randomized responses. 
This is useful for educational purposes and automating repetitive tasks, but should not be used for malicious purposes such as flooding surveys with false data.

---

## Prerequisites

Before running the code, you need to set up the following:

1. **Install Selenium WebDriver**:
   - You need to install the `Selenium.WebDriver` and `Selenium.WebDriver.ChromeDriver` NuGet packages. You can do this through the NuGet Package Manager in Visual Studio:
     - `Tools > NuGet Package Manager > Manage NuGet Packages for Solution`
     - Search for `Selenium.WebDriver` and install it.
     - Search for `Selenium.WebDriver.ChromeDriver` and install it.
     - **Common errors**:
       - Make sure you are in the **Browse** tab when searching for packages
       - You may need to install `DotNetSeleniumExtras.WaitHelpers`
       - You may need to install `Selenium.Support`
   
2. **Download ChromeDriver**:
   - Download the appropriate version of the ChromeDriver for your version of Google Chrome from [here](https://sites.google.com/a/chromium.org/chromedriver/).
   - Make sure to add the `chromedriver.exe` to your system's PATH, or specify the path to the executable in the code.

3. **Modify the Survey URL and Element IDs**:
   - Replace the `URL` variable with the URL of your survey.
   - Modify the element IDs (`labelId1`, `labelId2`, etc.) in the code according to the actual IDs in your survey. You can inspect the HTML of your survey page to find these IDs.

4. **Adjust the Number of Submissions**:
   - Change the loop count (`for (int i = 0; i < 5; i++)`) to specify how many times the survey should be filled out automatically.

---

## Setup Instructions

1. **Install NuGet Packages**:
   - Open Visual Studio and go to `Tools > NuGet Package Manager > Manage NuGet Packages for Solution`.
   - Search for and install:
     - `Selenium.WebDriver`
     - `Selenium.WebDriver.ChromeDriver`

2. **Download and Set Up ChromeDriver**:
   - Download the correct version of [ChromeDriver](https://sites.google.com/a/chromium.org/chromedriver/).
   - Add it to your PATH environment variable or specify the location in the code.

3. **Modify the Code**:
   - Replace the `URL` with the survey URL.
   - Update the element IDs for each survey question. These are typically the `id` attributes in the HTML of the survey.

---

## How to Run

1. **Open Visual Studio**:
   - Create a new Console Application project in C#.
   - Install the necessary NuGet packages as mentioned above.
   - Copy the provided code into the `Program.cs` file. You can rename the .cs file to anything you want, just make sure it matches anything that requires it.

2. **Modify the Survey Details**:
   - Update the `URL` with the survey URL.
   - Change the element IDs in the code to match the ones from the survey page.

3. **Run the Code**:
   - Press `Ctrl + F5` or click `Run` in Visual Studio to start filling out the survey automatically.
     - `Ctrl + F5` runs without debugging (used for quicker testing). Clicking `Run` will open the debugger and take longer but provide more in-depth error responses.

---

## Example Code Overview

This code simulates filling out a survey with random answers. It performs the following steps:

1. **Navigate to the Survey URL**: It opens the survey page in a Chrome browser.
2. **Randomly Select Answers**: For each question, it randomly selects one of the available options. The options are chosen based on the question's ID and a random number generator.
3. **Submit the Survey**: After selecting the answers, the code clicks the submit button to submit the survey.
4. **Repeat the Process**: The code repeats the survey filling process based on the loop count.

---

## Code Snippet Overview

```csharp
// Initialize the ChromeDriver
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("{URL}"); // Replace with your survey URL

// Wait for elements to be visible and interactable
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

// Randomly select answers for the survey questions
int randomOption1 = rnd.Next(1, 8); // Random number between 1 and 8

// The ID can be anything. QID2 is used as an example from when this code was written.
// 'QID' in documentation means "Question Identification" so "QID2" would be the second question.
// Survey questions can be randomized, but the IDs for each question typically remain the same.
// When looking for question IDs, the order in which you find them will likely be out of numerical order.
// In the case below, labelId1 doesn't match QID2 because it is hardcoded.
// There are ways to sync variable to question identifiers in numerical order, but in the case of this example, we won't learn about it.
string labelId1 = $"QID2-{randomOption1}-label";
IWebElement label1 = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(labelId1)));
label1.Click();

// Submit the survey
IWebElement submitButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("NextButton")));
submitButton.Click();
