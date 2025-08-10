using ConsoleApp1.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Customers
{
    // Müşteri bilgilerini tutan sınıf
    public class Customer
    {
        // Özel alanlar (field)
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _nationality;

        // İsim özelliği, boş veya 50 karakterden uzun olamaz
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (ValidationCheck.CheckValue(value, 50))
                    _firstName = value;
                else
                    throw new CheckValueException("First name cannot be empty or longer than 50 characters.", nameof(FirstName));
            }
        }

        // Soyisim özelliği, boş veya 50 karakterden uzun olamaz
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (ValidationCheck.CheckValue(value, 50))
                    _lastName = value;
                else
                    throw new CheckValueException("Last name cannot be empty or longer than 50 characters.", nameof(LastName));
            }
        }

        // Email özelliği, 50 karakterden uzun olamaz
        public string Email
        {
            get { return _email; }
            set
            {
                if (ValidationCheck.CheckValue(value, 50))
                    _email = value;
                else
                    throw new CheckValueException("Email cannot be longer than 50 characters.", nameof(Email));
            }
        }

        // Telefon numarası, 10 karakterden uzun olamaz (ülke kodu hariç)
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (ValidationCheck.CheckValue(value, 10))
                    _phoneNumber = value;
                else
                    throw new CheckValueException("Phone number cannot be longer than 10 characters.", nameof(PhoneNumber));
            }
        }

        // Ad ve soyad birleşimi (tam isim)
        public string FullName => _firstName + " " + _lastName;

        // Uyruk özelliği, 50 karakterden uzun olamaz
        public string Nationality
        {
            get { return _nationality; }
            set
            {
                if (ValidationCheck.CheckValue(value, 50))
                    _nationality = value;
                else
                    throw new CheckValueException("Nationality cannot be longer than 50 characters.", nameof(Nationality));
            }
        }
    }
}
