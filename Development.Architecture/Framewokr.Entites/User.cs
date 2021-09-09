using Framework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framewokr.Entites
{
    /*Entities katmanında veritabanındaki kolonlar bire bir oluşturulur.
     *Veritabanında ki tabloda ki nvarcharların değerini MaxLenght ile veriyorum.
     * ID'yi primary key yapabilmek için KEY attiribute'nü kullanıyorum
     * Required attiribute veritabanında ki kolonun boş geçilemez olduğunu belirtir
     */
    public class User : IEntity
    {
        public User()
        {
            UserDetails = new HashSet<UserDetail>();//list teker teker getirirken hash hepsini birden getirir
        }


        [MaxLength(50)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
