using Greycon_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace GreyconUnitTestProject
{
    [TestClass]
    public class UnitTestExceptions
    {
        [TestMethod]
        public void DifferentSizeDisks()
        {
            try
            {
                int[] used = new int[] { 300, 525, 110, 50 };
                int[] total = new int[] { 350, 600, 115 };

                DiskSet disksSet = new DiskSet(used, total);
                // Test fails if it makes it this far
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ValidationException ex)
            {
                Assert.AreEqual("NOTEQUALS", ex.Message);
            }
        }

        [TestMethod]
        public void DiskMoreThan50Elements()
        {
            try
            {
                int[] used = new int[] { 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49 };
                int[] total = new int[] { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };


                DiskSet disksSet = new DiskSet(used, total);
                // Test fails if it makes it this far
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ValidationException ex)
            {
                Assert.AreEqual("TOOLARGE", ex.Message);
            }
        }

        [TestMethod]
        public void UsedBiggerThanTotal()
        {
            try
            {
                int[] used = new int[] { 360, 525, 110 };
                int[] total = new int[] { 350, 600, 115 };

                DiskSet disksSet = new DiskSet(used, total);
                // Test fails if it makes it this far
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ValidationException ex)
            {
                Assert.AreEqual("USEDGREATHER", ex.Message);
            }
        }

        [TestMethod]
        public void TotalOutOfRange()
        {
            try
            {
                int[] used = new int[] { 1000, 525, 110 };
                int[] total = new int[] { 1100, 600, 115 };

                DiskSet disksSet = new DiskSet(used, total);
                // Test fails if it makes it this far
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ValidationException ex)
            {
                Assert.AreEqual("TOTALOUTOFRANGE", ex.Message);
            }
        }

        [TestMethod]
        public void UsedOutOfRange()
        {
            try
            {
                int[] used = new int[] { 1200, 525, 110 };
                int[] total = new int[] { 1000, 600, 115 };

                DiskSet disksSet = new DiskSet(used, total);
                // Test fails if it makes it this far
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ValidationException ex)
            {
                Assert.AreEqual("USEDOUTOFRANGE", ex.Message);
            }
        }
    }
}
