using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATV_Common_WebAPI.TEST.KIOXIA.Interfaces;

public interface IKioxiaService
{
    Task<List<object>> GetPKGSort_COMBINE_INF(string lotno);
}
