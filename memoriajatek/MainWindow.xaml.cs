using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace memoriajatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> meretek = new List<string>() {"4 x 4","6 x 6","8 x 8"};
        List<string> temak = new List<string>() {"Számok","Emoji-k","Szinek"};


        public MainWindow()
        {
            InitializeComponent();
            lbx_meretek.ItemsSource = meretek;
            lbx_temak.ItemsSource = temak;

            

        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            if(lbx_meretek.SelectedItem != null && lbx_temak.SelectedItem != null)
            {
            int meret = Convert.ToInt32(lbx_meretek.SelectedItem.ToString().First().ToString());
            string tema = lbx_temak.SelectedItem.ToString();

                for(int i = 0; i < meret; i++)
                {
                    grd_jatek.RowDefinitions.Add(new RowDefinition());
                    grd_jatek.ColumnDefinitions.Add(new ColumnDefinition());
                }


                for (int i = 0; i < meret; i++)
                {
                    for (int j = 0; j < meret; j++)
                    {
                        Button btn = new Button()
                        {
                            Content = "?",
                            FontSize = Math.Round(120.0 / meret)


                        };

                        Grid.SetRow(btn, i);
                        Grid.SetColumn(btn, j);
                        grd_jatek.Children.Add(btn);
                    }
                }



            }
            else
            {
                MessageBox.Show("Kérlek válassz ki méretet és témát!");
            }
        }
    }
}