using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Activite
    {
        [Key]
        public int ActiviteId { get; set; }
        public Zone Zone { get; set; }
        public double Prix { get; set; }
        public string TypeService { get; set; }
        public ActivitiType ActivitiType { get; set; }
        public virtual IEnumerable<Pack> packs { get; set; }



    }
}
