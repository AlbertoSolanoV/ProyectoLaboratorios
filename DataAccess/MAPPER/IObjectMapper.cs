using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public interface IObjectMapper
    {
        EntidadBase BuildObject(Dictionary<String, object> Row);

        List<EntidadBase> BuildObject(List<Dictionary<String, object>> ListRow);
    }
}
