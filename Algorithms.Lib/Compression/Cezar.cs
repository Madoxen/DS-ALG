namespace Algorithms.Lib.Encoding
{
    public static class Cezar
    {
        public static string Encode(string input, int shift)
        {
            char[] arr = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[i] = (char)((int)input[i] + shift);
            }
            return new string(arr);
        }

        //Decoding is just encoding with negative shift
        public static string Decode(string input, int shift)
        {
            return Encode(input, -shift);
        }

    }


}
