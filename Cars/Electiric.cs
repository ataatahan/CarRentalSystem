using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cars
{
    // Electric sınıfı, elektrikli otomobil tipini temsil eder, Car sınıfından türemiştir
    public class Electric : Car
    {
        // Yapıcı metot: baz sınıfın yapıcısını çağırır ve elektrikli araç özelliklerini ayarlar
        public Electric(string fuelType, string transmission, int seatCount) : base(fuelType, transmission, seatCount)
        {
            _fuelType = "Electric";       // Yakıt tipi elektrik
            _transmission = "Automatic";  // Vites tipi otomatik
            _seatCount = 5;               // Koltuk sayısı 5
            _dailyPrice = 2000;           // Günlük kira fiyatı (TL)
        }

        // Araç bilgilerini string olarak döndürür (base sınıfın ToString metodunu kullanır)
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
