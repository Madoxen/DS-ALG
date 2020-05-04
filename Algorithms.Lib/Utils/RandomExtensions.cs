using System;

namespace Algorithms.Lib.Utils
{
    public static class RandomExtensions
    {
        public static double NextGaussian(this Random rnd, double mean, double deviation)
        {
            Random rand = new Random(); //reuse this if you are generating many
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal = mean + deviation * randStdNormal; //random normal(mean,stdDev^2)
            return randNormal;
        }

        public static double RandomNormal(this Random r, double min, double max, int tightness)
        {
            double total = 0.0;
            for (int i = 1; i <= tightness; i++)
            {
                total += r.NextDouble();
            }
            return ((total / tightness) * (max - min)) + min;
        }

        public static double RandomNormalDist(this Random r, double min, double max, int tightness, double exp)
        {
            double total = 0.0;
            for (int i = 1; i <= tightness; i++)
            {
                total += Math.Pow(r.NextDouble(), exp);
            }

            return ((total / tightness) * (max - min)) + min;
        }


        public static double RandomBiasedPow(this Random r, double min, double max, int tightness, double peak)
        {
            // Calculate skewed normal distribution, skewed by Math.Pow(...), specifiying where in the range the peak is
            // NOTE: This peak will yield unreliable results in the top 20% and bottom 20% of the range.
            //       To peak at extreme ends of the range, consider using a different bias function

            double total = 0.0;
            double scaledPeak = peak / (max - min) + min;

            if (scaledPeak < 0.2 || scaledPeak > 0.8)
            {
                throw new Exception("Peak cannot be in bottom 20% or top 20% of range.");
            }

            double exp = GetExp(scaledPeak);

            for (int i = 1; i <= tightness; i++)
            {
                // Bias the random number to one side or another, but keep in the range of 0 - 1
                // The exp parameter controls how far to bias the peak from normal distribution
                total += BiasPow(r.NextDouble(), exp);
            }

            return ((total / tightness) * (max - min)) + min;
        }

        public static double GetExp(double peak)
        {
            // Get the exponent necessary for BiasPow(...) to result in the desired peak 
            // Based on empirical trials, and curve fit to a cubic equation, using WolframAlpha
            return -12.7588 * Math.Pow(peak, 3) + 27.3205 * Math.Pow(peak, 2) - 21.2365 * peak + 6.31735;
        }

        public static double BiasPow(double input, double exp)
        {
            return Math.Pow(input, exp);
        }
    }
}