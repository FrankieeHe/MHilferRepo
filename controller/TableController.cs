using MHilfer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHilfer.controller
{
    public class TableController
    {
        private MasterController masterController;

        public TableController(MasterController masterController)
        {
            this.masterController = masterController;
            if (masterController.hilfer.tables.Count() == 0) {
                Table maintable = new Table("MainTable", 0);
                masterController.hilfer.tables.Add(maintable);
                masterController.viewController.TableStep.actTable = maintable;
            }
        }


        public Table getTablePerName(string name) {
            Table table = masterController.hilfer.tables.Find(t => t.name == name);
            return table;

        }
        public void addNewTable(Table p)
        {
            if (p.name == null || p.stufe == 0)
            {
                return;
            }
            var pQuery = from pQ in masterController.hilfer.tables
                         where pQ.name == p.name && pQ.stufe == p.stufe
                         select pQ;
            if (pQuery.ToList<Table>().Count() >1)
            {
                throw new Exception("Duplicate Table!");
            }
            masterController.hilfer.tables.Add(p);
        }

        public Relation preRelation(Table p)
        {
            var selected = from rel in this.masterController.hilfer.relations
                           where rel.table.Equals(p) && rel.leftOwnRight == true
                           select rel;
            if (selected.ToList().Count() == 1)
            {
                Relation r = selected.ToList()[0];
                return r;
            }
            return null;
        }

        public List<Relation> allSubRelations(Table p)
        {
            List<Relation> selected =  masterController.hilfer.relations.
                Where(r => (r!=null && r.table.Equals(p) && r.leftOwnRight == false) )
                .ToList<Relation>();

            return selected;
        }

        public List<Element> allSubElements(Table p)
        {
            List<Relation> rs = allSubRelations(p);
            var es = from r in rs
                     select r.element;
            List<Element> eles = es.ToList<Element>();
            return eles;
            

        }
        public void addTableToElement(Element e, Table p)
        {
            if (this.masterController.hilfer.tables.Contains(p) == false) { throw new Exception("table not in datanbank(but should not see this)"); }
            List <Relation> rs = this.masterController.hilfer.relations.FindAll(
                r => (r.leftOwnRight == true && r.element.Equals(e)) ||
                     (r.element.Equals(e) && r.table.Equals(p)));
            if (rs.Count() > 0) { throw new Exception("add table to element which represented already other table or looped"); }

            Relation rela = new Relation(e, p, true);
            this.masterController.hilfer.relations.Add(rela);
        }

        
        public bool removeTable(Table p)
        {
            if (this.masterController.hilfer.relations.FindAll(r => r.table.Equals(p)&&r.leftOwnRight==false).Count()> 0) { throw new Exception("cannot remove the Table which is with Element"); }
            List<Relation> relations = this.masterController.hilfer.relations.FindAll(r => r.table.Equals(p) && r.leftOwnRight == true);
            if (relations.Count() == 1) { this.masterController.hilfer.relations.Remove(relations[0]); }

            return (masterController.hilfer.tables.Remove(p));
        }

        public bool removeElementRelationOnTable(Element e, Table p)
        {
            return this.masterController.hilfer.relations.Remove( 
                this.masterController.hilfer.relations.Find(r => r.table.Equals(p) &&r.element.Equals(e)&& r.leftOwnRight == false)
            );
        }
    }



}
