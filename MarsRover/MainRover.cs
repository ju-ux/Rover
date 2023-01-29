using MarsRover;
using MarsRover.Commandes;
using MarsRover.Test.Utilities;
using System.Xml.Serialization;
using System.Collections;
using System;

class MainRover
{
    static void Main(string[] args)
    {
        int stop = 0;
        Rover rover = new RoverBuilder()
               .SurUnePlanète(planète => planète.ToriqueDeTailleX(10).AyantUnObstacle(0, 5))
               .Orienté(Orientation.Nord)
               .Positionné(0, 0)
               .Build();

        Console.WriteLine("------------- ROVER -------------");

        //tant que l'utilsateur n'a pas dis stop on continue le jeu
        while (stop < 1)
        {
            Console.WriteLine("\nDéfinissez plusieurs directions à la suite entre : \n'a' pour avancer,\n'g' pour aller à gauche, \n'd' pour aller à droite, \n'stop' pour sortir du jeu");
            String directionCommande = Console.ReadLine();

            //si on veut arrêter de jouer
            //directionCommande == "stop" ? stop = 1 : stop = 0;
            if (directionCommande == "stop")
            {
                stop = 1;
            }

            //tableau des directions
            char[] tableauCommandes = directionCommande.ToCharArray();
            Point positionActuelle = new Point(0, 0);

            //pour passer dans le tableau des directions
            for (int i = 0; i < tableauCommandes.Length; i++)
            {
                //pour avancer
                if (tableauCommandes[i].ToString().ToLower().Equals("a"))
                {
                    try
                    {
                        positionActuelle = rover.Traiter(new AvancerCommande()).Position;
                        Console.WriteLine("Ma position est : " + positionActuelle);
                    }
                    catch
                    {
                        Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle);
                        break;
                    }
                }
                //pour aller à gauche
                else if (tableauCommandes[i].ToString().ToLower().Equals("g"))
                {
                    try
                    {
                        positionActuelle = rover.Traiter(new TourneAGaucheCommande()).Position;
                        Console.WriteLine("Ma position est : " + positionActuelle);
                    }
                    catch
                    {
                        Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle);
                        break;
                    }
                }
                //pour aller à droite
                else if (tableauCommandes[i].ToString().ToLower().Equals("d"))
                {
                    try
                    {
                        positionActuelle = rover.Traiter(new TournerADroiteCommande()).Position;
                        Console.WriteLine("Ma position est : " + positionActuelle);
                    }
                    catch
                    {
                        Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle);
                        break;
                    }
                }
                //si c'est une mauvaise direction
                else
                {
                    Console.WriteLine("La direction demandée n'est pas correcte");
                }
            }
            positionActuelle.X = 0;
            positionActuelle.Y = 0;
            //Console.ReadKey();
            
            //repartir du point à zero
            //remettre à la ligne
            //dire que le point repars de zéro

        }
    }
}