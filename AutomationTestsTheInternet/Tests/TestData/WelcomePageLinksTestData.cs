using System.Collections.Generic;
using System.Threading.Tasks;
using AutomationTestsTheInternet.Utilities;
using Microsoft.Playwright;
using NUnit.Framework;

namespace AutomationTestsTheInternet.Tests
{
    public class WelcomePageLinksTestData
    {
        public static IEnumerable<TestCaseData> LinkTestCases()
        {
            //The Welcome Page has 44 example links. Here is the list of them as test cases.
            yield return new TestCaseData("A/B Testing", "abtest").SetName("Link_A-BTesting");
            yield return new TestCaseData("Add/Remove Elements", "add_remove_elements/").SetName("Link_AddRemoveElements");
            yield return new TestCaseData("Basic Auth", "basic_auth").SetName("Link_BasicAuth");
            yield return new TestCaseData("Broken Images", "broken_images").SetName("Link_BrokenImages");
            yield return new TestCaseData("Challenging DOM", "challenging_dom").SetName("Link_ChallengingDOM");
            yield return new TestCaseData("Checkboxes", "checkboxes").SetName("Link_Checkboxes");
            yield return new TestCaseData("Context Menu", "context_menu").SetName("Link_ContextMenu");
            yield return new TestCaseData("Digest Authentication", "digest_auth").SetName("Link_DigestAuth");
            yield return new TestCaseData("Disappearing Elements", "disappearing_elements").SetName("Link_DisappearingElements");
            yield return new TestCaseData("Drag and Drop", "drag_and_drop").SetName("Link_DragAndDrop");
            yield return new TestCaseData("Dropdown", "dropdown").SetName("Link_Dropdown");
            yield return new TestCaseData("Dynamic Content", "dynamic_content").SetName("Link_DynamicContent");
            yield return new TestCaseData("Dynamic Controls", "dynamic_controls").SetName("Link_DynamicControls");
            yield return new TestCaseData("Dynamic Loading", "dynamic_loading").SetName("Link_DynamicLoading");
            yield return new TestCaseData("Entry Ad", "entry_ad").SetName("Link_EntryAd");
            yield return new TestCaseData("Exit Intent", "exit_intent").SetName("Link_ExitIntent");
            yield return new TestCaseData("File Download", "download").SetName("Link_FileDownload");
            yield return new TestCaseData("File Upload", "upload").SetName("Link_FileUpload");
            yield return new TestCaseData("Floating Menu", "floating_menu").SetName("Link_FloatingMenu");
            yield return new TestCaseData("Forgot Password", "forgot_password").SetName("Link_ForgotPassword");
            yield return new TestCaseData("Form Authentication", "login").SetName("Link_FormAuthentication");
            yield return new TestCaseData("Frames", "frames").SetName("Link_Frames");
            yield return new TestCaseData("Geolocation", "geolocation").SetName("Link_Geolocation");
            yield return new TestCaseData("Horizontal Slider", "horizontal_slider").SetName("Link_HorizontalSlider");
            yield return new TestCaseData("Hovers", "hovers").SetName("Link_Hovers");
            yield return new TestCaseData("Infinite Scroll", "infinite_scroll").SetName("Link_InfiniteScroll");
            yield return new TestCaseData("Inputs", "inputs").SetName("Link_Inputs");
            yield return new TestCaseData("JQuery UI Menus", "jqueryui/menu").SetName("Link_JQueryUIMenus");
            yield return new TestCaseData("JavaScript Alerts", "javascript_alerts").SetName("Link_JavaScriptAlerts");
            yield return new TestCaseData("JavaScript onload event error", "javascript_error").SetName("Link_JavaScriptOnloadEventError");
            yield return new TestCaseData("Key Presses", "key_presses").SetName("Link_KeyPresses");
            yield return new TestCaseData("Large & Deep DOM", "large").SetName("Link_LargeAndDeepDOM");
            yield return new TestCaseData("Multiple Windows", "windows").SetName("Link_MultipleWindows");
            yield return new TestCaseData("Nested Frames", "nested_frames").SetName("Link_NestedFrames");
            yield return new TestCaseData("Notification Messages", "notification_message_rendered").SetName("Link_NotificationMessages");
            yield return new TestCaseData("Redirect Link", "redirector").SetName("Link_RedirectLink");
            yield return new TestCaseData("Secure File Download", "download_secure").SetName("Link_SecureFileDownload");
            yield return new TestCaseData("Shadow DOM", "shadowdom").SetName("Link_ShadowDOM");
            yield return new TestCaseData("Shifting Content", "shifting_content").SetName("Link_ShiftingContent");
            yield return new TestCaseData("Slow Resources", "slow").SetName("Link_SlowResources");
            yield return new TestCaseData("Sortable Data Tables", "tables").SetName("Link_SortableDataTables");
            yield return new TestCaseData("Status Codes", "status_codes").SetName("Link_StatusCodes");
            yield return new TestCaseData("Typos", "typos").SetName("Link_Typos");
            yield return new TestCaseData("WYSIWYG Editor", "tinymce").SetName("Link_WYSIWYGEditor");
        }
    }
}