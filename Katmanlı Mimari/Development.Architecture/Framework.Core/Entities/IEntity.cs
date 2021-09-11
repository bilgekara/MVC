using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Entities
{
    public abstract class IEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
