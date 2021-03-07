using System;

namespace perceptron_net
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("--------Training OR Perceptron-----------");
            var perceptronOR = new Perceptron();
            TrainingDataGenerator trainingData1 = new TrainingDataGenerator(500, Operators.OR);
            foreach (var data in trainingData1.Data)
            {
                perceptronOR.Train(data.Input, data.CorrectVal);
            }
            System.Console.WriteLine("----------------------------------");

            System.Console.WriteLine("--------Training NAND Perceptron-----------");
            var perceptronNAND = new Perceptron();
            TrainingDataGenerator trainingData2 = new TrainingDataGenerator(500, Operators.NAND);
            foreach (var data in trainingData2.Data)
            {
                perceptronNAND.Train(data.Input, data.CorrectVal);
            }
            System.Console.WriteLine("----------------------------------");

            System.Console.WriteLine("--------Training AND Perceptron-----------");
            var perceptronAND = new Perceptron();
            TrainingDataGenerator trainingData = new TrainingDataGenerator(1500, Operators.AND);
            foreach (var data in trainingData.Data)
            {
                perceptronAND.Train(data.Input, data.CorrectVal);
            }
            System.Console.WriteLine("----------------------------------");

            System.Console.WriteLine("--------GETTING XOR VALUE-----------");
            double[] inputs = { 0.0, 1.0 };
            System.Console.WriteLine($"Input {inputs[0]}, {inputs[1]}");
            var NANDVal = perceptronNAND.Guess(inputs);
            var ORVal = perceptronOR.Guess(inputs);

            double[] resInputs = { NANDVal, ORVal };
            var XORVal = perceptronAND.Guess(resInputs);
            System.Console.WriteLine($"Result: {XORVal}");
        }
    }
}
