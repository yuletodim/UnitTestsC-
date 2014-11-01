namespace CustomLinkedList.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using System.Threading;

    [TestClass]
    public class DynamicListTest
    {
        private static StreamWriter writer;

        [ClassInitialize]
        public static void InitializeLoggingFile(TestContext context)
        {
            writer = new StreamWriter("logs.txt");
            writer.WriteLine("InitializeLoggingFile() method.");
        }

        [ClassCleanup]
        public static void CleanUpLogingFile()
        {
            writer.WriteLine("CleanUpLogingFile() method.");
            writer.Close();
        }

        [TestInitialize]
        public void InitializeTest()
        {
            writer.WriteLine("InitializeTest() method.");
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            writer.WriteLine("CleanUpTest() method.");
        }

        [TestMethod]
        public void CreatingNewEmptyDynamicListShoulReturnEmptyObjectWithCountZero()
        {
            var dynamicList = new DynamicList<int>();

            Assert.AreEqual(0, dynamicList.Count,
                "The count of the empty DynamicList is not 0.");

            writer.WriteLine(
                "CreatingNewEmptyDynamicListShoulReturnEmptyObjectWithCountZero() method.");
        }

        [TestMethod]
        public void AddingNewItemToAnEmptyDynamicListShouldReturnNonemptyObject()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            Assert.AreEqual(3, dynamicList.Count,
                "The count of the empty DynamicList is not 0.");

            writer.WriteLine(
                "AddingNewItemToAnEmptyDynamicListShouldReturnNonemptyObject() method.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Removing element with wrong index position didn't trow an exception.")]
        public void RemovingElementWithIndexOutOfRangeShouldThrowExceptionWrong()
        {
            writer.WriteLine(
                "RemovingElementWithIndexOutOfRangeShouldThrowExceptionWrong() method.");

            var dynamicList = new DynamicList<int>();
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.RemoveAt(3);
        }

        [TestMethod]
        public void RemovingElementByValueShouldReturnTheCurrentIndex()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);
            int i = dynamicList.Remove(2);

            Assert.AreEqual(1, i, "The method Remove() didn't give the write result.");

            writer.WriteLine(
                "RemovingElementByValueShouldReturnTheCurrentIndex() method.");

        }

        [TestMethod]
        public void RemovingElementByNonexistingValueShouldReturnNegative1()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);
            int i = dynamicList.Remove(4);

            Assert.AreEqual(-1, i, "The method Remove() didn't give the right result.");

            writer.WriteLine(
                "RemovingElementByNonexistingValueShouldReturnNegative1() method.");
        }

        [TestMethod]
        public void SearchingForItemByIndexShouldReturnTheIndex()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);
            dynamicList.Add(3);
            dynamicList.Add(3);
            int i = dynamicList.IndexOf(3);

            Assert.AreEqual(2, i,
                "The method IndexOF() didn't return the right index of the looking element.");

            writer.WriteLine(
                "SearchingForItemByIndexShouldReturnTheIndex() method.");
        }

        [TestMethod]
        public void SearchingForNonexistingItemByIndexShouldReturnNegative1()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(1);
            dynamicList.Add(2);
            int i = dynamicList.IndexOf(3);

            Assert.AreEqual(-1, i,
                "The method IndexOF() didn't return -1 index for looking for nonexisting element.");

            writer.WriteLine(
                "SearchingForNonexistingItemByIndexShouldReturnNegative1() method.");
        }

        [TestMethod]
        public void CheckingIfAnExistingItemIsInDynamicListShouldReturnTrue()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            Assert.AreEqual(true, dynamicList.Contains(2),
                "The method Contains() didn't return true when looking for existing item in the list.");

            writer.WriteLine(
                "CheckingIfAnExistingItemIsInDynamicListShouldReturnTrue() method.");
        }

        [TestMethod]
        public void CheckingIfAnNonExistingItemIsInDynamicListShouldReturnFalse()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            Assert.AreEqual(false, dynamicList.Contains(4),
                "The method Contains() didn't return false when looking for non-existing item in the list.");

            writer.WriteLine(
                "CheckingIfAnNonExistingItemIsInDynamicListShouldReturnFalse() method.");
        }

        [TestMethod]
        [Timeout(500)]
        [Ignore]
        public void CheckingForTestTime()
        {
            Thread.Sleep(800);
        }
    }
}