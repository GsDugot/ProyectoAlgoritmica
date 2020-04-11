using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial1
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
            Console.ReadLine();
        }
        public static void run()
        {
            PatientQueue pq = new PatientQueue();
            pq.createArray();
        }
    }
}
