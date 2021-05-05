using FactoryIOC.Enumerator;
using FactoryIOC.Factory;
using FactoryIOC.Shapes;
using System;
using System.Text;

namespace FactoryIOC.Service
{
    public class ShapeCalculationService : IShapeCalculationService
    {
        private readonly IShapeFactory _shapeFactory;
        private IShape _shape;

        public ShapeCalculationService(IShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }

        public string CalculateShapeMeasurements(EShape shape)
        {
            _shape = GetShapeFromUser(shape);

            var sb = new StringBuilder();

            sb.AppendLine(_shape.GenerateValues());
            sb.AppendLine(_shape.GetSurfaceArea());
            sb.AppendLine(_shape.GetVolume());

            return sb.ToString();
        }

        /// <summary>
        /// https://dev.to/chaitanyasuvarna/implementing-factory-pattern-for-dependency-injection-in-net-core-537l
        /// </summary>
        /// <returns></returns>
        private IShape GetShapeFromUser(EShape shape)
        {
            return _shapeFactory.GetShape(shape);
        }
    }
}
