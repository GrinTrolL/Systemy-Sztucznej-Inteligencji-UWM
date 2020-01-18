using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SterownikRozmyty
{
    public static class SterownikRozmyty_Algorytm
    {
		// .. statyczne zmienne i metody
        
        // public static zmienne, reguły itp
        //
        /// <summary>
        /// Metoda uruchamiana tylko raz podczas startu programu
        /// </summary>
        public static void inicjuj()
        {
                   
            //...
        } //public static void inicjuj()

        /// <summary>
        /// Metoda ma zaimplementować wskazany algorytm inteligencji obliczeniowej w celu sterowania procesu
        /// parkowania ciężarówki. Ciężarówka potrafi poruszać się jedynie do przodu ze stałą prędkością.
        /// Zadaniem algorytmu jest dobór odpowiedniego skrętu tak, aby ciężarówka dojechała do śródka górnej krawędzi
        /// i była ustawiona prostopadle do górnej krawędzi. 
        /// </summary>
        /// <param name="polozenie"> struktura opisuje aktualne położenie ciężarówki</param>
        /// <param name="obrot"> wartość wyjściowa algorytmu, która powinna zawierać się w [SymulacjaParametry.obrot_min; .obrot_max].
        /// Wartość dodatnia oznacza obrót zgodnie z ruchem wskazówek zegara.</param>
        public static void zwroc_odpowiedz(PojazdPolozenie polozenie, out int obrot)
        {
			// ...
            obrot = 0; // wartosc wyjsciowa 
        } //public static zwroc_odpowiedz(PojazdPolozenie polozenie, out double obrot)


    }
}
