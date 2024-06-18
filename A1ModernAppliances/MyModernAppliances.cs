using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

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
            // Write "Enter the item number of an appliance: "
            Console.Write($"Enter the item number of an appliance:\n    ");
            // Create long variable to hold item number
            long itemNumber;
            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.
            itemNumber = (long)Convert.ToDouble(Console.ReadLine());
            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance foundAppliance = null;
            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                if (appliance._itemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break;
                }
            }
            // Test appliance item number equals entered item number
            // Assign appliance in list to foundAppliance variable

            // Break out of loop (since we found what need to)

            // Test appliance was not found (foundAppliance is null)
            // Write "No appliances found with that item number."
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

            // Otherwise (appliance was found)
            // Test found appliance is available
            // Checkout found appliance

            // Write "Appliance has been checked out."
            // Otherwise (appliance isn't available)
            // Write "The appliance is not available to be checked out."
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
        
        // Write "Enter brand to search for:"
    
        // Create string variable to hold entered brand
        // Get user input as string and assign to variable.
    
        // Create list to hold found Appliance objects
    
        // Iterate through loaded appliances
        // Test current appliance brand matches what user entered
        // Add current appliance in list to found list
    
    
        // Display found appliances
        // DisplayAppliancesFromList(found, 0);
        }
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"
            Console.Write($"Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):\n    ");
            var option = 1;
            List<int> correct_choices = new List<int>(); 
            correct_choices.Add(0);
            correct_choices.Add(2);
            correct_choices.Add(3);
            correct_choices.Add(4);
            while (!correct_choices.Contains(option))
            {
                option = Convert.ToInt16(Console.ReadLine());
                //May break due it doesn't checks if the string is int, it just converts
                //So if you have something better, let me know.
            }
            bool isDoorless = false; //Default value
            if (option == 0)
            {
                Console.WriteLine("Is your refrigerator doorless? Y/N");
                var doorless_option = Console.ReadLine();
                if (doorless_option != null || doorless_option.ToLower() == "y")
                {
                    isDoorless = true;
                }
                else { isDoorless = false; }
            }
            MyModernAppliances appliances_list = new MyModernAppliances();
            List<Appliance> refrigerator_list = new List<Appliance>();
            int count = 0;
            foreach (var appliance_object in appliances_list.Appliances)
            {
                if (appliance_object is Refrigerator refrigerator)
                {
                    count += 1;
                    if (option == 0)
                    {
                        if (isDoorless)
                        {
                            if (option == refrigerator.Doors) {refrigerator_list.Add(refrigerator);}
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
            Console.WriteLine("Matching refrigerators:");
            DisplayAppliancesFromList(refrigerator_list, count);

            // Write "Enter number of doors: "

            // Create variable to hold entered number of doors

            // Get user input as string and assign to variable

            // Convert user input from string to int and store as number of doors variable.

            // Create list to hold found Appliance objects

            // Iterate/loop through Appliances
            // Test that current appliance is a refrigerator
            // Down cast Appliance to Refrigerator
            // Refrigerator refrigerator = (Refrigerator) appliance;

            // Test user entered 0 or refrigerator doors equals what user entered.
            // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
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
            int voltage;

            if (userInput == "0")
            {
                voltage = 0;
            }
            else if (userInput == "18")
            {
                voltage = 18;
            }
            else if (userInput == "24")
            {
                voltage = 24;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

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

            Console.WriteLine("Matching vacuums:");
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"

            // Write "Enter room type:"

            Console.Write("Room where the microwave will be installed: K (kitchen) or W (work site):\n    ");

            string userInput = Console.ReadLine();
            // Get user input as string and assign to variable

            // Create character variable that holds room type

            if (userInput == "1")
            {
                userInput = "K";
            }
            else if (userInput == "2")
            {
                userInput = "W";
            }
            else if (userInput == "0")
            {
                userInput = "A";
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
            // Test input is "0"
            // Assign 'A' to room type variable
            // Test input is "1"
            // Assign 'K' to room type variable
            // Test input is "2"
            // Assign 'W' to room type variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            // return;

            List<Appliance> found = new List<Appliance>();
            // Create variable that holds list of 'found' appliances

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
                    else if (userInput == "A")
                    {
                        found.Add(appliance);
                    }
                }
            }

            if (found.Count > 0)
            {
                Console.WriteLine("Matching microwaves:");
                DisplayAppliancesFromList(found, 0);
            }

            // Loop through Appliances
            // Test current appliance is Microwave
            // Down cast Appliance to Microwave

            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            var count = 0;
            Console.Write($"Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):\n    ");
            var option = 10;
            List<int> correct_choices = new List<int>();
            correct_choices.Add(0);
            correct_choices.Add(1);
            correct_choices.Add(2);
            correct_choices.Add(3);
            correct_choices.Add(4);
            while (!correct_choices.Contains(option))
            {
                if (count > 0)
                {
                    Console
                        .WriteLine("Invalid input.");
                }
                option = int.Parse(Console.ReadLine());
                //May break due it doesn't checks if the string is int, it just converts
                //So if you have something better, let me know.
                count += 1;
            }
            var sound_rating = "";
            switch (option)
            {
                case 0: sound_rating = "Any"; break;
                case 1: sound_rating = "Qt"; break;
                case 2: sound_rating = "Qr"; break;
                case 3: sound_rating = "Qu"; break;
                case 4: sound_rating = "M"; break;
            }
            MyModernAppliances appliances_list = new MyModernAppliances();
            List<Appliance> dishwashers_list = new List<Appliance>();
            count = 0;
            foreach (var appliance_object in appliances_list.Appliances)
            {
                if (appliance_object is Dishwasher dishwasher)
                {
                    count += 1;
                    if (sound_rating == "Any")
                    {
                        dishwashers_list.Add(dishwasher); 
                    } 
                    else
                    {
                        if (sound_rating == dishwasher.SoundRating) { dishwashers_list.Add(dishwasher); }
                    }
                }
            }
            Console.WriteLine("Matching dishwashers:");
            DisplayAppliancesFromList(dishwashers_list, count);
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"

            // Write "Enter sound rating:"

            // Get user input as string and assign to variable

            // Create variable that holds sound rating

            // Test input is "0"
            // Assign "Any" to sound rating variable
            // Test input is "1"
            // Assign "Qt" to sound rating variable
            // Test input is "2"
            // Assign "Qr" to sound rating variable
            // Test input is "3"
            // Assign "Qu" to sound rating variable
            // Test input is "4"
            // Assign "M" to sound rating variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method

            // Create variable that holds list of found appliances

            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher

            // Test sound rating is "Any" or equals soundrating for current dishwasher
            // Add current appliance in list to found list

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"
            // Get user input as string and assign to appliance type variable
            // Write "Enter number of appliances: "
            Console.Write($"Enter number of appliances:\n    ");

            // Get user input as string and assign to variable
            int numAppliancesInput = Convert.ToInt32(Console.ReadLine());

            if (numAppliancesInput > Appliances.Count || numAppliancesInput == 0)
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

                
                Console.WriteLine("Random appliances:");
                // Display found appliances (up to max. number inputted)
                DisplayAppliancesFromList(copyAppliance, numAppliancesInput);
            }
        }
    }
}
