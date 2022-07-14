using MyDatabase;
using RepositoryService.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            UnitOfWork unit = new UnitOfWork(db);

            var forceUsers = unit.ForceUsers.GetAll();

            foreach (var user in forceUsers)
            {
                Console.WriteLine(user.FirstName);
            }


            Console.WriteLine("----------------------------");

            //Test Delete
            unit.ForceUsers.Delete(1);
            unit.ForceUsers.Save();

            var deletedUsers = unit.ForceUsers.GetAll();

            foreach (var user in deletedUsers)
            {
                Console.WriteLine(user.FirstName);
            }
        }
    }
}
