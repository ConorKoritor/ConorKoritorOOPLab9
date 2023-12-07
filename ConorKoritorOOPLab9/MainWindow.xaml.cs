using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        ObservableCollection<Player> AllPlayers = new ObservableCollection<Player>();
        ObservableCollection<Player> SelectedPlayers = new ObservableCollection<Player>();
        string[] firstNames = {
                "Adam", "Amelia", "Ava", "Chloe", "Conor", "Daniel", "Emily",
                "Emma", "Grace", "Hannah", "Harry", "Jack", "James",
                "Lucy", "Luke", "Mia", "Michael", "Noah", "Sean", "Sophie"};

        string[] lastNames = {
                "Brennan", "Byrne", "Daly", "Doyle", "Dunne", "Fitzgerald", "Kavanagh",
                "Kelly", "Lynch", "McCarthy", "McDonagh", "Murphy", "Nolan", "O'Brien",
                "O'Connor", "O'Neill", "O'Reilly", "O'Sullivan", "Ryan", "Walsh"
            };
        int SpacesLeft = 11;

        public MainWindow()
        {
            InitializeComponent();

            CreatePlayers();

            lstbxAllPlayers.ItemsSource = AllPlayers;
            lstbxSelectedPlayers.ItemsSource = SelectedPlayers;
            txtblkSpacesLeft.Text = $"{SpacesLeft}";
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            //When the add Player button is clicked the program first checks if their are any spaces left on the team
            if (SpacesLeft != 0)
            {
                //If there are spaces left it then checks if there is a selected item in the lst box of all players
                if (lstbxAllPlayers.SelectedItem != null)
                {
                    //If there is a selected item it adds the player to the Selected players Collection which is the item source for the Selected players List box
                    //it then removes that player from the All Players Collection
                    SelectedPlayers.Add(lstbxAllPlayers.SelectedItem as Player);
                    AllPlayers.Remove(lstbxAllPlayers.SelectedItem as Player);
                    SpacesLeft--;
                    txtblkSpacesLeft.Text = $"{SpacesLeft}";
                }
            }

            
        }
        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            //When the remoive button is clicked there is no need to check if there are any spaces left on the team
            //This just checks if there is a selected player in the Selected Players List box
            if (lstbxSelectedPlayers.SelectedItem != null)
            {
                //If there is a selected player it adds that player back into the all players collection and removes that player from the selected players
                //collection
                AllPlayers.Add(lstbxSelectedPlayers.SelectedItem as Player);
                SelectedPlayers.Remove(lstbxSelectedPlayers.SelectedItem as Player);
                SpacesLeft++;
                txtblkSpacesLeft.Text = $"{SpacesLeft}";
            }
        }

        private void CreatePlayers()
        {
            //Creates 18 players using the random number generator to generate indices for the FirstName and LastName arrays
            //and to generate a random Year, Month and Day for DOB
            for(int i = 0; i < 18; i++)
            {
                Player p;
                //Checks how many players we created so that we have the right number of players for each position
                if(i < 2)
                {
                    p = new Player(firstNames[ThreadSafeRandom.ThisThreadsRandom.Next(0, firstNames.Length)], 
                        lastNames[ThreadSafeRandom.ThisThreadsRandom.Next(0, lastNames.Length)], 
                        new DateTime(ThreadSafeRandom.ThisThreadsRandom.Next(1993,2004), 
                            ThreadSafeRandom.ThisThreadsRandom.Next(1,13), 
                            ThreadSafeRandom.ThisThreadsRandom.Next(1, 28)), 
                        Position.GoalKeeper);
                }
                else if (i < 8)
                {
                    p = new Player(firstNames[ThreadSafeRandom.ThisThreadsRandom.Next(0, firstNames.Length)], 
                        lastNames[ThreadSafeRandom.ThisThreadsRandom.Next(0, lastNames.Length)], 
                        new DateTime(ThreadSafeRandom.ThisThreadsRandom.Next(1993, 2004), 
                            ThreadSafeRandom.ThisThreadsRandom.Next(1, 13), 
                            ThreadSafeRandom.ThisThreadsRandom.Next(1, 28)), 
                        Position.Defender);
                }
                else if (i < 14)
                {
                    p = new Player(firstNames[ThreadSafeRandom.ThisThreadsRandom.Next(0, firstNames.Length)],
                         lastNames[ThreadSafeRandom.ThisThreadsRandom.Next(0, lastNames.Length)],
                         new DateTime(ThreadSafeRandom.ThisThreadsRandom.Next(1993, 2004),
                             ThreadSafeRandom.ThisThreadsRandom.Next(1, 13),
                             ThreadSafeRandom.ThisThreadsRandom.Next(1, 28)),
                         Position.Midfielder);
                }
                else
                {
                    p = new Player(firstNames[ThreadSafeRandom.ThisThreadsRandom.Next(0, firstNames.Length)],
                        lastNames[ThreadSafeRandom.ThisThreadsRandom.Next(0, lastNames.Length)],
                        new DateTime(ThreadSafeRandom.ThisThreadsRandom.Next(1993, 2004),
                            ThreadSafeRandom.ThisThreadsRandom.Next(1, 13),
                            ThreadSafeRandom.ThisThreadsRandom.Next(1, 28)),
                        Position.Forward);
                }
                
                AllPlayers.Add(p);
            }
        }
        
    }
    public static class ThreadSafeRandom
    {
        /*Creates a new random object so that shuffle can randomize the order of the cards
        * This new random is created with a seed equal to the amount of ticks
        * the program has run for times 31 plus the ID of the current thread
        * This increases the randomness compared to a new random object with no seed
        */
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
}
