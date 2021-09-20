using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto CategoryAddDto { get; set; }
        #region NOT
        /* DTO ya gidecek bir partial view
        * yani post işlemi yapınca bunun sonucunda categoryAddPartial geliyor
        * ajax post işlemi yaptık eğer modelimizin valid durumu doğru değilse 
        * yani isModelStateValid dedik kullanıcı description alanını boş bıraktı
        * oysa biz required olmasını istiyoruz o zaman bununla ilgili hataları
        * geri dönmemiz gerekiyor; o yüzden CategoryAddPartali hem bir paartial vieew olarak
        * hem de içerisindeki modeliyle yani modelin son durumunu kullanıcıya dönüypr olucaz
        * o yüzden burada bir extension kullanarak buradaki bu kategori partialı string olarak
        * bir parse ediyor olacaz
        * */ 
        #endregion

        public string CategoryAddPartial { get; set; }
        // eklemis son kategorinin bize gelmesi gerekiyor
        public CategoryDto CategoryDto { get; set; }
    }
}
