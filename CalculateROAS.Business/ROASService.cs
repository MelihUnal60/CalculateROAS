using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateROAS.Business
{
    public class ROASService
    {
        private static List<ROAS> liste = new List<ROAS>();

        public static void SaveROAS(ROAS roas)
        {
            liste.Add(roas);
        }
        public static IReadOnlyCollection<ROAS> GetROASList()
        {
            return liste.AsReadOnly();
        }
    }
}
