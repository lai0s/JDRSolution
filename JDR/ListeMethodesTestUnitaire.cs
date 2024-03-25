using System;
using System.IO;

namespace test_unitaire_methode_lancerDes
{
    public class ListeMethodesTestUnitaire
    {
        public static void TestLancerDes()
            {
             //A refaire pour tester la fonction Test Lancer Des 
            
            int nb1, nb2, nb3, nb4, min = 1, max, lance;
            bool stat = false, fin = false;
            char[] lancers = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            string saisie;
            Random aleatoire = new Random();
            while (!fin)
            {
                Console.WriteLine("\nSaisir le(s) dé(s) à lancer (ex : 5d100)\nPour des dés de stats, ajouter un \"s\" devant (ex: s3d100)\nPour retourner au menu principal, saisir \"f\"\n");
                saisie = Console.ReadLine();
                if (saisie.Length > 10) // erreur
                {
                    Console.WriteLine("Saisie trop grande, veuillez recommencer");
                } // fin erreur
                else
                {
                    for (nb1 = 0; nb1 < saisie.Length; nb1++) // récupération saisie
                    {
                        lancers[nb1] = saisie[nb1];
                    } // fin récupération saisie
                    for (nb2 = nb1; nb2 < 9; nb2++) // remplacement valeurs inutiles par ' '
                    {
                        lancers[nb2] = ' ';
                    } // fin remplacement valeurs inutiles par ' '
                    nb1 = 0;
                    nb2 = 0;
                    if (lancers[0] < 47 | lancers[0] > 58) // mise en minuscule
                    {
                        lancers[0] = Char.ToLower(lancers[0]);
                    } //fin  mise en minuscule
                    if (lancers[0] == 'f') // retour menu principal
                    {
                        fin = true;
                    } // fin retour menu principal
                    else
                    {
                        if (lancers[0] == 's') // vérification dé stat ?
                        {
                            stat = true;
                            nb1++;
                        } // fin vérification dé stat ?
                        if (lancers[1] < 47 | lancers[1] > 58) // mise en minuscule
                        {
                            lancers[1] = Char.ToLower(lancers[1]);
                        } //fin  mise en minuscule
                        if (lancers[nb1] > 47 & lancers[nb1] < 58)
                        {
                            while (lancers[nb1] > 47 & lancers[nb1] < 58 & nb1 < 9) // récupération nombre lancers
                            {
                                nb2 = nb2 * 10;
                                nb4 = Convert.ToInt32(Convert.ToString(lancers[nb1]));
                                nb2 = nb2 + nb4;
                                nb1++;
                            } // fin récupération nombre lancers
                            nb1++;
                            max = 0;
                            while (lancers[nb1] > 47 & lancers[nb1] < 58 & nb1 < 9) // récupération max
                            {
                                max = max * 10;
                                max = max + Convert.ToInt32(Convert.ToString(lancers[nb1]));
                                nb1++;
                            } // fin récupération max
                            Console.WriteLine();
                            if (stat) // affichage des dés de stats
                            {
                                max = max / 5;
                                for (nb3 = 0; nb3 < nb2; nb3++)
                                {
                                    lance = aleatoire.Next(min, max + 1);
                                    Console.WriteLine(lance * 5);
                                }
                            } // fin affichage des dés de stats
                            else
                            {
                                for (nb3 = 0; nb3 < nb2; nb3++) // affichage des dés normaux
                                {
                                    lance = aleatoire.Next(min, max + 1);
                                    Console.WriteLine(lance);
                                } // fin affichage des dés normaux
                            }
                        }
                        else
                        {
                            if (lancers[nb1] == 'd') // lancé unique
                            {
                                max = 0;
                                nb1++;
                                while (lancers[nb1] > 47 & lancers[nb1] < 58 & nb1 < 9) // récupération max
                                {
                                    max = max * 10;
                                    saisie = Convert.ToString(lancers[nb1]);
                                    max = max + Convert.ToInt32(saisie);
                                    nb1++;
                                } // fin récupération max
                                if (stat) // affichage des dés de stats
                                {
                                    max = max / 5;
                                    lance = aleatoire.Next(min, max + 1);
                                    Console.WriteLine(lance * 5);
                                } // fin affichage des dés de stats
                                else
                                {
                                    lance = aleatoire.Next(min, max + 1);
                                    Console.WriteLine(lance);
                                    // fin affichage des dés normaux
                                }
                            }
                            else // erreur
                            {
                                Console.WriteLine("\nErreur de saisie du paramètre");
                            } // fin erreur
                        } // fin lancé unique
                    }
                }
            }
        }
    }
}
