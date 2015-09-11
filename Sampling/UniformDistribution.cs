using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomen.Sampling
{
    class UniformDistribution<T> : RandomDistribution<T>
    {
        public UniformDistribution(IEnumerable<T> values)
        {
            this.AddAll(values);
        }

        public UniformDistribution(params T[] values)
        {
            this.AddAll(values);
        }

        private void AddAll(IEnumerable<T> values)
        {
            foreach (var value in values)
                base.Set(value, 1.0);
        }
    }
}
