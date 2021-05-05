using FactoryIOC.Service;

namespace FactoryIOC.Shapes
{
    public class SphereShape : IShape
    {
        private readonly IRandomService _randomService;

        public SphereShape(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public decimal Radius { get; set; }

        public string GenerateValues()
        {
            Radius = _randomService.Get();

            return $"Sphere radius: {Radius}";
        }

        public string GetSurfaceArea()
        {
            return $"Surface Area of the sphere is: {(4 * 3.14m * Radius * Radius)}";
        }

        public string GetVolume()
        {
            return $"Volume of the sphere is: {(4 / 3 * 3.14m * Radius * Radius * Radius)}";
        }
    }
}
