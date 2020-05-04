using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class OptimizationFunctionTest
    {
        [TestMethod]
        /// <summary>
        /// Checks if optimization functions calculate correctly
        /// </summary>
        public void TestOptimizationFunctionsMinima()
        {
            Dictionary<IOptiTestFunc, double[]> functionInputPairs = new Dictionary<IOptiTestFunc, double[]>()
            {
                [new Rastragin()] = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                [new Rosenbrock()] = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                [new HyperEllipsoid()] = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
              //  [new Shubert()] = new double[] { 0, 0},
                [new Sphere()] = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                [new SumSquares()] = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                [new StyblinskiTang(10)] = new double[] { -2.9, -2.9, -2.9, -2.9, -2.9, -2.9, -2.9, -2.9, -2.9, -2.9 },
                [new Weierstrass()] = new double[] { -0.5, -0.5, -0.5, -0.5, -0.5, -0.5, -0.5, -0.5, -0.5, -0.5 },
            };

            foreach (KeyValuePair<IOptiTestFunc, double[]> pair in functionInputPairs)
            {
                Assert.AreEqual(pair.Key.MinimumValue, pair.Key.Func(pair.Value), 1, "Value does not match with expectation: " + pair.Key.GetType().ToString() + " fault");
            }
        }

    }

}