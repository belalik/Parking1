using System;
using System.Collections.Generic;
using System.Text;

namespace Parking1
{
    /**
     * v1.0
     * 
     * Ίσως η πιο σημαντική κλάση γιατί υλοποιεί την βασικότερη "λογική" του προγράμματος.
     * Είναι μια απλή υλοποίηση στην οποία καταλήξαμε κατά την διάρκεια του εργαστηρίου. 
     * Σίγουρα μπορεί να βελτιωθεί πολύ - θα δούμε λεπτομέρειες σε επόμενα εργαστήρια.
     * 
     * Ένα σημείο που θέλει προσοχή είναι το γεγονός πως οι μέθοδοι ParkCar και RemoveCar 
     * ενώ επιστρέφουν bool (και αυτό συχνά ακολουθείται για να μεταφέρει την "πληροφορία" 
     * αν οι συγκεκριμένες προσπάθειες ήταν επιτυχείς ή όχι), ουσιαστικά δεν εκμεταλλευόμαστε
     * αυτό το γεγονός εκεί που καλούνται (στη Main) και θα μπορούσαν κάλλιστα να είναι void. 
     * 
     * Τις αφήνουμε όμως bool και θα συζητήσουμε αυτό το συγκεκριμένο σημείο στο εργαστήριο..
     * 
     */
    class Parking
    {

        // Constructor tis klasis Parking pou dexetai ena int gia tin xoritikotita
        public Parking(int capacity)
        {
            // Sto Property Capacity tha ekxwrithei i eiserxomeni parametros gia xwritikothta
            Capacity = capacity;

            // Ftiaje keni lista
            Slots = new List<Slot>();

            // gemise lista me osa Slot antikeimena prepei (oso kai i xoritikothta tou parking)
            // Ola ta Slot antikeimena tha paroun auksonta arithmo gia thesi
            // kai ola tha ksekinisoun me IsFree=true kai ParkedCar=null (des constructor klasis Slot). 
            for (int i = 0; i < capacity; i++)
            {
                Slots.Add(new Slot(i));
            }

        }

        // Property pou krataei tin xwritikotita tou parking (poses theseis tha exei), typos: int
        public int Capacity { get; set; }

        // Property pou krataei mia lista apo theseis, typos: List<Slot>
        // Auto to property ousiastika krataei oles tis theseis (Slot) pou tha exei to parking
        public List<Slot> Slots { get; set; }

        /*
         * Methodos pou prospathei na "parkarei" ena car stin proti eleutheri thesi. 
         * - Epistrefei true an to parkarisma einai efikto (ypirxe eleutheri thesi kai den eixa idi car me autin tin pinakida)
         * - Epistrefei false an to parkarisma den einai efikto (den ypirxe eleutheri thesi i eixa idi amaji me idia pinakida!)
         */
        public bool ParkCar()
        {

            // bres to proto index eleutheris thesis (-1 an den brethei kamia)
            int firstFreeIndex = FindFirstFreeSlot();

            // an brikes -1, to parking einai full
            if (firstFreeIndex == -1)
            {
                Console.WriteLine("Sorry, to parking einai full");
                return false;
            }
            // an brikes eleutheri thesi
            else
            {
                // diabase pinakida apo xristi
                Console.WriteLine("hello, give me your plate: ");
                string plate = Console.ReadLine();

                // yparxei idi amaji me autin tin pinakida!  Epestrepse false, den thelw na exw dyo amajia me idies pinakides!
                // ypothetw pws egine lathos stin eisagogi pinakidas
                if (FindPlate(plate) != -1)
                {
                    Console.WriteLine($"ERROR - A car already exists with license plate: {plate}");
                    return false;
                }

                // an ftasw edw, ola einai ok, proxwraw me to 'parkarisma' tou sygekrimenou car
                Car c = new Car(plate);
                Slots[firstFreeIndex].IsFree = false;
                Slots[firstFreeIndex].ParkedCar = c;
                return true;
                // epistrefw true - to parkarisma itan epityxes

            }
        }

        /**
         * Methodos pou "kseparkarei" ena autokinito
         */
        public bool RemoveCar()
        {
            Console.WriteLine("Give me plate: ");
            string plate = Console.ReadLine();

            // psaxnw na dw an yparxei parkarismeno amaji me autin tin pinakida
            int plateIndex = FindPlate(plate);

            // an parw -1, den yparxei auto to amaji - epistrefw false
            if (plateIndex == -1)
            {
                Console.WriteLine($"No car with plate: {plate} is parked in our parking!");
                return false;
            }
            // alliws brika auto to amaji, opote kanw to 'kseparkarisma':
            // - to IsFree tou sygekrimenou slot ginetai pali true
            // - to ParkedCar pou eixe, ginetai null

            // Sti synexeia, enimerwnw me ena katallilo minima kai epistrefw true (to RemoveCar itan epityxes)
            else
            {
                Console.WriteLine($"OK, Car with plate: {plate} is removed!");
                Slots[plateIndex].IsFree = true;
                Slots[plateIndex].ParkedCar = null;

                return true;
            }


        }


        /**
         * Private methodos pou psaxnei na brei an yparxei amaji me tin sygekrimeni pinakida sto parking
         * An brei, gyrnaei tin thesi tou. 
         * An den brei, gyrnaei -1
         */
        private int FindPlate(string plate)
        {
            // psaxnw tin lista
            for (int i = 0; i < Slots.Count; i++)
            {
                // mono gia opoies theseis DEN einai Free
                // (an den to ekana auto, tha eixa NullPointer lathos, diladi tha epsaxna na elegxw pinakida
                // se amaji pou den yparxei (einai null) !
                if (Slots[i].IsFree == false)
                {
                    // psaxnw an i pinakida tou parkarismenou car einai i sygekrimeni
                    if (Slots[i].ParkedCar.Plate == plate)
                    {
                        // an brw pinakida, epistrefw tin thesi stin opoia tin brika
                        return i;
                    }

                }
            }
            // An ftasw edw, den brika pote tin pinakida, opote epistrefw -1
            return -1;
        }


        /**
         * Private methodos pou psaxnei na brei tin prwti eleutheri thesi sto parking
         * An brei, gyrnaei ton arithmo tis thesis mesa sti lista 
         * An den brei, gyrnaei -1
         */
        private int FindFirstFreeSlot()
        {

            // psaxe oli ti lista
            for (int i = 0; i < Slots.Count; i++)
            {
                // an breis eleutheri thesi
                if (Slots[i].IsFree == true)
                {
                    // epestrepse tin thesi tis listas stin opoia tin brikes
                    return i;

                }
            }
            // an ftasw edw, den brika kamia eleutheri thesi, opote epistrefw -1
            return -1;
        }


        /**
         * Methodos pou 'zwgrafizei' to parking me enan aplo tropo. 
         */
        public void DrawParking()
        {

            for (int i = 0; i < Slots.Count; i++)
            {
                if (Slots[i].IsFree)
                {
                    Console.Write("O ");
                }
                else
                {
                    Console.Write("X ");
                }
            }
            // dyo kenes grammes gia na jexwrizei apo tin ektypwsi tou menu
            Console.WriteLine();
            Console.WriteLine();

        }

    }
}
