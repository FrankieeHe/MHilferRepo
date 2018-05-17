using MHilfer.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHilfer.controller
{
    public class ElementController
    {
        private MasterController masterController;
        public void setMasterController(MasterController mc)
        {
            this.masterController = mc;
        }

        public void addElementToParent(Element child, Element parent)
        {
            if (child == null) { return; }
            var eleQuery = from ele in masterController.hilfer.elements
                           where ele.Equals(child)
                           select ele;
            if (eleQuery.Count() != 1)
            {
                throw new Exception("Error to hang element on(error of the set of elements)");
            }

            Table table = null;
            if (parent == null)
            {
                table = masterController.hilfer.tables.Find(t => t.stufe == 0);
            }
            else
            {
                table = masterController.tableController.getTablePerName(parent.name);
                if (table is null)
                {
                    table = new Table(parent.name, 1 + preRelation(parent).table.stufe);
                    Console.WriteLine(table.ToString());
                    masterController.tableController.addNewTable(table);
                    addTabletoElement(table, parent);
                }
            }
            addElementToTable(child, table);
        }

        public void addTabletoElement(Table t0, Element e)
        {
            Relation relation = new Relation(e, t0, true);
            this.masterController.hilfer.relations.Add(relation);
        }
        public void addElementToTable(Element e, Table t0)
        {
            Relation relation = new Relation(e, t0, false);
            this.masterController.hilfer.relations.Add(relation);
        }

        public void addNewElement(Element e)
        {
            if (e.name == null) { return; }
            var eleQuery = from ele in masterController.hilfer.elements
                           where ele.name == e.name
                           select ele;

            if (eleQuery.Count() != 0)
            {
                throw new Exception("Duplicated Name!");
            }
            masterController.hilfer.elements.Add(e);
        }

        public Element findElement(string obj)
        {
            return masterController.hilfer.elements.Where(e => e.name == obj).First();
        }

        public Relation subRelation(Element e)
        {
            var selected = from rel in masterController.hilfer.relations
                           where rel.element.name.Equals(e.name) && rel.leftOwnRight == true
                           select rel;
            List<Relation> relations = selected.ToList();
            if (relations.Count() == 1) { return relations[0]; }
            return null;
        }

        internal void overrideElement(string nameTextBox, string descTextBox)
        {
            int index = masterController.hilfer.elements.FindIndex(ele => ele == findElement(nameTextBox));
            masterController.hilfer.elements[index].desc = descTextBox;

        }

        public Table subTable(Element e)
        {
            Relation subrelation = subRelation(e);
            if(subrelation is null) { return null; }
            return subrelation.table;
        }

        public Element getPreElement(Element e)
        {
            string nam = preRelation(e) is null ? null: preRelation(e).table.name;
            if(nam is "MainTable" || nam is null) { return null; }
            return findElement(nam);
        }
        public Relation preRelation(Element e)
        {
            var selected = from rel in masterController.hilfer.relations
                           where rel.element.name.Equals(e.name) && rel.leftOwnRight == false
                           select rel;
            List<Relation> relations = selected.ToList();
            if (relations.Count() == 1) { return relations[0]; }
            return null;
        }

        public bool removeElement(Element e)
        {

            if (subRelation(e) != null) { throw new Exception("cannot remove the Element which is with Table"); }
            if (preRelation(e) != null)
            {
                this.masterController.hilfer.relations.RemoveAll(r => preRelation(e).Equals(r));
            }
            return masterController.hilfer.elements.Remove(e);
        }

        public bool cleanTableRelationOnElement(Element e)
        {
            if (subRelation(e) != null)
            {
                return this.masterController.hilfer.relations.Remove(subRelation(e));
            }

            return true;
        }
    }
}
