using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {

        // proprties
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        // iliskili tablolarda silme işi problem oldugundan dolayli aktif mi pasif mi?
        public bool CategoryStatus { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
