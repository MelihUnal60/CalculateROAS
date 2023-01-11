// ROAS = (Reklam geliri / reklam maliyeti) x 100
using CalculateROAS.Business;
namespace CalculateROAS
{
    public class Program
    {
        public static void Main()
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Yeni ROAS Hesabı \n2. ROAS Hesap Listesi\n3. Arama\n4. Çıkış");
            MenuSelection();

        }

        static void MenuSelection()
        {
            Console.Write("Yapılacak işlemi seçiniz");
            string secim = Console.ReadLine();
            switch(secim)
            {
                case "1":
                    NewRoas();
                    break;
                case "2":
                    ListOfROAS();
                    break;
                case "3":
                    Search();
                    break;
                        case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Hatalı seçim");
                    MenuSelection();
                    break;

            }
        }

        private static void Search()
        {
            
        }

        private static void NewRoas()
        {
            ROAS newROAS = new ROAS();   // sınıflardan nesne oluşturma yöntemi.. ilk sefer değer atarken soldaki ROAS sınıfı yazılır


            Console.Write("Reklam kanal adı : ");
            newROAS.reklamKanali = Console.ReadLine();
            Console.Write("Reklam maliyeti : ");
            newROAS.reklamMaliyeti = Convert.ToDouble(Console.ReadLine());
            Console.Write("Satılan ürün adedi : ");
            newROAS.satilanUrunAdedi = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ürün birim fiyatı : ");
            newROAS.birimFiyat = Convert.ToDouble(Console.ReadLine());

            ROASService.SaveROAS(newROAS);
            WriteToScreen(newROAS);
            Again();

        }

        private static void Again()
        {
            Console.WriteLine("Menüye dönmek için ENTER");
            Console.ReadLine();
            Menu();
        }

        static void WriteToScreen(ROAS r)
        {
            Console.WriteLine($"Reklam Kanalı : {r.reklamKanali}, Maliyet : {r.reklamMaliyeti}, Satılan ürün adedi : {r.satilanUrunAdedi}, Ürün birim fiyatı : {r.birimFiyat}, Toplam Getiri : {r.birimFiyat*r.satilanUrunAdedi}");
        }

        private static void ListOfROAS()
        {
            var roasList = ROASService.GetROASList();


            foreach(ROAS x in roasList)
            {
                WriteToScreen(x);
            }
        }
    }

    
}