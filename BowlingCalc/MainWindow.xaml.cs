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
using System.IO;

namespace idk_what_this_is
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global Vars
        double gameOneScore;
        double gameTwoScore;
        double gameThreeScore;
        string Gender;
        string User_Name;
        double AverageScore;
        double handicapScore;
        string topScoreGame;
        public MainWindow()
        {
            InitializeComponent();

        }
        // I wish I knew a better way to do this but whatever
        #region Radio Buttons
        private void Male_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Male";
        }

        private void Female_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Female";
        }

        private void Other_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Other";
        }
        #endregion

        private void Calculate(object sender, RoutedEventArgs e)
        {
            //Code so if theres no input, it doesnt crash + Message Box for the error
            if (GameOne.Text == "" || GameTwo.Text == "" || GameThree.Text == "")
            {
                MessageBox.Show("You must input each game score...");
            }
            else
            {
                gameOneScore = Double.Parse(GameOne.Text);
                gameTwoScore = Double.Parse(GameTwo.Text);
                gameThreeScore = Double.Parse(GameThree.Text);
                AverageScore = (gameOneScore + gameTwoScore + gameThreeScore) / 3;
                handicapScore = (200 - AverageScore) * .8;

                FindHigh();
                User_Name = String.Format(UserInput.Text);
                UserGender.Text = Gender;
                UserName.Text = User_Name;
                UserAverageScore.Text = AverageScore.ToString();
                Handicap.Text = handicapScore.ToString(); 
                textFile();
            }
        }
        #region ClearBtn
        private void Clear(object sender, RoutedEventArgs e)
        {
            //Resest all information
            gameOneScore = 0;
            gameTwoScore = 0;
            gameThreeScore = 0;
            Gender = "";
            User_Name = String.Format("");
            UserAverageScore.Text = "";
            UserGender.Text = Gender;
            UserName.Text = User_Name;
            UserInput.Text = "";
            GameOne.Text = "";
            GameTwo.Text = "";
            GameThree.Text = "";
            Handicap.Text = "";
            TopGame.Text = "";
        }
        #endregion

        private void ExitBtn(object sender, RoutedEventArgs e)
        {
            //Just Closes Program
            Close();
        }
        
        public void FindHigh()
        {
            if (gameOneScore > gameTwoScore && gameOneScore > gameThreeScore) { topScoreGame = "Game One!"; TopGame.Text = topScoreGame;} else if (gameTwoScore > gameOneScore && gameTwoScore > gameThreeScore) { topScoreGame = "Game Two!"; TopGame.Text = topScoreGame; } else if (gameThreeScore > gameOneScore && gameThreeScore > gameTwoScore) { topScoreGame = "Game Three!"; TopGame.Text = topScoreGame; } else { TopGame.Text = "It's a tie!"; }
        }


        public void textFile()
        {
            string playerInfo = $"Your name is {User_Name}. Your average score was {AverageScore.ToString()}. Your gender is {Gender}. The handicap you got is {handicapScore}. Your top scoring game was {topScoreGame}";
            File.WriteAllText("Scores.txt", playerInfo);
        }
    }
}