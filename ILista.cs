using System;
using System.Reflection.Metadata.Ecma335;

namespace Tarea2
{
     public interface IList 
    {
        Nodo Cabeza { get; }
        Nodo Cola{get; }
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
     
        void MergeSorted(IList listA, IList listB, SortDirection direction);
    }
    
}
