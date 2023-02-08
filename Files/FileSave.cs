using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using resourceEditor;

namespace FileSave
{
    public class FilesJson
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public FilesJson(string name)
        {
            Name = name;
            Path = $"{AppDomain.CurrentDomain.BaseDirectory}\\{name}.json";
        }

        public void saveToFile<t>(List<t> resources)
        {
            File.WriteAllText(this.Path, JsonConvert.SerializeObject(resources));
        }

        public List<t> loadSavedFile<t>()
        {
            if (File.Exists(this.Path))
            {
                using (StreamReader saveFile = new StreamReader(this.Path))
                {
                    string json = saveFile.ReadToEnd();
                    var save = JsonConvert.DeserializeObject<List<t>>(json); 
                    return save;
                }
            }
            return new List<t>();
        }
    }
}
