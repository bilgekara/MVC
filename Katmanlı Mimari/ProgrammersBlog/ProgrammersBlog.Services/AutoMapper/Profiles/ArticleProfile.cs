using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            /* ilki bizim kaynağımız-> neyi neye dönüştürmek istiyorsak onu veriyoruz
            * ArticleAddDto: kaynagımız, Article: sen articleDto yu al bir article a donustur
            * ArticleAddDto içinde created date degeri yok bu alanı dısardan vermemiz gerekiyor
            * elle de yazabiliriz
            * CreatedDate alanı yok ama sen benim yapamcagım islemlerle gerceklesitir
            */
            CreateMap<ArticleAddDto, Article>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
