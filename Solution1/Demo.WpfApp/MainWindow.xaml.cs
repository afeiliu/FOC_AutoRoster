using Demo.WpfApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
using Newtonsoft.Json;
using Demo.WpfApp.Common;

namespace Demo.WpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnInitData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new HttpClientUtility().GetHttpClient(this.txtToken.Text.Trim());

                HttpResponseMessage response = await client.GetAsync("api/values");
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                BaseViewModel model = JsonConvert.DeserializeObject<BaseViewModel>(content);

                this.dgUser.ItemsSource = model.data;
                this.lblTotal.Content = "总条数：" + model.total;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnToken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new HttpClientUtility();
                ResponseToken token = await client.GetToken("admin", "123456");

                this.txtToken.Text = token.AccessToken;
                this.lblRefreshToken.Content = token.RefreshToken;
            }
            catch (Exception ex)
            {
                this.txtToken.Text = ex.Message;
                this.lblRefreshToken.Content = string.Empty;
            }
        }

        private async void btnRefreshToken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new HttpClientUtility();
                ResponseToken token = await client.GetRefreshToken(this.lblRefreshToken.Content.ToString());

                this.txtToken.Text = token.AccessToken;
                this.lblRefreshToken.Content = token.RefreshToken;
            }
            catch (Exception ex)
            {
                this.txtToken.Text = ex.Message;
                this.lblRefreshToken.Content = string.Empty;
            }
        }
    }
}
