using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassendra_Crud
{
    public class Employee
    {
        public int id { get; set; }
        public string email_id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return this.id + " " + this.email_id + " " + this.name;
        }

        public string toJson()
        {
            return "{\"id\":" + this.id +", \"email\" : " + this.email_id +", \"name\": " + this.name + "}" ;
        }
    }
}
