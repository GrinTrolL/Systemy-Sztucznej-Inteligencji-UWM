using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SterownikRozmyty
{
    public enum Group
    {
        Low = 0,
        Zero = 1,
        High = 2
    }

    public static class SterownikRozmyty_Algorytm
    {

        static Dictionary<Group, List<int>> XGroups = new Dictionary<Group, List<int>>();
        static Dictionary<Group, List<int>> YGroups = new Dictionary<Group, List<int>>();
        static Dictionary<Group, List<int>> AngleGroups = new Dictionary<Group, List<int>>();
        static List<int> spins = new List<int>();

        #region Initializing
        public static void inicjuj()
        {
            GenerateGroups();
            GenerateSpins();
            for (int x = -181; x <= 181; x++)
            {
                AssignAngleToGroups(x);
            }

            for (int x = -101; x <= 101; x++)
            {
                AssignXToGroups(x);
            }

            for (int x = -101; x <= 1; x++)
            {
                AssignYToGroups(x); 
            }
        }

        public static void GenerateGroups()
        {
            foreach (Group group in GetAllGroupTypes())
            {
                XGroups.Add(group, new List<int>());
                YGroups.Add(group, new List<int>());
                AngleGroups.Add(group, new List<int>());
            }
        }

        public static void AssignXToGroups(int x)
        {
            if (x < -20)
                XGroups[Group.Low].Add(x);
            if (x >= -30 && x <= 30)
                XGroups[Group.Zero].Add(x);
            if (x > 20)
                XGroups[Group.High].Add(x);
        }

        public static void AssignYToGroups(int x)
        {
            if (x <= -50)
                YGroups[Group.Low].Add(x);
            if (x >= -60 && x <= -5)
                YGroups[Group.Zero].Add(x);
            if (x >= -20)
                YGroups[Group.High].Add(x);
        }

        public static void AssignAngleToGroups(int x)
        {
            if (x < -20)
                AngleGroups[Group.Low].Add(x);
            if (x >= -25 && x <= 25)
                AngleGroups[Group.Zero].Add(x);
            if (x > 20)
                AngleGroups[Group.High].Add(x);
        }

        public static void GenerateSpins()
        {
            var xGroups = GetAllGroupTypes();
            var yGroups = GetAllGroupTypes();
            var angleGroups = GetAllGroupTypes();

            foreach (var xGroup in xGroups)
            {
                foreach (var yGroup in yGroups)
                {
                    foreach (var angleGroup in angleGroups)
                    {
                        if (xGroup == Group.Low && angleGroup == Group.Low && yGroup == Group.Low)
                            spins.Add(20);//
                        if (xGroup == Group.Low && angleGroup == Group.Low && yGroup == Group.Zero)
                            spins.Add(15);//
                        if (xGroup == Group.Low && angleGroup == Group.Low && yGroup == Group.High)
                            spins.Add(20);//
                        if (xGroup == Group.Low && angleGroup == Group.High && yGroup == Group.Low)
                            spins.Add(-20);//
                        if (xGroup == Group.Low && angleGroup == Group.High && yGroup == Group.Zero)
                            spins.Add(-10);//
                        if (xGroup == Group.Low && angleGroup == Group.High && yGroup == Group.High)
                            spins.Add(-20);//
                        if (xGroup == Group.Low && angleGroup == Group.Zero && yGroup == Group.Low)
                            spins.Add(20);//
                        if (xGroup == Group.Low && angleGroup == Group.Zero && yGroup == Group.Zero)
                            spins.Add(20);//
                        if (xGroup == Group.Low && angleGroup == Group.Zero && yGroup == Group.High)
                            spins.Add(20);//
                        if (xGroup == Group.High && angleGroup == Group.Low && yGroup == Group.Low)
                            spins.Add(15);//
                        if (xGroup == Group.High && angleGroup == Group.Low && yGroup == Group.Zero)
                            spins.Add(15);//
                        if (xGroup == Group.High && angleGroup == Group.Low && yGroup == Group.High)
                            spins.Add(20);//
                        if (xGroup == Group.High && angleGroup == Group.High && yGroup == Group.Low)
                            spins.Add(-20);//
                        if (xGroup == Group.High && angleGroup == Group.High && yGroup == Group.Zero)
                            spins.Add(-15);//
                        if (xGroup == Group.High && angleGroup == Group.High && yGroup == Group.High)
                            spins.Add(-20);//
                        if (xGroup == Group.High && angleGroup == Group.Zero && yGroup == Group.Low)
                            spins.Add(-20);//
                        if (xGroup == Group.High && angleGroup == Group.Zero && yGroup == Group.Zero)
                            spins.Add(-20);//
                        if (xGroup == Group.High && angleGroup == Group.Zero && yGroup == Group.High)
                            spins.Add(-20);//
                        if (xGroup == Group.Zero && angleGroup == Group.Low && yGroup == Group.Low)
                            spins.Add(20);
                        if (xGroup == Group.Zero && angleGroup == Group.Low && yGroup == Group.Zero)
                            spins.Add(20);
                        if (xGroup == Group.Zero && angleGroup == Group.Low && yGroup == Group.High)
                            spins.Add(20);
                        if (xGroup == Group.Zero && angleGroup == Group.High && yGroup == Group.Low)
                            spins.Add(-20);
                        if (xGroup == Group.Zero && angleGroup == Group.High && yGroup == Group.Zero)
                            spins.Add(-20);
                        if (xGroup == Group.Zero && angleGroup == Group.High && yGroup == Group.High)
                            spins.Add(-20);
                        if (xGroup == Group.Zero && angleGroup == Group.Zero && yGroup == Group.Low)
                            spins.Add(0);
                        if (xGroup == Group.Zero && angleGroup == Group.Zero && yGroup == Group.Zero)
                            spins.Add(0);
                        if (xGroup == Group.Zero && angleGroup == Group.Zero && yGroup == Group.High)
                            spins.Add(0);
                    }
                }
            }
        }

        public static Group[] GetAllGroupTypes()
        {
            return (Group[])Enum.GetValues(typeof(Group));
        }
        #endregion

        #region Spin
        public static void zwroc_odpowiedz(PojazdPolozenie polozenie, out int obrot)
        {
            List<double> activations = new List<double>();

            foreach (var XGroup in XGroups.Select(g => g.Value))
            {
                foreach (var YGroup in YGroups.Select(g => g.Value))
                {
                    foreach (var AngleGroup in AngleGroups.Select(g => g.Value))
                    {
                        var activation = CountActivation(polozenie, XGroup, YGroup, AngleGroup);

                        activations.Add(activation);
                    }
                }
            }

            double activationSpinCalculus = 0;

            for (int i=0;i<activations.Count;i++)
            {
                activationSpinCalculus += spins[i] * activations[i];
            }

            var sum = activations.Sum();

            var toReturn = activationSpinCalculus / sum ;

            obrot = (int)toReturn;
        }

        public static double CountActivation(PojazdPolozenie vehicle, List<int> xGroup, List<int> yGroup, List<int> angleGroup)
        {
            var xActivation = GetGroupActivation(xGroup, vehicle.x);

            var yActivation = GetGroupActivation(yGroup, vehicle.y);

            var angleActivation = GetGroupActivation(angleGroup, vehicle.kat);

            if (xActivation > yActivation)
            {
                if (yActivation > angleActivation)
                    return angleActivation;
                else
                    return yActivation;
            }
            else
            {
                if (xActivation > angleActivation)
                    return angleActivation;
                else
                    return xActivation;
            }
        }

        public static double GetGroupActivation(List<int> group, int value)
        {
            double activation = 0;

            if (group.Contains(value))
            {
                //foreach (var element in group)
                //{
                //    activation += (element - value) * (element - value);
                //}

                double licznik = value - group[group.Count / 2];

                double mianownik = (group[0] - group[group.Count - 1]) * 0.4;

                double iloraz = licznik / mianownik;

                iloraz *= iloraz;

                activation += Math.Exp(-iloraz);
            }

            //var sum = 0;
            
            //group.ForEach(elem => sum += elem * elem);

            //activation /= sum;

            return activation;
        }
        #endregion
    }
}
