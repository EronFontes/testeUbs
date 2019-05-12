using Core.Entities;
using Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UBS.Web.Controllers;

namespace Business
{
    public class UpdateModel : IUpdateModel
    {
        public void Start(string pathFull)
        {
            List<Person> items = new List<Person>();

            try
            {
                using (StreamReader r = new StreamReader(pathFull))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<Person>>(json);
                    Console.WriteLine("Quantidade: " + items.Count());
                }
            } catch (Exception ex)
            {
                Console.Write(ex);
            }

            PersonProvider.ListPerson = items;
        }

        public void Stop()
        {

        }
    }
}
