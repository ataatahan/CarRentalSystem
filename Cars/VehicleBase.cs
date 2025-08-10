using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cars
{
    // Araçların temel özelliklerini tutan ana sınıf
    public class VehicleBase
    {
        private string _brand;
        protected string _fuelType = "Gasoline"; // Yakıt tipi, varsayılan benzin
        protected string _model;
        protected decimal _dailyPrice = 5000;    // Günlük kira fiyatı, varsayılan 5000 TL
        protected int _seatCount;
        protected string _transmission;
        protected string _color;

        // Farklı parametre setleri için aşırı yüklenmiş yapıcılar (constructor)
        public VehicleBase(string fuelType, string transmission, int seatCount, string color, string brand, string model)
        {
            FuelType = fuelType;
            SeatCount = seatCount;
            Transmission = transmission;
            Color = color;
            Brand = brand;
            Model = model;
        }

        public VehicleBase(string brand, string model)
        {
            Model = model;
            Brand = brand;
        }

        public VehicleBase(string fuelType, string transmission, int seatCount)
        {
            FuelType = fuelType;
            Transmission = transmission;
            SeatCount = seatCount;
        }

        // Marka özelliği
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        // Yakıt tipi özelliği
        public string FuelType
        {
            get { return _fuelType; }
            set { _fuelType = value; }
        }

        // Model özelliği
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        // Günlük kira fiyatı, negatif olamaz
        public decimal DailyPrice
        {
            get { return _dailyPrice; }
            set
            {
                if (value >= 0)
                    _dailyPrice = value;
                else
                    throw new Exception("Price cannot be zero or negative."); // Hata mesajı
            }
        }

        // Koltuk sayısı, en az 1 olmalı
        public int SeatCount
        {
            get { return _seatCount; }
            set
            {
                if (value > 0)
                    _seatCount = value;
                else
                    throw new Exception("Seat count cannot be less than 1."); // Hata mesajı
            }
        }

        // Vites tipi, sadece "Manual" veya "Automatic" olabilir
        public string Transmission
        {
            get { return _transmission; }
            set
            {
                if (value == "Manual" || value == "Automatic")
                    _transmission = value;
                else
                    throw new Exception("Please enter a valid transmission type."); // Hata mesajı
            }
        }

        // Renk özelliği
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // Araç bilgilerini string olarak döndürür (marka ve model)
        public override string ToString()
        {
            return $"Brand: {Brand} - Model: {Model}";
        }
    }
}
