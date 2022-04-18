using System;
using Automarket.Domain.Enum;

namespace Automarket.Domain.Entity
{
    public class Car
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Model { get; set; }
        
        public double Speed { get; set; }
        
        public decimal Price { get; set; }
        
        public DateTime DateCreate { get; set; }
        
        public TypeCar TypeCar { get; set; }
        
        public byte[]? Avatar { get; set; }
    }
}