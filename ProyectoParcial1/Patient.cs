using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial1
{
    class Patient
    {
        private int numero;
        private int prioridad;
        private bool estado;
        //private Patient next;

        public int Numero { get; set; }
        public int Prioridad { get; set; }
        public bool Estado { get; set; }
        //internal Patient Next { get => next; set => next = value; }

        public Patient(int numero, int prioridad, bool estado)
        {
            this.Numero = numero;
            this.Prioridad = prioridad;
            this.Estado = estado;
            //this.Next = next;
        }
    }
}
