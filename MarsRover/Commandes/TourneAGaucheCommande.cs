namespace MarsRover.Commandes
{
    public class TourneAGaucheCommande : IRoverCommande
    {
        /// <inheritdoc />
        public (Orientation Orientation, Point Position, Point? ObstacleEventuel) Traiter(Orientation orientation, Point position, IPlanète _)
        {
            return (orientation.MouvementSinistrogyre, position, default);
        }
    }
}