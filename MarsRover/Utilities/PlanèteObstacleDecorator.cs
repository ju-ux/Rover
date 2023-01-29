namespace MarsRover.Test.Utilities
{
    internal class PlanèteObstacleDecorator : IPlanète
    {
        private readonly IPlanète _planète;
        private readonly Point _obstacle;

        public PlanèteObstacleDecorator(IPlanète planète, Point obstacle)
        {
            _planète = planète;
            _obstacle = obstacle;
        }

        /// <inheritdoc />
        public Point Canoniser(Point point) => _planète.Canoniser(point);

        /// <inheritdoc />
        public bool PossèdeUnObstacle(Point point)
        {
            return point == _obstacle || _planète.PossèdeUnObstacle(point);
        }
    }
}
