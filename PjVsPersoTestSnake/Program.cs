using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace PjVsPersoTestSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PETROLORD");
            while (Jeu.enVie)
            {
                Jeu.TourDeJeu();
            }
            
        }
        //}

        public class Jeu
        {
            static int[,] grilleDeJeu = new int[8, 8];
            static int pommeX;
            static int pommeY;
            static int teteX;
            static int teteY;
            public static int snakeLenght = 1;

            static Random rand = new Random();

            public static bool enVie = true;
            static bool nvPomme = true;

            public static void TourDeJeu()
            {
                if (nvPomme)
                {
                    NouvPosPomme();
                    nvPomme = false;
                }
                MAJjeu();
                //Console.WriteLine());
                DeplaSnake(UserDepla(Console.ReadKey(true))[0], UserDepla(Console.ReadKey(true))[1]);
                AfficherJeu();
                Console.WriteLine(enVie);

            }

            static void MAJjeu()
            {
                for (int ligne = 0; ligne < grilleDeJeu.GetLength(0); ligne++)
                {
                    for (int casier = 0; casier < grilleDeJeu.GetLength(1); casier++)
                    {
                        if (grilleDeJeu[ligne, casier] > 0)
                        {
                            grilleDeJeu[ligne, casier] -= 1;
                        }
                    }
                }
            }

            static void DeplaSnake(int valX, int valY)
            {
                //met à jour le déplacement du snake sur la grille en fonction du mouvement user.
                teteX += valX;
                teteY += valY;
                if ((grilleDeJeu.GetLength(0) <= teteX || teteX < 0) || (grilleDeJeu.GetLength(1) <= teteY || teteY < 0))
                {
                    enVie = false;//ça, c'est moi...
                }
                else if (grilleDeJeu[teteX, teteY] > 0)
                {
                    enVie = false;
                }
                else if (grilleDeJeu[teteX, teteY] == -1)
                {
                    snakeLenght += 1;
                    grilleDeJeu[teteX, teteY] = snakeLenght;
                    nvPomme = true;
                }
                else
                {
                    grilleDeJeu[teteX, teteY] = snakeLenght;
                }
                //grilleDeJeu[teteX, teteY] = snakeLenght;

            }

            static void DemandeUser()
            {
                //va récuperer le mouvement du snake souhaité par l'utilisateur.
            }

            static int[] UserDepla(ConsoleKeyInfo pressedKey)
            {
                int[] reponse = new int[2];
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    reponse = new int[] { 0, 1 };
                }
                else if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    reponse = new int[] { 0, -1 };
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    reponse = new int[] { -1, 0 };
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    reponse = new int[] { 1, 0 };
                }
                else
                {
                    reponse = new int[] { 0, 0 };
                }
                return reponse;
            }

            static void AfficherJeu()
            {
                string reponse = "";
                for (int linie = 0; linie < grilleDeJeu.GetLength(0); linie++)
                {
                    for (int casier = 0; casier < grilleDeJeu.GetLength(1); casier++)
                    {
                        if ( grilleDeJeu[linie, casier] >-1 && grilleDeJeu[linie,casier] < 10)
                        {
                            reponse += ("[" + grilleDeJeu[linie, casier] + " ]");
                        }
                        else
                        {
                            reponse += ("[" + grilleDeJeu[linie, casier] + "]");
                        }
                    }
                    Console.WriteLine(reponse);
                    reponse = "";
                }
                Console.WriteLine("");
            }

            static void NouvPosPomme()
            {
                pommeX = rand.Next(0, grilleDeJeu.GetLength(0));
                pommeY = rand.Next(0, grilleDeJeu.GetLength(1));
                

                while (grilleDeJeu[pommeX,pommeY] != 0)
                {
                    pommeX = rand.Next(0, grilleDeJeu.GetLength(0));
                    pommeY = rand.Next(0, grilleDeJeu.GetLength(1));
                }

                grilleDeJeu[pommeX, pommeY] = -1;
            }

        }

    }
}
