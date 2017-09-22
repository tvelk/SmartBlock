using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBlock
{
    class Brain
    {
        private List<Neuron> inputNodes;
        private List<Neuron> hiddenNodes;
        private List<Neuron> outputNodes;
        private int numInputs;
        private int numInputNodes;
        private int numHiddenNodes;
        private int numOutputsNodes;
        private double learningRate;
        private int iterations;


        public Brain(int inputs, int inputNodeQty, int hiddenNodeQty, int outputNodeQty)
        {
            learningRate = 0.7;
            iterations = 1000;
            numInputs = inputs;
            numInputNodes = inputNodeQty;
            numHiddenNodes = hiddenNodeQty;
            numOutputsNodes = outputNodeQty;
            inputNodes = InitializeNeurons(numInputNodes, 1);
            hiddenNodes = InitializeNeurons(numHiddenNodes, numInputNodes);
            outputNodes = InitializeNeurons(numOutputsNodes, numHiddenNodes);
        }

        public void MarginOfError(double xMargin, double yMargin)
        {

        }

        public List<double> Calculate(List<double> inputValues)
        {
            List<double> results = new List<double>();
            results = Iterate(inputNodes, inputValues);
            results = Iterate(hiddenNodes, results);
            results = Iterate(outputNodes, results);
            return results;
        }

        private List<double> Iterate(List<Neuron> neurons, List<double> inputs)
        {
            List<double> outputs = new List<double>();
            for(int i = 0; i < neurons.Count; i++)
            {
                outputs.Add(neurons[i].Calculate(inputs));
            }
            return outputs;
        }

        private List<Neuron> InitializeNeurons(int qtyToMake, int inputs)
        {
            List<Neuron> list = new List<Neuron>();
            for(int i = 0; i < qtyToMake; i++)
            {
                Neuron neuron = new Neuron(inputs);
                list.Add(neuron);
            }
            return list;
        }
    }
}
