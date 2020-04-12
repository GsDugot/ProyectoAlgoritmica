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
            //pq.cambiarDatos(0, 4);
            //pq.cambiarDatos(1, 5);
            pq.addAtendido();

            // pq.showPatients();
            pq.prioritySort("NumeroAtendido");

            pq.showPatients();
            pq.prioritySort("NumeroLlegada");
            pq.showPatients();
            pq.showPatienByPriority(1);
            pq.showPatienByPriority(2);




        }
    }
}
