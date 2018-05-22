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
        }

        public void allSave()
        {
            JObject jsonAll = new JObject(
             new JProperty("elementJson", JsonConvert.SerializeObject(this.masterController.hilfer.elements, Formatting.Indented)),
             new JProperty("tablesJson", JsonConvert.SerializeObject(this.masterController.hilfer.tables, Formatting.Indented)),
             new JProperty("relationsJson", JsonConvert.SerializeObject(this.masterController.hilfer.relations, Formatting.Indented)),
             new JProperty("relevElesJson", JsonConvert.SerializeObject(this.masterController.hilfer.relevEles, Formatting.Indented)));


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "json";
            if (saveFileDialog.ShowDialog() == true)
            {
                saveFileDialog.Filter = "JSON file (*.json)|*.json";
                File.WriteAllText(saveFileDialog.FileName, @jsonAll.ToString());
            }



        }

        public void loadAll()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string jsonAll = File.ReadAllText(openFileDialog.FileName);
                JObject json = JObject.Parse(jsonAll);
                string jelements = (string)json["elementJson"];

                List<Element> elements = JsonConvert.DeserializeObject<List<Element>>(jelements);

                string jtables = (string)json["tablesJson"];
                List<Table> tables = JsonConvert.DeserializeObject<List<Table>>(jtables);

                string jrelations = (string)json["relationsJson"];
                List<Relation> relations = JsonConvert.DeserializeObject<List<Relation>>(jrelations);

                string jrelevEles = (string)json["relevElesJson"];
                if (jrelevEles != null)
                {
                    List<RelevEle> relevEles = JsonConvert.DeserializeObject<List<RelevEle>>(jrelevEles);
                    this.masterController.hilfer.relevEles = relevEles;
                }
                this.masterController.hilfer.elements = elements;
                this.masterController.hilfer.tables = tables;
                this.masterController.hilfer.relations = relations;
            }
        }


    }
}
