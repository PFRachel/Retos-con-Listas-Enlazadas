//TAREA EXTRACLASE 2
//Retos con Listas Enlazadas
using System;

namespace Tarea2
{
    public enum SortDirection
    {
        Ascendente,
        Descendente
    }
    public interface IList 
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(IList listA, IList listB, SortDirection direction);
        
    }
}
