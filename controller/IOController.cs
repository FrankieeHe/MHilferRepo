using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using MHilfer.model;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using WpfMHilfer.model;

namespace MHilfer.controller
{
    public class IOController
    {
        private MasterController masterController;
        public void setMasterController(MasterController mc)
        {
            this.masterController = mc;
            mdFileDir = new Uri(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)), "res");
            Directory.CreateDirectory(mdFileDir.AbsolutePath);
        }
        public Uri mdFileDir { get; set; }

        public void allSave()
        {
            JObject jsonAll = new JObject(
             new JProperty("elementJson", JsonConvert.SerializeObject(this.masterController.hilfer.elements, Formatting.Indented, new JsonSerializerSettings
             {
                 PreserveReferencesHandling = PreserveReferencesHandling.All
             })),
             new JProperty("tablesJson", JsonConvert.SerializeObject(this.masterController.hilfer.tables, Formatting.Indented, new JsonSerializerSettings
             {
                 PreserveReferencesHandling = PreserveReferencesHandling.All
             })),
             new JProperty("relationsJson", JsonConvert.SerializeObject(this.masterController.hilfer.relations, Formatting.Indented, new JsonSerializerSettings
             {
                 PreserveReferencesHandling = PreserveReferencesHandling.All
             })),
             new JProperty("relevElesJson", JsonConvert.SerializeObject(this.masterController.hilfer.relevEles, Formatting.Indented, new JsonSerializerSettings
             {
                 PreserveReferencesHandling = PreserveReferencesHandling.All
             }))
             );


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Filter = "JSON file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, @jsonAll.ToString());
            }



        }

        public string loadMD_Or_HTML()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "text file (*.md;*.html)|*.md;*.html";
            if (openFileDialog.ShowDialog() == true)
            {
                string mdfileName = openFileDialog.FileName;
                return mdfileName;
            }
            return null;
        }

        public void copyToLocal(string filename, string elementname)
        {
            if(File.Exists(new Uri(mdFileDir, elementname).AbsolutePath)) { return; }
            System.IO.File.Copy(filename,  (new Uri(mdFileDir, elementname)).AbsolutePath );
        }

        public void loadAll()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON file (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string jsonAll = File.ReadAllText(openFileDialog.FileName);
                    JObject json = JObject.Parse(jsonAll);
                    string jelements = (string)json["elementJson"];

                    List<Element> elements = JsonConvert.DeserializeObject<List<Element>>(jelements, new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.All
                    });

                    string jtables = (string)json["tablesJson"];
                    List<Table> tables = JsonConvert.DeserializeObject<List<Table>>(jtables, new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.All
                    });

                    string jrelations = (string)json["relationsJson"];
                    List<Relation> relations = JsonConvert.DeserializeObject<List<Relation>>(jrelations, new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.All
                    });

                    string jrelevEles = (string)json["relevElesJson"];
                    if (jrelevEles != null)
                    {
                        List<RelevEle> relevEles = JsonConvert.DeserializeObject<List<RelevEle>>(jrelevEles, new JsonSerializerSettings
                        {
                            PreserveReferencesHandling = PreserveReferencesHandling.All
                        });
                        this.masterController.hilfer.relevEles = relevEles;
                    }
                    this.masterController.hilfer.elements = elements;
                    this.masterController.hilfer.tables = tables;
                    this.masterController.hilfer.relations = relations;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


    }
}
