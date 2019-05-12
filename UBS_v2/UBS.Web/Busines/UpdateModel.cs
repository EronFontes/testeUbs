using Core.Entities;
using Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UBS.Web.Controllers;

namespace Business
{
    /// <summary>
    /// UpdateModel.
    /// </summary>
    public class UpdateModel : IUpdateModel
    {
        /// <summary>
        /// Start.
        /// </summary>
        /// <param name="pathFull"></param>
        public void Start(string pathFull)
        {
            // Lista local para leitura do json.
            List<Person> listPerson = new List<Person>();

            try
            {
                // Leitura do .json via streamReader.
                using (StreamReader streamReader = new StreamReader(pathFull))
                {
                    // Binding do json serializado para a listagem.
                    listPerson = JsonConvert.DeserializeObject<List<Person>>(streamReader?.ReadToEnd());
                }

                // Binding da nova lista para a lista estática do middleware.
                PersonProvider.ListPerson = listPerson;
            }
            catch
            {
                // Tratamento para exceptions em System.IO.
                Task.Delay(2000).ContinueWith(task => Start(pathFull));
            }
        }
    }
}
