using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Qazbot.DataManager
{
    class DataManager<T>
    {
        public static void SaveData(T data, string filename) {
            BinaryFormatter bf = new BinaryFormatter();

            CreateDirectory(filename);
            FileStream filestream = File.Open(filename, FileMode.Create);
            bf.Serialize(filestream, data);
            filestream.Close();
        }

        public static T LoadData(string filename) {
            BinaryFormatter bf = new BinaryFormatter();

            if (!File.Exists(filename)) {
                throw new Exception($"The file {filename} does not exist!");
            }

            FileStream filestream = File.Open(filename, FileMode.Open);
            T data = (T)bf.Deserialize(filestream);
            filestream.Close();

            return data;
        }

        private static void CreateDirectory(string filename) {
            string directory = "";

            string[] fileSplit = filename.Split('/');

            for (int i = 0; i < fileSplit.Length - 1; i++) {
                directory += fileSplit[i] + "/";
            }
            
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
