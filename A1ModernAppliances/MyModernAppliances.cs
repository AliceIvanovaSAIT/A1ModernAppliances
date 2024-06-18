using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using System.Reflection.Metadata;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.Write($"Enter the item number of an appliance:\n    ");
            long itemNumber;
            itemNumber = (long)Convert.ToDouble(Console.ReadLine());
            Appliance foundAppliance = null;
            foreach (Appliance appliance in Appliances)
            {
                if (appliance._itemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break;
                }
            }
            if (foundAppliance == null)
            {
                Console.WriteLine($"No appliances found with that item number.\n");
            }
            else if (foundAppliance.IsAvailable == false)
            {
                Console.WriteLine($"The appliance is not available to be checked out.\n");
            }
            else
            {
                foundAppliance.Checkout();
                Console.WriteLine($"Appliance \"{foundAppliance.ItemNumber}\" has been checked out.\n");
            }
        }
        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.Write($"Enter brand to search for:\n    ");
            string inputBrand = Console.ReadLine();
            if (inputBrand == null)
            {
                Console.WriteLine("Invalid Input.");
                return;
            }
            else
            {
                List<Appliance> foundAppliance = new List<Appliance>();
                foreach (Appliance appliance in Appliances)
                {
                    if (appliance.Brand == inputBrand)
                    {
                        foundAppliance.Add(appliance);
                    }
                }
                DisplayAppliancesFromList(foundAppliance, foundAppliance.Count());

            }
        }
        public override void DisplayRefrigerators()
        {
            Console.Write($"Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):\n    ");
            List<int> correct_choices = new List<int>
            {
                0,
                2,
                3,
                4
            };
            bool isNumber = int.TryParse(Console.ReadLine(),out int option);
            bool isDoorless = false; //Default value
            if (isNumber)
            {
                if (option == 0)
                {
                    Console.WriteLine("Is your refrigerator doorless? Y/N");
                    var doorless_option = Console.ReadLine();
                    if (doorless_option != null && doorless_option.ToLower() == "y")
                    {
                        isDoorless = true;
                    }
                    else { isDoorless = false; }
                }
                List<Appliance> refrigerator_list = new List<Appliance>();
                foreach (var appliance_object in Appliances)
                {
                    if (appliance_object is Refrigerator refrigerator)
                    {
                        if (option == 0)
                        {
                            if (isDoorless)
                            {
                                if (option == refrigerator.Doors) { refrigerator_list.Add(refrigerator); }
                            }
                            else
                            {
                                refrigerator_list.Add(refrigerator);
                            }
                        } // For doorless Fridges
                        else
                        {
                            if (option == refrigerator.Doors) { refrigerator_list.Add(refrigerator); }
                        }
                    }
                }
                DisplayAppliancesFromList(refrigerator_list, refrigerator_list.Count());
            }
            else
            {
                Console.WriteLine("Wrong Input.");
            }
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.Write("Enter battery voltage value. 18 V (low) or 24 V (high):\n    ");
            string userInput = Console.ReadLine();
            int voltage = 0;
            if (userInput != null)
            {
                switch (userInput)
                {
                    case "18": voltage = 18; break;
                    case "24": voltage = 24; break;
                    default: Console.WriteLine("Invalid Option"); break;
                }
                if (voltage == 18 || voltage == 24)
                {
                    List<Appliance> found = new List<Appliance>();
                    foreach (var appliance in Appliances)
                    {
                        if (appliance is Vacuum vacuum)
                        {
                            if (voltage == 0 || vacuum.BatteryVoltage == voltage)
                            {
                                found.Add(appliance);
                            }
                        }
                    }
                    DisplayAppliancesFromList(found, 0);
                }
            }else { Console.WriteLine("Wrong Input"); }

        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.Write("Room where the microwave will be installed: K (kitchen) or W (work site):\n    ");
            string userInput = Console.ReadLine();
            List<string> correct_choices = new List<string>
            {
                "W",
                "K"
            };
            if (userInput != null && correct_choices.Contains(userInput.ToUpper())) {
                List<Appliance> found = new List<Appliance>();
                foreach (Appliance appliance in Appliances)
                {
                    if (appliance is Microwave microwave)
                    {
                        if (userInput == "K" && microwave.RoomTypeDisplay == "Kitchen")
                        {
                            found.Add(appliance);
                        }
                        else if (userInput == "W" && microwave.RoomTypeDisplay == "Work Site")
                        {
                            found.Add(appliance);
                        }
                    }
                }
                DisplayAppliancesFromList(found, found.Count());
            }else { Console.WriteLine("Wrong Input"); }
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.Write($"Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):\n    ");
            List<string> correct_choices = new List<string>
            {
                "qt",
                "qr",
                "qu",
                "m",
                "any"
            };
            string userInput = Console.ReadLine();
            if (userInput != null && correct_choices.Contains(userInput.ToLower()))
            {
                MyModernAppliances appliances_list = new MyModernAppliances();
                List<Appliance> dishwashers_list = new List<Appliance>();
                foreach (var appliance_object in appliances_list.Appliances)
                {
                    if (appliance_object is Dishwasher dishwasher)
                    {
                        if (userInput == "Any") { dishwashers_list.Add(dishwasher); }
                        else { if (userInput == dishwasher.SoundRating) { dishwashers_list.Add(dishwasher); } }

                    }
                }
                DisplayAppliancesFromList(dishwashers_list, dishwashers_list.Count());
            }
            else { Console.WriteLine("Wrong Input"); return; }
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.Write($"Enter number of appliances:\n    ");
            string RAWuserInput = Console.ReadLine();
            bool isNumber = int.TryParse(RAWuserInput, out int userInput);
            if (isNumber && RAWuserInput != null)
            {
                if (userInput > Appliances.Count || userInput == 0)
                {
                    Console.WriteLine("Invalid option.");
                }
                else
                {
                    Random random = new Random();
                    List<Appliance> copyAppliance = new List<Appliance>(Appliances);
                    for (int i = copyAppliance.Count - 1; i > 0; i--)
                    {
                        int j = random.Next(i + 1);
                        Appliance temp = copyAppliance[i];
                        copyAppliance[i] = copyAppliance[j];
                        copyAppliance[j] = temp;
                    }
                    DisplayAppliancesFromList(copyAppliance, userInput);
                }
            }else { Console.WriteLine("Wrong Input"); }
        }
    }
}
