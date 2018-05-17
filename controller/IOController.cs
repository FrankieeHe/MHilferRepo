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

namespace MHilfer.controller
{
    public class IOController
    {
        private MasterController masterController;
        public void setMasterController(MasterController mc)
        {
            this.masterController = mc;
        }

        /**
           * Verbinden mit sql Datenbase. Aber muss man hier nicht.
          public class ConverterContractResolver : DefaultContractResolver
          {
              public new static readonly ConverterContractResolver Instance = new ConverterContractResolver();

              protected override JsonContract CreateContract(Type objectType)
              {
                  JsonContract contract = base.CreateContract(objectType);

                  // this will only be called once and then cached
                  if (objectType == typeof(DateTime) || objectType == typeof(DateTimeOffset))
                  {
                      contract.Converter = new JavaScriptDateTimeConverter();
                  }

                  return contract;
              }
      

          protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
          {
              JsonProperty property = base.CreateProperty(member, memberSerialization);

              if (property.DeclaringType == typeof(List<Panel>) || property.DeclaringType == typeof(List<Element>) &&
                  (property.PropertyName == "cPanel" || property.PropertyName == "elements"))
              {
                  property.ShouldSerialize =
                      instance =>
                      {
                          Employee e = (Employee)instance;
                          return e.Manager != e;
                      };
              }

              return property;
          }
      }
      */

        public void allSave()
        {
            JObject jsonAll = new JObject(
             new JProperty("elementJson", JsonConvert.SerializeObject(this.masterController.hilfer.elements,Formatting.Indented)),
             new JProperty("tablesJson", JsonConvert.SerializeObject(this.masterController.hilfer.tables,Formatting.Indented)),
             new JProperty("relationsJson", JsonConvert.SerializeObject(this.masterController.hilfer.relations,Formatting.Indented)));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
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

                this.masterController.hilfer.elements = elements;
                this.masterController.hilfer.tables = tables;
                this.masterController.hilfer.relations = relations;
            }
        }


    }
}
