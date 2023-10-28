using System.Text;
using Szoftverek;

static List<Szoftver> MagasErtekelesuAntivirus(List<Szoftver> szoftverek) 
{
    return szoftverek
        .Where(sz => sz.Ertekeles > 8.5 && sz.Kategoria == "antivírus")
        .ToList();
}
static void MajdnemLegjobbErtekeles(List<Szoftver> szoftverek) 
{
    double legjobb = szoftverek
        .Max(sz => sz.Ertekeles);
    double elmarad = 0.1;
    var megfeleloSzoftverek = szoftverek
        .Where(sz => sz.Ertekeles + elmarad == legjobb);

    foreach (var szoftver in megfeleloSzoftverek)
    {
        Console.WriteLine(szoftver);
    }
    Console.WriteLine($"\t{megfeleloSzoftverek.Count()} db szoftver van aminek az értékelés 0,1-el marad el a legjobbtól ami meg : {legjobb}\n");

}
static double AtlagBrutto(List<Szoftver> szoftverek) 
{
    var AdobeSzoftverek = szoftverek
        .Where(sz => sz.Nev.StartsWith("Adobe"))
        .ToList();
    double osszBrutto = 0;

    for (int i = 0; i < AdobeSzoftverek.Count(); i++)
    {
        osszBrutto += AdobeSzoftverek[i].burttoAr();
    }

    return osszBrutto / AdobeSzoftverek.Count();

}

static List<Szoftver> Feladat11(List<Szoftver> szoftverek) 
{
    return szoftverek
        .Where(sz => sz.OpKompabilitas2 is not null)
        .OrderBy(sz => sz.Kategoria)
        .ToList();
}
static List<int> Feladat12(List<Szoftver> szoftverek) 
{
    return szoftverek
        .Where(sz => sz.NettoArUSD > 500 && sz.Ertekeles < 9)
        .Select(sz => sz.Azonosito)
        .ToList();
}
static void Kiiras(List<Szoftver> szoftverek) 
{
    StreamWriter sw = new(@"..\..\..\src\elso10fizetos.txt",false);
    var elso10fizetos = szoftverek
        .Where(sz => sz.LicencTipus == "fizetős")
        .ToList();
    for (int i = 0; i < elso10fizetos.Count() && i < 10; i++)
    {
        sw.WriteLine(elso10fizetos[i].ToString());
    }
    sw.Close();
}

List<Szoftver> szoftverek = new();
StreamReader sr = new(@"..\..\..\src\szoftverek.txt",Encoding.UTF8);

_ = sr.ReadLine();

while (!sr.EndOfStream) szoftverek.Add(new(sr.ReadLine()));

foreach (var szoftver in szoftverek)
    Console.WriteLine(szoftver);

Console.WriteLine("7. feladat:\n");
foreach (var szoftver in MagasErtekelesuAntivirus(szoftverek))
    Console.WriteLine(szoftver);

Console.WriteLine("8. feladat:\n");
MajdnemLegjobbErtekeles(szoftverek);

Console.WriteLine("10. feladat:\n");
Console.WriteLine($"\tAz Adobe termékek átlagos bruttó ára: {AtlagBrutto(szoftverek)} usd\n");

Console.WriteLine("11. feladat:\n");
try
{
    foreach (var szoftver in Feladat11(szoftverek))
    {
        Console.WriteLine(szoftver);
    }
}
catch
{
    Console.WriteLine("\tNincs olyan szoftver a listábna ami kompatibilis lenne 2 operációs rendszerrel!\n");
}

Console.WriteLine("12. feladat:\n");

if (Feladat12(szoftverek).Count() == 0)
    Console.WriteLine("\tNincs olyan szoftver ami 500 USD-nál drágább, 9-esnél gyengébb értékeléssel rendelkezik!\n");
else 
{
    Console.WriteLine("\t500 USD-nál drágább, 9-esnél gyengébb értékeléssel rendelkező szoftverek azonosíja/ji: ");
    foreach (var szoftverID in Feladat12(szoftverek))
    {
        Console.Write($"{szoftverID}");
    }
}

Kiiras(szoftverek);

Console.ReadKey();