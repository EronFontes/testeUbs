using Core.Entities;
using Core.Interfaces;
using Core.Provider;
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
            // Local list for reading json.
            List<People> listPeople = new List<People>();

            try
            {
                // Reading .json via streamReader.
                using (StreamReader streamReader = new StreamReader(pathFull))
                {
                    // Binding json
                    listPeople = JsonConvert.DeserializeObject<List<People>>(streamReader?.ReadToEnd());
                }

                // Binding to new static list for middleware.
                PeopleProvider.ListPeople = listPeople;
            }
            catch
            {
                // ttreatment for exceptions em System.IO.
                Task.Delay(2000).ContinueWith(task => Start(pathFull));
            }
        }
    }
}
