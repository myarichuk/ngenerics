﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class GetEnumerator
    {

        [Test]
        public void Simple()
        {
            var circularQueue = CircularQueueTest.GetFullTestQueue();

            var list = new List<int>();

            using (var enumerator = circularQueue.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }
            }

            Assert.AreEqual(list.Count, 200);

            for (var i = 0; i < 200; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }

        [Test]
        public void Interface()
        {
            IEnumerable circularQueue = CircularQueueTest.GetFullTestQueue();

            var list = new List<int>();

            var enumerator = circularQueue.GetEnumerator();

            while (enumerator.MoveNext())
            {
                list.Add((int)enumerator.Current);
            }

            Assert.AreEqual(list.Count, 200);

            for (var i = 0; i < 200; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }

    }
}