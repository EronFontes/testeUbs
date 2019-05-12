using Core.Interfaces;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business
{
    public class UpdateModel : IUpdateModel
    {
        public void Start(string pathFull)
        {
            using (StreamReader r = new StreamReader(pathFull))
            {
                string json = r.ReadToEnd();
                List<Person> items = JsonConvert.DeserializeObject<List<Person>>(json);

                Console.WriteLine("Quantidade: " + items.Count());
            }
        }

        public void Stop()
        {

        }
    }
}
