using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();
        // bir veri ekleyince IResult dönücez ve veri eklerken de kategorinin
        // tamamını değil sadece front end tarafını kullanıcıdan isteyecez
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto,string createdByName);
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        // bu gercekten category'i silmicek delete degerini true yapacak
        //getAll diye cagirdigimizda delete olanlar gelmiyor olacak
        Task<IDataResult<CategoryDto>> Delete(int categoryId, string modifiedByName);
        // veri tabanından silincek
        Task<IResult> HardDelete(int categoryId);
    }
}
