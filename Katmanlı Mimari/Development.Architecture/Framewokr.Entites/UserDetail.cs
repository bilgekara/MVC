using Framework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framewokr.Entites
{
    public class UserDetail : IEntity
    {

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public string Job { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
