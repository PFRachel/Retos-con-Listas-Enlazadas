using System;
namespace Tarea2
{
    public class Nodo
    {
        public int Value {get; set; }
        public Nodo Siguiente {get; set; }
        public Nodo Anterior { get; set; }
        public Nodo(int value)
        {
            Value = value;
            Siguiente = null;
            Anterior = null;
        }

    }
}