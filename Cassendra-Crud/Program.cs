using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassendra_Crud
{
    class Program
    {
        static EmployeeRepo empRepo = new EmployeeRepo();

        public static void Print()
        {
            IEnumerable<Employee> result = empRepo.Get();

            foreach (var item in result)
            {
                Console.WriteLine(item.toJson());
            }
        }

        static void Main(string[] args)
        {
            //Read initial data
            Console.WriteLine("-----INITIAL DATA-----");
            Print();

            Console.WriteLine("------DATA AFTER ADD------");
            //Insert Employee
            empRepo.Add(new Employee { id = 2, name = "Syam", email_id = "Syam@gmail.com" });
            Print();

            Console.WriteLine("------DATA AFTER UPDATE------");
            //Update some property
            empRepo.Update(new Employee { id = 1, name = "Ram", email_id = "Ram@gmail.com" });
            Print();

            //Delete 
            Console.WriteLine("------DATA AFTER DELETE------");
            empRepo.Delete(new Employee { id = 1 });
            Print();



            Console.ReadLine();
        }
    }
}
