# **Automation-Tests-The-Internet - Playwright UI Automation Framework (C# / .NET / GitHub Actions)**  
![CI](https://github.com/GrumpyButterfly/Automation-Tests-The-Internet/actions/workflows/playwright-ci.yml/badge.svg)

A complete UI automation framework built using **Playwright**, **C#**, **.NET**, and **GitHub Actions**, designed to demonstrate industry-standard testing practices.  
The test suite targets the public “**The Internet**” application, covering real-world scenarios such as dynamic elements, authentication, and asynchronous UI behavior.

This project uses the **Page Object Model**, includes a fully working CI pipeline, and serves as a portfolio-quality demonstration of automation engineering skills.

---

## **📁 Project Structure**

The framework is organized using the **Page Object Model (POM)** pattern, supported by the NUnit library.  
Pages contain locators + actions, tests contain assertions, and helpers centralize shared logic.

```plaintext
/src
  /Pages
    BasePage.cs                 # Shared functionality for all pages
    WelcomePage.cs              # Page object for the main landing page
    AbTestingPage.cs            # Handles A/B Testing variant behavior
    AddRemoveElementsPage.cs    # Add/Remove Elements functionality
    BasicAuthPage.cs            # Modal auth + credential handling
    DynamicControlsPage.cs      # Async UI interactions (enable/disable, add/remove)
    ...Page.cs                  # Additional page models

  /Tests
    BaseTest.cs                 # Browser setup, teardown, shared test config
    WelcomePageTests.cs         # Navigation + link visibility validation
    AbTestingTests.cs           # Variant text assertions
    AddRemoveElementsTests.cs   # Add/remove elements tests
    BasicAuthTests.cs           # Positive/negative auth tests
    DynamicControlsTests.cs     # Async wait & state-change tests
    ...Tests.cs                 # Additional test files

  /Helpers
    TestConfig.cs               # Centralized runtime settings
    WaitHelpers.cs              # Reusable async wait functionality
    TestData.cs                 # Static test data and constants

/.github
  /workflows
    ci.yml                      # GitHub Actions CI pipeline

README.md                       # Project documentation
```

---

## **🧪 Current Test Coverage**

### **Welcome Page**
- Validates all homepage links  
- Navigation tests

### **A/B Testing**
- Handles variant page headers  
- Verifies expected text content

### **Add / Remove Elements**
- Adds new elements  
- Removes elements  
- Asserts element counts

### **Basic Auth**
- Positive credential tests  
- Negative credential tests  
- Handles modal prompt behavior

### **Dynamic Controls**
- Remove/add element interactions  
- Enable/disable input field  
- Waits for asynchronous changes

(More pages coming soon.)

---

## **🧰 Technology Stack**

- **C# (.NET 10)**
- **Microsoft Playwright**
- **NUnit**
- **Page Object Model (POM)**
- **GitHub Actions CI**
- **Cross-browser testing:** Chromium, Firefox, WebKit

---

## **🚀 Running Tests Locally**

```bash
### **Install dependencies**
dotnet restore

### **Install playwright browsers**
pwsh ./bin/Debug/net10.0/playwright.ps1 install

### **Run all tests**
dotnet test

### **Run with TRX output**
dotnet test --logger "trx;LogFileName=test-results.trx" --results-directory "TestResults"
```

## **🤖 Continuous Integration (GitHub Actions)**

Every push and pull request triggers the `ci.yml` workflow, which automatically:

1. Checks out the repository  
2. Installs .NET  
3. Installs Playwright and required browsers  
4. Builds the solution  
5. Runs all tests using NUnit  
6. Publishes TRX test results as pipeline artifacts  

The CI badge in this repository reflects the real-time status of the workflow.  
This setup mirrors how automation suites run in professional SDET environments, ensuring reliability and consistency across contributions and environments.

---

## **📈 Roadmap**

**Planned improvements include:**

### 🔧 Framework Enhancements
- Add remaining “The Internet” pages (Dropdown, Drag & Drop, Frames, File Upload, Alerts, etc.)
- Introduce reusable component objects for repeated UI patterns  
- Add a configuration layer for environment selection (base URLs, browsers, headless mode)

### 🚀 Execution & CI Improvements
- Parallel test execution  
- Matrix builds (Chromium, Firefox, WebKit)  
- Automatic screenshots & video capture on failure  
- Generate and publish HTML reports (Allure or ExtentReports)

### 🧪 Test Quality Improvements
- Add negative test cases where appropriate  
- Add accessibility checks  
- Add network interception / request mocking examples  

### 📊 Developer Experience
- Add pre-commit hooks for formatting & linting  
- Expand README documentation  
- Add badges for coverage, test count, or code quality  

---

## **📜 Purpose**

This project exists to demonstrate:

- The ability to design and maintain a scalable automation framework  
- Competency with **C#**, **Playwright**, **NUnit**, and **GitHub Actions**  
- Familiarity with modern testing architecture such as the **Page Object Model**  
- A clear understanding of asynchronous UI behavior and dynamic DOM handling  
- Real-world SDET skills, including CI integration, locator strategy, reusable code structure, and robust assertions  

It serves as a portfolio-quality example for roles such as:
- **SDET**
- **QA Automation Engineer**
- **Automation Developer**
- **Technical QA Lead**

The goal is to showcase both technical depth and practical industry knowledge through a clean, organized, fully automated UI test suite.
