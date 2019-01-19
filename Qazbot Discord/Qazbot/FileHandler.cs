using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileHandler <T>
{
	public FileHandler()
	{
	}

    public static T ReadFile(string filename) {
        T result = default(T);

        if (File.Exists(filename)) {
            StreamReader stream = new StreamReader(filename);

            BinaryFormatter bf = new BinaryFormatter();
            result = (T)bf.Deserialize(stream.BaseStream);
            
            stream.Close();
        }

        return result;
    }

    public static void SaveFile(string filename, T saveObject) {
        StreamWriter stream = new StreamWriter(File.OpenWrite(filename));

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(stream.BaseStream, saveObject);

        stream.Flush();
        stream.Close();
    }
}
