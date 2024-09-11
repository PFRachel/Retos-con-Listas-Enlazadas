using Tarea2;

namespace Tarea2
{
    [TestClass]
    public class ListaDobleTests
    {
        [TestMethod]
        public void InsertInOrder_InsertaValoresEnOrdenAscendente()
        {
            // Arrange
            var lista = new ListaDoble();

            // Act
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(20);

            // Assert
            Assert.AreEqual(10, lista.GetMiddle(), "El valor del medio deberia ser 10");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetMiddle_ListaVacia_DebeLanzarExcepcion()
        {
            // Arrange
            var lista = new ListaDoble();

            // Act & Assert
            lista.GetMiddle(); // Debe lanzar una excepcion porque la lista esta vacia
        }

        [TestMethod]
        public void DeleteFirst_EliminaElPrimerNodoCorrectamente()
        {
            // Arrange
            var lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(20);
            lista.InsertInOrder(30);

            // Act
            var eliminado = lista.DeleteFirst();

            // Assert
            Assert.AreEqual(10, eliminado, "El primer nodo eliminado deberia ser 10");
            Assert.AreEqual(20, lista.GetMiddle(), "El nuevo valor del medio deberia ser 20");
        }

        public void DeleteLast_EliminaElUltimoNodoCorrectamente()
        {
            // Arrange
            var lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(20);
            lista.InsertInOrder(30);

            // Act
            var eliminado = lista.DeleteLast();

            // Assert
            Assert.AreEqual(30, eliminado, "El ultimo nodo eliminado deberia ser 30");
            Assert.AreEqual(20, lista.GetMiddle(), "El nuevo valor del medio deberia ser 20");
        }

        [TestMethod]
        public void DeleteValue_EliminaValorEspecifico()
        {
            // Arrange
            var lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(20);
            lista.InsertInOrder(30);

            // Act
            var eliminado = lista.DeleteValue(20);

            // Assert
            Assert.IsTrue(eliminado, "El valor 20 deberia haberse eliminado correctamente");
            Assert.AreEqual(10, lista.GetMiddle(), "El nuevo valor del medio deberia ser 10");
        }

        [TestMethod]
        public void DeleteValue_NoEliminaValorInexistente()
        {
            // Arrange
            var lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(20);

            // Act
            var eliminado = lista.DeleteValue(30);

            // Assert
            Assert.IsFalse(eliminado, "El valor 30 no deberia existir en la lista");
        }

        [TestMethod]
        public void Invert_InvierteLaListaCorrectamente()
        {
            // Arrange
            var lista = new ListaDoble();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            // Act
            lista.Invert();

            // Assert
            Assert.AreEqual(2, lista.GetMiddle(), "Despues de invertir, el valor medio deberia ser 2");
        }

        [TestMethod]
        public void MergeSorted_CombineDosListasAscendente()
        {
            // Arrange
            var listaA = new ListaDoble();
            listaA.InsertInOrder(0);
            listaA.InsertInOrder(2);
            listaA.InsertInOrder(6);

            var listaB = new ListaDoble();
            listaB.InsertInOrder(3);
            listaB.InsertInOrder(7);

            // Act
            listaA.MergeSorted(listaA, listaB, SortDirection.Ascendente);

            // Assert
            Assert.AreEqual(3, listaA.GetMiddle(), "Despues de mezclar, el valor medio deberia ser 3");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MergeSorted_ListaANull_DebeLanzarExcepcion()
        {
            // Arrange
            var listaA = (ListaDoble)null; // Lista A es nula
            var listaB = new ListaDoble();
            listaB.InsertInOrder(1);

            // Act & Assert
            new ListaDoble().MergeSorted(listaA, listaB, SortDirection.Ascendente); // Debe lanzar una excepcion
        }

        [TestMethod]
        public void MergeSorted_CombineDosListasDescendente()
        {
            // Arrange
            var listaA = new ListaDoble();
            listaA.InsertInOrder(15);
            listaA.InsertInOrder(10);

            var listaB = new ListaDoble();
            listaB.InsertInOrder(9);
            listaB.InsertInOrder(40);

            // Act
            listaA.MergeSorted(listaA, listaB, SortDirection.Descendente);

            // Assert
            Assert.AreEqual(15, listaA.GetMiddle(), "Despues de mezclar en orden descendente, el valor medio deberia ser 15");
        }
    }
}