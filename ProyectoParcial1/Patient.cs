using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParcial1
{
    class Patient
    {


        public int NumeroLlegada { get; set; }
        public int Prioridad { get; set; }
        public bool Estado { get; set; }
        public int NumeroAtendido { get; set; }
        public Patient Next { get; set; }

        public Patient(int numeroLlegada, int prioridad, bool estado, int numeroAtendido, Patient next)
        {
            this.NumeroLlegada = numeroLlegada;
            this.Prioridad = prioridad;
            this.Estado = estado;
            this.NumeroAtendido = numeroAtendido;
            if (next != null)
            {
                this.Next = new Patient(next.NumeroLlegada, next.Prioridad, next.Estado, next.NumeroAtendido, next.Next);
            }
            else
            {
                this.Next = next;
            }
        }
    }
}
