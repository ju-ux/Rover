namespace MarsRover.Commandes
{
    public interface IRoverCommande
    {
        (Orientation Orientation, Point Position, Point? ObstacleEventuel) 
            Traiter(Orientation orientation, Point position, IPlanète planète);
    }
}