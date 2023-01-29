namespace MarsRover
{
    public class Tore : IPlanète
    {
        private readonly int _taille;

        public Tore(int taille)
        {
            _taille = taille;
        }

        public Point Canoniser(Point point)
        {
            return new Point((point.X % _taille), (point.Y % _taille));
        }

        /// <inheritdoc />
        public bool PossèdeUnObstacle(Point point) => false;
    }
}
