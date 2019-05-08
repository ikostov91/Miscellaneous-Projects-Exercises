using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte sByteTypeOne = -44;
            sbyte sbyteTypeTwo = -115; 
            byte byteTypeOne = 224;
            byte byteTypeThree = 97;
            byte byteTypeTwo = 112;
            short shortTypeOne = -10000;
            short shortTypeTwo = 1990;
            ushort ushortTypeOne = 20000;
            ushort ushortTypeTwo = 52130;
            int intTypeOne = 4825932;
            int intTypeTwo = -1000000;
            long longTypeOne = 970700000;
            ulong ulongTypeOne = 123456789123456789;

            Console.WriteLine($"{sByteTypeOne}" + Environment.NewLine +
                                $"{sbyteTypeTwo}" + Environment.NewLine +
                                $"{byteTypeOne}" + Environment.NewLine +
                                $"{byteTypeTwo}" + Environment.NewLine +
                                $"{byteTypeThree}" + Environment.NewLine +
                                $"{shortTypeOne}" + Environment.NewLine +
                                $"{shortTypeTwo}" + Environment.NewLine +
                                $"{ushortTypeOne}" + Environment.NewLine +
                                $"{ushortTypeTwo}" + Environment.NewLine +
                                $"{intTypeOne}" + Environment.NewLine +
                                $"{intTypeTwo}" + Environment.NewLine +
                                $"{longTypeOne}" + Environment.NewLine +
                                $"{ulongTypeOne}");
        }
    }
}
