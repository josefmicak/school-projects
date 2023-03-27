using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIC0378
{
    class User
    {
        private int? id;
        private string name;
        private bool? adult;

        public int? Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public bool? Adult
        {
            get { return this.adult; }
            set { this.adult = value; }
        }
    }
}
