using System;

namespace PriceService.Models
{
    public class Price
    {
        public Guid Id => Guid.NewGuid();
        public Guid ProductId => Guid.NewGuid();
        public double RRP => new Random().NextDouble();
        public double Sale => new Random().NextDouble();
        public double Cost => new Random().NextDouble();
    }
}
