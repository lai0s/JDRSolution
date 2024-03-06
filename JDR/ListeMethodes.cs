using System;
using System.IO;

namespace JDR
{
    public class ListeMethodes
    {
        /// <summary>
        /// /// remplit lu des stats du personnages créer ou modifier
        /// </summary>
        /// <param name="stats">tableau de stats</param>
        /// <param name="nb">numéro du tableau stat à remplir</param>
        static void RemplirStats(ref int[] stats, int nb)
        {
            bool ok = false;
            string saisie;
            while (!ok)
            {
                saisie = Console.ReadLine();
                ok = Int32.TryParse(saisie, out stats[nb]);
                if (!ok) // erreur
                {
                    Console.WriteLine("Erreur de saisie de la stat, veuillez recommencer.");
                } // erreur de saisis fin erreur
            }
        }
        /// <summary>
        /// modifie le tableau de stats
        /// </summary>
        /// <param name="stats">tableau de stats</param>
        /// <param name="nb">numéro du tableau stat à modifier</param>
        static void ModifierStats(ref int[] stats, int nb)
        {
            bool ok = false;
            string saisie;
            while (!ok)
            {
                saisie = Console.ReadLine();
                ok = Int32.TryParse(saisie, out stats[nb]);
                if (!ok) // erreur
                {
                    Console.WriteLine("Erreur de saisie de la stat, veuillez recommencer.");
                } // fin erreur
                else
                {
                    Console.WriteLine("modification terminée");
                }
            }
        }
        public static void CreerFiche(ref string user)
        {
            int[] stats = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            // puissance = stats[0], endurance = stats[1], rapidite = stats[2], agilite = stats[3], furtivite = stats[4], concentration = stats[5], reflexion = stats[6], force_mentale = stats[7], endurance_psy = stats[8], intelligence = stats[9], Charisme = stats[10], Negociation = stats[11], Elocution = stats[12], Persuasion = stats[13], Charme = stats[14], connaissances_magiques = stats[15], connaissances_medicinales = stats[16], connaissances_geographiques = stats[17], connaissances_politiques = stats[18], connaissances_legendes = stats[19]
            // si 3 stats : physique = stats[0], mental = stats[1], social = stats[2]
            int NbFiches = 0, numero = 0, nb1, nb2, nb3, nb4, nb5;
            string saisie, cheminListe = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste.txt", FicheTampon = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\fiche_tampon.txt",
                cheminFiches, nom, morphologie, race, lien, bio, test, ListeTampon = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste_tampon.txt";
            string[] liens = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }, bios = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            bool ok = false, stat = false;
            StreamWriter sw;
            StreamReader sr;

