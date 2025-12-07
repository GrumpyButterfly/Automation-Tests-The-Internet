using Microsoft.Playwright;
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

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
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

            await _context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = $"trace-{TestContext.CurrentContext.Test.Name}-{DateTime.Now:yyyyMMddHHmmss}.zip"
            });

            await _context.CloseAsync();
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
