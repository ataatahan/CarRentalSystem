using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cars
{
    // Değer kontrolünde oluşan hataları temsil eden özel istisna sınıfı
    public class CheckValueException : Exception
    {
        // Hata ile ilişkili özellik adı
        public string PropertyName { get; set; }

        // Yapıcı metot: hata mesajı ve ilgili özellik adı alır, temel Exception mesajını hazırlar
        public CheckValueException(string message, string propertyName)
            : base($"Property:  {propertyName}  Message: {message} Date: {DateTime.Now}")
        {
            PropertyName = propertyName;
        }
    }
}
