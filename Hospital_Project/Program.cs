using Hospital_Project;
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Hospital hospital = new Hospital();

        while (true)
        {
            RestartLogin: ;
            Console.Clear();
            Console.WriteLine("Welcome to the Hospital! Please sign in first.");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine(); //email@gmail.com
            Console.WriteLine("Enter your phone number:");
            string phone = Console.ReadLine();
            try
            {
                User newUser = new User(name, surname, email, phone);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try again");
                Thread.Sleep(2000);
                continue;
            }

            string[] departments =
                { hospital.Departments[0].Name, hospital.Departments[1].Name, hospital.Departments[2].Name };
            int selectedDepartmentIndex = 0;

            while (true)
            {
                BackToDepartmentSelection: ;

                Console.Clear();
                Console.WriteLine("Choose a department:\n");
                for (int i = 0; i < departments.Length; i++)
                {
                    if (i == selectedDepartmentIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"> {departments[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {departments[i]}");
                    }
                }

                int backOptionIndex = departments.Length;
                if (selectedDepartmentIndex == backOptionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("> Back");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("  Back");
                }

                ConsoleKey deptKey = Console.ReadKey(true).Key;
                switch (deptKey)
                {
                    case ConsoleKey.UpArrow:
                        selectedDepartmentIndex =
                            (selectedDepartmentIndex - 1 + backOptionIndex + 1) % (backOptionIndex + 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedDepartmentIndex = (selectedDepartmentIndex + 1) % (backOptionIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        if (selectedDepartmentIndex == backOptionIndex)
                        {
                            goto RestartLogin;
                        }
                        else
                        {
                            var doctors = hospital.Departments[selectedDepartmentIndex].Doctors;
                            if (doctors.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("No doctors in this department.");
                                Console.WriteLine("Press any key to go back.");
                                Console.ReadKey(true);
                                break;
                            }

                            int selectedDoctorIndex = 0;
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine($"Department: {departments[selectedDepartmentIndex]}");
                                Console.WriteLine("Choose a doctor:\n");
                                for (int i = 0; i < doctors.Count; i++)
                                {
                                    if (i == selectedDoctorIndex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine($"> {doctors[i].Name} {doctors[i].Surname}");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"  {doctors[i].Name} {doctors[i].Surname}");
                                    }
                                }

                                int doctorBackIndex = doctors.Count;
                                if (selectedDoctorIndex == doctorBackIndex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("> Back");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine("  Back");
                                }

                                ConsoleKey doctorKey = Console.ReadKey(true).Key;
                                switch (doctorKey)
                                {
                                    case ConsoleKey.UpArrow:
                                        selectedDoctorIndex = (selectedDoctorIndex - 1 + doctorBackIndex + 1) %
                                                              (doctorBackIndex + 1);
                                        break;
                                    case ConsoleKey.DownArrow:
                                        selectedDoctorIndex = (selectedDoctorIndex + 1) % (doctorBackIndex + 1);
                                        break;
                                    case ConsoleKey.Enter:
                                        if (selectedDoctorIndex == doctorBackIndex)
                                        {
                                            goto BackToDepartmentSelection;
                                        }
                                        else
                                        {
                                            int selectedHourIndex = 0;

                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.WriteLine(
                                                    $"Dr. {doctors[selectedDoctorIndex].Name} {doctors[selectedDoctorIndex].Surname}");
                                                Console.WriteLine("Choose a time slot:\n");

                                                bool[] available =
                                                {
                                                    doctors[selectedDoctorIndex].NineToEleven,
                                                    doctors[selectedDoctorIndex].TwelveToThirteen,
                                                    doctors[selectedDoctorIndex].FifteenToSeventeen,
                                                };

                                                string[] hours =
                                                {
                                                    $"09:00 - 11:00 - {(available[0] ? "Free" : "Reserved")}",
                                                    $"12:00 - 14:00 - {(available[1] ? "Free" : "Reserved")}",
                                                    $"15:00 - 17:00 - {(available[2] ? "Free" : "Reserved")}",
                                                    "Back"
                                                };

                                                // secile bilib bilmediiyini yoxlayir
                                                while (selectedHourIndex < 3 && !available[selectedHourIndex])
                                                {
                                                    selectedHourIndex = (selectedHourIndex + 1) % hours.Length;
                                                }

                                                for (int i = 0; i < hours.Length; i++)
                                                {
                                                    if (i == selectedHourIndex)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.WriteLine($"> {hours[i]}");
                                                        Console.ResetColor();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"  {hours[i]}");
                                                    }
                                                }

                                                ConsoleKey hourKey = Console.ReadKey(true).Key;
                                                switch (hourKey)
                                                {
                                                    case ConsoleKey.UpArrow:
                                                        do
                                                        {
                                                            selectedHourIndex = (selectedHourIndex - 1 + hours.Length) %
                                                                hours.Length;
                                                        } while (selectedHourIndex < 3 &&
                                                                 !available[selectedHourIndex]);

                                                        break;

                                                    case ConsoleKey.DownArrow:
                                                        do
                                                        {
                                                            selectedHourIndex = (selectedHourIndex + 1) % hours.Length;
                                                        } while (selectedHourIndex < 3 &&
                                                                 !available[selectedHourIndex]);

                                                        break;

                                                    case ConsoleKey.Enter:
                                                        if (selectedHourIndex == 3)
                                                        {
                                                            goto BackToDoctorSelection;
                                                        }
                                                        else if (available[selectedHourIndex])
                                                        {
                                                            // reserve edirik 
                                                            if (selectedHourIndex == 0)
                                                                doctors[selectedDoctorIndex].NineToEleven = false;
                                                            else if (selectedHourIndex == 1)
                                                                doctors[selectedDoctorIndex].TwelveToThirteen = false;
                                                            else if (selectedHourIndex == 2)
                                                                doctors[selectedDoctorIndex].FifteenToSeventeen = false;

                                                            Console.Clear();
                                                            Console.WriteLine(
                                                                $"Thank you {name} {surname}. You have booked {hours[selectedHourIndex]} with Dr. {doctors[selectedDoctorIndex].Name} {doctors[selectedDoctorIndex].Surname}");
                                                            Console.WriteLine("Press any key to return to login...");
                                                            Console.ReadKey(true);
                                                            goto RestartLogin;
                                                        }

                                                        break;
                                                }
                                            }

                                            BackToDoctorSelection: ;
                                        }

                                        break;
                                }
                            }
                        }

                        break;
                }
            }
        }
    }
}