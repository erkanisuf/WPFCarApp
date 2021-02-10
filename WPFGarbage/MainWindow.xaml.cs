using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WPFGarbage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        CarModel bmw = new CarModel();
        CarModel audi = new CarModel();
        string EngineType;      //globaali -muuttuja (ei suositeltava)
        string GearType;
        string RadioType;
        
        public MainWindow()
        {
            InitializeComponent();
            txtMaxSpeed.Text = "0";
            txtHorsePower.Text = "0";
            if(checkfrontLight.IsChecked == true)
            {
                FrontLightbtn.Background = Brushes.Yellow;
            }
            else
            {
                FrontLightbtn.Background = Brushes.Red;
            }

        }
        private void ShowCarInfo(CarModel auto) //Tämä rutiini listaa parametrinä saadun olion arvot
        {
            string message = "Model:" + auto.Model + "\n" +
                "Color: " + auto.Color + "\n" +
                  //"Maxspeed: " + auto.MaxSpeed + "\n" +
                  "Maxspeed: " + auto.GetMaxSpeed() + "\n" +
                "GearType: " + auto.GearType + "\n" +
                "EngineType: " + auto.EngineType + "\n" +
                "Engine running: " + auto.Running + "\n" +
                "Radio: " + auto.RadioType + "\n" +
                "--------------------------"+ "\n" +
            "Horse Power: " + auto.HorsePower + "\n";

            MessageBox.Show(message);
        }

        //First Column
        private void TallenaAuto(object sender, RoutedEventArgs e)
        {

            try
            {
               
                bmw.Color = txtColor.Text;
                bmw.Model = txtModel.Text;
                int speed = int.Parse(txtMaxSpeed.Text);
                int horsepower = int.Parse(txtHorsePower.Text);
                bmw.SetMaxSpeed(speed);
                bmw.setHorsePower(horsepower);
                /* bmw.SetMaxSpeed(int.Parse(txtMaxSpeed.Text));
                 bmw.setHorsePower(int.Parse(txtHorsePower.Text));*/
                bmw.GearType = GearType;
                bmw.EngineType = EngineType;
                bmw.RadioType = RadioType;
            }
            catch (ArgumentOutOfRangeException )
            {
                MessageBox.Show("Not more than 400 and less than 0 !" );
            }
            ClearTextBoxes();
            SetRadioButtonsOff();

        }

        private void AutoOneInfo(object sender, RoutedEventArgs e)
        {
            ShowCarInfo(bmw);


        }

        private void StartAutoOne(object sender, RoutedEventArgs e)
        {
            bmw.StartEngine();
            if (bmw.Running)
            {
                btnIndicator.Background = Brushes.Green;
                
            }
        }

        private void StopAutoOne(object sender, RoutedEventArgs e)
        {

            bmw.StopEngine();
            if (!bmw.Running)
            {
                btnIndicator.Background = Brushes.Red;

            }
        }
        private void SpeedUPone(object sender, RoutedEventArgs e)
        {
            if (!bmw.Running)
            {
                MessageBox.Show("Please turn on car first !!!");
            }
            else if (bmw.GetMaxSpeed() == 0)
            {
                MessageBox.Show("Please Set Max speed !!!!");
            }
            else {
                bmw.Accelerate();
                CarsSpeed.Text = bmw.AverageSpeed.ToString() + "km/h";
            }
           
        }
        private void BreakUPOne(object sender, RoutedEventArgs e)
        {
            bmw.Brake();
            CarsSpeed.Text = bmw.AverageSpeed.ToString() + "km/h" ;
        }

        //Second COlumn
        private void TallenaAutoTwo(object sender, RoutedEventArgs e)
        {
            try
            {
                audi.Color = txtColor.Text;
                audi.Model = txtModel.Text;
                int speed = int.Parse(txtMaxSpeed.Text);
                int horsepower = int.Parse(txtHorsePower.Text);
                audi.SetMaxSpeed(speed);
                audi.setHorsePower(horsepower);
              
                audi.GearType = GearType;
                audi.EngineType = EngineType;
                audi.RadioType = RadioType;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Not more than 400 and less than 0 !");
            }
            ClearTextBoxes();
            SetRadioButtonsOff();
        }

        private void AutoTwoInfo(object sender, RoutedEventArgs e)
        {
            ShowCarInfo(audi);
        }


        private void StartAutoTwo(object sender, RoutedEventArgs e)
        {
            audi.StartEngine();
            if (audi.Running) {
                btnIndicator2.Background = Brushes.Green;
            }
        }

        

        private void StopAutoTwo(object sender, RoutedEventArgs e)
        {
            audi.StopEngine();
            if (!audi.Running)
            {
                btnIndicator2.Background = Brushes.Red;
                
            }
        }

        private void btnChecked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;

            GearType = button.Content.ToString();

        }

        private void engineType(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;

            EngineType = button.Content.ToString();
        }
        private void radioTurn(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;

            RadioType = button.Content.ToString();
        }
        private void ClearTextBoxes()
        {
            txtColor.Text = "";
            txtModel.Text = "";
            txtMaxSpeed.Text = "";
            txtHorsePower.Text = "";
        }

        private void SetRadioButtonsOff()
        {
           
            manualRadio.IsChecked = false;
            automaticRadio.IsChecked = false;
            gasolineAuto.IsChecked = false;
            dieselAuto.IsChecked = false;
            electricAuto.IsChecked = false;
            radioAutoOff.IsChecked = false;
            radioAutoOn.IsChecked = false;
            roboticRadio.IsChecked = false;
        }

        private void SpeedUpTwo(object sender, RoutedEventArgs e)
        {
            if (!audi.Running)
            {
                MessageBox.Show("Please turn on car first !!!");
            } else if (audi.GetMaxSpeed() == 0) {
                MessageBox.Show("Please Set Max speed !!!!");
            }
            else {
                audi.Accelerate();
                CarsSpeedTwo.Text = audi.AverageSpeed.ToString() + "km/h";
            }
         

        }

        private void BreakUpTwo(object sender, RoutedEventArgs e)
        {
            audi.Brake();
            CarsSpeedTwo.Text = audi.AverageSpeed.ToString() + "km/h";
        }

        private void previewMaxSpeed(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.-]+").IsMatch(e.Text);
        }

        

        private void openFrontLIght(object sender, RoutedEventArgs e)
        {
            var button = sender as CheckBox;
          
            if (button.IsChecked == true)
            {
                
                audi.turnFrontLight(true);
                if (audi.FrontLight) {
                    FrontLightbtn.Background = Brushes.Yellow;
                }
            }
            else {
                audi.turnFrontLight(false);
                if (!audi.FrontLight)
                {
                    FrontLightbtn.Background = Brushes.Red;
                }
            }

            
        }
    }
}
