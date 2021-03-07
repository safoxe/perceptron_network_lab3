using System;
namespace perceptron_net
{
    public class Perceptron
    {
        private double[] weights = new double[2];
        private double LearningRate = 0.8;

        public Perceptron() {
            for(int i =0; i< weights.Length; i++) {
                weights[i] = new System.Random().NextDouble();
            }
        }

// гіперболічний тангенс
        private double ActivationFunction(double x) {
            return Math.Tanh(x);
        }

        public double Guess(double[] input) {
            double sum = 0.0;
            for(int i = 0; i< weights.Length; i++) {
                sum += input[i]*weights[i];
            }
            return ActivationFunction(sum);
        }

        public void Train(double[] inputs, double correctVal) {
            double guess = Guess(inputs);
            double err = correctVal - guess;
            for(int i = 0; i< weights.Length; i++) {
                // налаштовуємо ваги таким чином, аби подальші значення були більш наближені
                // до наших бажаних
                weights[i] += err*inputs[i]*LearningRate;
            }
            System.Console.WriteLine($"Training: {guess} guess on {inputs[0]}, {inputs[1]}. error: {err}");
        }


    }
}