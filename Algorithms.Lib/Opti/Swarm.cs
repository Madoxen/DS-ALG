using System;

namespace Algorithms.Lib.Opti
{
    public class Swarm : IOptiAlg
    {
        private static Random rnd = new Random();
        //Fancy math stuff
        public double[] searchSpace = { -10.0, 10.0 };
        public int dimension = 10;


        public int interCount = 10000;
        public int particleCount = 100;




        public double[] Opti(Func<double[], double> func)
        {
            throw new NotImplementedException();
        }
    }
}