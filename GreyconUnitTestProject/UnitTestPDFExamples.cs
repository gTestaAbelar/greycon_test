using Greycon_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreyconUnitTestProject
{
    [TestClass]
    public class UnitTestPDFExamples
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            int[] used = new int[] { 300, 525, 110 };
            int[] total = new int[] { 350, 600, 115 };
            int expected = 2;
            DiskSet disksSet = new DiskSet(used, total);

            // Act
            int actual = Utils.packData(disksSet);

            // Assert
            Assert.AreEqual(expected, actual, "No es correcta la solucion");
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            int[] used = new int[] { 1, 200, 200, 199, 200, 200 };
            int[] total = new int[] { 1000, 200, 200, 200, 200, 200 };
            int expected = 1;
            DiskSet disksSet = new DiskSet(used, total);

            // Act
            int actual = Utils.packData(disksSet);

            // Assert
            Assert.AreEqual(expected, actual, "No es correcta la solucion");
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            int[] used = new int[] { 750, 800, 850, 900, 950 };
            int[] total = new int[] { 800, 850, 900, 950, 1000 };
            int expected = 5;
            DiskSet disksSet = new DiskSet(used, total);

            // Act
            int actual = Utils.packData(disksSet);

            // Assert
            Assert.AreEqual(expected, actual, "No es correcta la solucion");
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Arrange
            int[] used = new int[] { 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49 };
            int[] total = new int[] { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
            int expected = 49;
            DiskSet disksSet = new DiskSet(used, total);

            // Act
            int actual = Utils.packData(disksSet);

            // Assert
            Assert.AreEqual(expected, actual, "No es correcta la solucion");
        }

        [TestMethod]
        public void TestMethod5()
        {
            // Arrange
            int[] used = new int[] { 331, 242, 384, 366, 428, 114, 145, 89, 381, 170, 329, 190, 482, 246, 2, 38, 220, 290, 402, 385 };
            int[] total = new int[] { 992, 509, 997, 946, 976, 873, 771, 565, 693, 714, 755, 878, 897, 789, 969, 727, 765, 521, 961, 906 };
            int expected = 6;
            DiskSet disksSet = new DiskSet(used, total);

            // Act
            int actual = Utils.packData(disksSet);

            // Assert
            Assert.AreEqual(expected, actual, "No es correcta la solucion");
        }

        [TestMethod]
        public void TestMethod6()
        {
            // Arrange
            int[] used = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] total = new int[] { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
            int expected = 0;
            DiskSet disksSet = new DiskSet(used, total);

            // Act
            int actual = Utils.packData(disksSet);

            // Assert
            Assert.AreEqual(expected, actual, "No es correcta la solucion");
        }

        [TestMethod]
        public void TestMethod7()
        {
            // Arrange
            int[] used = new int[] { 800, 850, 900, 950, 1000 };
            int[] total = new int[] { 800, 850, 900, 950, 1000 };
            int expected = 5;
            DiskSet disksSet = new DiskSet(used, total);

            // Act
            int actual = Utils.packData(disksSet);

            // Assert
            Assert.AreEqual(expected, actual, "No es correcta la solucion");
        }

        [TestMethod]
        public void TestMethod8()
        {
            // Arrange
            int[] used = new int[0];
            int[] total = new int[0];
            int expected = 0;
            DiskSet disksSet = new DiskSet(used, total);

            // Act
            int actual = Utils.packData(disksSet);

            // Assert
            Assert.AreEqual(expected, actual, "No es correcta la solucion");
        }

    }
}
