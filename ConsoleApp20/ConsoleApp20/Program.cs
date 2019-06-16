using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    class Program
    {
        static void Main(string[] args)
        {

            int NumberOfDocs = 2;
            PersonOnLine Ophir = new PersonOnLine();
            Ophir.PersonName = "Ophir";
            Ophir.PersonDocs = AddDocs(Ophir.PersonDocs, NumberOfDocs);
            TheLine.Enqueue(Ophir);
            PersonOnLine Yuval = new PersonOnLine();
            Yuval.PersonName = "Yuval";
            Yuval.PersonDocs = AddDocs(Yuval.PersonDocs, NumberOfDocs);
            TheLine.Enqueue(Yuval);
            Employee Shirah = new Employee();
            Shirah.EmployeeName = "Shirah";
            Shirah.EmployeeDocs = AddDocs(Shirah.EmployeeDocs, NumberOfDocs);
            Console.Write("These are the following people waiting on line at the Misrad Hapanim");
            foreach (var person in TheLine)
            {
                Console.Write(" " + person.PersonName);
            }
            Console.WriteLine();
            int limit = 0;
            while(limit!=10)
            {
                var GivenPersonOnline = TheLine.Dequeue();
                Console.Write("These are " + Shirah.EmployeeName + "'s documents ");
                foreach (var doc in Shirah.EmployeeDocs)
                {
                    Console.Write(doc + " ");
                }
                Console.WriteLine();
                Console.Write("These are " + GivenPersonOnline.PersonName + "'s documents ");
                foreach (var Doc in GivenPersonOnline.PersonDocs)
                {
                    Console.Write( Doc+" " );
                }
                Console.WriteLine();
                if (CheckDocs(Shirah, GivenPersonOnline) == NumberOfDocs)
                {
                    Console.WriteLine(GivenPersonOnline.PersonName + " had the correct documentation and was able to go home");
                }
                else
                {
                    Console.WriteLine(GivenPersonOnline.PersonName + " didnt have the right documentation and had to go to the back of the line");
                    TheLine.Enqueue(GivenPersonOnline);
                }
                limit++;
            }
           


            Console.ReadLine();
        }        
        static Random WhichDocs = new Random();
        static string[] Documents = { "Teudat Zehut", "Darchon", "Teudat Laidah", "Ishur Hanachah LeArnona", "Mispar Bituach Leumi" };
        static Queue<PersonOnLine> TheLine = new Queue<PersonOnLine>();
        static string[] AddDocs(string[] ArrayToSet, int HowManyDocs)
        {

            string[] temparry = new string[HowManyDocs];
            for (int i = 0; i < temparry.Length; i++)
            {
                temparry[i] = Documents[WhichDocs.Next(Documents.Length)];

            }
            ArrayToSet = temparry;
            return ArrayToSet;

        }
        static int CheckDocs(Employee ExampleEmployee,PersonOnLine ExamplePerson)
        {
            int tracker = 0;
           
            for (int EmpDocsNum = 0; EmpDocsNum < ExampleEmployee.EmployeeDocs.Length; EmpDocsNum++)
            {
                for (int PersDocsNum = 0; PersDocsNum < ExamplePerson.PersonDocs.Length; PersDocsNum++)
                {
                    if(ExampleEmployee.EmployeeDocs[EmpDocsNum]==ExamplePerson.PersonDocs[PersDocsNum])
                    {
                        tracker++;
                    }
                }
            }
            return tracker;
        }
        
       




        







    }
}
