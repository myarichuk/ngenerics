using FizzWare.NBuilder;
using NGenerics.DataStructures.Trees;
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Search
    {
        #region Test Object Definitions
        private class DummyObject
        {
            public int Property1 { get; set; }

            public string Property2 { get; set; }
        }

        private class DummyObjectComparer : IComparer<DummyObject>
        {
            private DummyObjectComparer() { }

            private static DummyObjectComparer m_Instance;

            public static DummyObjectComparer Instance
            {
                get
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new DummyObjectComparer();
                    }
                    return m_Instance;
                }
            }

            public int Compare(DummyObject x, DummyObject y)
            {
                if (x == null || y == null) return 0;
                return x.Property1.CompareTo(y.Property1);
            }
        }
        #endregion

        [Test]
        public void SimpleKeySearch()
        {
            const string VALUE_TO_FIND = "This is a dummy string";
            const int KEY_TO_FIND = 33;
            var tree = new BinarySearchTree<int,string>()
                           {
                               new KeyValuePair<int,string>(11,"Just Another String"),
                               new KeyValuePair<int,string>(22,"String Value"),
                               new KeyValuePair<int,string>(33,VALUE_TO_FIND),
                               new KeyValuePair<int,string>(44,"Another Dummy String"),
                           };

            var searchResult = tree.Search(kvp => KEY_TO_FIND.CompareTo(kvp.Key));
            Assert.AreEqual(searchResult.Value, VALUE_TO_FIND);
        }

        [Test]
        public void StringKeySearch()
        {
            const string ENDING_OF_STRING_TO_FIND = "test";
            var tree = new BinarySearchTree<string, int>()
                           {
                               new KeyValuePair<string, int>("Just Another String", 2),
                               new KeyValuePair<string, int>("String key", 3),
                               new KeyValuePair<string, int>("This is a test", 123),
                               new KeyValuePair<string, int>("Dummy string", 4),
                           };
            
            var searchResult = tree.Search(kvp =>
                {
                    if (kvp.Key.EndsWith(ENDING_OF_STRING_TO_FIND)) return 0;
                    else return ENDING_OF_STRING_TO_FIND.CompareTo(kvp.Key);
                });

            Assert.AreEqual(123, searchResult.Value);
        }

        [Test]
        public void ObjectKeySearch()
        {
            var dummyObjects = Builder<DummyObject>.CreateListOfSize(10).Build().ToList();
            var treeData = new List<KeyValuePair<DummyObject, int>>();
            int index = 1;
            dummyObjects.ForEach(dummyObject => treeData.Add(new KeyValuePair<DummyObject, int>(dummyObject, index++)));

            var tree = new BinarySearchTree<DummyObject, int>(DummyObjectComparer.Instance);
            treeData.ForEach(dataItem => tree.Add(dataItem));

            var targetItem = treeData[4];

            var searchResult = tree.Search(kvp => DummyObjectComparer.Instance.Compare(targetItem.Key, kvp.Key));

            Assert.AreEqual(searchResult.Value, targetItem.Value);
        }
    }
}
