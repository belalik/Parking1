using System;

namespace Parking1
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking lalakia = new Parking(6);


            int choice;
            do
            {
                Console.WriteLine("1 - Park Car");
                Console.WriteLine("2 - Remove Car");
                Console.WriteLine("3 - Draw Parking");
                Console.WriteLine("4 - Exit");
                Console.Write("Select: ");

                // prosoxi, an o xristis den dwsei noumero, to programma tha termatistei me lathos.. 
                // tha eprepe na eixa xrisimopoihsei thn TryParse gia na to apofygw auto...
                //int.TryParse(Console.ReadLine(), out choice);
                choice = int.Parse(Console.ReadLine());


                if (choice == 1)
                {
                    // ένα παράδειγμα του πως μπορεί να χρησιμοποιηθεί το bool που επιστρέφει 
                    // η ParkCar, αλλά δίχως ιδιαίτερο νόημα, αφού αντίστοιχο μήνυμα τυπώνει η 
                    // ίδια η ParkCar, και είναι μάλλον καλύτερα να γίνεται εκεί.... 
                    // Δες περισσότερα comments στην κλάση Parking. 
                    bool result = lalakia.ParkCar();

                    if (result)
                    {
                        Console.WriteLine("OK");
                    }
                    else
                    {
                        Console.WriteLine("sorry! ... ");
                    }

                }
                else if (choice == 2)
                {
                    // Εδώ πχ την καλούμε απλώς σα να ήταν void - δεν εκμεταλλευόμαστε το bool που επιστρέφει..
                    lalakia.RemoveCar();
                }
                else if (choice == 3)
                {
                    lalakia.DrawParking();
                }
            } while (choice != 4);


        }
    }
}
