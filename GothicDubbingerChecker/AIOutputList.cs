using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GothicDubbingChecker.Classes
{

    class AIOutput : IComparable<AIOutput>
    {
        public string Instance;
        public string Owner;
        public string Text;

        public AIOutput(string instance, string owner, string text)
        {
            Instance = instance;
            Owner = owner;
            Text = text;
        }


        public int CompareTo(AIOutput other)
        {
            return Instance.CompareTo(other.Instance);
        }

        public void Print(StreamWriter sw)
        {
            sw.WriteLine(Parser.MakeDiaString(Instance,Text));
        }
    }

    class AIOutputList
    {
        // klucz to instancja pisana wielkimi literami
        public Dictionary<string, AIOutput> List;
        public string DubPath;
        public string AlphabetPath;


        public AIOutputList(GothicPaths paths)
        {
            List = new Dictionary<string,AIOutput>();
            DubPath = paths.DubPath;
            AlphabetPath = paths.OutputAlphabet;
        }

        public AIOutputList(string dubPath, string alphabetPath)
        {
            List = new Dictionary<string,AIOutput>();
            DubPath = dubPath;
            AlphabetPath = alphabetPath;
        }


        public void PrintSorted()
        {
            List<AIOutput> l = List.Values.ToList();
            l.Sort();

            using (StreamWriter sw = new StreamWriter(AlphabetPath, false, Encoding.Default))
            {
                foreach (var aio in l)
                {
                    aio.Print(sw);
                }
            }

        }


        /// <summary>
        /// Sprawdza, czy w liście istnieje już wyraz s. Wielkość liter nie ma znaczenia.
        /// </summary>
        /// <param name="s">Wyraz do sprawdzenia, czy istnieje w liście.</param>
        /// <returns></returns>
        public bool Exists(string s, List<AIOutput> aiOutputs)
        {

            foreach (var aio in aiOutputs)
            {
                if (aio.Instance.ToUpper().Equals(s.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ExistsString(string str, List<string> list)
        {

            foreach (var item in list)
            {
                if (item.ToUpper().Equals(str.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }

        // TODO strasznie niewydajnie... musi byc na poczatku dzialania programu
        // pobrana lista wszystkich plikow w folderze i potem wykreslanie podczas pierwszego sprawdzania z tej listy
        /// <summary>
        /// Wypisuje pliki dialogowe, dla których brakuje nagrań dubbngowych.
        /// </summary>
        /// <param name="streamWriter">Dokąd zapisać info?</param>
        public void CheckMissingWavs(StreamWriter streamWriter)
        {
            string[] files = Directory.GetFiles(DubPath);

            for (int i=0; i<files.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(files[i]);
                files[i] = fileInfo.Name;
            }

            Console.WriteLine("zaczynam tworzyc slownik");
            Dictionary<string, string> d = new Dictionary<string, string>();
            List<string> filesList = files.ToList();
            foreach (var item in filesList)
            {
                d.Add(item.ToUpper(), item.ToUpper());
            }
            Console.WriteLine("stworzylem");

            foreach (AIOutput aio in List.Values)
                // czy kwestia dialogowa ma swoj odpowiednik w folderze?
                if (!d.ContainsKey(aio.Instance.ToUpper() + ".WAV"))
                    aio.Print(streamWriter);

        }

        /// <summary>
        /// Sprawdza, czy są jakieś zbędne nagrania w folderze z dubbingiem.
        /// </summary>
        /// <param name="streamWriter">Dokąd zapisać info?</param>
        public void CheckUnnecessaryWavs(StreamWriter streamWriter)
        {
            
            string[] files = Directory.GetFiles(DubPath);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!fileInfo.Extension.ToUpper().Equals(".WAV"))
                    throw new Exception("Found a not wav file -> " + file);

                int len = fileInfo.Name.Length;
                string withoutExtension = fileInfo.Name.Substring(0,len-4);
                // czy plik istnieje w slowniku?
                if (!List.ContainsKey(withoutExtension.ToUpper()))
                    streamWriter.WriteLine(fileInfo.Name);
            
            }
            
        }




    }
}
