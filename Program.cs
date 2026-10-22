using System.ComponentModel.Design;

Console.OutputEncoding = System.Text.Encoding.UTF8;
const int Gyozelmi = 3;
int nyerteskorok;
int veszteskorok;
int dontetlenkorok;

char valasztas;
do
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("===");
    Console.Write("  Kő");
    Console.Write(" ===");
    Console.Write(" Papír");
    Console.Write(" ===");
    Console.WriteLine(" Olló");
    Console.ResetColor();

    Konzol.Cim("Főmenü");
    Konzol.Menupontok("Új mérkőzés", 1);
    Konzol.Menupontok("Statisztika", 2);
    Konzol.Menupontok("Statisztika nullázása", 3);
    Konzol.Menupontok("Kilépés, [K]");
    Konzol.Menupontok("Választás: ");


    valasztas = Console.ReadKey().KeyChar;
    Console.WriteLine();
    
    switch (valasztas)
    {
        case '1':
            char ujrajatekvalaszt;
            
            do
            {
                Console.WriteLine("Új mérkőzés! Aki előbb eléri a 3 pontot, nyer. ");
                int jatekospont = 0;
                int geppont = 0;
                bool megszakitva = false;
                while (jatekospont < 3 && geppont < 3) ;
                {
                    Console.Write("A választásod (k = kő, p = papír, o = olló)");
                    string? beviteli = Console.ReadLine();
                    string jatekosvalasztas = beviteli switch
                    {
                        "k" or "K" => "kő",
                        "p" or "P" => "papír",
                        "o" or "O" => "ollo",
                        _ => "hiba"
                    };
                    if (jatekosvalasztas == "hiba")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Csak k, p, o betűt írhatsz");
                        Console.ResetColor();
                        continue;
                    }
                    int gepszam = Random.Shared.Next(1, 3);
                    string gepvalasztasa = gepszam switch
                    {
                        1 => "kő",
                        2 => "papír",
                        _ => "olló",
                    };
                    Console.Write($"Te: {jatekosvalasztas}");
                    if (jatekosvalasztas == gepvalasztasa)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Döntetlen");
                        dontetlenkorok++;
                    }
                    else if ((jatekosvalasztas == "kő" && gepvalasztasa == "olló") ||
                        (jatekosvalasztas == "olló" && gepvalasztasa == "papír") ||
                        (jatekosvalasztas == "papír" && gepvalasztasa == "kő")) ;
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nyertél");
                        nyerteskorok++;

                    }

                    else if((jatekosvalasztas == "kő" && gepvalasztasa == "papír")||
                        (jatekosvalasztas == "papír" && gepvalasztasa == "olló") ||
                        (jatekosvalasztas == "olló" && gepvalasztasa == "kő")
                     )
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Veszítettél");
                        veszteskorok++;
                    }
                }


            }
            while (valasztas != 'k' && valasztas != 'K');
            break;
