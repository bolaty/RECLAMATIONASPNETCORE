using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsObjetRetour
    {
        private bool _OR_BOOLEEN = true;
        private string _OR_STRING = "";
        private DataSet _OR_DATASET = new DataSet();
        private Object _OR_OBJET;
        private List<Object> _OR_LIST;
        private string _OR_MESSAGE = "";

        public bool OR_BOOLEEN
        {
            get { return _OR_BOOLEEN; }
            set { _OR_BOOLEEN = value; }
        }
        public string OR_STRING
        {
            get { return _OR_STRING; }
            set { _OR_STRING = value; }
        }
        public DataSet OR_DATASET
        {
            get { return _OR_DATASET; }
            set { _OR_DATASET = value; }
        }

        public object OR_OBJET
        {
            get { return _OR_OBJET; }
            set { _OR_OBJET = value; }
        }

        public List<Object> OR_LIST
        {
            get { return _OR_LIST; }
            set { _OR_LIST = value; }
        }

        public string OR_MESSAGE
        {
            get { return _OR_MESSAGE; }
            set { _OR_MESSAGE = value; }
        }

        public clsObjetRetour() { }

        public clsObjetRetour(bool OR_BOOLEEN, string OR_STRING, DataSet OR_DATASET, object OR_OBJET, List<Object> OR_LIST, string OR_MESSAGE)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_STRING = OR_STRING;
            this.OR_DATASET = OR_DATASET;
            this.OR_OBJET = OR_OBJET;
            this.OR_LIST = OR_LIST;
            this.OR_MESSAGE = OR_MESSAGE;

        }

        public clsObjetRetour(clsObjetRetour clsObjetRetour)
        {
            OR_BOOLEEN = clsObjetRetour.OR_BOOLEEN;
            OR_STRING = clsObjetRetour.OR_STRING;
            OR_DATASET = clsObjetRetour.OR_DATASET;
            OR_OBJET = clsObjetRetour.OR_OBJET;
            OR_LIST = clsObjetRetour.OR_LIST;
            OR_MESSAGE = clsObjetRetour.OR_MESSAGE;
        }

        public clsObjetRetour SetValue(bool OR_BOOLEEN)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            return this;

        }

        public clsObjetRetour SetValue(bool OR_BOOLEEN, string OR_STRING)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_STRING = OR_STRING;
            return this;

        }

        public clsObjetRetour SetValueMessage(bool OR_BOOLEEN, string OR_MESSAGE)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_MESSAGE = OR_MESSAGE;
            return this;

        }

        public clsObjetRetour SetValue(bool OR_BOOLEEN, DataSet OR_DATASET)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_DATASET = OR_DATASET;
            return this;
        }

        public clsObjetRetour SetValue(bool OR_BOOLEEN, object OR_OBJET)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_OBJET = OR_OBJET;
            return this;
        }

        public clsObjetRetour SetValue(bool OR_BOOLEEN, List<Object> OR_LIST)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_LIST = OR_LIST;
            return this;
        }

        public clsObjetRetour SetValue(bool OR_BOOLEEN, string OR_STRING, string OR_MESSAGE)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_MESSAGE = OR_MESSAGE;
            this.OR_STRING = OR_STRING;
            return this;

        }

        public clsObjetRetour SetValue(bool OR_BOOLEEN, DataSet OR_DATASET, string OR_MESSAGE)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_MESSAGE = OR_MESSAGE;
            this.OR_DATASET = OR_DATASET;
            return this;
        }
        public clsObjetRetour SetValue(bool OR_BOOLEEN, object OR_OBJET, string OR_MESSAGE)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_MESSAGE = OR_MESSAGE;
            this.OR_OBJET = OR_OBJET;
            return this;
        }

        public clsObjetRetour SetValue(bool OR_BOOLEEN, List<Object> OR_LIST, string OR_MESSAGE)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_MESSAGE = OR_MESSAGE;
            this.OR_LIST = OR_LIST;
            return this;
        }


        public clsObjetRetour SetValue(bool OR_BOOLEEN, string OR_STRING, DataSet OR_DATASET, string OR_MESSAGE)
        {
            this.OR_BOOLEEN = OR_BOOLEEN;
            this.OR_MESSAGE = OR_MESSAGE;
            this.OR_STRING = OR_STRING;
            this.OR_DATASET = OR_DATASET;
            return this;
        }

    }
}
