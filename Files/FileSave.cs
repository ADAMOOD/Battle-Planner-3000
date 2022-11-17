using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using resourceEditor;

namespace FileSave
{
    public class FileSave
    {
        public string Name {get; set;}
        public string Path {get; set;}

        public FileSave(string name)
        {
            Name=name;
            Path= $"{AppDomain.CurrentDomain.BaseDirectory}\\{name}.json";
        }

        public void saveFile(Resource resource)
        {
            using (FileStream fs = File.Create(this.Path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(resource));
                fs.Write(info, 0, info.Length);
            }
        }

        public void loadSavedFile()
        {
            
            if (File.Exists(this.Path))
            {
                using (StreamReader saveFile = new StreamReader(this.Path))
                {
                    string json = saveFile.ReadToEnd();
                    var save= JsonConvert.DeserializeObject<Resource>(json);
                }
            }
        }
       

    }
}
