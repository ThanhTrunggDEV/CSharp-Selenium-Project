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

        private void BuyAndConfirm(ref FirefoxDriver firefoxDriver)  // Buy and Confirm Action
        {
            flag:
            var scrollDown = (IJavaScriptExecutor)firefoxDriver;                     
            scrollDown.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");   // Scroll down to the bottom aimed to see buy button
            var buyButton = firefoxDriver.FindElement(By.XPath("//button[contains(@class, 'btn btn-primary') and normalize-space(text())='Mua dịch vụ']"));
            Thread.Sleep(500);                                                             // wait until everything is oke then click
            buyButton.Click();
            var confirmButton = firefoxDriver.FindElement(By.XPath("//button[contains(@class, 'swal2-confirm btn btn-success') and normalize-space(text())='Mua hàng']"));
            confirmButton.Click();
            try
            {
                Thread.Sleep(2000);
                var okButton = firefoxDriver.FindElement(By.ClassName("swal2-confirm"));
                okButton.Click();
                goto flag;
            }
            catch
            {
                try
                {
                    var okButton = firefoxDriver.FindElement(By.ClassName("swal2-confirm"));
                    okButton.Click();
                }
                catch
                {
                    goto flag;
                }
                goto flag;
            }
        }
        private void Login(ref FirefoxDriver firefoxDriver)   // Login action
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
            Thread.Sleep(2000);
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

        private void TymTikTok(ref FirefoxDriver firefoxDriver, string quantity, string link, string option)
        {
            firefoxDriver.Url = "https://dichvu.baostar.pro/tiktok-like";
            firefoxDriver.Navigate();
            SelectOption(ref firefoxDriver, option);
            EnterQuantityAndUrl(ref firefoxDriver, quantity, link);
            BuyAndConfirm(ref firefoxDriver);
        }
        private void FollowTikTok(ref FirefoxDriver firefoxDriver, string quantity, string link, string option)
        {
            firefoxDriver.Url = "https://dichvu.baostar.pro/tiktok-follow";
            firefoxDriver.Navigate();
            SelectOption(ref firefoxDriver, option);
            EnterQuantityAndUrl(ref firefoxDriver, quantity, link);
            BuyAndConfirm(ref firefoxDriver);
        }
        private void ViewTikTok(ref FirefoxDriver firefoxDriver, string quantity, string link, string option)
        {
            firefoxDriver.Url = "https://dichvu.baostar.pro/tiktok-view";
            firefoxDriver.Navigate();
            SelectOption(ref firefoxDriver, option);
            EnterQuantityAndUrl(ref firefoxDriver, quantity, link);
            BuyAndConfirm(ref firefoxDriver);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = textBoxLink.Text;
                string quantity = textBoxQuantity.Text;
                if (url == string.Empty || quantity == string.Empty)
                {
                    MessageBox.Show("You Need To Enter Link And Quantity Before Start", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                FirefoxDriver firefoxDriver = new FirefoxDriver();
                Login(ref firefoxDriver);
                Thread.Sleep(5000);
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
                    if (listServices.Text == "Like TikTok việt giá rẻ 14 vnđ")
                        option = "customRadio0";
                    if (listServices.Text == "S2 Like tiktok việt high 16 vnđ")
                        option = "customRadio1";
                    if (listServices.Text == "S4 like tiktok việt 11 vnđ")
                        option = "customRadio3";
                    if (listServices.Text == "S5 Like tiktok Tây Nhanh 7.5 vnđ")
                        option = "customRadio4";
                    if (listServices.Text == "S7 Like Tiktok tây 11.5 vnđ")
                        option = "customRadio5";
                    if (listServices.Text == "S8 like TikTok tây 5 vnđ")
                        option = "customRadio6";
                    TymTikTok(ref firefoxDriver, quantity, url, option);
                }
                else if (followTiktok.IsChecked == true)
                {
                    if (listServices.Text == "S9 follow tiktok tây 9 vnđ")
                        option = "customRadio2";
                    if (listServices.Text == "S10 Follow tiktok tây 14 vnđ")
                        option = "customRadio3";
                    if (listServices.Text == "S6 Follow tiktok việt 22 vnđ")
                        option = "customRadio4";
                    FollowTikTok(ref firefoxDriver, quantity, url, option);
                }
                else if (viewTikTok.IsChecked == true)
                {
                    if (listServices.Text == "View Tăng tỉ lệ lên xu hướng [ Trending ] 2 vnđ")
                        option = "customRadio0";
                    if (listServices.Text == "View tiktok siêu tốc 0.07 vnđ")
                        option = "customRadio1";
                    if (listServices.Text == "S2 view siêu tốc sale 0.06 vnđ")
                        option = "customRadio2";
                    if (listServices.Text == "S3 view siêu tốc sale 0.08 vnđ")
                        option = "customRadio3";
                    ViewTikTok(ref firefoxDriver, quantity, url, option);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void likeFaceBook_Checked(object sender, RoutedEventArgs e)
        {
            listServices.IsEnabled = true;
            listServices.Items[0] = "Like beta vip độc quyền 6.5 vnđ";
            listServices.Items[1] = "Like clone siêu sale độc quyền 7 vnđ";
            listServices.Items[2] = "S3 like clone siêu rẻ 5 vnđ";
            listServices.Items[3] = string.Empty;
            listServices.Items[4] = string.Empty;
            listServices.Items[5] = string.Empty;
            listServices.Items[6] = string.Empty;
            listServices.Items[7] = string.Empty;
            listServices.Items[8] = string.Empty;
        }
        private void followFacebook_Checked(object sender, RoutedEventArgs e)
        {
            listServices.IsEnabled = true;
            listServices.Items[0] = "Follow clone Việt 21 vnđ";
            listServices.Items[1] = "S9 Follow Vip | Sub page 23 vnđ";
            listServices.Items[2] = "S8 Follow Clone + Vip độc quyền 22.4 vnđ";
            listServices.Items[3] = string.Empty;
            listServices.Items[4] = string.Empty;
            listServices.Items[5] = string.Empty;
            listServices.Items[6] = string.Empty;
            listServices.Items[7] = string.Empty;
            listServices.Items[8] = string.Empty;

        }

        private void listServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            startButton.IsEnabled = true;
        }

        private void tymTikTok_Checked(object sender, RoutedEventArgs e)
        {
            listServices.IsEnabled = true;
            listServices.Items[0] = "Like TikTok việt giá rẻ 14 vnđ";
            listServices.Items[1] = "S2 Like tiktok việt high 16 vnđ";
            listServices.Items[2] = "S4 like tiktok việt 11 vnđ";
            listServices.Items[3] = "S5 Like tiktok Tây Nhanh 7.5 vnđ";
            listServices.Items[4] = "S7 Like Tiktok tây 11.5 vnđ";
            listServices.Items[5] = "S8 like TikTok tây 5 vnđ";
            listServices.Items[6] = string.Empty;
            listServices.Items[7] = string.Empty;
            listServices.Items[8] = string.Empty;

        }


        private void viewTikTok_Checked(object sender, RoutedEventArgs e)
        {
            listServices.IsEnabled = true;
            listServices.Items[0] = "View Tăng tỉ lệ lên xu hướng [ Trending ] 2 vnđ";
            listServices.Items[1] = "View tiktok siêu tốc 0.07 vnđ";
            listServices.Items[2] = "S2 view siêu tốc sale 0.06 vnđ";
            listServices.Items[3] = "S3 view siêu tốc sale 0.08 vnđ";
            listServices.Items[4] = string.Empty;
            listServices.Items[5] = string.Empty;
            listServices.Items[6] = string.Empty;
            listServices.Items[7] = string.Empty;
            listServices.Items[8] = string.Empty;

        }

        private void followTiktok_Checked(object sender, RoutedEventArgs e)
        {
            listServices.IsEnabled = true;
            listServices.Items[0] = "S9 follow tiktok tây 9 vnđ";
            listServices.Items[1] = "S10 Follow tiktok tây 14 vnđ";
            listServices.Items[2] = "S6 Follow tiktok việt 22 vnđ";
            listServices.Items[3] = string.Empty;
            listServices.Items[4] = string.Empty;
            listServices.Items[5] = string.Empty;
            listServices.Items[6] = string.Empty;
            listServices.Items[7] = string.Empty;
            listServices.Items[8] = string.Empty;

        }

        private void likePageFaceBook_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This feature is testing");
            listServices.IsEnabled = true;
            listServices.Items[0] = "";
            listServices.Items[1] = "";
            listServices.Items[2] = "";
            listServices.Items[3] = string.Empty;
            listServices.Items[4] = string.Empty;
            listServices.Items[5] = string.Empty;
            listServices.Items[6] = string.Empty;
            listServices.Items[7] = string.Empty;
            listServices.Items[8] = string.Empty;
        }
    }
}
