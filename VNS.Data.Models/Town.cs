using System.Collections.Generic;
using VNS.Data.Models.Abstracts;

namespace VNS.Data.Models
{
    public class Town : DataModel
    {
        public Town()
        {
            this.Addresses = new List<Address>();
        }

        public string Name { get; set; }

        public virtual Municipality Municipality { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
