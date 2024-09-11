using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2;

namespace Tarea2
{
    // Argumento de direction
    public enum SortDirection
    {
        Ascendente,//menor a mayor 
        Descendente// mayor a menor 
    }
    public class ListaDoble : IList
    { //Clase de lista doble heredando de IList
        private Nodo? cabeza;
        private Nodo? cola;
        private Nodo? medio;  // Referencia para manejar el nodo central
        private int tamaño;  // Contador de nodos
        public ListaDoble()
        {
            cabeza = null;
            cola = null;
            medio = null;
            tamaño = 0;
        }
      
        //
        // Método para insertar en ORDEN ASCENDENTE
        //
        public void InsertInOrder(int value)
        {
            Nodo nuevo = new Nodo(value);
            if (cabeza == null) // Lista vacía
            {
                cabeza = cola = medio = nuevo;
            }
            else if (value < cabeza.Valor) // Insertar al inicio
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
            }
            else if (value >= cola.Valor) // Insertar al final
            {
                nuevo.Anterior = cola;
                cola.Siguiente = nuevo;
                cola = nuevo;
            }
            else // Insertar en el medio
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null && actual.Siguiente.Valor < value)
                {
                    actual = actual.Siguiente;
                }
                nuevo.Siguiente = actual.Siguiente;
                nuevo.Anterior = actual;
                if (actual.Siguiente != null)
                {
                    actual.Siguiente.Anterior = nuevo;
                }
                actual.Siguiente = nuevo;
            }
            tamaño++;
            ActualizarMedio();
        }
        // Método para eliminar el primer nodo
        public int DeleteFirst()
        {
            if (cabeza == null)
                throw new InvalidOperationException("La lista está vacía.");
            int valor = cabeza.Valor;
            if (cabeza == cola) // Un solo elemento
            {
                cabeza = cola = medio = null;
            }
            else
            {
                cabeza = cabeza.Siguiente;
                if (cabeza != null) cabeza.Anterior= null;
            }
            tamaño--;
            ActualizarMedio();
            return valor;
        }
        // Método para eliminar el último nodo
        public int DeleteLast()
        {
            if (cola == null)
                throw new InvalidOperationException("La lista está vacía.");

            int valor = cola.Valor;
            if (cabeza == cola) // Un solo elemento
            {
                cabeza = cola = medio = null;
            }
            else
            {
                cola = cola.Anterior;
                cola.Siguiente = null;
            }
            tamaño--;
            ActualizarMedio();
            return valor;
        }
        // Método para eliminar un valor específico
        public bool DeleteValue(int value)
        {
            if (cabeza == null)
                return false;
            Nodo actual = cabeza;
            while (actual != null && actual.Valor != value)
            {
                actual = actual.Siguiente;
            }
            if (actual == null) // No encontrado
                return false;
            if (actual == cabeza)
                DeleteFirst();
            else if (actual == cola)
                DeleteLast();
            else // Eliminar nodo en el medio
            {
                actual.Anterior.Siguiente = actual.Siguiente;
                actual.Siguiente.Anterior = actual.Anterior;
            }
            tamaño--;
            ActualizarMedio();
            return true;
        }
        //
        //PROBLEMA #3: OBTENER EL ELEMENTO CENTRAL
        //
        // Método para obtener el nodo central
        public int GetMiddle()
        {
            if (cabeza == null)
                throw new InvalidOperationException("La lista está vacía.");
            return medio.Valor;
        }
        //
        // PROBLEMA #1: MEZCLAR EN ORDEN
        //
        // Método para mezclar dos listas ordenadas
        public void MergeSorted(ListaDoble listA, ListaDoble listB, SortDirection direction)
        {
            if (listA == null || listB == null)
                throw new InvalidOperationException("Una o ambas listas son nulas.");
            // Implementar lógica de mezcla aquí (combinar listA y listB en la dirección indicada)
            Nodo currentA = listA.cabeza;//acceder a la cabeza de listA
            Nodo currentB = listB.cabeza;//acceder a la cabeza de listB

            ListaDoble mergedList = new ListaDoble();
            // Lógica para fusionar en orden ascendente
            if (direction == SortDirection.Ascendente)
            {
                while (currentA != null && currentB != null)
                {
                    if (currentA.Valor <= currentB.Valor)
                    {
                        mergedList.InsertInOrder(currentA.Valor);
                        currentA = currentA.Siguiente;
                    }
                    else
                    {
                        mergedList.InsertInOrder(currentB.Valor);
                        currentB = currentB.Siguiente;
                    }
                }
            }
            // Lógica para fusionar en orden descendente
            else if (direction == SortDirection.Descendente)
            {
                while (currentA != null && currentB != null)
                {
                    if (currentA.Valor >= currentB.Valor)
                    {
                        mergedList.InsertInOrder(currentA.Valor);
                        currentA = currentA.Siguiente;
                    }
                    else
                    {
                        mergedList.InsertInOrder(currentB.Valor);
                        currentB = currentB.Siguiente;
                    }
                }
            }
            // Si quedan elementos en listA
            while (currentA != null)
            {
                mergedList.InsertInOrder(currentA.Valor);
                currentA = currentA.Siguiente;
            }
            // Si quedan elementos en listB
            while (currentB != null)
            {
                mergedList.InsertInOrder(currentB.Valor);
                currentB = currentB.Siguiente;
            }

            // Actualizar listA con la lista fusionada
            listA.cabeza = mergedList.cabeza;
            listA.cola = mergedList.cola;
            listA.ActualizarMedio();//actualiza nodo central 

        }
        //
        //PROBLEMA #2: INVERTIR LISTA
        // Método para invertir la lista
        public void Invert()
        {
            if (cabeza == null)
                return;
            Nodo actual = cabeza;
            Nodo temp = null;

            while (actual != null)
            {
                temp = actual.Anterior;//guarda temporal 
                actual.Anterior = actual.Siguiente;//cambia el codigo anterior 
                actual.Siguiente = temp;//asigna el valor
                actual = actual.Anterior; // Moverse hacia el "siguiente", que es el anterior en la lista invertida
            }
            // Ajustar cabeza y cola
            if (temp != null)
            {
                cabeza = temp.Anterior;//cambia de puntero
            }
            ActualizarMedio();
        }
        // Método para actualizar la referencia al nodo medio
        private void ActualizarMedio()
        {// para saber cual es el centro de la lista.
            if (tamaño == 0)
            {
                medio = null;
                return;
            }
            if (tamaño == 1)
            {
                medio = cabeza;
                return;
            }
            Nodo actual = medio;
            if (tamaño % 2 == 0) // Si el tamaño es par, moverse un nodo hacia atrás
            {
                medio = medio.Anterior;
            }
            else // Si el tamaño es impar, moverse un nodo hacia adelante
            {
                medio = medio.Siguiente;
            }
        }
    }
}