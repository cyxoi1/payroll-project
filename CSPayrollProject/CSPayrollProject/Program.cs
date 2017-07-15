using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public float TotalPay() { get; protected set; }

        public float BasicPay() { get; private set; }

        public string NameOfStaff() { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        public Staff(string name, float rate)
        // Parent constructor for Staff class
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
