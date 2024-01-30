using System;
using JDR;
using System.IO;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            string saisie, user = "", mdp, dossier = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\",
                ListeComptes = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\ListeComptes.txt";
            bool fin = false, fini, ok, menu, erreur = true, connexion = false;
            StreamWriter sw;
            StreamReader sr;
            string[] identifiants;

            if (!Directory.Exists("C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso")) // création répertoire stockage fiches
            {
                if (!Directory.Exists("C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr"))
                {
                    Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr");
                }
                if (!Directory.Exists("C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru"))
                {
                    Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru");
                }
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso");
                Console.WriteLine("Création du dossier de stockage des fiches pour Naaru terminée.\n\n\n");
            } // fin création répertoire stockage fiches
            while (!fin)
            {
                while (!connexion & !fin) // menu connexion
                {
                    Console.WriteLine(" ----------------------------- ");
                    Console.WriteLine("|                             |");
                    Console.WriteLine("|       Se connecter (1)      |");
                    Console.WriteLine("|                             |"); // ajouter une ligne pour les niveaux sur les fiches
                    Console.WriteLine("| Créer un nouveau compte (2) |"); // faire en sorte que le dé de stat n'utilise pas de max définit par l'utilisateur
                    Console.WriteLine("|                             |"); // ajouter la possibilité de faire des calculs de base avec les dés et afficher le détail
                    Console.WriteLine("|    Arrêt du programme (3)   |"); // 
                    Console.WriteLine("|                             |"); // faire en sorte qu'un mj puisse accéder aux fiches des joueurs
                    Console.WriteLine(" ----------------------------- \n");
                    saisie = Console.ReadLine();
                    if (saisie == "1") // tentative connexion
                    {
                        Console.WriteLine("\nVeuillez saisir votre pseudo :\n");
                        user = Console.ReadLine();
                        Console.WriteLine("\nVeuillez saisir votre mot de passe :\n");
                        mdp = Console.ReadLine();
                        Console.WriteLine();
                        sr = new StreamReader(ListeComptes);
                        ok = false;
                        while (!sr.EndOfStream & !ok) // vérification existence d'un compte
                        {
                            saisie = sr.ReadLine();
                            identifiants = saisie.Split("#&"); // sépare l'user du mdp
                            if (user == identifiants[0] & mdp == identifiants[1])
                            {
                                ok = true;
                            }
                        }
                        if (ok) // connexion réussie
                        {
                            Console.WriteLine("\nBienvenue {0}\n\n", user);
                            connexion = true;
                        } // fin connexion réussie
                        else // échec connexion
                        {
                            Console.WriteLine("\nInformations de connexion fausses.\n");
                        } // fin échec connexion
                    } // fin tentative connexion
                    else
                    {
                        if (saisie == "2") // création compte
                        {
                            fini = false;
                            while (!fini)
                            {
                                Console.WriteLine("Veuillez saisir un pseudo :");
                                user = Console.ReadLine();
                                if (!Directory.Exists(dossier + user))
                                {
                                    ok = false;
                                    while (!ok)
                                    {
                                        Console.WriteLine("\nSaisir un mot de passe :");
                                        mdp = Console.ReadLine();
                                        Console.WriteLine("\nValider le mot de passe :");
                                        saisie = Console.ReadLine();
                                        if (saisie == mdp)
                                        {
                                            Directory.CreateDirectory(dossier + user);
                                            Console.WriteLine("\nNouvel utilisateur créé\n");
                                            sw = new StreamWriter(ListeComptes, true);
                                            sw.WriteLine(user + "#&" + mdp);
                                            sw.Close();
                                            sw = new StreamWriter("C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste.txt");
                                            sw.Close();
                                            ok = true;
                                            fini = true;
                                        }
                                        else // erreur mdp
                                        {
                                            Console.WriteLine("\n Mot de passe incorrect, veuillez recommencer.\n");
                                        } // fin erreur mdp
                                    }
                                }
                                else // erreur user
                                {
                                    Console.WriteLine("Pseudo déjà utilisé, veuillez en choisir un autre");
                                } // fin erreur user
                            }
                        } // fin création compte
                        else
                        {
                            if (saisie == "3") // arret programme
                            {
                                fin = true;
                            } // fin arret programme
                            else // erreur
                            {
                                Console.WriteLine("Erreur de saisie du menu");
                            } // fin erreur
                        }
                    }
                } // fin menu connexion
                while (connexion & !fin)
                {
                    Console.WriteLine(" ---------------------------- ");
                    Console.WriteLine("|                            |");
                    Console.WriteLine("|   Gestion des fiches (1)   |");
                    Console.WriteLine("|                            |");
                    Console.WriteLine("|     Lancer des dés (2)     |");
                    Console.WriteLine("|                            |");
                    Console.WriteLine("|     Se déconnecter (3)     |");
                    Console.WriteLine("|                            |");
                    Console.WriteLine("|   Arrêt du programme (4)   |");
                    Console.WriteLine("|                            |");
                    Console.WriteLine(" ---------------------------- \n");
                    saisie = Console.ReadLine();
                    if (saisie == "1") // menu gestion fiches
                    {
                        erreur = false;
                        menu = false;
                        while (!menu)
                        {
                            ok = File.Exists("C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\fiche_tampon.txt");
                            Console.WriteLine(" --------------------------------------------- ");
                            Console.WriteLine("|                                             |");
                            Console.WriteLine("|             Créer une fiche (1)             |");
                            Console.WriteLine("|                                             |");
                            Console.WriteLine("|            Modifier une fiche (2)           |");
                            Console.WriteLine("|                                             |");
                            Console.WriteLine("|            Afficher une fiche (3)           |");
                            Console.WriteLine("|                                             |");
                            Console.WriteLine("|       Afficher la liste des fiches (4)      |");
                            Console.WriteLine("|                                             |");
                            Console.WriteLine("|           Supprimer une fiche (5)           |");
                            Console.WriteLine("|                                             |");
                            if (ok)
                            {
                                Console.WriteLine("|  Restaurer la dernière fiche supprimée (6)  |");
                                Console.WriteLine("|                                             |");
                                Console.WriteLine("|         Retour au menu principal (7)        |");
                                Console.WriteLine("|                                             |");
                            }
                            else
                            {
                                Console.WriteLine("|         Retour au menu principal (6)        |");
                                Console.WriteLine("|                                             |");
                            }
                            Console.WriteLine(" --------------------------------------------- \n");
                            saisie = Console.ReadLine();
                            if (saisie == "1") // créer une fiche
                            {
                                Class1.CreerFiche(ref user);
                            } // fin créer une fiche
                            else
                            {
                                if (saisie == "2") // modifier une fiche
                                {
                                    Class1.ModifierFiche(ref user);
                                } // fin modifier une fiche
                                else
                                {
                                    if (saisie == "3") // afficher une fiche
                                    {
                                        Class1.AfficherFiche(ref user);
                                    } // fin afficher une fiche
                                    else
                                    {
                                        if (saisie == "4") // afficher la liste
                                        {
                                            Class1.AfficherListe(ref user);
                                        } // fin afficher la liste
                                        else
                                        {
                                            if (saisie == "5") // supprimer une fiche
                                            {
                                                Class1.SupprimerFiche(ref user);
                                            } // fin supprimer une fiche
                                            else
                                            {
                                                if (ok & saisie == "6") // restaurer une fiche
                                                {
                                                    Class1.RestaurerFiche(ref user);
                                                } // fin restaurer une fiche
                                                else
                                                {
                                                    if (!ok & saisie == "6" | ok & saisie == "7")
                                                    {
                                                        menu = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("erreur de saisie");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    } // fin menu gestion fiches
                    if (saisie == "2") // menu lancer dés
                    {
                        erreur = false;
                        Class1.LancerDes();
                    } // fin menu lancer dés
                    if (saisie == "3") // déconnexion
                    {
                        erreur = false;
                        connexion = false;
                    } // fin déconnexion
                    if (saisie == "4") // arrêt programme
                    {
                        erreur = false;
                        fin = true;
                    } // fin arrêt programme
                    if (erreur) // erreur
                    {
                        Console.WriteLine("\nErreur lors de la saisie du menu\n");
                    } // fin erreur
                }
            }
        }
    }
}