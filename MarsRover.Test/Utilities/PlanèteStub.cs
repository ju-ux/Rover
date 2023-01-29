namespace MarsRover.Test.Utilities
{
    internal class PlanèteStub : IPlanète
    {
        /// <inheritdoc />
        public Point Canoniser(Point point) => point;

        /// <inheritdoc />
        public bool PossèdeUnObstacle(Point point) => default;
    }
}
