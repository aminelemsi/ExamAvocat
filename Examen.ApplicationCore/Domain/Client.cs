using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Client
    {
        [Key] 
        public int Identifiant { get; set; }

        [Required(ErrorMessage = "le champ doit etre saisir par l'utilisateur")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Photo { get; set; }

        public int ConseillerFk { get; set; }
        [ForeignKey("ConseillerFk")]
        public virtual Conseiller conseiller { get; set; }

        public virtual IEnumerable<Reservation> lemsiii { get; set; }

    }
}
