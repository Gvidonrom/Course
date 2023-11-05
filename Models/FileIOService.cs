using Course.Services;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;


namespace Course.Models
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<ItemInventory> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ItemInventory>();
            }

            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ItemInventory>>(fileText);
            }

        }

        public void SaveData(object itemInventoryList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(itemInventoryList);
                writer.Write(output);
            }
        }
    }
}
