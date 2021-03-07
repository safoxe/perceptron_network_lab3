using System.Collections.Generic;
using System;
using System.Collections;

namespace perceptron_net
{
    public enum Operators
    {
        OR = 1,
        AND = 2,
        NAND = 3,
        XOR = 4
    }
    public class TrainingData
    {
        public double[] Input { get; set; }
        public double CorrectVal { get; set; }

        public TrainingData(double correctVal, params double[] inputs)
        {
            Input = inputs;
            CorrectVal = correctVal;
        }
    }
    public class TrainingDataGenerator
    {
        public List<TrainingData> Data { get; set; }

        public TrainingDataGenerator(int numberOfItems, Operators caseVal)
        {
            Data = new List<TrainingData>();
            for (int i = 0; i < numberOfItems; i++)
            {
                int val1 = new System.Random().Next(0, 2);
                int val2 = new System.Random().Next(0, 2);
                BitArray resultBits = CalculateExpected(caseVal, val1, val2);
                double result = Convert.ToDouble(ToNumeral(resultBits));
                System.Console.WriteLine($"Training data generation: {val1} val1 {caseVal.ToString()} {val2} val2 is {result}");
                Data.Add(new TrainingData(result,  Convert.ToDouble(val1),  Convert.ToDouble(val2)));
            }
        }

        public int ToNumeral(BitArray binary)
        {
            if (binary == null)
                throw new ArgumentNullException("binary");
            if (binary.Length > 32)
                throw new ArgumentException("must be at most 32 bits long");

            var result = new int[1];
            binary.CopyTo(result, 0);
            return result[0];
        }

        public BitArray CalculateExpected(Operators caseVal, int val1, int val2)
        {
            switch (caseVal)
            {
                // OR
                case Operators.OR: return new BitArray(BitConverter.GetBytes(val1)).Or(new BitArray(BitConverter.GetBytes(val2)));
                // AND
                case Operators.AND: return new BitArray(BitConverter.GetBytes(val1)).And(new BitArray(BitConverter.GetBytes(val2)));
                // NAND
                case Operators.NAND: return new BitArray(BitConverter.GetBytes(val2)).Not().And(new BitArray(BitConverter.GetBytes(val1)));
                // XOR
                case Operators.XOR: return new BitArray(BitConverter.GetBytes(val1)).Xor(new BitArray(BitConverter.GetBytes(val2)));

                default: return new BitArray(2);
            }
        }
    }
}