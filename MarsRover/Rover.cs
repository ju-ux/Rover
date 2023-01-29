using System;
using MarsRover.Commandes;

namespace MarsRover
{
    public class Rover
    {
        private readonly IPlanète _planète;
        private Point _coordonnées;
        private Orientation _orientation;

       /* public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }
        public ILandingSurface LandingSurface { get; }
       */
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
        /*
        public void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.g:
                    TournerAGaucheCommande();
                    break;
                case Movement.d:
                    TournerADroiteCommande();
                    break;
                case Movement.a:
                    AvancerCommande();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(movement), movement, null);
            }
        }

        private void AvancerCommande()
        {
            switch (Direction)
            {
                case Direction.N:
                    if (Y + 1 <= LandingSurface.Size.Height)
                        Y += 1;
                    break;

                case Direction.E:
                    if (X + 1 <= LandingSurface.Size.Width)
                        X += 1;
                    break;

                case Direction.S:
                    if (Y - 1 >= 0)
                        Y -= 1;
                    break;

                case Direction.W:
                    if (X - 1 >= 0)
                        X -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TournerAGaucheCommande()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;

                case Direction.W:
                    Direction = Direction.S;
                    break;

                case Direction.S:
                    Direction = Direction.E;
                    break;

                case Direction.E:
                    Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TournerADroiteCommande()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.E;
                    break;

                case Direction.E:
                    Direction = Direction.S;
                    break;

                case Direction.S:
                    Direction = Direction.W;
                    break;

                case Direction.W:
                    Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return $"{X} {Y} {Direction:G}";
        }*/
    }
}