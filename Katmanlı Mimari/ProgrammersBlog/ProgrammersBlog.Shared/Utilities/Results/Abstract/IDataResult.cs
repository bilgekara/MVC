using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    // out: bir kategoriyi tek de taşımak isteyebilirim veya Ilist
    // ya da IEnumarable olarak da taşımak isteyebilirim.
    // her iki işlem için de farklı farklı proportieler tanımlamak yerine
    // bu şekilde tek bir prportie içerisinde ister bir liste istersek de te bir entitie taşıyabiliyor olacaz.
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; } // new DataResult<Category>(ResultStatus.Success,category);
                               // new DataResult<IList<Category>>(ResultStatus.Success, categoryList);
    }
}
