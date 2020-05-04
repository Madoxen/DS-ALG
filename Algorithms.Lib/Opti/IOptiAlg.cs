using System;

namespace Algorithms.Lib.Opti
{
    public interface IOptiAlg
    {
        /// <summary>
        /// Tries to find global minimum
        /// </summary>
        /// <param name="func">1D Function to find global minimum of </param>
        /// <returns>global minimum X coord</returns>
        double[] Opti(Func<double[], double> func);

        
    }


}