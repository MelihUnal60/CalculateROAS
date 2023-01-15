using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ROASApp.Data;

namespace CalculateROAS.Business
{
    public class ROASService // bu sınıfın içinde roas listesini tutuyoruz
    {
        private static List<ROAS> liste = new List<ROAS>();

        public static void SaveROAS(ROAS roas)
        {
            GetROASList();
            liste.Add(roas);

            string json = JsonSerializer.Serialize(liste, new JsonSerializerOptions { IncludeFields = true});

            FileOperations.Write(json);
        }
        public static IReadOnlyCollection<ROAS> GetROASList() // roas listesinin sadece okunabilir bir kopyası oluşturulur. Diğer metodların içinde bu kopya üzerinde işlem yapılamaz.
        {
            
            string json = FileOperations.Read();
            if (!string.IsNullOrEmpty(json))
            {
                liste = JsonSerializer.Deserialize<List<ROAS>>(json, new JsonSerializerOptions { IncludeFields = true });
            }
                return liste.AsReadOnly(); //sadece okunabilir koleksiyon
            
        }
        public static IReadOnlyCollection<ROAS> SearchROAS(string reklamKanali)
        {
            GetROASList();

            var sonuc = new List<ROAS>();

            foreach(var item in liste) 
            {
                if(item.reklamKanali == reklamKanali)
                    sonuc.Add(item);    

            }
            return sonuc.AsReadOnly();
        }
        
    }
}
