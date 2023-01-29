using MarsRover;
using MarsRover.Commandes;
using MarsRover.Test.Utilities;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

class MainRover 
{
    static void Main(string[] args)
    {
        int stop = 0;
        Console.WriteLine("------------- ROVER -------------");

        //tant que l'utilsateur n'a pas dis stop on continue le jeu
        while (stop < 1)
        {
            Rover rover = new RoverBuilder()
               .SurUnePlanète(planète => planète.ToriqueDeTailleX(10).AyantUnObstacle(0, 5))
               .Orienté(Orientation.Nord)
               .Positionné(0, 0)
               .Build();

            Console.WriteLine("\nDéfinissez plusieurs directions à la suite entre : \n'a' pour avancer,\n'g' pour aller à gauche, \n'd' pour aller à droite, \n'stop' pour sortir du jeu");
            String directionCommande = Console.ReadLine();

            //si on veut arrêter de jouer
            if (directionCommande == "stop")
            {
                stop = 1;
            }

            //tableau des directions
            char[] tableauCommandes = directionCommande.ToCharArray();
            Point positionActuelle = new Point(0, 0);
            
            Point triche = new Point(0, 4);
            
            //pour passer dans le tableau des directions
            for (int i = 0; i < tableauCommandes.Length; i++)
            {
                //pour avancer
                if (tableauCommandes[i].ToString().ToLower().Equals("a"))
                {
                    positionActuelle = rover.Traiter(new AvancerCommande()).Position;
                    Console.WriteLine("Ma position est : " + positionActuelle);
                    
                    if(positionActuelle == triche)
                    {
                        Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle + "\nJe ne peux plus avancer, retour à la position de départ");
                        i = tableauCommandes.Length;
                    }
                    
                }
                //pour aller à gauche
                else if (tableauCommandes[i].ToString().ToLower().Equals("g"))
                {
                    positionActuelle = rover.Traiter(new TourneAGaucheCommande()).Position;
                    Console.WriteLine("Ma position est : " + positionActuelle);

                    if (positionActuelle == triche)
                    {
                        Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle + "\nJe ne peux plus avancer, retour à la position de départ");
                        i = tableauCommandes.Length;
                    }
                }
                //pour aller à droite
                else if (tableauCommandes[i].ToString().ToLower().Equals("d"))
                {
                    positionActuelle = rover.Traiter(new TournerADroiteCommande()).Position;
                    Console.WriteLine("Ma position est : " + positionActuelle);

                    if (positionActuelle == triche)
                    {
                        Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle + "\nJe ne peux plus avancer, retour à la position de départ");
                        i = tableauCommandes.Length;
                    }
                }
                //si c'est une mauvaise direction
                else
                {
                    Console.WriteLine("La direction demandée n'est pas correcte");
                }
            }
        }
    }
}