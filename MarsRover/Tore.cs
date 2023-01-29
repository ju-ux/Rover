namespace MarsRover
{
    public class Tore : IPlanète
    {
        private readonly ushort _taille;

        public Tore(ushort taille)
        {
            _taille = taille;
        }

        public Point Canoniser(Point point)
        {
            return new Point((ushort) (point.X % _taille), (ushort) (point.Y % _taille));
        }

        /// <inheritdoc />
        public bool PossèdeUnObstacle(Point point) => false;
    }
}
