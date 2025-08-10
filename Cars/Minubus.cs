using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cars
{
    // Minibus sınıfı, minibüs tipinde araçları temsil eder, Car sınıfından türetilmiştir
    public class Minibus : Car
    {
        // Yapıcı metot: baz sınıfın yapıcısını çağırır ve minibüs özelliklerini ayarlar
        public Minibus(string fuelType, string transmission, int seatCount) : base(fuelType, transmission, seatCount)
        {
            _fuelType = "Gasoline";      // Yakıt tipi benzin
            _transmission = "Automatic"; // Vites tipi otomatik
            _seatCount = 14;             // Koltuk sayısı minibüs için 14
            _dailyPrice = 10000;         // Günlük kira fiyatı (TL)
        }

        public bool AssistantSeat { get; set; }  // Yardımcı koltuk (rehberlik veya refakatçi koltuğu)

        // Araç bilgilerini string olarak döndürür, yardımcı koltuk bilgisini ekler
        public override string ToString()
        {
            return base.ToString() + " - Assistant Seat: " + AssistantSeat;
        }
    }
}
