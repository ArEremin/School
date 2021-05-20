using System;
using System.Collections.Generic;
using System.Linq;
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


namespace School.Pages
{
    /// <summary>
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : Page
    {
        List<Service> ServiswList = Classes.Base.TE.Service.ToList();
        public Services()
        {
            InitializeComponent();
            DGServises.ItemsSource = ServiswList;
        }
        int i = -1;
        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                i++;
                MediaElement ME = (MediaElement)sender;
                Service S = ServiswList[i];
                Uri U = new Uri(S.MainImagePath, UriKind.RelativeOrAbsolute);
                ME.Source = U;
                // i++;
            }
        }

        private void Title_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];
                TB.Text = S.Title;
                //  i++;
            }

        }

        private void Cost_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];
                string St = S.Cost.ToString();
                string cost = St.Substring(0, St.IndexOf(','));
                if (S.Discount > 0)
                {
                    TB.Text = cost.ToString() + " ₽";
                }
            }

        }
        private void CostU_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];
                string St = S.Cost.ToString();
                string cost = St.Substring(0, St.IndexOf(','));
                if (S.Discount == 0)
                {
                    TB.Text = cost.ToString() + " ₽";
                }
            }

        }

        private void Price_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];
                string St = S.Cost.ToString();
                string cost = St.Substring(0, St.IndexOf(','));
                if (S.Discount > 0)
                {

                    float a = Convert.ToInt32(S.Cost);
                    var c = S.Discount * 100;
                    float b = Convert.ToInt32(c);
                    TB.Text = (a - (a * b / 100)).ToString() + " ₽";
                }
                
            }

        }

        private void Duration_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];
                int hour = S.DurationInSeconds;
                hour = hour / 3600;
                float min = (S.DurationInSeconds / 60);
                min = (min / 60 - hour) * 60;
                if (hour > 0 && min < 60 && min > 0)
                {
                    TB.Text = hour.ToString() + " час." + " " + min.ToString() + " мин.";
                }
                else if (hour > 0 && min < 1)
                {
                    TB.Text = hour.ToString() + " час.";
                }
                else if (hour < 1)
                {
                    TB.Text = min.ToString() + " мин.";
                }

            }

        }

        private void Discount_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];
                S.Discount = S.Discount * 100;
                if (S.Discount > 0)
                {
                    TB.Text = "Скидка: " + S.Discount.ToString() + " %";
                }
                
            }

        }

        private void BRed_Initialized(object sender, EventArgs e)
        {
            Button BtnRed = (Button)sender;
            if (BtnRed != null)
            {
                BtnRed.Uid = Convert.ToString(i);
            }
        }

        private void BRed_Click(object sender, RoutedEventArgs e)
        {
            Button BtnRed = (Button)sender;
            int ind = Convert.ToInt32(BtnRed.Uid);
            Service S = ServiswList[ind];
            MessageBox.Show(S.Title);

        }

        private void StackPanel_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                StackPanel SP = (StackPanel)sender;
                Service S = ServiswList[i];
                if (S.Discount != 0)
                {
                    SP.Background = new SolidColorBrush(Color.FromRgb(231, 250, 191));
                }
            }
        }

    }
}
