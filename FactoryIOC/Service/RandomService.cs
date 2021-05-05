using System;

namespace FactoryIOC.Service
{
    public class RandomService : IRandomService
    {
        public decimal Get()
        {
            var _rng = new Random();

            return new decimal(_rng.Next(50, 150),
                               0,
                               0,
                               false,
                               2);
        }
    }
}
