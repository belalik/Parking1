using System;
using System.Collections.Generic;
using System.Text;

namespace Parking1
{
    class Slot
    {
        /*
         * Constructor klasis Slot.  Kaleitai opote dimiourgw mia nea (keni) thesi. 
         * Dexetai mia parametro pou antistoixei ston arithmo tis thesis.
         * To IsFree ginetai true (i thesi otan dimiourgeitai einai keni)
         * To ParkedCar ginetai null (to Car se keni thesi einai null)
         * 
         */
        public Slot(int index)
        {
            Index = index;
            IsFree = true;
            ParkedCar = null;
        }

        // Property pou krataei ton arithmo tis thesis, typos: int
        public int Index { get; set; }

        // Property pou krataei an i thesi einai keni, typos: bool
        public bool IsFree { get; set; }

        // Property pou krataei ton autokinito sthn thesi, typos: Car
        public Car ParkedCar { get; set; }


    }
}
