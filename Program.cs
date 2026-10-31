using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

const int GyozelmiPont = 3;
int nyertMerkozesek = 0;
int vesztettMerkozesek = 0;
int nyertKorok = 0;
int vesztettKorok = 0;
int dontetlenKorok = 0;

char menupont;

do
{
    Console.WriteLine("=== KŐ – PAPÍR – OLLÓ ===");
    Console.WriteLine(" Új mérkőzés");
    Console.WriteLine(" Statisztika");
    Console.WriteLine(" Statisztika nullázása");
    Console.WriteLine("[K] Kilépés");
    Console.Write("Választás: ");

    menupont = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (menupont)
    {
        case '1':
            char ujrajatekValaszt;
            do
            {
                Console.WriteLine("\nÚj mérkőzés! Aki előbb eléri a 3 pontot, nyer.");
                int jatekosPont = 0;
                int gepPont = 0;
                bool megszakitva = false;

                while (jatekosPont < GyozelmiPont && gepPont < GyozelmiPont && !megszakitva)
                {
                    Console.Write("Választásod (k = kő, p = papír, o = olló, m = főmenü): ");
                    string? beviteli = Console.ReadLine();

                    string jatekosValasztasa = beviteli switch
                    {
                        "k" or "K" => "kő",
                        "p" or "P" => "papír",
                        "o" or "O" => "olló",
                        "m" or "M" => "főmenü",
                        _ => "hiba"
                    };

                    if (jatekosValasztasa == "hiba")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Csak k, p, o vagy m betűt adhatsz meg!");
                        Console.ResetColor();
                        continue;
                    }

                    if (jatekosValasztasa == "főmenü")
                    {
                        megszakitva = true;
                        break;
                    }

                    int gepszam = Random.Shared.Next(1, 4);
                    string gepValasztasa = gepszam switch
                    {
                        1 => "kő",
                        2 => "papír",
                        _ => "olló",
                    };

                    Console.Write($"Te: {jatekosValasztasa}, gép: {gepValasztasa} — ");

                    if (jatekosValasztasa == gepValasztasa)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("döntetlen.");
                        dontetlenKorok++;
                    }
                    else if ((jatekosValasztasa == "kő" && gepValasztasa == "olló") ||
                             (jatekosValasztasa == "olló" && gepValasztasa == "papír") ||
                             (jatekosValasztasa == "papír" && gepValasztasa == "kő"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ezt a kört te nyerted!");
                        jatekosPont++;
                        nyertKorok++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ezt a kört a gép nyerte.");
                        gepPont++;
                        vesztettKorok++;
                    }
                    Console.ResetColor();

                    Console.WriteLine($"Állás: te {jatekosPont} – {gepPont} gép\n");
                }

                if (!megszakitva)
                {
                    if (jatekosPont == GyozelmiPont)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Megnyerted a mérkőzést {jatekosPont}:{gepPont} arányban!");
                        nyertMerkozesek++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"A gép megnyerte a mérkőzést {gepPont}:{jatekosPont} arányban!");
                        vesztettMerkozesek++;
                    }
                    Console.ResetColor();

                    do
                    {
                        Console.Write("Akarsz újra játszani? (i/n): ");
                        ujrajatekValaszt = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                    } while (ujrajatekValaszt != 'i' && ujrajatekValaszt != 'I' &&
                             ujrajatekValaszt != 'n' && ujrajatekValaszt != 'N');
                }
                else
                {
                    ujrajatekValaszt = 'n';
                    Console.WriteLine("\nMérkőzés megszakítva. Visszatérés a főmenübe...\n");
                }

            } while (ujrajatekValaszt == 'i' || ujrajatekValaszt == 'I');
            break;

        case '2':
            int osszesMerkozes = nyertMerkozesek + vesztettMerkozesek;
            int osszesKor = nyertKorok + vesztettKorok + dontetlenKorok;

            Console.WriteLine("\n--- Statisztika ---");
            Console.WriteLine($"Mérkőzések: {osszesMerkozes} (nyert: {nyertMerkozesek}, vesztett: {vesztettMerkozesek})");

            if (osszesMerkozes > 0)
            {
                double arany = (double)nyertMerkozesek / osszesMerkozes;
                Console.WriteLine($"Győzelmi arány: {arany:P0}");
            }

            Console.WriteLine($"Körök: {osszesKor} (nyert: {nyertKorok}, vesztett: {vesztettKorok}, döntetlen: {dontetlenKorok})\n");
            break;

        case '3':
            char megerosites;
            do
            {
                Console.Write("Biztosan nullázni szeretnéd a statisztikát? (i/n): ");
                megerosites = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (megerosites != 'i' && megerosites != 'I' &&
                     megerosites != 'n' && megerosites != 'N');

            if (megerosites == 'i' || megerosites == 'I')
            {
                nyertMerkozesek = 0;
                vesztettMerkozesek = 0;
                nyertKorok = 0;
                vesztettKorok = 0;
                dontetlenKorok = 0;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Statisztika sikeresen nullázva!\n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Nullázás megszakítva.\n");
            }
            break;

        case 'k':
        case 'K':
            Console.WriteLine("\nKöszönöm a játékot! Kilépés...");
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nHibás menüpont! Kérlek válassz a lehetőségek közül.\n");
            Console.ResetColor();
            break;
    }

} while (menupont != 'k' && menupont != 'K');
