using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: Kihyun Kim </remarks>
    /// <remarks>Date: 06 FEB 2023 </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.WriteLine("Enter the item number of an appliance: ");
            // Create long variable to hold item number
            long itemNumber = 0;
            // Get user input as string and assign to variable.
            string itemNumInput = Console.ReadLine();
            // Convert user input from string to long and store as item number variable.
            itemNumber = long.Parse(itemNumInput);
            // Create 'foundAppliance' variable to hold appliance with item number
            Appliance foundAppliance = null;
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)

            // Loop through Appliances
            // Test appliance item number equals entered item number
            // Assign appliance in list to foundAppliance variable
            // Break out of loop (since we found what need to)

            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break;
                }
            }

            // Test appliance was not found (foundAppliance is null)
            // Write "No appliances found with that item number."
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");

            }
            // Otherwise (appliance was found)
            // Test found appliance is available
            // Checkout found appliance

            // Write "Appliance has been checked out."
            // Otherwise (appliance isn't available)
            // Write "The appliance is not available to be checked out."
            else
            {
                if (foundAppliance.IsAvailable)
                {
                    Console.WriteLine("Appliance" + itemNumInput + " has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }


        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter brand to search for: ");
            // Create string variable to hold entered brand
            string brandInput = Console.ReadLine();
            // Get user input as string and assign to variable.
            // Create list to hold found Appliance objects
            List<Appliance> foundAppliances = new List<Appliance>();

            // Iterate through loaded appliances
            // Test current appliance brand matches what user entered
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (brandInput == appliance.Brand)
                {
                    foundAppliances.Add(appliance);
                }
            }
            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundAppliances, 0);

        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: ");

            Console.WriteLine("0 – Any");
            Console.WriteLine("2 – Double doors");
            Console.WriteLine("3 – Three doors");
            Console.WriteLine("4 – Four doors");

            Console.WriteLine("Enter number of doors: ");

            // Create variable to hold entered number of doors
            int doorNum;

            // Get user input as string and assign to variable
            string door = Console.ReadLine();
            // Convert user input from string to int and store as number of doors variable.
            doorNum = int.Parse(door);
            // Create list to hold found Appliance objects
            List<Appliance> foundAppliances = new List<Appliance>();

            // Iterate/loop through Appliances
            // Test that current appliance is a refrigerator
            // Test user entered 0 or refrigerator doors equals what user entered.
            // Add current appliance in list to found list



            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Refrigerator)
                {
                    // Down cast Appliance to Refrigerator
                    Refrigerator refrigerator = (Refrigerator)appliance;

                    if (doorNum == refrigerator.Doors)
                    {
                        foundAppliances.Add(appliance);
                    }
                }

            }
            // Display found appliances
            DisplayAppliancesFromList(foundAppliances, 0);


        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: ");

            Console.WriteLine("0 – Any");
            Console.WriteLine("1 – Residential");
            Console.WriteLine("2 – Commercial");

            Console.WriteLine("Enter grade: ");

            // Get user input as string and assign to variable
            string VacumInput = Console.ReadLine();
            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string grade = "";

            // Test input is "0"
            // Assign "Any" to grade
            // Test input is "1"
            // Assign "Residential" to grade
            // Test input is "2"
            // Assign "Commercial" to grade
            // Otherwise (input is som
            // ething else)
            // Write "Invalid option."
            // Return to calling (previous) method
            // return;
            if (VacumInput == "0")
            {
                grade = "Any";
            }
            else if (VacumInput == "1")
            {
                grade = "Residential";
            }
            else if (VacumInput == "2")
            {
                grade = "Commercial";
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Write "Possible options:"
            Console.WriteLine("Possible options: ");

            Console.WriteLine("0 – Any");
            Console.WriteLine("1 – 18 Volt");
            Console.WriteLine("2 – 24 Volt");

            Console.WriteLine("Enter voltage: ");

            // Get user input as string
            // Create variable to hold voltage

            string VoltageInput = Console.ReadLine();

            short wattage = 0;

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
            if (VoltageInput == "0")
            {
                wattage = 0;
            }
            else if (VoltageInput == "1")
            {
                wattage = 18;
            }
            else if (VoltageInput == "2")
            {
                wattage = 24;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }


            // Create found variable to hold list of found appliances.
            List<Appliance> foundAppliances = new List<Appliance>();

            // Loop through Appliances
            // Check if current appliance is vacuum
            // Down cast current Appliance to Vacuum object
            // Vacuum vacuum = (Vacuum)appliance;

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;
                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                    // Add current appliance in list to found list
                    if ((VacumInput == "0") || (VacumInput == vacuum.Grade) && (wattage == 0) || (wattage == vacuum.BatteryVoltage))
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(foundAppliances, 0);

        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: ");

            Console.WriteLine("0 – Any");
            Console.WriteLine("1 – Kitchen");
            Console.WriteLine("2 – Work site");

            Console.WriteLine("Enter room type: ");

            // Get user input as string and assign to variable
            string MicroInput = Console.ReadLine();
            // Create character variable that holds room type
            char roomTypes;


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
            if (MicroInput == "0")
            {
                roomTypes = 'A';
            }
            else if (MicroInput == "1")
            {
                roomTypes = 'K';
            }
            else if (MicroInput == "2")
            {
                roomTypes = 'W';
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }


            // Create variable that holds list of 'found' appliances
            List<Appliance> foundAppliances = new List<Appliance>();

            // Loop through Appliances
            // Test current appliance is Microwave
            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Microwave)
                {
                    // Down cast Appliance to Microwave
                    Microwave microwave = (Microwave)appliance;

                    if (roomTypes == microwave.RoomType)
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(foundAppliances, 0);

        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: ");

            Console.WriteLine("0 – Any");
            Console.WriteLine("1 – Quietest");
            Console.WriteLine("2 – Quieter");
            Console.WriteLine("3 – Quiet");
            Console.WriteLine("4 – Moderate");

            Console.WriteLine("Enter sound rating: ");
            // Get user input as string and assign to variable
            string DishInput = Console.ReadLine();
            // Create variable that holds sound rating
            string soundRate = null;

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
            if (DishInput == "0")
            {
                soundRate = "Any";
            }
            else if (DishInput == "1")
            {
                soundRate = "Qt";
            }
            else if (DishInput == "2")
            {
                soundRate = "Qr";
            }
            else if (DishInput == "3")
            {
                soundRate = "Qu";
            }
            else if (DishInput == "4")
            {
                soundRate = "M";
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Create variable that holds list of found appliances
            List<Appliance> foundAppliances = new List<Appliance>();

            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                    // Add current appliance in list to found list
                    if ((DishInput == "0") || (DishInput == dishwasher.SoundRating))
                    {
                        foundAppliances.Add(appliance);
                    }
                }
            }
            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundAppliances, 0);

        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"
            Console.WriteLine("Appliance Types ");

            Console.WriteLine("0 – Any");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            Console.WriteLine("Enter type of appliance: ");

            // Get user input as string and assign to appliance type variable
            string typeInput = Console.ReadLine();

            Console.WriteLine("Enter number of appliance: ");
            // Get user input as string and assign to variable
            string NumOfAppliance = Console.ReadLine();

            // Convert user input from string to int
            int typeOfAppliance = 0;
            typeOfAppliance = int.Parse(NumOfAppliance);

            // Create variable to hold list of found appliances
            List<Appliance> foundAppliances = new List<Appliance>();

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

            foreach (Appliance appliance in Appliances)
            {
                
                if (typeOfAppliance == 0)
                {
                    foundAppliances.Add(appliance);
                }
                else if (typeOfAppliance is Refrigerator)
                {
                    if(typeOfAppliance == 1)
                    {
                        foundAppliances.Add(appliance);
                    }
                else if (typeOfAppliance is Vacuum)
                    {
                        if(typeOfAppliance == 2)
                        {
                            foundAppliances.Add(appliance);
                        }
                        else if(typeOfAppliance is Microwave)
                        {
                            if(typeOfAppliance == 3)
                            {
                                foundAppliances.Add(appliance);
                            }
                            else if(typeOfAppliance is Dishwasher)
                            {
                                if(typeOfAppliance == 4)
                                {
                                    foundAppliances.Add(appliance);
                                }
                            }
                        }
                    }
                }
            }

            // Randomize list of found appliances 
            // found.Sort(new RandomComparer());
            foundAppliances.Sort(new RandomComparer());


            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
            DisplayAppliancesFromList(foundAppliances, typeOfAppliance);

        }
    }
}

