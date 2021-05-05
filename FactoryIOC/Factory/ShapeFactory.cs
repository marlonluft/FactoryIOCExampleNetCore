using FactoryIOC.Enumerator;
using FactoryIOC.Shapes;
using System;

namespace FactoryIOC.Factory
{
    public class ShapeFactory : IShapeFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ShapeFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IShape GetShape(EShape shapeEnum)
        {
            return shapeEnum switch
            {
                EShape.Cube => (IShape)_serviceProvider.GetService(typeof(CubeShape)),
                EShape.Sphere => (IShape)_serviceProvider.GetService(typeof(SphereShape)),
                _ => throw new ArgumentOutOfRangeException(nameof(shapeEnum), shapeEnum, $"Shape of {shapeEnum} is not supported."),
            };
        }
    }
}
