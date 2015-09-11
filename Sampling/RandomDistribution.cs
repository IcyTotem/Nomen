using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomen.Sampling
{
    class RandomDistribution<T>
    {
        private IDictionary<T, double> weights;
        private Random generator;
        private double total;

        public RandomDistribution()
        {
            this.total = 0;
            this.generator = new Random();
            this.weights = new Dictionary<T, double>();
        }

        public void Set(T value, double p)
        {
            if (weights.ContainsKey(value))
                total -= weights[value];

            weights[value] = p;
            total += p;
        }

        public T Sample()
        {
            var x = generator.NextDouble() * total;
            var sum = 0.0;

            foreach (var entry in weights)
            {
                var t = x - sum;

                if (t < 0)
                    break;

                if (t < entry.Value)
                    return entry.Key;

                sum += entry.Value;
            }

            return weights.Last().Key;
        }
    }
}
