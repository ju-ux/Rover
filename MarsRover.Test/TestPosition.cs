using MarsRover.Commandes;
using MarsRover.Test.Utilities;

namespace MarsRover.Test
{
    public class TestPosition
    {
        [Fact]
        public void TestAvancer()
        {
            // ETANT DONNE une planète Tore de taille 2
            // ET un rover positionné en 0,0 orienté Nord
            var rover = new RoverBuilder()
                .SurUnePlanète(planète => planète.ToriqueDeTailleX(2))
                .Orienté(Orientation.Nord)
                .Positionné(0, 0)
                .Build();

            // QUAND on lui demande d'avancer
            var positionFinale = rover.Traiter(new AvancerCommande()).Position;

            // ALORS la position renvoyée est de 0,1
            Assert.Equal(new Point(0, 1), positionFinale);
        }

        [Fact]
        public void TestAvancerBoucle()
        {
            // ETANT DONNE une planète Tore de taille 2
            // ET un rover positionné en 0,0 orienté Nord
            var rover = new RoverBuilder()
                .SurUnePlanète(planète => planète.ToriqueDeTailleX(2))
                .Orienté(Orientation.Nord)
                .Positionné(0, 0)
                .Build();

            // QUAND on lui demande d'avancer 2 fois
            var positionFinale = rover.Traiter(new AvancerCommande(), new AvancerCommande()).Position;

            // ALORS la position renvoyée est de 0,0
            Assert.Equal(new Point(0, 0), positionFinale);
        }
    }
}
