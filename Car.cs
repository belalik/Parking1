using System;
using System.Collections.Generic;
using System.Text;

namespace Parking1
{
    class Car
    {
        // Constructor klasis Car
        public Car(string plate)
        {
            Plate = plate;
        }

        // Property pou krataei toin pinakida tou Car, typos: string
        public string Plate { get; private set; }

    }
}
