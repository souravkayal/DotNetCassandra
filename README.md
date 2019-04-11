# Dot Net Cassandra
Implementation of CRUD Operation in .NET with Cassandra Database

This example is to demonstrate how we can implement basic CRUD operation using Cassandra Database. I have used Datastax (https://docs.datastax.com) library to connect to Cassandra sandbox database. The example is just to show working CRUD operation without following any design principle or best practice. 

        //ADD IN DB
        public void Add(Employee emp)
        {
            string cql = @"insert into emp(id, name, email_id) values(?,?,?)";
            var ps = session.Prepare(cql);
            var statement = ps.Bind(emp.id , emp.name, emp.email_id);
            session.Execute(statement);
        }

        //DELETE FROM DB
        public void Delete(Employee emp)
        {
            string cql = @"delete from emp where id =?";
            var ps = session.Prepare(cql);
            var statement = ps.Bind(emp.id);
            session.Execute(statement);
        }

        //READ TABLE CONTENT
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

        //UPDATE ROW IN TABLE
        public void Update(Employee emp)
        {
            string cql = "update emp set name=?, email_id=? where id=?";

            var ps = session.Prepare(cql);
            var statement = ps.Bind(emp.name, emp.email_id , emp.id);
            session.Execute(statement);
        }
