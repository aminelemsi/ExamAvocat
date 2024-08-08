using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Reservation
    {
        [DataType(DataType.Date)]
        public DateTime DateReservation { get; set; }

        [Range(1, 4)]
        [Display(Name ="si il veut afficher un message normale non pas erreur message")]
        public int NbPersonnes { get; set; }

        public int ClientFk { get; set; }
        [ForeignKey("ClientFk")]
        public virtual Client lemsi { get; set; }

        public int PackFk { get; set; }
        [ForeignKey("PackFk")]
        public virtual Pack Pack { get; set; }
    }
}
