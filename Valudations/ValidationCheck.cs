using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cars
{
    internal class ValidationCheck
    {
        // String değerin boş olup olmadığını ve maksimum uzunluğunu kontrol eder
        public static bool CheckValue(string value, int lenght)
        {
            if (string.IsNullOrEmpty(value) || value.Length > lenght)
            {
                return false; // Geçersiz değer
            }
            else
                return true; // Geçerli değer
        }

        // Tarihin bugünden sonraki bir tarih olup olmadığını kontrol eder
        public static bool CheckDate(DateTime date)
        {
            if (DateTime.Now < date)
                return false; // Tarih bugünden sonra olamaz
            else
                return true; // Tarih geçerli
        }
    }
}