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
        Patient patArrival;

        public void createArray()
        {
               Console.WriteLine("Ingrese tamaño del arreglo");
               int length = Int32.Parse(Console.ReadLine());
               size = length;

               for (int i = 0; i < size; i++)
               {
                   index = i + 1;
                   prior = random.Next(1, 3);

                   addPatient(index, prior, state);
               }              

            quickSort(pat2, pat);

            showPatientsArrivalOrder(patArrival);

        }
        public void addPatient(int indx, int prior, bool state)
        {
            
            if (pat == null)
            {
                pat = new Patient(indx, prior, state, 0, null);
                pat2 = pat;
                patArrival = pat;
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
        public void showPatientsArrivalOrder(Patient first)
        {

            while (first != null)
            {
                Console.WriteLine("No. paciente: " + first.NumeroLlegada + " prioridad: " + first.Prioridad +
                   " estado: " + first.Estado + " No. Atendido: " + first.NumeroAtendido);
                first = first.Next;
            }
        }
       public Patient partition(Patient left, Patient right)
       {
            if(left == right || left == null || left == null)
            {
                return left;
            }
            Patient i = left;
            Patient j = left;
            int piv = right.NumeroLlegada;

            while (left != right && left != null)
            {
                if (left.NumeroLlegada < piv)
                {
                    i = j;
                    int tmp = j.NumeroLlegada;
                    j.NumeroLlegada = left.NumeroLlegada;
                    left.NumeroLlegada = tmp;
                    j = j.Next;
                }
                left = left.Next;
            }
            if (left != null)
            {
                int tmp2 = j.NumeroLlegada;
                j.NumeroLlegada = piv;
                right.NumeroLlegada = tmp2;
            }
           
            return i;
       }
        public void quickSort(Patient first, Patient last)
        {
            if (first == last)
            {
                return;
            }

            Patient pivotNode = partition(first, last);
            quickSort(first, pivotNode);
            Patient current = pivotNode;
           
            if (pivotNode != null && pivotNode == first)
            {
                quickSort(pivotNode.Next, last);
            }
            else if (pivotNode != null && pivotNode.Next != null)
            {
                quickSort(pivotNode.Next.Next, last);
            }
        }
    }
}
