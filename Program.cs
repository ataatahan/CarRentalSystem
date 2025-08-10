using ConsoleApp1.Cars;
using ConsoleApp1.Customers;
using ConsoleApp1.Registrations;
using System;
using System.Collections.Generic;
using System.Threading;

namespace VehicleRentalOnline
{
    internal class Program
    {
        // Müşteri listesini tutar
        static List<Customer> customers = new List<Customer>();

        // Araç listesini tutar, başlangıçta bazı araçlar ekli
        static List<VehicleBase> vehicles = new List<VehicleBase>
        {
            new VehicleBase("BMW", "M4"),
            new VehicleBase("Toyota", "Corolla"),
            new VehicleBase("Mercedes", "Benz"),
            new VehicleBase("Tesla", "Model Y")
        };

        // Kiralama kayıtlarını tutar
        static List<RentalRecord> rentals = new List<RentalRecord>();

        static void Main(string[] args)
        {
            // Program ana döngüsü, kullanıcı çıkana kadar devam eder
            bool exit = true;
            while (exit)
            {
                ShowMenu(); // Menü gösterilir
                string input = Console.ReadLine();

                // Kullanıcının seçimine göre işlem yapılır
                switch (input)
                {
                    case "1":
                        AddCustomer(); // Yeni müşteri ekle
                        break;

                    case "2":
                        ListAvailableVehicles(); // Mevcut araçları listele
                        break;

                    case "3":
                        AddNewVehicle(); // Yeni araç ekle
                        break;

                    case "4":
                        RentVehicle(); // Araç kiralama işlemi
                        break;

                    case "5":
                        ListRentedVehicles(); // Kiralanan araçları listele
                        break;

                    case "6":
                        Console.Write("Are you sure you want to exit? [Y / N]: ");
                        string exitChoice = Console.ReadLine();
                        exit = ConfirmExit(exit, exitChoice); // Çıkış onayı al
                        break;

                    default:
                        Console.WriteLine("Invalid selection"); // Geçersiz seçim uyarısı
                        break;
                }
            }
        }

        // Menü seçeneklerini ekrana yazdırır
        private static void ShowMenu()
        {
            Console.WriteLine("--- VEHICLE RENTAL SYSTEM ---");
            Console.WriteLine("\n [1] Add New Customer");
            Console.WriteLine(" [2] List Available Vehicles");
            Console.WriteLine(" [3] Add New Vehicle");
            Console.WriteLine(" [4] Rent a Vehicle");
            Console.WriteLine(" [5] List Rented Vehicles");
            Console.WriteLine(" [6] Exit");
            Console.Write("Choice: ");
        }

