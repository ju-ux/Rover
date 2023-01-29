using MarsRover.Commandes;
using MarsRover.Test.Utilities;

namespace MarsRover.Test
{
    public class TestOrientation
    {
        public static IEnumerable<object[]> DataTestTourneADroite => new[]
        {
            new []{ Orientation.Nord, Orientation.Est },
            new []{ Orientation.Est, Orientation.Sud },
            new []{ Orientation.Sud, Orientation.Ouest },
            new []{ Orientation.Ouest, Orientation.Nord },
        };

        [Theory]
        [MemberData(nameof(DataTestTourneADroite))]
        public void TestTourneDroite(Orientation origine, Orientation destination)
        {
            // ETANT DONNE un rover orienté vers <origine>
            var rover = new RoverBuilder().Orienté(origine).Build();

            // QUAND on lui demande de tourner vers la droite
            var orientationFinale = rover.Traiter(new TournerADroiteCommande()).Orientation;

            // ALORS il répond qu'il est désormais orienté <destination>
            Assert.Equal(destination, orientationFinale);
        }

        public static IEnumerable<object[]> DataTestTourneAGauche =>
            DataTestTourneADroite.Select(paire => paire.Reverse().ToArray());

        [Theory]
        [MemberData(nameof(DataTestTourneAGauche))]
        public void TestTourneGauche(Orientation origine, Orientation destination)
        {
            // ETANT DONNE un rover orienté vers <origine>
            var rover = new RoverBuilder().Orienté(origine).Build();

            // QUAND on lui demande de tourner vers la gauche
            var orientationFinale = rover.Traiter(new TourneAGaucheCommande()).Orientation;

            // ALORS il répond qu'il est désormais orienté <destination>
            Assert.Equal(destination, orientationFinale);
        }
    }
}