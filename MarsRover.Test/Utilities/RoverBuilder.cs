namespace MarsRover.Test.Utilities
{
    internal class RoverBuilder
    {
        private Orientation _orientation = Orientation.Nord;
        private Point _positionDépart = new (0, 0);
        private IPlanète _planète = new PlanèteStub();

        public RoverBuilder Orienté(Orientation orientation)
        {
            _orientation = orientation;
            return this;
        }

        public RoverBuilder Positionné(ushort x, ushort y)
        {
            _positionDépart = new Point(x, y);
            return this;
        }

        public RoverBuilder SurUnePlanète(Func<PlanèteBuilder, PlanèteBuilder> configuration)
        {
            var planèteBuilder = new PlanèteBuilder();
            _planète = configuration(planèteBuilder).Build();
            return this;
        }

        public Rover Build()
        {
            return new Rover(_planète, _positionDépart, _orientation);
        }
    }
}
