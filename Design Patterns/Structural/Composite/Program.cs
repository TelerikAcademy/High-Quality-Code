namespace CompositePattern
{
    public static class Program
    {
        public static void Main()
        {
            var king = new Commander("Leonidas");

            var grandGeneral = new Commander("Xena The Princess Warrior");
            king.Add(grandGeneral);

            var generalProtos = new Commander("General Protos");
            grandGeneral.Add(generalProtos);

            var officerTonga = new Commander("Officer Tonga");
            generalProtos.Add(officerTonga);
            officerTonga.Add(new Person("Kin"));
            officerTonga.Add(new Person("Briko"));
            officerTonga.Add(new Person("Zaler"));

            var officerHerin = new Commander("Officer Herin");
            generalProtos.Add(officerHerin);
            officerHerin.Add(new Person("Gorok"));
            officerHerin.Add(new Person("Bozat"));
            officerHerin.Add(new Person("Koreb"));
            officerHerin.Add(new Person("Tikal"));
            officerHerin.Add(new Person("Mera"));

            var officerSalazar = new Commander("Officer Salazar");
            generalProtos.Add(officerSalazar);
            officerSalazar.Add(new Person("Kira"));
            officerSalazar.Add(new Person("Zaler"));
            officerSalazar.Add(new Person("Perin"));
            officerSalazar.Add(new Person("Subotli"));

            king.Display(1);
        }
    }
}