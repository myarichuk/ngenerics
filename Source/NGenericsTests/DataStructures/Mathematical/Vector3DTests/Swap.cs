﻿using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Swap
    {

        [Test]
        public void Vector3d()
        {
            var vector1 = new Vector3D(1, 2, 3);

            var vector2 = new Vector3D(3, 4, 6);

            vector1.Swap(vector2);

            Assert.AreEqual(3, vector1.X);
            Assert.AreEqual(4, vector1.Y);
            Assert.AreEqual(6, vector1.Z);

            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(2, vector2.Y);
            Assert.AreEqual(3, vector2.Z);
        }

        [Test]
        public void IVector()
        {
            var vector3D = new Vector3D(1, 2, 3);

            var vectorN = new VectorN(3);
            vectorN.SetValues(3, 4, 6);

            vector3D.Swap(vectorN);

            Assert.AreEqual(3, vector3D.X);
            Assert.AreEqual(4, vector3D.Y);
            Assert.AreEqual(6, vector3D.Z);

            Assert.AreEqual(1, vectorN[0]);
            Assert.AreEqual(2, vectorN[1]);
            Assert.AreEqual(3, vectorN[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullOther()
        {
            var vector = new Vector3D();
            vector.Swap(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector = new Vector3D();
            VectorBase<double> vectorBase = new VectorN(4);
            vector.Swap(vectorBase);
        }

    }
}