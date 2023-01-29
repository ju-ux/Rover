using MarsRover.Commandes;

namespace MarsRover
{
    public class Rover
    {
        private readonly IPlanète _planète;
        private Point _coordonnées;
        private Orientation _orientation;

        public Rover(IPlanète planète, Point coordonnéesDépart, Orientation orientation)
        {
            _planète = planète;
            _coordonnées = coordonnéesDépart;
            _orientation = orientation;
        }

        public (Orientation Orientation, Point Position, Point? ObstacleEventuel) Traiter(params IRoverCommande[] commandesATraiter)
        {
            foreach (var commande in commandesATraiter)
            {
                var final = commande.Traiter(_orientation, _coordonnées, _planète);
                _orientation = final.Orientation;
                _coordonnées = final.Position;

                if(final.ObstacleEventuel is not null)
                    return (_orientation, _coordonnées, final.ObstacleEventuel);
            }

            return (_orientation, _coordonnées, default);
        }
    }
}
