using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial1
{
    class Patient
    {


        public int Numero { get; set; }
        public int Prioridad { get; set; }
        public bool Estado { get; set; }
        public Patient Next { get; set; }

        public Patient(int numero, int prioridad, bool estado, Patient next)
        {
            this.Numero = numero;
            this.Prioridad = prioridad;
            this.Estado = estado;
            this.Next = next;
        }
    }
}
