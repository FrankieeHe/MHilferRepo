using NUnit.Framework;
using WpfMHilfer.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHilfer.controller;
using MHilfer;
using System.Collections;
using MHilfer.model;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WpfMHilfer.model;

namespace WpfMHilfer.controller.Tests
{
    [TestFixtureSource(typeof(MyFixtureData), "FixtureParms")]
    public class SearchControllerTests
    {
        private MasterController masterController ;
        private string keywordsExist;
        private string NotkeywordsExist;

        public SearchControllerTests(string kwE, string kwNotE )
        {
            this.keywordsExist = kwE;
            this.NotkeywordsExist = kwNotE;
        }

        [OneTimeSetUp]
        public void setup()
        {
            masterController = new MasterController();
            string jsonAll = File.ReadAllText("C: \\Users\\donghui.he\\Documents\\johnson.json");
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

        [Test]
        public void SearchProcedureTest()
        {
            Dictionary<Element,int> searched = masterController.searchController.searchProcedure(keywordsExist, masterController.hilfer.elements);
            Console.WriteLine(searched);
            Assert.That(searched, Is.Not.Empty);
        }

        [Test]
        public void SearchProcedureNullTest()
        {
            Dictionary<Element, int> searched = masterController.searchController.searchProcedure(NotkeywordsExist, masterController.hilfer.elements);
            Assert.That(searched, Is.Empty);

        }
    }

    public class MyFixtureData
    {
        public static IEnumerable FixtureParms
        {
            get
            {
                yield return new TestFixtureData("johnson", "oiuhd");
                yield return new TestFixtureData("Magic player", "notmogic");
                yield return new TestFixtureData("ok with such good magic","weighted function");
                //case insensitive search
                yield return new TestFixtureData("chiyo", "weighted function");

            }
        }
    }
}