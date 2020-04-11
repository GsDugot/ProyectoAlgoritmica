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

        int size = 0;
        int index = 0;
        int prior = 0;
        bool state = false;
        int numAten = 0;
        static Random random = new Random();
        Patient pat;
        Patient pat2;

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

                addPatient(index, prior, state);
            }
            showPatients();
        }
        public void addPatient(int indx, int prior, bool state)
        {
            
            if (pat == null)
            {
                pat = new Patient(indx, prior, state, 0, null);
                pat2 = pat;
            }
            else
            {
                Patient recent = new Patient(indx, prior, state, 0, null);
                Patient aux = pat;
                pat = recent;
                aux.Next = pat;
            }
        }
        public void showPatients()
        {
            Patient aux = pat2;
            while (aux.Next != null)
            {
                Console.WriteLine("No. paciente: " + aux.NumeroLlegada + " prioridad: " + aux.Prioridad +
                   " estado: " + aux.Estado + " No. Atendido: " + aux.NumeroAtendido);
                aux = aux.Next;
            }
        }
    }
}
