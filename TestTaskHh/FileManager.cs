using Newtonsoft.Json;
using TestTaskHh.Models;

namespace TestTaskHh
{
    public class FileManager
    {
        public FileManager(string path)
        {
            FilePath = path;

            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Dispose();
            }
        }

        public void OverWriteAll<T>(List<T> items)
        {
            using (var sw = new StreamWriter(FilePath, false))
            {
                foreach (var item in items)
                {
                    sw.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public void Write<T>(T item)
        {
            using StreamWriter sw = new(FilePath, true);
            sw.WriteLine(JsonConvert.SerializeObject(item));
        }

        public List<T> ReadAll<T>()
        {
            var items = new List<T>();

            using (var sr = new StreamReader(FilePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    T? item = JsonConvert.DeserializeObject<T>(line);
                    if (item != null)
                        items.Add(item);
                }
            }

            return items;
        }

        public int GetNewId<T>()
            where T : Helper
        {
            var items = ReadAll<T>();
            return items.Any() ? items.Max(x => x.Id) + 1 : 0;
        }

        private readonly string FilePath;
    }
}
