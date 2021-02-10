using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFGarbage
{
    class CarModel
    {
        public string Color { get; set; } //Tämä on ominaisuus (property)
        public int MaxSpeed { get; set; }
        private int maxSpeed; //Tämä on kenttä, eikä ominaisuus
        public Boolean Running { get; set; }
        public Boolean FrontLight { get; set; }
        public Boolean BackLight { get; set; }
        public string Model { get; set; }
        public string GearType { get; set; }
        public string EngineType { get; set; }
        public string RadioType { get; set; }

        
        
        public int HorsePower{ get; set; }
        public int AverageSpeed { get; set; }

        public void turnFrontLight(Boolean param) //Tämä on metodi
        {
            //------//
            FrontLight = param;
        }
        public void StartEngine() //Tämä on metodi
        {
            //------//
            Running = true;
        }

        public void StopEngine()
        {
            Running = false;
        }

        //Auton huippunopeuden asettaminen metodin kautta, tiedon tallennuspaikaksi määritelty kenttä, mikä on tyypiltään Private (eli ei ole ominaisuus)
        public void SetMaxSpeed(int UserInputMaxSpeed)
        {

            if ((UserInputMaxSpeed >= 0) && (UserInputMaxSpeed <= 400))
                maxSpeed = UserInputMaxSpeed;
           
            else
            {
                maxSpeed = 0;

                throw new ArgumentOutOfRangeException();  //lisätäään ominaisuuden tarkastamiseen poikkeuksen nostamistoiminto. Poikkeus nostetaan, jos nopeus on alle 0 tai yli 400
            }
        }

        public void setHorsePower(int userinput)
        {

            if (userinput >=0)
                HorsePower = userinput;

            else
            {
                HorsePower = 0;

                throw new ArgumentOutOfRangeException();  //lisätäään ominaisuuden tarkastamiseen poikkeuksen nostamistoiminto. Poikkeus nostetaan, jos nopeus on alle 0 tai yli 400
            }
        }

        //Metodi, mikä lukee Private-kentän arvon ja palauttaa sen
        public int GetMaxSpeed()
        {
            return maxSpeed;
        }

        public void Accelerate()
        {
            
                AverageSpeed++;
           
            
        }

        public void Brake()
        {
            if (AverageSpeed > 0) {
                AverageSpeed--;
            }
            
        }

        public int getSpeed()
        {
            return AverageSpeed;
        }


    }
}
