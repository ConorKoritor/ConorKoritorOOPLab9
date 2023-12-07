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

namespace ConorKoritorOOPLab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    //Enum for Positions a player can play
    public enum Position
    {
        GoalKeeper,
        Defender,
        Midfielder,
        Forward 
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Player player = new Player("Conor", "Koritor", new DateTime(1998, 12, 26), Position.GoalKeeper);

            txtblkSpacesLeft.Text = player.ToString();
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
