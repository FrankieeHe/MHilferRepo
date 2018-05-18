using MHilfer.model;

namespace WpfMHilfer.view
{
    internal class TableSteps
    {
        private TableSteps _p, _n;
        private Table t;
        public TableSteps previousStep
        {
            get { return this._p; }
            set { this._p = value; }
        }
        public TableSteps nextStep
        {
            get { return this._n; }
            set { this._n = value; }
        }
        public Table actTable
        {
            get { return this.t; }
            set {  this.t = value ; }
        }

    }
}