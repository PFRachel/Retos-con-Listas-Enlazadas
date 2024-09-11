using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2;

namespace Tarea2
{ // Definicion de la interface IList 
    public interface IList
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(ListaDoble listA, ListaDoble listB, SortDirection direction);
    }
}

