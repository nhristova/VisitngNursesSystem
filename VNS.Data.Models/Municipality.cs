using System.Collections.Generic;
using VNS.Data.Models.Abstracts;

namespace VNS.Data.Models
{
    public class Municipality : DataModel
    {
        public Municipality()
        {
            this.Towns = new List<Town>();
        }

        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}