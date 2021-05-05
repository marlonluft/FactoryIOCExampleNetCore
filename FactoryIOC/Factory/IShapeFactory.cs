using FactoryIOC.Enumerator;
using FactoryIOC.Shapes;

namespace FactoryIOC.Factory
{
    public interface IShapeFactory
    {
        public IShape GetShape(EShape shapeEnum);
    }
}
