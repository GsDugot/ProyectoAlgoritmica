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
        Patient pat3;
        Patient checkedPat;

        public void createArray(int length)
        {
            size = length;

            for (int i = 0; i < size; i++)
            {
                index = random.Next(1,size);
                prior = random.Next(1, 3);

                addPatient(index, prior, state);
            }

            //orderByQuickSort("NumeroLlegada");
            //addAtendido();
            //showPatientsArrivalOrder(patArrival);


           // addPatient(index, prior, state);
        }
        //showPatients();

        public void simulate(int length)
        {
            int n = 0;
            int checkNum = 1;
            bool isAllChecked = false;
            int numeroPatient = 0;
            while (!isAllChecked)
            {
                if (numeroPatient < length)
                {
                    int priority = random.Next(1, 3);
                    addPatient(numeroPatient + 1, priority, false);
                    orderByQuickSort("Prioridad");
                    numeroPatient++;
                }
                if(n ==2 && pat2 !=null)
                {
                    moveToChecked(checkNum);
                    n = 0;
                    checkNum++;
                    pat2 = pat2.Next;

                }else
                {
                    n++;
                }
                if(pat2== null && length ==numeroPatient)
                {
                    isAllChecked = true;
                }
                //moveToChecked(checkNum);
                  //      n = n + 3;
                    //    checkNum++;
                    
                   
                
            }
            showPatients();
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

        public void moveToChecked(int num)
        {
            Patient auxH = pat2;

            //  while (aux.Next.Next != null)
            // {
            //   aux = aux.Next;
            //}
            if (checkedPat == null)
            {
                checkedPat = new Patient(auxH.NumeroLlegada, auxH.Prioridad, true, num, null);
                pat3 = checkedPat;
                patArrival = checkedPat;

            }
            else
            {
                Patient recent = new Patient(auxH.NumeroLlegada, auxH.Prioridad, true, num, null);
                Patient aux = checkedPat;
                checkedPat = recent;
                aux.Next = checkedPat;
            }
        }
        public void showPatients()
        {
            Patient aux = pat3;
            while (aux != null)
            {
                Console.WriteLine("No. paciente: " + aux.NumeroLlegada + " prioridad: " + aux.Prioridad +
                   " estado: " + aux.Estado + " No. Atendido: " + aux.NumeroAtendido);
                aux = aux.Next;
            }
        }

        public void showPatients(Patient first)
        {

            while (first != null)
            {
                Console.WriteLine("No. paciente: " + first.NumeroLlegada + " prioridad: " + first.Prioridad +
                   " estado: " + first.Estado + " No. Atendido: " + first.NumeroAtendido);
                first = first.Next;
            }
        }
        public void showCheckedPatients()
        {
            showPatients(checkedPat);
        }

        public Patient Partition(Patient left, Patient right, string sortBy)
        {

            if (left == right || left == null || left == null)
            {
                return left;
            }
            Patient i = left;
            Patient j = left;
            int piv = right.NumeroLlegada;
            int piv2 = right.Prioridad;
            int piv3 = right.NumeroAtendido;
            switch (sortBy)
            {
                case "NumeroLlegada":

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

                case "Prioridad":

                    while (left != right && left != null)
                    {
                        if (left.Prioridad < piv2)
                        {
                            i = j;
                            int tmp = j.Prioridad;
                            j.Prioridad = left.Prioridad;
                            left.Prioridad = tmp;
                            j = j.Next;
                        }
                        left = left.Next;
                    }
                    if (left != null)
                    {
                        int tmp2 = j.Prioridad;
                        j.Prioridad = piv2;
                        right.Prioridad = tmp2;
                    }
                    return i;

                case "NumeroAtendido":

                    while (left != right && left != null)
                    {
                        if (left.NumeroAtendido < piv3)
                        {
                            i = j;
                            int tmp = j.NumeroAtendido;
                            j.NumeroAtendido = left.NumeroAtendido;
                            left.NumeroAtendido = tmp;
                            j = j.Next;
                        }
                        left = left.Next;
                    }
                    if (left != null)
                    {
                        int tmp2 = j.NumeroAtendido;
                        j.NumeroAtendido = piv3;
                        right.NumeroAtendido = tmp2;
                    }
                    return i;
            }
            return i;

        }

        public void orderByQuickSort(string by)
        {
            quickSort(pat2, pat, by);
        }

        public void quickSort(Patient first, Patient last, string order)
        {
            if (first == last)
            {
                return;
            }

            Patient pivotNode = Partition(first, last, order);
            quickSort(first, pivotNode, order);
            Patient current = pivotNode;

            if (pivotNode != null && pivotNode == first)
            {
                quickSort(pivotNode.Next, last, order);
            }
            else if (pivotNode != null && pivotNode.Next != null)
            {
                quickSort(pivotNode.Next.Next, last, order);
            }
        }


        public void SelectionSort(string OrdenType)
        {

            Patient auxHead = pat3;
            int size = getSize();
            for (int x = 0; x < size - 1; x++)//n-1
            {
                int minimo = getData(OrdenType, x); ;//numberArray[x];//1
                int indice = x;//1
                for (int y = x + 1; y < size; y++)//n-1				{
                {
                    int actualData = getData(OrdenType, y);
                    if (actualData < minimo)//3
                    {
                        minimo = actualData;//1
                        indice = y;//1

                    }
                }
                if (indice != x)

                {
                    cambiarDatos(x, indice);
                }

            }
        }
        public int getSize()
        {
            Patient aux = pat3;
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
            Patient aux = pat3;
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
            aux = pat3;
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
            int ind = 100;
            while (aux != null)
            {

                aux.NumeroAtendido = random.Next(1, 100);
                aux = aux.Next;
            }
        }
        public int getData(string data, int pos)
        {
            Patient aux = pat3;
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
            SelectionSort("NumeroAtendido");
            Patient aux = pat3;

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




