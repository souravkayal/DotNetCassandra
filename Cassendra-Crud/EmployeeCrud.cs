using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassendra_Crud
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> Get();
        void Add(Employee emp);
        void Update(Employee emp);
        void Delete(Employee emp);
    }

    public class EmployeeRepo : IEmployeeRepo
    {
        ISession session;
        public EmployeeRepo()
        {
            //This is default IP for cassendra.
            var cluster = Cluster.Builder()
                     .AddContactPoints("127.0.0.1")
                     .Build();

            // Connect to the nodes using a keyspace
            //hr is keyspace for me. Please update with yours
            session = cluster.Connect("hr");
        }


        public void Add(Employee emp)
        {
            string cql = @"insert into emp(id, name, email_id) values(?,?,?)";
            var ps = session.Prepare(cql);
            var statement = ps.Bind(emp.id , emp.name, emp.email_id);
            session.Execute(statement);
        }

        public void Delete(Employee emp)
        {
            string cql = @"delete from emp where id =?";
            var ps = session.Prepare(cql);
            var statement = ps.Bind(emp.id);
            session.Execute(statement);
        }

        public IEnumerable<Employee> Get()
        {
            List<Employee> result = new List<Employee>();
            var rs = session.Execute("SELECT * FROM emp");

            foreach (var row in rs)
            {
                var id = row.GetValue<int>("id");
                var name = row.GetValue<String>("name");
                var email = row.GetValue<String>("email_id");
                result.Add(new Employee { id = id, name = name, email_id = email });
            }
            return result;
        }

        public void Update(Employee emp)
        {
            string cql = "update emp set name=?, email_id=? where id=?";

            var ps = session.Prepare(cql);
            var statement = ps.Bind(emp.name, emp.email_id , emp.id);
            session.Execute(statement);
        }
    }
}
