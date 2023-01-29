namespace MarsRover.Test.Utilities
{
    internal class PlanèteBuilder
    {
        private int? _tailleTorique;
        private Point? _obstacleEventuel;

        public PlanèteBuilder ToriqueDeTailleX(int taille)
        {
            _tailleTorique = taille;
            return this;
        }

        public IPlanète Build()
        {
            IPlanète planète = _tailleTorique.HasValue ? new Tore(_tailleTorique.Value) : new PlanèteStub();
            if (_obstacleEventuel is not null) planète = new PlanèteObstacleDecorator(planète, _obstacleEventuel);
            return planète;
        }

        public PlanèteBuilder AyantUnObstacle(int x, int y)
        {
            _obstacleEventuel = new Point(x, y);
            return this;
        }
    }
}
