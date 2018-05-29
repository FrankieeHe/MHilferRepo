using MHilfer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMHilfer.controller;
using WpfMHilfer.model;
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
        public RelevEleController relevEleController{ set; get; }
        public SearchViewController searchViewController { get;  set; }
        public SearchController searchController { get; set; }

        public MasterController()
        {
            List<Table> ts = new List<Table>();
            List<Element> es = new List<Element>();
            List<Relation> rs = new List<Relation>();
            this.hilfer = new Hilfer(ts, es, rs);
            this.hilfer.relevEles = new List<RelevEle>();
            viewController = new ViewController(this);
            elementController = new ElementController();
            elementController.setMasterController(this);
            ioController = new IOController();
            ioController.setMasterController(this);
            tableController = new TableController(this);
            relevEleController = new RelevEleController(this);
            addElementViewModel = new AddElementViewModel();
            addElementViewModel.setMasterController(this);
            searchViewController = new SearchViewController();
            searchViewController.setMasterController(this);
            searchController = new SearchController();
            searchController.setMasterController(this);

        }
    }
}
