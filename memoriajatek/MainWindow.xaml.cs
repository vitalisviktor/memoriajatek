using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace memoriajatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> meretek = new List<string>() { "4 x 4", "6 x 6", "8 x 8" };
        List<string> temak = new List<string>() { "Számok", "Emoji-k" };

        List<string> szamok = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", };
        List<string> emoijik = new List<string>() { "😀", "😂", "😍", "🥳", "😎", "🤔", "😢", "😡", "🤩", "😴", "🤗", "🙃", "👍", "👎", "👏", "🙌", "❤️", "💔", "🔥", "⭐", "🎉", "🚀", "🌈", "☀️", "🌙", "🍕", "🍔", "🍺", "🐶", "🐱", "🦄", "👻" };

        List<string> ujlista;
        string[,] ertekek;

        List<Button> kitalaltak = new List<Button>();
        Button mostbtn;
        bool elozovesztett = false;

        Button elozogomb;
        string elozoertek;
        bool elso = true;

        public MainWindow()
        {
            InitializeComponent();
            lbx_meretek.ItemsSource = meretek;
            lbx_temak.ItemsSource = temak;



        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_meretek.SelectedItem != null && lbx_temak.SelectedItem != null)
            {
                grd_jatek.RowDefinitions.Clear();
                grd_jatek.ColumnDefinitions.Clear();
                int meret = Convert.ToInt32(lbx_meretek.SelectedItem.ToString().First().ToString());
                string tema = lbx_temak.SelectedItem.ToString();

                for (int i = 0; i < meret; i++)
                {
                    grd_jatek.RowDefinitions.Add(new RowDefinition());
                    grd_jatek.ColumnDefinitions.Add(new ColumnDefinition());
                }



                switch (tema)
                {
                    case "Számok":
                        ujlista = szamok.Shuffle().ToList();
                        ujlista.RemoveRange((meret * meret / 2) - 1, ujlista.Count - (meret * meret / 2));

                        ujlista = ujlista.Concat(ujlista).ToList();
                        ujlista = ujlista.Shuffle().ToList();

                        break;
                    case "Emoji-k":
                        ujlista = emoijik.Shuffle().ToList();
                        ujlista.RemoveRange((meret * meret / 2) - 1, ujlista.Count - (meret * meret / 2));

                        ujlista = ujlista.Concat(ujlista).ToList();
                        ujlista = ujlista.Shuffle().ToList();
                        break;
                }
                int g = 0;
                ertekek = new string[meret, meret];
                for (int i = 0; i < meret; i++)
                {
                    for (int j = 0; j < meret; j++)
                    {
                        ertekek[i, j] = ujlista[g];
                        g++;

                        Button btn = new Button()
                        {
                            Content = "?",
                            FontSize = Math.Round(120.0 / meret),
                            Background = System.Windows.Media.Brushes.LightGray

                        };
                        Grid.SetRow(btn, i);
                        Grid.SetColumn(btn, j);
                        btn.Click += Button_click;
                        grd_jatek.Children.Add(btn);
                    }
                }



            }
            else
            {
                MessageBox.Show("Kérlek válassz ki méretet és témát!");
            }
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {

            if (elozovesztett)
            {
                mostbtn.Content = "?";
                elozogomb.Content = "?";
                elozogomb.Background = System.Windows.Media.Brushes.LightGray;
                mostbtn.Background = System.Windows.Media.Brushes.LightGray;
                elozovesztett = false;
            }
            mostbtn = (Button)sender;

            if (!kitalaltak.Contains(mostbtn))
            {


                int row = Grid.GetRow(mostbtn);
                int col = Grid.GetColumn(mostbtn);

                mostbtn.Content = ertekek[row, col];

                if (elso)
                {
                    elozoertek = mostbtn.Content.ToString();
                    elozogomb = mostbtn;
                    elso = false;
                }
                else
                {
                    if (mostbtn != elozogomb)
                    {

                        if (mostbtn.Content == elozoertek)
                        {

                            elozogomb.Background = System.Windows.Media.Brushes.LightGreen;
                            mostbtn.Background = System.Windows.Media.Brushes.LightGreen;
                            kitalaltak.Add(mostbtn);
                            kitalaltak.Add(elozogomb);
                            if(kitalaltak.Count == grd_jatek.RowDefinitions.Count * grd_jatek.RowDefinitions.Count)
                            {
                                MessageBox.Show("NYERTÉL!!!!!!!!","GYŐZTES",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                            }
                        }
                        else
                        {
                            elozogomb.Background = System.Windows.Media.Brushes.Red;
                            mostbtn.Background = System.Windows.Media.Brushes.Red;
                            elozovesztett = true;
                        }
                        elso = true;
                    }
                }
            }
        }
    }
}