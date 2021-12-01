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
                double AverageScore = (gameOneScore + gameTwoScore + gameThreeScore) / 3;
                double HandicapScore = (200 - AverageScore) * .8;

                FindHigh();
                User_Name = String.Format(UserInput.Text);
                UserGender.Text = Gender;
                UserName.Text = User_Name;
                UserAverageScore.Text = AverageScore.ToString();
                Handicap.Text = HandicapScore.ToString(); 
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
            gameOneScore = Double.Parse(GameOne.Text);
            gameTwoScore = Double.Parse(GameTwo.Text);
            gameThreeScore = Double.Parse(GameThree.Text);

            if (gameOneScore > gameTwoScore && gameOneScore > gameThreeScore) {TopGame.Text = "Game One!";} else if (gameTwoScore > gameOneScore && gameTwoScore > gameThreeScore) { TopGame.Text = "Game Two!"; } else if (gameThreeScore > gameOneScore && gameThreeScore > gameTwoScore) { TopGame.Text = "Game Three!"; } else { TopGame.Text = "It's a tie!"; }
        }


        public void textFile()
        {
            // Fix average score, handicap and add a top score (find new way to do a FindHigh).
            string playerInfo = $"Your name is {User_Name}. Your average score was {AverageScore.ToString()}. Your gender is {Gender}. The handicap you got is {Handicap}.";
            File.WriteAllText("Scores.txt", playerInfo);
        }
    }
}