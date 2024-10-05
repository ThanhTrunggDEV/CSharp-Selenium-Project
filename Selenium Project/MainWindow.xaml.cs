using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace Selenium_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BuyAndConfirm(ref FirefoxDriver firefoxDriver)
        {
            var scrollDown = (IJavaScriptExecutor)firefoxDriver;
            scrollDown.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            var buyButton = firefoxDriver.FindElement(By.XPath("//button[contains(@class, 'btn btn-primary') and normalize-space(text())='Mua dịch vụ']"));
            Thread.Sleep(2000);
            buyButton.Click();
            var confirmButton = firefoxDriver.FindElement(By.XPath("//button[contains(@class, 'swal2-confirm btn btn-success') and normalize-space(text())='Mua hàng']"));
            confirmButton.Click();
        }
        private void Login(ref FirefoxDriver firefoxDriver)
        {
            firefoxDriver.Url = "https://dichvu.baostar.pro/dang-nhap";
            firefoxDriver.Navigate();
            var enterUserName = firefoxDriver.FindElement(By.Id("useremail"));
            enterUserName.SendKeys("Trung1506");
            var enterPassWord = firefoxDriver.FindElement(By.Id("password_"));
            enterPassWord.SendKeys("Trung1506");
            var loginButton2 = firefoxDriver.FindElement(By.CssSelector(".btn.btn-primary.w-100"));
            loginButton2.Click();
        }
        private void SelectOption(ref FirefoxDriver firefoxDriver, string option)
        {
            var selectButton = firefoxDriver.FindElement(By.Id(option));
            selectButton.Click();
        }
        private void EnterQuantityAndUrl(ref FirefoxDriver firefoxDriver, string quantity, string link)
        {
            var linkStatus = firefoxDriver.FindElement(By.Id("object_id"));
            linkStatus.SendKeys(link);
            var quantityLike = firefoxDriver.FindElement(By.Name("quantity"));
            quantityLike.Clear();
            quantityLike.SendKeys(quantity.ToString());
        }
        private void LikeFaceBook(ref FirefoxDriver firefoxDriver, string quantity, string link, string option)
        {
            firefoxDriver.Url = "https://dichvu.baostar.pro/facebook-like-gia-re";
            firefoxDriver.Navigate();
            SelectOption(ref firefoxDriver, option);
            EnterQuantityAndUrl(ref firefoxDriver, quantity, link);
            try
            {
                var likeButton = firefoxDriver.FindElement(By.XPath("//img[@data-type='like']"));
                likeButton.Click();
                var tymButton = firefoxDriver.FindElement(By.XPath("//img[@data-type='love']"));
                tymButton.Click();
            }
           catch { }
            BuyAndConfirm(ref firefoxDriver);
        }
        private void FollowFaceBook(ref FirefoxDriver firefoxDriver, string quantity, string link, string option)
        {
            firefoxDriver.Url = "https://dichvu.baostar.pro/facebook-follow";
            firefoxDriver.Navigate();
            SelectOption(ref firefoxDriver, option);
            EnterQuantityAndUrl(ref firefoxDriver, quantity, link);
            BuyAndConfirm(ref firefoxDriver);
        }

        private void TymTikTok(ref FirefoxDriver firefoxDriver, string quatity, string link, string option)
        {
            firefoxDriver.Url = "https://dichvu.baostar.pro/tiktok-like";
            firefoxDriver.Navigate();
            SelectOption(ref firefoxDriver, option);
            EnterQuantityAndUrl(ref firefoxDriver, quatity, link);
            BuyAndConfirm(ref firefoxDriver);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FirefoxDriver firefoxDriver = new FirefoxDriver();
            Login(ref firefoxDriver);
            string url = textBoxLink.Text;
            string quantity = textBoxQuantity.Text;
            string option = string.Empty;
            if (likeFaceBook.IsChecked == true)
            {
                if (listServices.Text == "Like beta vip độc quyền 6.5 vnđ")
                    option = "customRadio0";
                if (listServices.Text == "Like clone siêu sale độc quyền 7 vnđ")
                    option = "customRadio2";
                if (listServices.Text == "S3 like clone siêu rẻ 5 vnđ")
                    option = "customRadio6";
                LikeFaceBook(ref firefoxDriver, quantity, url, option);
            }
            else if (followFacebook.IsChecked == true)
            {
                if (listServices.Text == "Follow clone Việt 21 vnđ")
                    option = "customRadio0";
                if (listServices.Text == "S9 Follow Vip | Sub page 23 vnđ")
                    option = "customRadio1";
                if (listServices.Text == "S8 Follow Clone + Vip độc quyền 22.4 vnđ")
                    option = "customRadio2";
                FollowFaceBook(ref firefoxDriver, quantity, url, option);
            }
            else if (tymTikTok.IsChecked == true)
            {

            }
            else if (followTiktok.IsChecked == true)
            {

            }
        }

        private void likeFaceBook_Checked(object sender, RoutedEventArgs e)
        {
            listServices.IsEnabled = true;
            listServices.Items[0] = "Like beta vip độc quyền 6.5 vnđ";
            listServices.Items[1] = "Like clone siêu sale độc quyền 7 vnđ";
            listServices.Items[2] = "S3 like clone siêu rẻ 5 vnđ";
        }
        private void followFacebook_Checked(object sender, RoutedEventArgs e)
        {
            listServices.IsEnabled = true;
            listServices.Items[0] = "Follow clone Việt 21 vnđ";
            listServices.Items[1] = "S9 Follow Vip | Sub page 23 vnđ";
            listServices.Items[2] = "S8 Follow Clone + Vip độc quyền 22.4 vnđ";
        }
    }
}
