using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBlock
{
    class Neuron
    {
        private List<double> inputWeights;
        private int numInputs;
        private double inputSum;

        public Neuron(int inputs)
        {
            numInputs = inputs;
            inputWeights = InitializeWeights(numInputs);
        }

        public double Calculate(List<double> inputValues)
        {
            inputSum = 0;
            for(int i = 0; i < inputValues.Count; i++)
            {
                inputSum += inputValues[i] * inputWeights[i];
            }
            return ActivationFunction();
        }

        private double ActivationFunction()
        {
            double result = 1.0 / (1.0 + Math.Exp(-1.0 * inputSum));
            return result;
        }

        private List<double> InitializeWeights(int qtyToMake)
        {
            List<double> list = new List<double>();
            for(int i = 0; i < qtyToMake; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                double weight = rand.NextDouble();
                list.Add(weight);
            }
            return list;
        }
    }
}
