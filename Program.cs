namespace abstract_osztály
{
    internal abstract class Program
    {





        abstract class Alakzat //nem tudod példányosítani mert nyomi,de az öröklődéstben lehet haszálni
        {
            public string Nev { get; set; }
            protected Alakzat(string nev) //kontruktor vagy micsoda,ezzel lehet adni az alakzat nevét
            {
                Nev = nev;
            }

        }
        public abstract double Terulet();//metódus, amit az öröklődő osztálynak kell impelementálnia(mert ez is nyomorék)

        public virtual string Leiras() //metódus, amit az öröklődő osztálynak lehet impelementálnia, de nem kötelező(ez kevésbé nyomorék)
        {
            return $"Az alakzat neve: {Nev},adatai:{Terulet():F2}.";
        }
        class Teglalap : Alakzat //öröklődés kiírása
        {
            public double Szelesseg { get; set; }
            public double Magasság { get; set; }

            public Teglalap(string nev, double szelesseg, double magassag)
                : base(nev)//a base kulcsszóval hívjuk meg az ősosztály konstruktorát
            {
                Szelesseg = szelesseg;
                Magasság = magassag;
            }
            public override double Terulet()
            {
                return Szelesseg * Magasság;
            }

            class Kor : Alakzat // a kör egy nyomorék alakzat
            {
                public double Sugar { get; set; }
                public Kor(string nev, double sugar)
                    : base(nev)
                {
                    Sugar = sugar;
                }
                public override double Terulet()
                {
                    return Math.PI * Sugar * Sugar;//eltakarodhat szépen a mélytengerekre horgászhalat molesztálni(rohadjon meg)
                }
            }

            class Haromszog : Alakzat //ez se jobb a körnél,de legalább nem molesztálja a horgászhalakat(csak a polipokat,mert egy gyökér)
            {
                public double A { get; set; }
                public double B { get; set; }
                public double C { get; set; }

                public Haromszog(string nev, double a, double b, double c)
                    : base(nev)
                {
                    A = a;
                    B = b;
                    C = c;
                }
                public override double Terulet()
                {
                    double s = (A + B + C) / 2;
                    return Math.Sqrt(s * (s - A) * (s - B) * (s - C)); //ezt inkább nem részletezem mert ez nem csak nyomorék,hanem borzalmas
                }



                class Program
                {
                    static void Main()
                    {

                        List<Alakzat> alakzatok = new List<Alakzat>(); //lista létrehozása amiben az alakzatokat tároljuk

                        alakzatok.Add(new Kor(3));
                        alakzatok.Add(new Teglalap(4, 5));
                        alakzatok.Add(new Haromszog(3, 4, 5));


                        double osszterulet = 0;
                        Alakzat legnagyobb = alakzatok[0];

                        foreach (Alakzat a in alakzatok)
                        {
                            Console.WriteLine(a.Leiras());
                            osszterulet = osszterulet a.Terulet();



                            if (a.Terulet() > legnagyobb.Terulet())
                            {
                                legnagyobb = a;
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Osszes terulet: {osszterulet:F2}");
                        Console.WriteLine($"A legnagyobb: {legnagyobb.Nev}");
                    }
                }
            }


        }

    }
}





       
    


