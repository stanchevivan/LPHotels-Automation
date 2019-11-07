using System;
using System.Security.Cryptography;

namespace Common
{
    public static class RandomGenerator
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string Numbers = "0123456789";
        private static readonly Random Random;

        static RandomGenerator()
        {
            var cryptoResult = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(cryptoResult);
            var seed = BitConverter.ToInt32(cryptoResult, 0);
            Random = new Random(seed);
        }

        public static string AlphaNumeric(int length)
        {
            return NextFromString(length, Chars);
        }

        public static string OnlyLetters(int length)
        {
            return NextFromString(length, Letters);
        }

        public static string OnlyNumeric(int length)
        {
            return NextFromString(length, Numbers);
        }

        public static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = Random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

        public static int RandomIntBetween(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue + 1);
        }

        public static object RandomValueType(Type type, int length = 10)
        {
            if (!type.IsValueType && type != typeof(string))
            {
                throw new Exception();
            }

            switch (type.Name)
            {
                case "String":
                    return AlphaNumeric(5);

                case "Int32":
                case "Int64":
                    return (int)RandomNumberBetween(1, length);

                case "Double":
                    return RandomNumberBetween(0, length);

                case "Decimal":
                    return (decimal)RandomNumberBetween(0, length);

                default:
                    return null;
            }
        }

        private static string NextFromString(int length, string str)
        {
            var stringChars = new char[length];

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = str[Random.Next(str.Length)];
            }

            return new string(stringChars);
        }

        public static bool RandomBoolean()
        {
            return new Random().Next(2) == 0;
        }

        public static T PickRandomEnumValue<T>()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("The type passed is not enum");
            }

            var enumValues = Enum.GetValues(typeof(T));

            return (T)enumValues.GetValue(RandomIntBetween(0, enumValues.Length - 1));
        }

        public static decimal RandomDecimal()
        {
            var doubleValue = new Random().NextDouble() + RandomIntBetween(10, 1000);

            var valueToReturn = decimal.Parse($"{doubleValue,0:0.00}");

            return valueToReturn;
        }
    }
}
