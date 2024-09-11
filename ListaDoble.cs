using System;

namespace Tarea2
{
     public class ListaDoble : IList
    {
        private Nodo cabeza;
        private Nodo cola;
        public Nodo Cabeza
        {
            get { return cabeza; }
        }
        public Nodo Cola
        {
            get { return cola; }
        }
      
        public ListaDoble()
        {
            cabeza = null;
            cola = null;
        }
        public void InsertInOrder(int value)
        {
            Nodo nuevoNodo = new Nodo(value);

            // Si la lista está vacía
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            // Si el valor es menor o igual al valor de la cabeza (insertar al principio)
            else if (value <= cabeza.Value)
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza.Anterior = nuevoNodo;
                cabeza = nuevoNodo;
            }
            // Si el valor es mayor o igual al valor de la cola (insertar al final)
            else if (value >= cola.Value)
            {
                cola.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = cola;
                cola = nuevoNodo;
            }
            // Si el valor debe ir en algún lugar intermedio
            else
            {
                Nodo actual = cabeza;
                while (actual != null && actual.Value < value)
                {
                    actual = actual.Siguiente;
                }

                // Inserta el nuevo nodo antes del nodo actual
                Nodo anterior = actual.Anterior;
                anterior.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = anterior;
                nuevoNodo.Siguiente = actual;
                actual.Anterior = nuevoNodo;
            }
        }

        public int DeleteFirst()
        {
            //implementacion
            return -1;
        }
        public int DeleteLast()
        {
            return -1;
        }
        public bool DeleteValue(int value)
        {
            return false;
        }
        public int GetMiddle()
        {
            return -1;
        }
        public void MergeSorted(IList listA, IList listB, SortDirection direction)
        {
            if (listA == null || listB == null)
            {
                throw new ArgumentNullException("Una o ambas listas son nulas");
            }
            Nodo currentA = listA.Cabeza;
            Nodo currentB = listB.Cabeza;

            ListaDoble mergedList = new ListaDoble();
            if (direction == SortDirection.Ascendente)
            {
                while(currentA != null && currentB != null)
                {
                    if (currentA.Value <= currentB.Value)
                    {
                        mergedList.InsertInOrder(currentA.Value);
                        currentA = currentA.Siguiente;
                    }
                    else
                    {
                        mergedList.InsertInOrder(currentB.Value);
                        currentB = currentB.Siguiente;
                    }

                }
            }
            else if (direction == SortDirection.Descendente)
            {
                while(currentA != null && currentB != null)
                {
                    if(currentA.Value>= currentB.Value)
                    {
                        mergedList.InsertInOrder(currentA.Value);
                        currentA = currentA.Siguiente;
                    }
                    else
                    {
                        mergedList.InsertInOrder(currentB.Value);
                        currentB = currentB.Siguiente;

                    }
                
                }
            }
            while(currentA != null)
            {
                mergedList.InsertInOrder(currentA.Value);
                currentA = currentA.Siguiente;
            }
            while(currentB != null)
            {
                mergedList.InsertInOrder(currentB.Value);
                currentB = currentB.Siguiente;
            }
            this.cabeza = mergedList.Cabeza;
            this.cola = mergedList.Cola;
        }
        
        //PROBLEMA #1: MEZCLAR EN ORDEN

        //PROBLEMA #2: INVERTIR LISTA

        // Metodo PROBLEMA #3: OBTENER EL ELEMENTO CENTRAL
    }
}