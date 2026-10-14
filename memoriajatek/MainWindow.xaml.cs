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
        List<string> temak = new List<string>() { "Számok", "Emoji-k", "Ország-Főváros" };

        List<string> szamok = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", };
        List<string> emojik = new List<string>() { "😀", "😂", "😍", "🥳", "😎", "🤔", "😢", "😡", "🤩", "😴", "🤗", "🙃", "👍", "👎", "👏", "🙌", "❤️", "💔", "🔥", "⭐", "🎉", "🚀", "🌈", "☀️", "🌙", "🍕", "🍔", "🍺", "🐶", "🐱", "🦄", "👻" };

        Dictionary<string, string> orszagok = new Dictionary<string, string>
{
    { "Magyarország", "Budapest" },
    { "Ausztria", "Bécs" },
    { "Németország", "Berlin" },
    { "Franciaország", "Párizs" },
    { "Olaszország", "Róma" },
    { "Spanyolország", "Madrid" },
    { "Portugália", "Lisszabon" },
    { "Belgium", "Brüsszel" },
    { "Hollandia", "Amszterdam" },
    { "Svájc", "Bern" },
    { "Csehország", "Prága" },
    { "Szlovákia", "Pozsony" },
    { "Lengyelország", "Varsó" },
    { "Románia", "Bukarest" },
    { "Bulgária", "Szófia" },
    { "Görögország", "Athén" },
    { "Horvátország", "Zágráb" },
    { "Szerbia", "Belgrád" },
    { "Szlovénia", "Ljubljana" },
    { "Oroszország", "Moszkva" },
    { "Montenegró", "Podgorica" },
    { "Albánia", "Tirana" },
    { "Észak-Macedónia", "Szkopje" },
    { "Norvégia", "Oslo" },
    { "Svédország", "Stockholm" },
    { "Finnország", "Helsinki" },
    { "Dánia", "Koppenhága" },
    { "Írország", "Dublin" },
    { "Egyesült Királyság", "London" },
    { "Izland", "Reykjavík" },
    { "Észtország", "Tallinn" },
    { "Lettország", "Riga" }
};
        Dictionary<string, string> forditottorszagok = new Dictionary<string, string>
{
    { "Budapest", "Magyarország" },
    { "Bécs", "Ausztria" },
    { "Berlin", "Németország" },
    { "Párizs", "Franciaország" },
    { "Róma", "Olaszország" },
    { "Madrid", "Spanyolország" },
    { "Lisszabon", "Portugália" },
    { "Brüsszel", "Belgium" },
    { "Amszterdam", "Hollandia" },
    { "Bern", "Svájc" },
    { "Prága", "Csehország" },
    { "Pozsony", "Szlovákia" },
    { "Varsó", "Lengyelország" },
    { "Bukarest", "Románia" },
    { "Szófia", "Bulgária" },
    { "Athén", "Görögország" },
    { "Zágráb", "Horvátország" },
    { "Belgrád", "Szerbia" },
    { "Ljubljana", "Szlovénia" },
    { "Moszkva", "Oroszország" },
    { "Podgorica", "Montenegró" },
    { "Tirana", "Albánia" },
    { "Szkopje", "Észak-Macedónia" },
    { "Oslo", "Norvégia" },
    { "Stockholm", "Svédország" },
    { "Helsinki", "Finnország" },
    { "Koppenhága", "Dánia" },
    { "Dublin", "Írország" },
    { "London", "Egyesült Királyság" },
    { "Reykjavík", "Izland" },
    { "Tallinn", "Észtország" },
    { "Riga", "Lettország" }
};



        int moves = 0;

        List<string> ujlista;
        string[,] ertekek;

        List<Button> kitalaltak = new List<Button>();
        Button mostbtn;
        bool elozovesztett = false;

        Button elozogomb;
        string elozoertek;
        bool elso = true;

        bool helyes = false;

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

                moves = 0;
                kitalaltak.Clear();
                grd_jatek.RowDefinitions.Clear();
                grd_jatek.ColumnDefinitions.Clear();
                int meret = 4 + lbx_meretek.SelectedIndex * 2;
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
                        ujlista = emojik.Shuffle().ToList();
                        ujlista.RemoveRange((meret * meret / 2) - 1, ujlista.Count - (meret * meret / 2));

                        ujlista = ujlista.Concat(ujlista).ToList();
                        ujlista = ujlista.Shuffle().ToList();
                        break;
                    case "Ország-Főváros":
                        Dictionary<String, String> dict = new Dictionary<String, String>();
                        Dictionary<String, String> shuffledorszagok = orszagok.Shuffle().ToDictionary();

                        for (int i = 0; i < (meret * meret / 2); i++)
                        {
                            dict.Add(shuffledorszagok.Keys.ElementAt(i), shuffledorszagok.Values.ElementAt(i));
                        }

                        ujlista = dict.Keys.ToList();
                        ujlista = ujlista.Concat(dict.Values).ToList();
                        ujlista = ujlista.Shuffle().ToList();
                        break;
                }
                int g = 0;
                ertekek = new string[meret, meret];
                int fontmeret = ((24 / meret) * 5 / 2);
                if (tema != "Ország-Főváros")
                {
                    fontmeret *= 2;
                }
                else
                {
                    fontmeret--;
                }
                for (int i = 0; i < meret; i++)
                {
                    for (int j = 0; j < meret; j++)
                    {
                        ertekek[i, j] = ujlista[g];
                        g++;

                        Button btn = new Button()
                        {
                            Content = "?",
                            FontSize = fontmeret,
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
                MessageBox.Show("Kérlek válassz ki méretet és témát!","Hiba",MessageBoxButton.OK,MessageBoxImage.Warning);
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

                        moves++;
                        if (mostbtn.Content == elozoertek)
                        {
                            helyes = true;
                        }
                        else if (orszagok.Keys.Contains(mostbtn.Content.ToString()))
                        {
                            if (orszagok[mostbtn.Content.ToString()] == elozoertek)
                            {
                                helyes = true;
                            }
                        }
                        else if (forditottorszagok.Keys.Contains(mostbtn.Content.ToString()))
                        {
                            if (forditottorszagok[mostbtn.Content.ToString()] == elozoertek)
                            {
                                helyes = true;
                            }
                        }

                        if (helyes)
                        {


                            elozogomb.Background = System.Windows.Media.Brushes.LightGreen;
                            mostbtn.Background = System.Windows.Media.Brushes.LightGreen;
                            kitalaltak.Add(mostbtn);
                            kitalaltak.Add(elozogomb);
                            if (kitalaltak.Count == grd_jatek.RowDefinitions.Count * grd_jatek.RowDefinitions.Count)
                            {
                                MessageBox.Show($"NYERTÉL! Próbálkozás száma: {moves}", "GYŐZTES", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            helyes = false;
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