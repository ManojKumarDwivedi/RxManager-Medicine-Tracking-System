using System.Text.Json;

namespace PSDemo_MedicineApp_ByMkd.Helpers
{
    public static class FileHelper
    {
        public static List<T> ReadList<T>(string path)
        {
            if (!File.Exists(path))
                return new List<T>();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public static void WriteList<T>(string path, List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }
    }
}
