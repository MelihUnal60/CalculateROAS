namespace CalculateROAS.Business
{


    //Access Modifier (Erişim Belirleyici)
    /*
     * public : Genel, her yerden erişilebilir
     * Internal : Sadece bulunduğu assembly erişebilir
     * private : Sadece içinde olduğu sınıftan erişilebilir
     * protected : Sadece içinde olduğu sınıftan ve kalıtım alan sınıflardan erişilebilir
     */






    public class ROAS
    {
        public string reklamKanali;
        public double reklamMaliyeti;
        public double birimFiyat;
        public int satilanUrunAdedi;

        public double ROASHesapla()
        {
            return ((satilanUrunAdedi * birimFiyat) / reklamMaliyeti) * 100;
        }

    }
}