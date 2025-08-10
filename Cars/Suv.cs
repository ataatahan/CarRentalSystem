using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cars
{
    // Suv sınıfı, SUV tipi araçları temsil eder, Car sınıfından türemiştir
    public class Suv : Car
    {
        // Yapıcı metot: baz sınıf yapıcısını çağırır ve SUV için varsayılan değerleri ayarlar
        public Suv(string fuelType, string transmission, int seatCount) : base(fuelType, transmission, seatCount)
        {
            _fuelType = "Gasoline";      // Yakıt tipi benzin
            _transmission = "Automatic"; // Vites tipi otomatik
            _seatCount = 7;              // Koltuk sayısı 7
            _dailyPrice = 9000;          // Günlük kira fiyatı (TL)
        }

        // Araç bilgilerini string olarak döndürür (base sınıf metodunu kullanır)
        public override string ToString()
        {
            return base.ToString();
        }
    }
}