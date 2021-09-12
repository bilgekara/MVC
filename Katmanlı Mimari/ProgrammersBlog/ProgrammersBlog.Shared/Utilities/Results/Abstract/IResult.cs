using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        /* Kullanıcılara bir sonuç döneceksek bu result durumunu 
         * kullanıcıyla paylaşmamız gerekiyor. Yani buradaki işleme 
         * başarılı mı, hatalı mı, uyarı mı yoksa sadece bilgilendirme 
         * işlemi mi? Bunu state durum olarak tutacaz.
         */
        public ResultStatus ResultStatus { get; } // ResultStatus.Success // ResultStatus.Error
        public string Message { get; }
        public Exception Exception { get; }
    }
}
