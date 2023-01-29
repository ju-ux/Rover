namespace MarsRover
{
    public interface IPlanète
    {
        Point Canoniser(Point point);

        bool PossèdeUnObstacle(Point point);
    }
}