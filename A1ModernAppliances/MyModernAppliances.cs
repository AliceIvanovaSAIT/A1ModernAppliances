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

            // Create long variable to hold item number

            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)

            // Loop through Appliances
                // Test appliance item number equals entered item number
                    // Assign appliance in list to foundAppliance variable

                    // Break out of loop (since we found what need to)

            // Test appliance was not found (foundAppliance is null)
                // Write "No appliances found with that item number."

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

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"
            Console.WriteLine("0 - Any\n2 - Double Doors\n3 - Three Doors\n4 = Four Doors\nEnter Number of doors:");
            var option = 1;
            List<int> correct_choices = new List<int>(); 
            correct_choices.Add(0);
            correct_choices.Add(2);
            correct_choices.Add(3);
            correct_choices.Add(4);
            while (!correct_choices.Contains(option))
            {
                option = int.Parse(Console.ReadLine());
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
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"

            // Write "Enter grade:"

            // Get user input as string and assign to variable

            // Create grade variable to hold grade to find (Any, Residential, or Commercial)

            // Test input is "0"
                // Assign "Any" to grade
            // Test input is "1"
                // Assign "Residential" to grade
            // Test input is "2"
                // Assign "Commercial" to grade
            // Otherwise (input is something else)
                // Write "Invalid option."

                // Return to calling (previous) method
                // return;

            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"

            // Write "Enter voltage:"

            // Get user input as string
            // Create variable to hold voltage

            // Test input is "0"
                // Assign 0 to voltage
            // Test input is "1"
                // Assign 18 to voltage
            // Test input is "2"
                // Assign 24 to voltage
            // Otherwise
                // Write "Invalid option."
                // Return to calling (previous) method
                // return;

            // Create found variable to hold list of found appliances.

            // Loop through Appliances
                // Check if current appliance is vacuum
                    // Down cast current Appliance to Vacuum object
                    // Vacuum vacuum = (Vacuum)appliance;

                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                        // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
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

            // Get user input as string and assign to variable

            // Create character variable that holds room type

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

            // Create variable that holds list of 'found' appliances

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
            Console.WriteLine("0 - Any\n1 - Quietest\n2 - Quieter\n3 - Quiet\n4 - Moderate\nEnter sound rating:");
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
                        .WriteLine("Error: Wrong Input");
                }
                option = int.Parse(Console.ReadLine());
                //May break due it doesn't checks if the string is int, it just converts
                //So if you have something better, let me know.
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

            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"

            // Write "Enter type of appliance:"

            // Get user input as string and assign to appliance type variable

            // Write "Enter number of appliances: "

            // Get user input as string and assign to variable

            // Convert user input from string to int

            // Create variable to hold list of found appliances

            // Loop through appliances
                // Test inputted appliance type is "0"
                    // Add current appliance in list to found list
                // Test inputted appliance type is "1"
                    // Test current appliance type is Refrigerator
                        // Add current appliance in list to found list
                // Test inputted appliance type is "2"
                    // Test current appliance type is Vacuum
                        // Add current appliance in list to found list
                // Test inputted appliance type is "3"
                    // Test current appliance type is Microwave
                        // Add current appliance in list to found list
                // Test inputted appliance type is "4"
                    // Test current appliance type is Dishwasher
                        // Add current appliance in list to found list

            // Randomize list of found appliances
            // found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
        }
    }
}
