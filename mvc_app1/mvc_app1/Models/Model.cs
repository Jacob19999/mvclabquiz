// Written By Jacob Tang

using System.Data;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;

namespace mvc_app1.Models
{

    public class PersonModel

    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }


    public class Person
    {
        public DataTable updatePersons(string path)
        {
            var person = new File.FileGateway();
            return person.GetDataTabletFromCSVFile(path);
        }

        public List<PersonModel> UpdateDT(DataTable dt)
        {

            int i = dt.Rows.Count;
            Console.WriteLine(i);

           //System.Diagnostics.Debug.WriteLine("Size of table: " + i);
           List <PersonModel> list1 = new List<PersonModel>();

            for (int j=0; j<i; j++)
            {

                var k = new PersonModel();


                k.LastName = Convert.ToString(dt.Rows[j][0].ToString());
                k.FirstName = Convert.ToString(dt.Rows[j][1].ToString());

                list1.Add(k);

            }
      
            return list1;
        }
    }

   
}
