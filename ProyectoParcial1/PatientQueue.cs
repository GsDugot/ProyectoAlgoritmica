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
        Patient pat3;

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
            //showPatients();
        }
        public void addPatient(int indx, int prior, bool state)
        {

            if (pat == null)
            {
                pat = new Patient(indx, prior, state, 0, null);
                pat2 = pat;
                pat3 = pat;
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
            while (aux != null)
            {
                Console.WriteLine("No. paciente: " + aux.NumeroLlegada + " prioridad: " + aux.Prioridad +
                   " estado: " + aux.Estado + " No. Atendido: " + aux.NumeroAtendido);
                aux = aux.Next;
            }
        }

        public void prioritySort(string OrdenType)
        {

            Patient auxHead = pat2;
            int size = getSize();
            for (int x = 0; x < size; x++)//n-1
            {
                int minimo = getData(OrdenType, x); ;//numberArray[x];//1
                int indice = x;//1
                for (int y = x + 1; y < size; y++)//n-1				{

                {
                    int actualData = getData(OrdenType, y);
                    if (actualData <= minimo)//3
                    {
                        //minimo = actualData;//1
                        indice = y;//1

                    }
                }
                if (indice != x)

                {
                    cambiarDatos(x, indice);
                }

                //numberArray[indice] = numberArray[x];//1
                //numberArray[x] = minimo;//1



            }
        }
        public int getSize()
        {
            Patient aux = pat2;
            int size = 0;
            while (aux != null)
            {

                aux = aux.Next;
                size++;
            }
            return size;
        }
        public void cambiarDatos(int posicion1, int posicion2)
        {
            Patient p1 = null;
            Patient p2 = null;
            Patient aux = pat2;
            Patient auxNext = null;
            Patient auxNext2 = null;

            for (int x = 0; x <= posicion2; x++)
            {

                if (x == posicion1)
                {
                    p1 = new Patient(aux.NumeroLlegada, aux.Prioridad, aux.Estado, aux.NumeroAtendido, aux.Next);

                    auxNext = new Patient(aux.NumeroLlegada, aux.Prioridad, aux.Estado, aux.NumeroAtendido, aux.Next);
                }
                else if (x == posicion2)
                {
                    p2 = new Patient(aux.NumeroLlegada, aux.Prioridad, aux.Estado, aux.NumeroAtendido, aux.Next);
                    auxNext2 = new Patient(aux.NumeroLlegada, aux.Prioridad, aux.Estado, aux.NumeroAtendido, aux.Next);

                }
                aux = aux.Next;
            }
            // p1.NumeroAtendido = p2.NumeroAtendido;
            //p1.NumeroLlegada = p2.NumeroLlegada;
            //p1.Prioridad = p2.Prioridad;
            //p2.NumeroAtendido = auxNext.NumeroAtendido;
            //p2.NumeroLlegada = auxNext.NumeroLlegada;
            //p2.Prioridad = auxNext.Prioridad;
            // p2 = auxNext;
            // p1.Next = p2;
            //p2.Next =auxNext.Next;
            aux = pat2;
            for (int x = 0; x <= posicion2; x++)
            {

                if (x == posicion1 - 1 && posicion1 != 0)
                {
                    p2.Next = auxNext.Next;
                    aux.Next = p2;

                    //auxNext = new Patient(aux.NumeroLlegada, aux.Prioridad, false, aux.NumeroAtendido, null);
                }
                else if (x == posicion1 && posicion1 == 0)
                {
                    //  p2 = auxNext2;
                    p2.Next = auxNext.Next;
                    aux = p2;
                    pat2 = aux;
                }


                else if (x == posicion2 - 1)
                {
                    p1.Next = auxNext2.Next;
                    aux.Next = p1;
                }

                aux = aux.Next;
            }

        }
        public void addAtendido()
        {
            Patient aux = pat2;
            int ind = 15;
            while (aux != null)
            {

                aux.NumeroAtendido = ind;
                ind--;
                aux = aux.Next;
            }
        }
        public int getData(string data, int pos)
        {
            Patient aux = pat2;
            for (int x = 0; x < pos; x++)
            {
                aux = aux.Next;
            }
            switch (data)
            {
                case "NumeroLlegada":
                    return aux.NumeroLlegada;

                case "Prioridad":
                    return aux.Prioridad;
                case "NumeroAtendido":
                    return aux.NumeroAtendido;
                default:
                    return 0;

            }
        }

        public void showPatienByPriority(int prioridad)
        {
            prioritySort("NumeroAtendido");
            Patient aux = pat2;

            Console.WriteLine("prioridad {0}", prioridad);

            while (aux != null)
            {
                if (aux.Prioridad == prioridad)
                {
                    Console.WriteLine("No. paciente: " + aux.NumeroLlegada + " prioridad: " + aux.Prioridad +
                       " estado: " + aux.Estado + " No. Atendido: " + aux.NumeroAtendido);
                }
                aux = aux.Next;
            }
        }



    }
}
