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

            bool isProgramEnd = false;
            Console.WriteLine("---------Sistema de pacientes-----");
            Console.WriteLine("Ingrese el tamaño de la lista");
            try
            {
                int rango = int.Parse(Console.ReadLine());

                //pq.createArray(rango);
                pq.simulate(rango);


                while (!isProgramEnd)
                {

                    Console.WriteLine("------------Método de ordenamiento------------");
                    Console.WriteLine("1.- Ordenar por selectionSort");
                    Console.WriteLine("2.- Ordenar por quickSort");

                    int method = int.Parse(Console.ReadLine());

                    Console.WriteLine("------------Reportes------------");
                    Console.WriteLine("1.- Ordenar por numero de ficha o de llegada");
                    Console.WriteLine("2.- Ordenar por orden de atención");
                    Console.WriteLine("3.- Ordenar por prioridad");
                    Console.WriteLine("4.- salir");
                    int reportNumber = int.Parse(Console.ReadLine());


                    switch (reportNumber)
                    {
                        case 1:
                            if (method == 1)
                            {
                                pq.SelectionSort("NumeroLlegada");
                                pq.showPatients();


                            }
                            else if (method == 2)
                            {
                                pq.orderByQuickSort("NumeroLlegada");
                                pq.showPatients();
                            }
                            break;
                        case 2:
                            if (method == 1)
                            {
                                pq.SelectionSort("NumeroAtendido");
                                pq.showPatients();
                                pq.showCheckedPatients();
                            }
                            else if (method == 2)
                            {
                                pq.orderByQuickSort("NumeroAtendido");
                                pq.showPatients();
                                pq.showCheckedPatients();

                            }
                            break;
                        case 3:
                            Console.WriteLine("---------Ingrese prioridad 1 o 2---------");
                            int prioridad = int.Parse(Console.ReadLine());
                            if (method == 1 && prioridad == 1)
                            {
                                pq.SelectionSort("Prioridad");
                                pq.showPatienByPriority(prioridad);
                            }
                            else if (method == 2 && prioridad == 1)
                            {
                                pq.orderByQuickSort("Prioridad");
                                pq.showPatienByPriority(prioridad);
                            }
                            else if (method == 1 && prioridad == 2)
                            {
                                pq.orderByQuickSort("Prioridad");
                                pq.showPatienByPriority(prioridad);
                            }
                            else if (method == 2 && prioridad == 2)
                            {
                                pq.orderByQuickSort("Prioridad");
                                pq.showPatienByPriority(prioridad);
                            }
                            break;
                        case 4:
                            isProgramEnd = true;
                            break;


                    }


                }
            }
            catch
            {
                Console.WriteLine("Numero no valido");
            }


            /*pq.showPatients();
            pq.addAtendido();
            Console.WriteLine();

            pq.showPatients();
            pq.SelectionSort("NumeroAtendido");
            Console.WriteLine();

            pq.showPatients();
            pq.SelectionSort("NumeroLlegada");

            pq.showPatients();
            pq.showPatienByPriority(1);
            pq.showPatienByPriority(2);*/





        }
    }
}
