using ConsoleApp1.Cars;
using ConsoleApp1.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Registrations
{
    // Kiralama kaydını temsil eden yapı
    public struct RentalRecord
    {
        public Customer Customer { get; set; }      // Kiralayan müşteri
        public VehicleBase Vehicle { get; set; }    // Kiralanan araç
        public int NumberOfDays { get; set; }       // Kiralama süresi (gün)
        public decimal TotalAmount { get; set; }    // Toplam ödeme tutarı

        // Yapıcı metot: müşteri, araç ve gün sayısını alır, toplam ücreti hesaplar
        public RentalRecord(Customer customer, VehicleBase vehicle, int numberOfDays)
        {
            Customer = customer;
            Vehicle = vehicle;
            NumberOfDays = numberOfDays;
            TotalAmount = numberOfDays * vehicle.DailyPrice; // Günlük ücret * gün sayısı
        }

        // Kiralama bilgilerini okunabilir string olarak döndürür
        public override string ToString()
        {
            return $"Customer: {Customer.FullName} - Vehicle: {Vehicle.Brand} {Vehicle.Model} - Days: {NumberOfDays} - Total Amount: {TotalAmount} TL";
        }
    }
}
