using MarsRover.Commandes;
using MarsRover.Test.Utilities;

namespace MarsRover.Test
{
    public class TestListeCommandes
    {
        [Fact]
        public void TestDeuxCommandes()
        {
            // ETANT DONNE un rover en position (0,0) orienté Nord
            var rover = new RoverBuilder()
                .Positionné(0, 0)
                .Orienté(Orientation.Nord)
                .Build();

            // QUAND on lui envoie une liste de commandes (Avancer + Tourner à droite)
            var commandeAvancer = new AvancerCommande();
            var commandeTournerDroite = new TournerADroiteCommande();
            var etatFinal = rover.Traiter(commandeAvancer, commandeTournerDroite);

            // ALORS il répond qu'il est désormais orienté Est et positionné (0, 1)
            Assert.Equal(Orientation.Est, etatFinal.Orientation);
            Assert.Equal(new Point(0, 1), etatFinal.Position);
        }

        [Fact]
        public void TestObstacle()
        {
            // ETANT DONNE un rover en position (0,0) orienté Nord
            // ET un obstacle en (0,2)
            var rover = new RoverBuilder()
                .Positionné(0, 0)
                .Orienté(Orientation.Nord)
                .SurUnePlanète(planète => planète.AyantUnObstacle(0, 2))
                .Build();
            
            // QUAND on lui demande d'avancer 2 fois
            var etatFinal = rover.Traiter(new AvancerCommande(), new AvancerCommande());

            // ALORS il répond qu'il est désormais positionné (0, 1)
            Assert.Equal(new Point(0, 1), etatFinal.Position);

            // ET qu'un obstacle est présent en (0,2)
            Assert.Equal(new Point(0, 2), etatFinal.ObstacleEventuel);
        }
    }
}
