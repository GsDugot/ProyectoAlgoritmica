using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial1
{
    class PatientQueue
    {

        Stopwatch sw = new Stopwatch();

        LinkedList<Patient> list = new LinkedList<Patient>();
        int size = 0;
        int index = 0;
        int prior = 0;
        bool state = false;
        static Random random = new Random();
        Patient pat;

        public void createArray()
        {

            Console.WriteLine("Ingrese tamaño del arreglo");
            int length = Int32.Parse(Console.ReadLine());
            size = length;

            Console.WriteLine("Arreglo desordenado: \n");

            for (int i = 0; i < size; i++)
            {
                index = i + 1;
                prior = random.Next(1, 3);
                state = false;

                pat = new Patient(index, prior, state);

                list.AddLast(pat);

               // Console.WriteLine("Paciente " + list.Numero + " > indice: " + index +
                //    " prioridad: "+ prior + " estado: " + state);
            }
            foreach (var element in list)
            {
                Console.WriteLine("Paciente " + (element.Numero +1) + " > indice: " + element.Numero +
                    " prioridad: " + element.Prioridad + " estado: " + element.Estado);
            }
        }
    }
}
