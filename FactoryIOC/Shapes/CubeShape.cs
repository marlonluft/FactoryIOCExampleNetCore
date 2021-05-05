using FactoryIOC.Service;

namespace FactoryIOC.Shapes
{
    public class CubeShape : IShape
    {
        private readonly IRandomService _randomService;

        public CubeShape(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public decimal Side { get; set; }

        public string GenerateValues()
        {
            Side = _randomService.Get();

            return $"Cube Side: {Side}";
        }

        public string GetSurfaceArea()
        {
            return $"Surface Area of the Cube is: {(6 * Side * Side)}";
        }

        public string GetVolume()
        {
            return $"Volume of the Cube is: {(Side * Side * Side)}";
        }
    }
}
