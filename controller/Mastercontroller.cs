using MHilfer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMHilfer.controller;
using WpfMHilfer.view;

namespace MHilfer.controller
{
    public class MasterController
    {
        public AddElementViewModel addElementViewModel;

        public ElementController elementController { set; get; }
        public IOController ioController { set; get; }
        public TableController tableController { set; get; }
        public ViewController viewController { set; get; }
        public Hilfer hilfer { set; get; }
        public RelevEleController relevanceElementController{ set; get; } 

        public MasterController()
        {
            List<Table> ts = new List<Table>();
            List<Element> es = new List<Element>();
            List<Relation> rs = new List<Relation>();
            this.hilfer = new Hilfer(ts, es, rs);
            viewController = new ViewController(this);
            elementController = new ElementController();
            elementController.setMasterController(this);
            ioController = new IOController();
            ioController.setMasterController(this);
            tableController = new TableController(this);
            relevanceElementController = new RelevEleController(this);
            addElementViewModel = new AddElementViewModel(this);

        }
    }
}
