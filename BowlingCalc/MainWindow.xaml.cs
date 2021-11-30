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

namespace idk_what_this_is
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double gameOneScore;
        double gameTwoScore;
        double gameThreeScore;
        string Gender;
        string User_Name;
        public MainWindow()
        {
            InitializeComponent();

        }

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

        private void Calculate(object sender, RoutedEventArgs e)
        {
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


                User_Name = String.Format(UserInput.Text);
                UserGender.Text = Gender;
                UserName.Text = User_Name;
                UserAverageScore.Text = AverageScore.ToString();
                Handicap.Text = HandicapScore.ToString();
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
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
        }

        private void ExitBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}