using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTestsTheInternet.Utilities
{
    public class BaseTest
    {
        protected IPlaywright _playwright;
        protected IBrowser _browser;
        protected IBrowserContext _context;
        protected IPage _page;
        protected string _baseURL = "https://the-internet.herokuapp.com/";

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                Channel = "firefox",
                SlowMo = 50
            });
            _context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                BaseURL = "https://the-internet.herokuapp.com/"
            });

            await _context.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            _page = await _context.NewPageAsync();

        }

        [TearDown]
        public async Task TearDown()
        {
            await _page.CloseAsync();

            if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                await _page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = $"screenshot-{MakeSafeFileName(TestContext.CurrentContext.Test.Name)}-{DateTime.Now:yyyyMMddHHmmss}.png"
                });
            }

            await _context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = $"trace-{MakeSafeFileName(TestContext.CurrentContext.Test.Name)}-{DateTime.Now:yyyyMMddHHmmss}.zip"
            });

            await _context.CloseAsync();
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        // sanitize test name and ensure directory exists before writing trace/screenshot
        private static string MakeSafeFileName(string name)
        {
            var invalid = System.IO.Path.GetInvalidFileNameChars();
            var safe = new System.Text.StringBuilder(name.Length);
            foreach (var c in name)
            {
                safe.Append(Array.IndexOf(invalid, c) >= 0 ? '_' : c);
            }
            return safe.ToString();
        }
    }
}
