namespace MarsRover.Commandes
{
    public class TournerADroiteCommande : IRoverCommande
    {
        /// <inheritdoc />
        public (Orientation Orientation, Point Position, Point? ObstacleEventuel) Traiter(Orientation orientation, Point position, IPlanète _)
        {
            return (orientation.MouvementDextrogyre, position, default);
        }
    }
}