            while (!ok) // saisie type de stats
            {
                Console.WriteLine("Saisir le type de stats :\n3 stats (1)      20 stats(2)\n");
                saisie = Console.ReadLine();
                if (saisie == "1")
                {
                    stat = false;
                    ok = true;
                }
                else
                {
                    if (saisie == "2")
                    {
                        stat = true;
                        ok = true;
                    }
                    else
                    {
                        Console.WriteLine("saisie du type de stats faux, veuillez recommencer\n");
                    }
                }
            } // fin saisie type de stats
            Console.WriteLine("Saisir le nom du personnage :\n");
            nom = Console.ReadLine();
            if (stat) // saisie 20 stats
            {
                Console.WriteLine("\nSaisir les stats du personnage :\nPuissance :"); nb4 = 0; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nEndurance :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nRapidite :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nAgilité :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nFurtivité :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nConcentration :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nRéflexion :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nForce mentale :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nEndurance psychique :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nIntelligence :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nCharisme :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nNégociation :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nÉlocution :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nPersuasion :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nCharme :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nConnaissances magiques :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nConnaissances médicinales :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nConnaissances géographiques :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nConnaissances politiques :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nConnaissances légendes :"); nb4++; RemplirStats(ref stats, nb4);
            } // fin saisie 20 stats
            else // saisie 3 stats
            {
                Console.WriteLine("\nSaisir les stats du personnage :\nPhysique :"); nb4 = 0; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nMental :"); nb4++; RemplirStats(ref stats, nb4);
                Console.WriteLine("\nSocial :"); nb4++; RemplirStats(ref stats, nb4);
            } // fin saisie 3 stats
            Console.WriteLine("\nSaisir la race du personnage\n");
            race = Console.ReadLine();
            Console.WriteLine("\nSaisir la morphologie (si réfléchie) : taille et poids (ex : 1m72 64kg).\n");
            morphologie = Console.ReadLine();
            ok = false;
            while (!ok) // saisie du nombre d'image
            {
                Console.WriteLine("\nSaisir le nombre d'images discord du personnage (max 20) :\n");
                saisie = Console.ReadLine();
                ok = Int32.TryParse(saisie, out numero);
                if (!ok)
                {
                    Console.WriteLine("Erreur lors de la saisie du nombre de paragraphes, recommencez.");
                }
            } // fin saisie du nombre d'image
            for (nb2 = 0; nb2 < numero; nb2++) // saisie images
            {
                Console.WriteLine("\nSaisir le lien discord numéro {0} du personnage\n", nb2 + 1);
                lien = Console.ReadLine();
                liens[nb2] = lien;
            } // fin saisie images
            ok = false;
            while (!ok) // saisie du nombre de paragraphes
            {
                Console.WriteLine("\nSaisir le nombre de paragraphes comportant la bio (max 20) :\n");
                saisie = Console.ReadLine();
                ok = Int32.TryParse(saisie, out numero);
                if (!ok)
                {
                    Console.WriteLine("Erreur lors de la saisie du nombre de paragraphes, recommencez.");
                }
            } // fin saisie du nombre de paragraphes
            for (nb3 = 0; nb3 < numero; nb3++) // saisie paragraphes
            {
                Console.WriteLine("\nSaisir le paragraphe numéro {0} de la bio du personnage\n", nb3 + 1);
                bio = Console.ReadLine();
                bios[nb3] = bio;
            } // fin saisie paragraphes
            if (File.Exists(FicheTampon)) // 1ere possible sélection numéro de fiche
            {
                sr = new StreamReader(FicheTampon);
                nb5 = Convert.ToInt32(sr.ReadLine());
                sr.Close();
                sr = new StreamReader(cheminListe);
                while (!sr.EndOfStream | !ok & nb5 != NbFiches)
                {
                    test = sr.ReadLine();
                    if (test == " ")
                    {
                        ok = true;
                    }
                    else
                    {
                        NbFiches++;
                    }
                }
                sr.Close();
            } // fin 1ere possible sélection numéro de fiche
            else // 2eme possible sélection numéro de fiche
            {
                if (File.Exists(cheminListe))
                {
                    ok = false;
                    sr = new StreamReader(cheminListe);
                    while (!sr.EndOfStream & !ok)
                    {
                        test = sr.ReadLine();
                        if (test == " ")
                        {
                            ok = true;
                        }
                        else
                        {
                            NbFiches++;
                        }
                    }
                    sr.Close();
                }
            } // fin 2eme possible sélection numéro de fiche
            cheminFiches = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\fiche_numero_" + NbFiches + ".txt";
            sw = new StreamWriter(cheminFiches);
            if (stat) // définition type de stats
            {
                sw.WriteLine("2");
                for (nb1 = 0; nb1 < 20; nb1++) // enregistrement 20 stats
                {
                    sw.WriteLine(stats[nb1]);
                } // fin enregistrement 20 stats
            } // fin définition type de stats
            else
            {
                sw.WriteLine("1");
                for (nb1 = 0; nb1 < 3; nb1++) // enregistrement 3 stats
                {
                    sw.WriteLine(stats[nb1]);
                } // fin enregistrement 3 stats
            }
            sw.WriteLine("{0}\n{1}\n{2}", nom, race, morphologie);
            for (nb1 = 0; nb1 < nb2; nb1++) // enregistrement liens images discord
            {
                lien = liens[nb1];
                sw.WriteLine(lien);
            } // fin enregistrement liens images discord
            sw.WriteLine(" ");
            for (nb1 = 0; nb1 < nb3; nb1++) // enregistrement paragraphes bio
            {
                bio = bios[nb1];
                sw.WriteLine(bio);
            } // fin enregistrement paragraphes bio
            sw.Close();
            sr = new StreamReader(cheminListe);
            sw = new StreamWriter(ListeTampon);
            while (!sr.EndOfStream) // sauvegarde liste
            {
                sw.WriteLine(sr.ReadLine());
            } // fin sauvegarde liste
            sr.Close();
            sw.Close();
            sw = new StreamWriter(cheminListe);
            sr = new StreamReader(ListeTampon);
            for (nb1 = 0; nb1 < NbFiches; nb1++) // écriture début liste
            {
                sw.WriteLine(sr.ReadLine());
            } // fin écriture début liste
            Console.WriteLine("\nLa fiche porte le numéro {0}\n", NbFiches);
            sw.WriteLine("La fiche de {0} est la numéro {1}.", nom, NbFiches);
            while (!sr.EndOfStream) // écriture fin liste
            {
                sw.WriteLine(sr.ReadLine());
            } // fin écriture fin liste
            sw.Close();
            sr.Close();
        }
        public static void ModifierFiche(ref string user)
        {
            int[] stats = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            // puissance = stats[0], endurance = stats[1], rapidite = stats[2], agilite = stats[3], furtivite = stats[4], concentration = stats[5], reflexion = stats[6], force_mentale = stats[7], endurance_psy = stats[8], intelligence = stats[9], Charisme = stats[10], Negociation = stats[11], Elocution = stats[12], Persuasion = stats[13], Charme = stats[14], connaissances_magiques = stats[15], connaissances_medicinales = stats[16], connaissances_geographiques = stats[17], connaissances_politiques = stats[18], connaissances_legendes = stats[19]
            int numero, nb1, nb2, nb3, nb4;
            string saisie1, saisie2, saisie3, cheminTampon = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste_tampon.txt", cheminListe = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste.txt",
                cheminFiches, nom, morphologie, race;
            string[] liens = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }, bios = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            bool test, ok, fini, stat = false, modif = true;
            StreamReader sr;
            StreamWriter sw;