        // Yeni müşteri eklemek için bilgileri alır ve listeye ekler
        static void AddCustomer()
        {
            try
            {
                Customer customer = new Customer();

                Console.Write("First Name: ");
                customer.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                customer.LastName = Console.ReadLine();

                Console.Write("Email: ");
                customer.Email = Console.ReadLine();

                Console.Write("Phone (+90 not included, 10 digits): ");
                customer.PhoneNumber = Console.ReadLine();

                Console.Write("Nationality: ");
                customer.Nationality = Console.ReadLine();

                customers.Add(customer); // Müşteri listesine ekle
                Console.WriteLine("Customer added successfully.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // Kiralanabilir araçları listeler
        static void ListAvailableVehicles()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles available for rent.");
            }
            else
            {
                int i = 1;
                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine($"[{i++}] - {vehicle.ToString()} - Daily Price: {vehicle.DailyPrice} TL");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Yeni araç eklemek için bilgileri alır ve listeye ekler
        static void AddNewVehicle()
        {
            try
            {
                Console.WriteLine("Select vehicle type:");
                Console.WriteLine("1 - Car\n2 - SUV\n3 - Minibus\n4 - Electric");
                string choice = Console.ReadLine();

                Console.Write("Fuel type: ");
                string fuel = Console.ReadLine();

                Console.Write("Transmission type (Manual/Automatic): ");
                string transmission = Console.ReadLine();

                Console.Write("Number of seats: ");
                int seats = int.Parse(Console.ReadLine());

                // Seçilen türe göre araç nesnesi oluşturulur
                VehicleBase newVehicle = choice switch
                {
                    "1" => new Car(fuel, transmission, seats),
                    "2" => new Suv(fuel, transmission, seats),
                    "3" => new Minibus(fuel, transmission, seats),
                    "4" => new Electric(fuel, transmission, seats),
                    _ => null
                };

                if (newVehicle != null)
                {
                    Console.Write("Color: ");
                    newVehicle.Color = Console.ReadLine();

                    Console.Write("Brand: ");
                    newVehicle.Brand = Console.ReadLine();

                    Console.Write("Model: ");
                    newVehicle.Model = Console.ReadLine();

                    vehicles.Add(newVehicle); // Araç listesine ekle
                    Console.WriteLine("Vehicle added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid vehicle type."); // Geçersiz araç tipi uyarısı
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı göster
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Araç kiralama işlemi gerçekleştirir
        static void RentVehicle()
        {
            try
            {
                // Müşteri kontrolü
                if (customers.Count == 0)
                {
                    Console.WriteLine("Customer list is empty!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                // Araç kontrolü
                if (vehicles.Count == 0)
                {
                    Console.WriteLine("No vehicles available for rent!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                // Müşteri listesini göster
                Console.WriteLine("Customers:");
                for (int i = 0; i < customers.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {customers[i].FullName}");
                }

                // Kiralayan müşteri seçimi
                Console.Write("Customer number: ");
                if (!int.TryParse(Console.ReadLine(), out int customerIndex) || customerIndex < 1 || customerIndex > customers.Count)
                {
                    Console.WriteLine("Invalid customer number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
                customerIndex--;

                // Araç listesini göster
                Console.WriteLine("Vehicles:");
                for (int i = 0; i < vehicles.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {vehicles[i].Brand} {vehicles[i].Model}");
                }

                // Kiralanacak araç seçimi
                Console.Write("Vehicle number: ");
                if (!int.TryParse(Console.ReadLine(), out int vehicleIndex) || vehicleIndex < 1 || vehicleIndex > vehicles.Count)
                {
                    Console.WriteLine("Invalid vehicle number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
                vehicleIndex--;

                // Kiralama süresi alınır
                Console.Write("Number of days to rent: ");
                if (!int.TryParse(Console.ReadLine(), out int days) || days <= 0)
                {
                    Console.WriteLine("Invalid number of days.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                // Yeni kiralama kaydı oluşturulur ve listeye eklenir
                var record = new RentalRecord(customers[customerIndex], vehicles[vehicleIndex], days);
                rentals.Add(record);

                Console.WriteLine("\nVehicle rented successfully:");
                Console.WriteLine(record.ToString());
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Kiralanan araçları listeler
        static void ListRentedVehicles()
        {
            if (rentals.Count == 0)
            {
                Console.WriteLine("No vehicles have been rented yet.");
            }
            else
            {
                int i = 1;
                foreach (var record in rentals)
                {
                    Console.WriteLine($"[{i++}] {record.ToString()}");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Çıkış işlemini onaylar, yanlış girişte tekrar sorar
        static bool ConfirmExit(bool exit, string choice)
        {
            if (choice.ToLower() == "y")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Exiting the program...");
                Thread.Sleep(1000);
                Console.ResetColor();
                exit = false; // Programdan çık
            }
            else if (choice.ToLower() == "n")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Continuing the program...");
                Console.ResetColor();
                Thread.Sleep(1000);
            }
            else
            {
                // Yanlış girişte uyarı ve tekrar sorma
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("INVALID CHOICE...");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("RETURNING TO MENU...");
                Console.ResetColor();
                Thread.Sleep(1000);

                Console.Write("Are you sure you want to exit? [Y / N]: ");
                string secondChoice = Console.ReadLine();

                exit = ConfirmExit(exit, secondChoice); // Rekürsif çağrı ile tekrar kontrol
            }
            return exit;
        }
    }
}
