using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cars
{
    // Car sınıfı, VehicleBase'ten türemiş otomobil tipi araç sınıfı
    public class Car : VehicleBase
    {
        // Yapıcı metot: baz sınıfın yapıcısını çağırır ve varsayılan değerleri atar
        public Car(string fuelType, string transmission, int seatCount) : base(fuelType, transmission, seatCount)
        {
            _fuelType = "Gasoline";    // Yakıt tipi varsayılan benzin
            _transmission = "Automatic"; // Vites tipi varsayılan otomatik
            _seatCount = 5;            // Koltuk sayısı varsayılan 5
        }

        public bool Sunroof { get; set; }          // Cam tavan özelliği
        public bool DigitalDisplay { get; set; }   // Dijital gösterge paneli özelliği

        // Aracın bilgilerini string olarak döndürür, base ToString metoduna ek özellikler ekler
        public override string ToString()
        {
            return base.ToString() + $" - Sunroof: {Sunroof} - Digital Display: {DigitalDisplay}";
        }
    }
}
