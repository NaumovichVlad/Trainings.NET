using ChessEngineLibrary.Players;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ChessGUI
{
    /// <summary>
    /// Логика взаимодействия для LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        List<IPlayer> players;
        public LoginWin(List<IPlayer> players)
        {
            this.players = players;
            InitializeComponent();
            InitializeCombobox();
        }

        private void InitializeCombobox()
        {

            var items = new List<string>() { FirstPlayerName.Text, SecondPlayerName.Text };
            if (NamesCombobox != null)
            {
                NamesCombobox.ItemsSource = items;
                NamesCombobox.SelectedIndex = 0;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ChessEngineLibrary.Color firstPlayerColor;
            ChessEngineLibrary.Color secondPlayerColor;
            if (NamesCombobox.SelectedIndex == 0)
            {
                firstPlayerColor = ChessEngineLibrary.Color.White;
                secondPlayerColor = ChessEngineLibrary.Color.Black;
            }
            else
            {
                firstPlayerColor = ChessEngineLibrary.Color.Black;
                secondPlayerColor = ChessEngineLibrary.Color.White;
            }
            players = new List<IPlayer>();
            players.Add(new Player(FirstPlayerName.Text, firstPlayerColor));
            players.Add(new Player(SecondPlayerName.Text, secondPlayerColor));
            Close();
        }

        private void FirstTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            if (SecondPlayerName != null)
                InitializeCombobox();
        }

        private void SecondTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            InitializeCombobox();
        }

        public List<IPlayer> Dialog()
        {
            ShowDialog();
            return players;
        }
    }
}
