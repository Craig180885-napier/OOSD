using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace TrackAndTrace
{
    
    class Data
    {
        
       public List<Person> displayAllPeopleFromFile(string path)
        {
            List<Person> lp = new List<Person>();

                using (var reader = new StreamReader(path))
                {
                reader.ReadLine();
                  
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        
                        Console.WriteLine(values[0]);                      
                        Console.WriteLine(values[1]);
                    int UserID = int.Parse(values[0]);
                    string phoneNumber = "0" + values[1];

                    lp.Add(new Person(UserID, phoneNumber));
                 
                    }                
                }
            return lp;

        }

        public void displayAllFromFileForEach()
        {
            
            //var streamReader = File.OpenText(path);
            //var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
            
            //var users = csvReader.GetRecords<Person>();
           
            //foreach (var user in users)
            //{
            //    Console.WriteLine(user);
            //}

            
        }
    }
}
