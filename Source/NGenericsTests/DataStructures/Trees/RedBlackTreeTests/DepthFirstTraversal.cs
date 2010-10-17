﻿using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class DepthFirstTraversal : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = new RedBlackTree<string, int>
                                   {
                                       new KeyValuePair<string, int>("horse", 4),
                                       new KeyValuePair<string, int>("cat", 1),
                                       new KeyValuePair<string, int>("dog", 2),
                                       new KeyValuePair<string, int>("canary", 3)
                                   };

            var visitor = new TrackingVisitor<KeyValuePair<string, int>>();

            var inOrderVisitor =
                new InOrderVisitor<KeyValuePair<string, int>>(visitor);

            redBlackTree.DepthFirstTraversal(inOrderVisitor);

            Assert.AreEqual(visitor.TrackingList[0].Key, "canary");
            Assert.AreEqual(visitor.TrackingList[1].Key, "cat");
            Assert.AreEqual(visitor.TrackingList[2].Key, "dog");
            Assert.AreEqual(visitor.TrackingList[3].Key, "horse");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var redBlackTree = GetTestTree(20);
            redBlackTree.DepthFirstTraversal(null);
        }

    }
}