            Console.WriteLine("\nSélectionner le numéro de la fiche à modifier");
            saisie1 = Console.ReadLine();
            test = Int32.TryParse(saisie1, out numero);
            if (test)
            {
                cheminFiches = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\fiche_numero_" + numero + ".txt";
                if (File.Exists(cheminFiches))
                {
                    fini = false;
                    sr = new StreamReader(cheminFiches);
                    saisie1 = sr.ReadLine();
                    if (saisie1 == "2") // vérification type stats
                    {
                        stat = true;
                        for (nb1 = 0; nb1 < 20; nb1++) // récupération 20 stats
                        {
                            stats[nb1] = Convert.ToInt32(sr.ReadLine());
                        } // fin récupération 20 stats
                    }
                    else
                    {
                        for (nb1 = 0; nb1 < 3; nb1++) // récupération 3 stats
                        {
                            stats[nb1] = Convert.ToInt32(sr.ReadLine());
                        } // fin récupération 3 stats
                    }
                    nom = sr.ReadLine();
                    race = sr.ReadLine();
                    morphologie = sr.ReadLine();
                    ok = false;
                    nb3 = 0;
                    while (!ok) // récupération liens images discord
                    {
                        liens[nb3] = sr.ReadLine();
                        if (liens[nb3] == " ")
                        {
                            ok = true;
                        }
                        nb3++;
                    } // fin récupération liens images discord
                    nb2 = 0;
                    while (!sr.EndOfStream) // récupération paragraphes bio
                    {
                        bios[nb2] = sr.ReadLine();
                        nb2++;
                    } // fin récupération paragraphes bio 
                    sr.Close();
                    while (!fini) // modification 
                    {
                        Console.WriteLine("\nSélectionner la partie de la fiche à modifier :\nStatistiques (1)   Informations (2)\nAfficher la fiche complète (3)   Terminer la modification (4)   Annuler la modification de fiche (5)\n");
                        saisie3 = Console.ReadLine();
                        ok = false;
                        while (saisie3 == "1") // modification stats    
                        {
                            if (stat) //  modif 20 stats
                            {
                                Console.WriteLine("\nSélectionner l'arbre à modifier :\nPhysique (1)   Mental (2)   Social (3)   Connaissances (4)   Afficher les statistiques (5)\nRevenir au menu précédent (6)   Terminer la modification (7)   Annuler la modification (8)");
                                saisie1 = Console.ReadLine();
                                ok = false;
                                while (saisie1 == "1") // arbre physique
                                {
                                    ok = true;
                                    Console.WriteLine("\nSélectionner la stat à modifier :\nPuissance (1)   Endurance (2)   Rapidité (3)   Agilité (4)   Furtivité (5)   Afficher les stats de l'arbre (6)\nRetourner au menu précédent (7)   Terminer la modification (8)   Annuler la modification (9)");
                                    saisie2 = Console.ReadLine();
                                    if (saisie2 == "1") // modification puissance
                                    {
                                        Console.WriteLine("\nSaisir la nouvelle valeur de la stat Puissance :"); nb4 = 0;
                                        ModifierStats(ref stats, nb4);
                                    } // fin modification puissance
                                    else
                                    {
                                        if (saisie2 == "2") // modification endurance
                                        {
                                            Console.WriteLine("\nSaisir la nouvelle valeur de la stat Endurance :"); nb4 = 1;
                                            ModifierStats(ref stats, nb4);
                                        } // fin modification endurance
                                        else
                                        {
                                            if (saisie2 == "3") // modification rapidité
                                            {
                                                Console.WriteLine("\nSaisir la nouvelle valeur de la stat Rapidité :"); nb4 = 2;
                                                ModifierStats(ref stats, nb4);
                                            } // fin modification rapidité
                                            else
                                            {
                                                if (saisie2 == "4") // modification agilité
                                                {
                                                    Console.WriteLine("\nSaisir la nouvelle valeur de la stat Agilité :"); nb4 = 3;
                                                    ModifierStats(ref stats, nb4);
                                                } // fin modification agilité
                                                else
                                                {
                                                    if (saisie2 == "5") // modification furtivité
                                                    {
                                                        Console.WriteLine("\nSaisir la nouvelle valeur de la stat Furtivité :"); nb4 = 4;
                                                        ModifierStats(ref stats, nb4);
                                                    } // fin modification furtivité
                                                    else
                                                    {
                                                        if (saisie2 == "6") // affichage stats de l'arbre
                                                        {
                                                            Console.WriteLine("\nPuissance : {0}\nEndurance : {1}\nRapidité : {2}\nAgilité : {3}\nFurtivité : {4}\n\n", stats[0], stats[1], stats[2], stats[3], stats[4]);
                                                        } // fin affichage stats de l'arbre
                                                        else
                                                        {
                                                            if (saisie2 == "7") // retour menu précédent
                                                            {
                                                                saisie1 = "";
                                                            } // fin retour menu précédent
                                                            else
                                                            {
                                                                if (saisie2 == "8") // arrêt modification
                                                                {
                                                                    saisie3 = "";
                                                                    saisie1 = "";
                                                                    fini = true;
                                                                } // fin arrêt modification
                                                                else
                                                                {
                                                                    if (saisie2 == "9")// annulation modification
                                                                    {
                                                                        fini = true;
                                                                        modif = false;
                                                                        saisie3 = "";
                                                                        saisie1 = "";
                                                                    }// fin annulation modification
                                                                    else // erreur
                                                                    {
                                                                        Console.WriteLine("\nErreur de saisie de la stat\n");
                                                                    } // fin erreur
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                } // fin arbre physique
                                while (saisie1 == "2") // arbre mental
                                {
                                    ok = true;
                                    Console.WriteLine("\nSélectionner la stat à modifier :\nConcentration (1)   Réflexion (2)   Force mentale (3)   Endurance psychique (4)   Intelligence (5)\nAffichage des stats de l'arbre (6)   Retourner au menu précédent (7)   Terminer la modification (8)   Annuler la modification (9)");
                                    saisie2 = Console.ReadLine();
                                    if (saisie2 == "1") // modification concentration
                                    {
                                        Console.WriteLine("\nSaisir la nouvelle valeur de la stat Concentration :"); nb4 = 5;
                                        ModifierStats(ref stats, nb4);
                                    } // fin modification concentration
                                    else
                                    {
                                        if (saisie2 == "2") // modification réflexion
                                        {
                                            Console.WriteLine("\nSaisir la nouvelle valeur de la stat Réflexion :"); nb4 = 6;
                                            ModifierStats(ref stats, nb4);
                                        } // fin modification réflexion
                                        else
                                        {
                                            if (saisie2 == "3") // modification force mentale
                                            {
                                                Console.WriteLine("\nSaisir la nouvelle valeur de la stat Force mentale :"); nb4 = 7;
                                                ModifierStats(ref stats, nb4);
                                            } // fin modification force mentale
                                            else
                                            {
                                                if (saisie2 == "4") // modification endurance psychique
                                                {
                                                    Console.WriteLine("\nSaisir la nouvelle valeur de la stat Endurance psychique :"); nb4 = 8;
                                                    ModifierStats(ref stats, nb4);
                                                } // fin modification endurance psychique
                                                else
                                                {
                                                    if (saisie2 == "5") // modification intelligence
                                                    {
                                                        Console.WriteLine("\nSaisir la nouvelle valeur de la stat Intelligence :"); nb4 = 9;
                                                        ModifierStats(ref stats, nb4);
                                                    } // fin modification intelligence
                                                    else
                                                    {
                                                        if (saisie2 == "6") // affichage stats de l'arbre
                                                        {
                                                            Console.WriteLine("\nConcentration : {0}\nEndurance : {1}\nRéflexion : {2}\nForce mentale : {3}\nEndurance psychique : {4}\n\n", stats[5], stats[6], stats[7], stats[8], stats[9]);
                                                        } // fin affichage stats de l'arbre
                                                        else
                                                        {
                                                            if (saisie2 == "7") // retour menu précédent
                                                            {
                                                                saisie1 = "";
                                                            } // fin retour menu précédent
                                                            else
                                                            {
                                                                if (saisie2 == "8") // arrêt modification
                                                                {
                                                                    saisie3 = "";
                                                                    saisie1 = "";
                                                                    fini = true;
                                                                } // fin arrêt modification
                                                                else
                                                                {
                                                                    if (saisie2 == "9")// annulation modification
                                                                    {
                                                                        fini = true;
                                                                        modif = false;
                                                                        saisie3 = "";
                                                                        saisie1 = "";
                                                                    }// fin annulation modification
                                                                    else // erreur
                                                                    {
                                                                        Console.WriteLine("\nErreur de saisie de la stat\n");
                                                                    } // fin erreur
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                } // fin arbre mental
                                while (saisie1 == "3") // arbre social
                                {
                                    ok = true;
                                    Console.WriteLine("\nSélectionner la stat à modifier :\nCharisme (1)   Négociation (2)   Élocution (3)   Persuasion (4)   Charme (5)   Afficher les stats de l'arbre (6)\nRetourner au menu précédent (7)   Terminer la modification (8)   Annuler la modification (9)");
                                    saisie2 = Console.ReadLine();
                                    if (saisie2 == "1") // modification charisme
                                    {
                                        Console.WriteLine("\nSaisir la nouvelle valeur de la stat Charisme :"); nb4 = 10;
                                        ModifierStats(ref stats, nb4);
                                    } // fin modification charisme
                                    else
                                    {
                                        if (saisie2 == "2") // modification négociation
                                        {
                                            Console.WriteLine("\nSaisir la nouvelle valeur de la stat Négociation :"); nb4 = 11;
                                            ModifierStats(ref stats, nb4);
                                        } // fin modification négociation
                                        else
                                        {
                                            if (saisie2 == "3") // modification élocution
                                            {
                                                Console.WriteLine("\nSaisir la nouvelle valeur de la stat Élocution :"); nb4 = 12;
                                                ModifierStats(ref stats, nb4);
                                            } // fin modification élocution
                                            else
                                            {
                                                if (saisie2 == "4") // modification persuasion
                                                {
                                                    Console.WriteLine("\nSaisir la nouvelle valeur de la stat Persuasion :"); nb4 = 13;
                                                    ModifierStats(ref stats, nb4);
                                                } // fin modification persuasion
                                                else
                                                {
                                                    if (saisie2 == "5") // modification charme
                                                    {
                                                        Console.WriteLine("\nSaisir la nouvelle valeur de la stat Charme :"); nb4 = 14;
                                                        ModifierStats(ref stats, nb4);
                                                    } // fin modification charme
                                                    else
                                                    {
                                                        if (saisie2 == "6") // affichage stats de l'arbre
                                                        {
                                                            Console.WriteLine("\nCharisme : {0}\nNégociation : {1}\nÉlocution : {2}\nPersuasion : {3}\nCharme : {4}\n\n", stats[10], stats[11], stats[12], stats[13], stats[14]);
                                                        } // fin affichage stats de l'arbre
                                                        else
                                                        {
                                                            if (saisie2 == "7") // retour menu précédent
                                                            {
                                                                saisie1 = "";
                                                            } // fin retour menu précédent
                                                            else
                                                            {
                                                                if (saisie2 == "8") // arrêt modification
                                                                {
                                                                    saisie3 = "";
                                                                    saisie1 = "";
                                                                    fini = true;
                                                                } // fin arrêt modification
                                                                else
                                                                {
                                                                    if (saisie2 == "9")// annulation modification
                                                                    {
                                                                        fini = true;
                                                                        modif = false;
                                                                        saisie3 = "";
                                                                        saisie1 = "";
                                                                    }// fin annulation modification
                                                                    else // erreur
                                                                    {
                                                                        Console.WriteLine("\nErreur de saisie de la stat\n");
                                                                    } // fin erreur
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                } // fin arbre social
                                while (saisie1 == "4") // arbre connaissances
                                {
                                    ok = true;
                                    Console.WriteLine("\nSélectionner la stat à modifier :\nConnaissances magiques (1)   Connaissances médicinales (2)   Connaissances géographiques (3)   Connaissances politiques (4)   Connaissances légendes (5)\nAfficher les stats de l'arbre (6)   Retourner au menu précédent (7)   Terminer la modification (8)   Annuler la modification (9)");
                                    saisie2 = Console.ReadLine();
                                    if (saisie2 == "1") // modification connaissances magiques
                                    {
                                        Console.WriteLine("\nSaisir la nouvelle valeur de la stat Connaissances magiques :"); nb4 = 15;
                                        ModifierStats(ref stats, nb4);
                                    } // fin modification connaissances magiques
                                    else
                                    {
                                        if (saisie2 == "2") // modification connaissances médicinales
                                        {
                                            Console.WriteLine("\nSaisir la nouvelle valeur de la stat Connaissances médicinales :"); nb4 = 16;
                                            ModifierStats(ref stats, nb4);
                                        } // fin modification connaissances médicinales
                                        else
                                        {
                                            if (saisie2 == "3") // modification connaissances géographiques
                                            {
                                                Console.WriteLine("\nSaisir la nouvelle valeur de la stat Connaissances géographiques :"); nb4 = 17;
                                                ModifierStats(ref stats, nb4);
                                            } // fin modification connaissances géographiques
                                            else
                                            {
                                                if (saisie2 == "4") // modification connaissances politiques
                                                {
                                                    Console.WriteLine("\nSaisir la nouvelle valeur de la stat Connaissances politiques :"); nb4 = 18;
                                                    ModifierStats(ref stats, nb4);
                                                } // fin modification connaissances politiques
                                                else
                                                {
                                                    if (saisie2 == "5") // modification connaissainces légendes
                                                    {
                                                        Console.WriteLine("\nSaisir la nouvelle valeur de la stat Connaissances légendes :"); nb4 = 19;
                                                        ModifierStats(ref stats, nb4);
                                                    } // fin modification connaissances légendes
                                                    else
                                                    {
                                                        if (saisie2 == "6") // affichage stats de l'arbre
                                                        {
                                                            Console.WriteLine("\nConnaissances magiques : {0}\nConnaissances médicinales : {1}\nConnaissances géographiques : {2}\nConnaissances politiques : {3}\nConnaissances légendes : {4}\n\n", stats[15], stats[16], stats[17], stats[18], stats[19]);
                                                        } // fin affichage stats de l'arbre
                                                        else
                                                        {
                                                            if (saisie2 == "7") // retour menu précédent
                                                            {
                                                                saisie1 = "";
                                                            } // fin retour menu précédent
                                                            else
                                                            {
                                                                if (saisie2 == "8") // arrêt modification
                                                                {
                                                                    saisie3 = "";
                                                                    saisie1 = "";
                                                                    fini = true;
                                                                } // fin arrêt modification
                                                                else
                                                                {
                                                                    if (saisie2 == "9")// annulation modification
                                                                    {
                                                                        fini = true;
                                                                        modif = false;
                                                                        saisie3 = "";
                                                                        saisie1 = "";
                                                                    }// fin annulation modification
                                                                    else // erreur
                                                                    {
                                                                        Console.WriteLine("\nErreur de saisie de la stat\n");
                                                                    } // fin erreur
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                } // fin arbre connaissances
                                if (saisie1 == "5") // affichage stats
                                {
                                    ok = true;
                                    Console.WriteLine("\nStats :\nPuissance : {0}\nEndurance : {1}\nRapidité : {2}\nAgilité : {3}\nFurtivité : {4}\nConcentration : {5}\nRéflexion : {6}\nForce mentale : {7}\nEndurance psychique : {8}\nIntelligence : {9}\nCharisme : {10}\nNégociation : {11}\nÉlocution : {12}\nPersuasion : {13}\nCharme : {14}\nConnaissances magiques : {15}\nConnaissances médicinales : {16}\nConnaissances géographiques : {17}\nConnaissances politiques : {18}\nConnaissances légendes : {19}\n\n", stats[0], stats[1], stats[2], stats[3], stats[4], stats[5], stats[6], stats[7], stats[8], stats[9], stats[10], stats[11], stats[12], stats[13], stats[14], stats[15], stats[16], stats[17], stats[18], stats[19]);
                                } // fin affichage stats
                                if (saisie1 == "6") // retour menu précédent
                                {
                                    ok = true;
                                    saisie3 = "";
                                } // fin retour menu précédent
                                if (saisie1 == "7") // arrêt modification
                                {
                                    ok = true;
                                    saisie3 = "";
                                    fini = true;
                                } // fin arrêt modification
                                if (saisie1 == "8")// annulation modification
                                {
                                    ok = true;
                                    fini = true;
                                    modif = false;
                                    saisie3 = "";
                                }// fin annulation modification
                            } // fin modif 20 stats
                            else // modif 3 stats
                            {
                                ok = true;
                                Console.WriteLine("\nSélectionner la stat à modifier :\nPhysique (1)   Mental (2)   Social (3)\nAfficher les stats (4)   Retourner au menu précédent (5)   Terminer la modification (6)");
                                saisie1 = Console.ReadLine();
                                if (saisie1 == "1")
                                {
                                    Console.WriteLine("\nSaisir la nouvelle valeur de la stat Physique :");
                                    ModifierStats(ref stats, 0);
                                } // fin modif physique
                                else
                                {
                                    if (saisie1 == "2")
                                    {
                                        Console.WriteLine("\nSaisir la nouvelle valeur de la stat Mental :");
                                        ModifierStats(ref stats, 1);
                                    } // fin modif mental
                                    else
                                    {
                                        if (saisie1 == "3")
                                        {
                                            Console.WriteLine("\nSaisir la nouvelle valeur de la stat Social :");
                                            ModifierStats(ref stats, 2);
                                        } // fin modif social
                                        else
                                        {
                                            if (saisie1 == "4") // affichage stats
                                            {
                                                ok = true;
                                                if (stat)
                                                {
                                                    Console.WriteLine("\nStats :\nPuissance : {0}\nEndurance : {1}\nRapidité : {2}\nAgilité : {3}\nFurtivité : {4}\nConcentration : {5}\nRéflexion : {6}\nForce mentale : {7}\nEndurance psychique : {8}\nIntelligence : {9}\nCharisme : {10}\nNégociation : {11}\nÉlocution : {12}\nPersuasion : {13}\nCharme : {14}\nConnaissances magiques : {15}\nConnaissances médicinales : {16}\nConnaissances géographiques : {17}\nConnaissances politiques : {18}\nConnaissances légendes : {19}\n\n", stats[0], stats[1], stats[2], stats[3], stats[4], stats[5], stats[6], stats[7], stats[8], stats[9], stats[10], stats[11], stats[12], stats[13], stats[14], stats[15], stats[16], stats[17], stats[18], stats[19]);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nStats :\nPhysique : {0}\nMental : {1}\nSocial : {2}\n\n", stats[0], stats[1], stats[2]);
                                                }
                                            } // fin affichage stats
                                            else
                                            {
                                                if (saisie1 == "5") // retour menu précédent
                                                {
                                                    ok = true;
                                                    saisie3 = "";
                                                } // fin retour menu précédent
                                                else
                                                {
                                                    if (saisie1 == "6") // arrêt modification
                                                    {
                                                        ok = true;
                                                        saisie3 = "";
                                                        fini = true;
                                                    } // fin arrêt modification
                                                    else
                                                    {
                                                        if (saisie1 == "7")// annulation modification
                                                        {
                                                            fini = true;
                                                            modif = false;
                                                            saisie3 = "";
                                                        }// fin annulation modification
                                                        else // erreur
                                                        {
                                                            Console.WriteLine("\nErreur de saisie de la stat\n");
                                                        } // fin erreur
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            } // fin modif 3 stats
                            if (!ok) // erreur
                            {
                                Console.WriteLine("\nErreur de saisie de l'arbre à modifier\n");
                            } // fin erreur
                        } // fin modification stats  
                        while (saisie3 == "2") // modification informations 
                        {
                            ok = true;
                            Console.WriteLine("\nSélectionner l'information à modifier :\nNom (1)   Race (2)   Morphologie (3)   Lien image (4)   Bio (5)   Afficher les informations (6)\nRetourner au menu précédent (7)   Terminer la modification (8)   Annuler la modification (9)");
                            saisie1 = Console.ReadLine();//numero contient le numéo de la fiche où le nom pourrait être modifié
                            if (saisie1 == "1") // modification nom
                            {
                                Console.WriteLine("\nSaisir le nouveau nom :");
                                nom = Console.ReadLine();
                            } // fin modification nom
                            else
                            {
                                if (saisie1 == "2") // modification race
                                {
                                    Console.WriteLine("\nSaisir la nouvelle race :");
                                    race = Console.ReadLine();
                                } // fin modification race
                                else
                                {
                                    if (saisie1 == "3") // modification morphologie
                                    {
                                        Console.WriteLine("\nSaisir la nouvelle morphologie (ex: 1m65 52kg) :");
                                        morphologie = Console.ReadLine();
                                    } // fin modification morphologie
                                    else
                                    {
                                        if (saisie1 == "4") // modification liens images discord
                                        {
                                            test = false;
                                            while (!test) // saisie du nombre d'image
                                            {
                                                Console.WriteLine("\nSaisir le nombre d'images discord du personnage (max 20) :");
                                                saisie1 = Console.ReadLine();
                                                test = Int32.TryParse(saisie1, out nb3);
                                                if (!test)
                                                {
                                                    Console.WriteLine("\nErreur lors de la saisie du nombre de paragraphes, recommencez.\n");
                                                }
                                            } //fin saisie nombre d'images
                                            for (nb1 = 0; nb1 < nb3; nb1++) // modification liens images discord
                                            {
                                                Console.WriteLine("\nSaisir le lien numéro {0}", nb1 + 1);
                                                saisie2 = Console.ReadLine();
                                                liens[nb1] = saisie2;
                                            }
                                        } // fin modification liens images discord
                                        else
                                        {
                                            if (saisie1 == "5") // modification bio
                                            {
                                                test = false;
                                                while (!test) // saisie du nombre de paragraphes
                                                {
                                                    Console.WriteLine("\nSaisir le nombre de paragraphes comportant la bio (max 20) :");
                                                    saisie1 = Console.ReadLine();
                                                    test = Int32.TryParse(saisie1, out nb2);
                                                    if (!test)
                                                    {
                                                        Console.WriteLine("\nErreur lors de la saisie du nombre de paragraphes, recommencez.\n");
                                                    }
                                                } // fin saisie du nombre de paragraphes
                                                for (nb1 = 0; nb1 < nb2; nb1++) // saisie paragraphes
                                                {
                                                    Console.WriteLine("\nSaisir le paragraphe numéro {0}", nb1 + 1);
                                                    saisie2 = Console.ReadLine();
                                                    bios[nb1] = saisie2;
                                                } // fin saisie paragraphes
                                            } // fin modification bio
                                            else
                                            {
                                                if (saisie1 == "6") // affichage informations
                                                {
                                                    Console.WriteLine("\nNom : {0}\nRace : {1}\nMorphologie : {2}\n\nLien photo discord :", nom, race, morphologie);
                                                    for (nb1 = 0; nb1 < nb3; nb1++) // affichage liens
                                                    {
                                                        Console.WriteLine(liens[nb1]);
                                                    } // fin affichage liens
                                                    Console.WriteLine("\nBio :");
                                                    for (nb1 = 0; nb1 < nb2; nb1++) // affichage bio
                                                    {
                                                        Console.WriteLine(bios[nb1]);
                                                    } // fin affichage bio
                                                } // fin affichage informations
                                                else
                                                {
                                                    if (saisie1 == "7") // retour menu précédent
                                                    {
                                                        saisie3 = "";
                                                    } // fin retour menu précédent
                                                    else
                                                    {
                                                        if (saisie1 == "8") // choix arrêt modification
                                                        {
                                                            saisie3 = "";
                                                            fini = true;
                                                        }// fin choix arrêt modification
                                                        else
                                                        {
                                                            if (saisie1 == "9")// annulation modification
                                                            {
                                                                fini = true;
                                                                saisie3 = "";
                                                                modif = false;
                                                            }// fin annulation modification
                                                            else // erreur
                                                            {
                                                                Console.WriteLine("Erreur de saisie de paramètre");
                                                            } // fin erreur
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        } // fin modification informations
                        if (saisie3 == "3") // affichage fiche entière
                        {
                            ok = true;
                            Console.WriteLine("\n\nNom : {0}\nRace : {1}\nMorphologie : {2}\n\nLien photo discord :", nom, race, morphologie);
                            for (nb1 = 0; nb1 < nb3; nb1++) // lecture liens images discord
                            {
                                Console.WriteLine(liens[nb1]);
                            } // fin lecture images discord
                            Console.WriteLine("\nBio :");
                            for (nb1 = 0; nb1 < nb2; nb1++) // lecture bio
                            {
                                Console.WriteLine(bios[nb1]);
                            } // fin lecture bio
                            if (stat)
                            {
                                Console.WriteLine("\nStats :\nPuissance : {0}\nEndurance : {1}\nRapidité : {2}\nAgilité : {3}\nFurtivité : {4}\nConcentration : {5}\nRéflexion : {6}\nForce mentale : {7}\nEndurance psychique : {8}\nIntelligence : {9}\nCharisme : {10}\nNégociation : {11}\nÉlocution : {12}\nPersuasion : {13}\nCharme : {14}\nConnaissances magiques : {15}\nConnaissances médicinales : {16}\nConnaissances géographiques : {17}\nConnaissances politiques : {18}\nConnaissances légendes : {19}\n\n", stats[0], stats[1], stats[2], stats[3], stats[4], stats[5], stats[6], stats[7], stats[8], stats[9], stats[10], stats[11], stats[12], stats[13], stats[14], stats[15], stats[16], stats[17], stats[18], stats[19]);
                            }
                            else
                            {
                                Console.WriteLine("\nStats :\nPhysique : {0}\nMental : {1}\nSocial : {2}\n\n", stats[0], stats[1], stats[2]);
                            }
                        } // fin affichage fiche entière
                        if (saisie3 == "4") // arrêt modification
                        {
                            ok = true;
                            fini = true;
                            Console.WriteLine("\n\n\n");
                        } // fin arrêt modification
                        if (saisie3 == "5")// annulation modification
                        {
                            ok = true;
                            fini = true;
                            modif = false;
                        }// fin annulation modification
                        if (!ok) // erreur
                        {
                            Console.WriteLine("\nErreur de saisie du paramètre\n");
                        } // fin erreur
                    } // fin modification
                    if (modif) // enregistrement modification
                    {
                        sw = new StreamWriter(cheminFiches);
                        if (stat)
                        {
                            sw.WriteLine("2");
                            for (nb1 = 0; nb1 < 20; nb1++) // réécriture 20 stats
                            {
                                sw.WriteLine(stats[nb1]);
                            } // fin réécriture 20 stats
                        }
                        else
                        {
                            sw.WriteLine("1");
                            for (nb1 = 0; nb1 < 3; nb1++) // réécriture 3 stats
                            {
                                sw.WriteLine(stats[nb1]);
                            } // fin réécriture 3 stats
                        }
                        sw.WriteLine("{0}\n{1}\n{2}", nom, race, morphologie);
                        for (nb1 = 0; nb1 < nb3; nb1++) // réécriture liens images discord
                        {
                            sw.WriteLine(liens[nb1]);
                        } // fin réécriture liens images discord
                        sw.WriteLine(" ");
                        for (nb1 = 0; nb1 < nb2; nb1++) // réécriture bio
                        {
                            sw.WriteLine(bios[nb1]);
                        } // fin réécriture bio
                        sw.Close();
                        sr = new StreamReader(cheminListe);
                        sw = new StreamWriter(cheminTampon);
                        while (!sr.EndOfStream) // sauvegarde liste
                        {
                            sw.WriteLine(sr.ReadLine());
                        } // fin sauvegarde liste
                        sr.Close();
                        sw.Close();
                        sr = new StreamReader(cheminTampon);
                        sw = new StreamWriter(cheminListe);
                        for (nb1 = 0; nb1 < numero; nb1++) // réécriture début liste non modifié
                        {
                            sw.WriteLine(sr.ReadLine());
                        } // fin réécriture début liste non modifié
                        sw.WriteLine("La fiche de {0} est la numéro {1}.", nom, numero);
                        sr.ReadLine();
                        while (!sr.EndOfStream) // réécriture fin liste non modifié
                        {
                            sw.WriteLine(sr.ReadLine());
                        } // fin réécriture fin liste non modifié
                        sr.Close();
                        sw.Close();
                        Console.WriteLine("Modification de la fiche de " + nom + " terminée avec succès.");
                    } // fin enregistrement modification
                    else // confirmation annulation
                    {
                        Console.WriteLine("\nModification de la fiche de " + nom + " annulée.\n");
                    } // fin confirmation annulation
                }
                else // erreur
                {
                    Console.WriteLine("\nFiche inexistante\n\n\n");
                } // fin erreur
            }
        }
        public static void AfficherFiche(ref string user)
        {
            int[] stats = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            // puissance = stats[0], endurance = stats[1], rapidite = stats[2], agilite = stats[3], furtivite = stats[4], concentration = stats[5], reflexion = stats[6], force_mentale = stats[7], endurance_psy = stats[8], intelligence = stats[9], Charisme = stats[10], Negociation = stats[11], Elocution = stats[12], Persuasion = stats[13], Charme = stats[14], connaissances_magiques = stats[15], connaissances_medicinales = stats[16], connaissances_geographiques = stats[17], connaissances_politiques = stats[18], connaissances_legendes = stats[19]
            // si 3 stats : physique = stats[0], mental = stats[1], social = stats[2]
            int numero, nb;
            string saisie, cheminFiches, nom, morphologie, race;
            bool test, ok, stat = false;
            StreamReader sr;
            Console.WriteLine("Saisir le numéro de la fiche\n");
            saisie = Console.ReadLine();
            Console.WriteLine();
            test = Int32.TryParse(saisie, out numero);
            if (test)
            {
                cheminFiches = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\fiche_numero_" + numero + ".txt";
                if (File.Exists(cheminFiches)) // lecture fiche
                {
                    sr = new StreamReader(cheminFiches);
                    saisie = sr.ReadLine();
                    if (saisie == "2") // vérification type de stats
                    {
                        stat = true;
                    } // fin vérification type de stats
                    if (stat)
                    {
                        for (nb = 0; nb < 20; nb++) // lecture 20 stats
                        {
                            stats[nb] = Convert.ToInt32(sr.ReadLine());
                        } // fin lecture 20 stats
                    }
                    else
                    {
                        for (nb = 0; nb < 3; nb++) // lecture 3 stats
                        {
                            stats[nb] = Convert.ToInt32(sr.ReadLine());
                        } // fin lecture 3 stats
                    }
                    nom = sr.ReadLine();
                    race = sr.ReadLine();
                    morphologie = sr.ReadLine();
                    Console.WriteLine("Nom : {0}\nRace : {1}\nMorphologie : {2}\n\nLien photo discord :", nom, race, morphologie);
                    ok = false;
                    while (!ok) // lecture liens
                    {
                        saisie = sr.ReadLine();
                        if (saisie.Length != 0)
                        {
                            Console.WriteLine(saisie);
                        }
                        if (saisie == " ")
                        {
                            ok = true;
                        }
                    } // fin lecture liens
                    Console.WriteLine("Bio :");
                    ok = false;
                    while (!sr.EndOfStream) // lecture bio
                    {
                        Console.WriteLine(sr.ReadLine());
                    } // fin lecture bio
                    sr.Close();
                    if (stat)
                    {
                        Console.WriteLine("\nStats :\nPuissance : {0}\nEndurance : {1}\nRapidité : {2}\nAgilité : {3}\nFurtivité : {4}\nConcentration : {5}\nRéflexion : {6}\nForce mentale : {7}\nEndurance psychique : {8}\nIntelligence : {9}\nCharisme : {10}\nNégociation : {11}\nÉlocution : {12}\nPersuasion : {13}\nCharme : {14}\nConnaissances magiques : {15}\nConnaissances médicinales : {16}\nConnaissances géographiques : {17}\nConnaissances politiques : {18}\nConnaissances légendes : {19}", stats[0], stats[1], stats[2], stats[3], stats[4], stats[5], stats[6], stats[7], stats[8], stats[9], stats[10], stats[11], stats[12], stats[13], stats[14], stats[15], stats[16], stats[17], stats[18], stats[19]);
                    }
                    else
                    {
                        Console.WriteLine("\nStats :\nPhysique : {0}\nMental : {1}\nSocial : {2}", stats[0], stats[1], stats[2]);
                    }
                } // fin lecture fiche
                else // erreur de numéro
                {
                    Console.WriteLine("\nFiche personnage inexistante au numéro {0}", numero);
                } // fin erreur de numéro
            }
            else // erreur de saisie
            {
                Console.WriteLine("Erreur lors de la saisie du numéro.");
            } // fin erreur de saisie
            Console.WriteLine("\n\n\n");
        }
        public static void AfficherListe(ref string user)
        {
            StreamReader sr;
            string saisie, cheminListe = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste.txt";
            int nb;
            if (File.Exists(cheminListe))
            {
                sr = new StreamReader(cheminListe);
                nb = 0;
                while (sr.EndOfStream == false)
                {
                    saisie = sr.ReadLine();
                    if (saisie != " ")
                    {
                        Console.WriteLine(saisie);
                        nb++;
                    }
                }
                sr.Close();
                if (nb<1)
                {
                    Console.WriteLine("Aucune fiche n'existe ici pour le moment.");
                }
                Console.WriteLine("\n\n\n");
            }
            else
            {
                Console.WriteLine("\nAucune fiche n'a été créée\n\n\n");
            }
        }
        public static void SupprimerFiche(ref string user)
        {
            int numero, nb;
            string saisie, FicheTampon = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\fiche_tampon.txt", ListeTampon = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste_tampon.txt", cheminListe = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste.txt",
                cheminFiches;
            bool ok;
            StreamReader sr;
            StreamWriter sw;

            Console.WriteLine("Saisir le numéro de la fiche à supprimer\n");
            saisie = Console.ReadLine();
            Console.WriteLine();
            ok = Int32.TryParse(saisie, out numero);
            if (ok)
            {
                cheminFiches = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\fiche_numero_" + numero + ".txt";
                if (File.Exists(cheminFiches))
                {
                    Console.WriteLine("Êtes-vous sûr de vouloir supprimer cette fiche ?\nOui (o)   Non (n)");
                    saisie = Console.ReadLine().ToLower();
                    if (saisie == "n") // arrêt suppression de la fiche
                    {
                        Console.WriteLine("\nSuppression annulée\n\n\n");
                    } // fin arrêt suppression de la fiche
                    else
                    {
                        if (saisie == "o") // suppression de la fiche
                        {
                            Console.WriteLine("\nSuppression effectuée\n\n\n");
                            sr = new StreamReader(cheminListe);
                            sw = new StreamWriter(ListeTampon);
                            while (!sr.EndOfStream) // sauvegarde liste
                            {
                                sw.WriteLine(sr.ReadLine());
                            } // fin sauvegarde liste
                            sr.Close();
                            sw.Close();
                            sr = new StreamReader(ListeTampon);
                            sw = new StreamWriter(cheminListe);
                            for (nb = 0; nb < numero; nb++) // réécriture début liste
                            {
                                sw.WriteLine(sr.ReadLine());
                            } // fin réécriture début liste
                            sr.ReadLine();
                            sw.WriteLine(" ");
                            while (!sr.EndOfStream) // réécriture fin liste
                            {
                                sw.WriteLine(sr.ReadLine());
                            } // fin réécriture fin liste
                            sr.Close();
                            sw.Close();
                            sr = new StreamReader(cheminFiches);
                            sw = new StreamWriter(FicheTampon);
                            sw.WriteLine(numero);
                            while (!sr.EndOfStream) // sauvegarde fiche tampon
                            {
                                sw.WriteLine(sr.ReadLine());
                            } // fin sauvegarde fiche tampon
                            sr.Close();
                            sw.Close();
                            File.Delete(cheminFiches);
                        } // fin suppression de la fiche
                        else // erreur
                        {
                            Console.WriteLine("\nErreur de saisie de la commande, retour au menu principal\n\n\n");
                        } // fin erreur
                    }
                }
                else // erreur
                {
                    Console.WriteLine("Fiche inexistante au numéro {0}\n\n\n", numero);
                } // fin erreur
            }
            else // erreur
            {
                Console.WriteLine("Erreur lors de la saisie du numéro de la fiche");
            } // fin erreur
        }
        public static void RestaurerFiche(ref string user)
        {
            int numero, nb;
            string saisie, FicheTampon = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\fiche_tampon.txt", cheminTampon = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste_tampon.txt", cheminListe = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\liste.txt",
                cheminFiches, nom;
            StreamReader sr;
            StreamWriter sw;

            sr = new StreamReader(FicheTampon);
            numero = Convert.ToInt32(sr.ReadLine());
            saisie = sr.ReadLine();
            if (saisie == "2")
            {
                for (nb = 0; nb < 20; nb++) // ignore 20 stats
                {
                    sr.ReadLine();
                } // fin ignore 20 stats
            }
            else
            {
                for (nb = 0; nb < 3; nb++) // ignore 3 stats
                {
                    sr.ReadLine();
                } // fin ignore 3 stats
            }
            nom = sr.ReadLine();
            sr.Close();
            Console.WriteLine("Restorer la fiche de {0} ?\nOui (o)   Non (n)\n", nom);
            saisie = Console.ReadLine().ToLower();
            if (saisie == "o")
            {
                cheminFiches = "C:\\Users\\" + Environment.UserName + "\\Desktop\\jdr\\Naaru\\fiche perso\\" + user + "\\fiche_numero_" + numero + ".txt";
                sw = new StreamWriter(cheminFiches);
                sr = new StreamReader(FicheTampon);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    sw.WriteLine(sr.ReadLine());
                }
                sw.Close();
                sr.Close();
                Console.WriteLine("\nLa fiche porte le numéro {0}\n", numero);
                sw = new StreamWriter(cheminTampon);
                sr = new StreamReader(cheminListe);
                while (!sr.EndOfStream) // sauvegarde liste
                {
                    sw.WriteLine(sr.ReadLine());
                } // fin sauvegarde liste
                sw.Close();
                sr.Close();
                sw = new StreamWriter(cheminListe);
                sr = new StreamReader(cheminTampon);
                for (nb = 0; nb < numero; nb++) // réécriture début liste
                {
                    sw.WriteLine(sr.ReadLine());
                } // fin réécriture début liste
                sw.WriteLine("La fiche de {0} est la numéro {1}.", nom, numero);
                sr.ReadLine();
                while (!sr.EndOfStream) // réécriture fin liste
                {
                    sw.WriteLine(sr.ReadLine());
                } // réécriture fin liste
                sr.Close();
                sw.Close();
                File.Delete(FicheTampon);
            }
            else
            {
                if (saisie == "n") // annulation
                {
                    Console.WriteLine("\nRestoration annulée\n\n\n");
                } // fin annulation
                else // erreur
                {
                    Console.WriteLine("Erreur de saisie lors de la validation, retour au menu principal");
                } // fin erreur
            }
        }
        public static void LancerDes()
        {
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
//git c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbiengit c tropbien