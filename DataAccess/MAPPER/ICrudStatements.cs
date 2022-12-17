using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public interface ICrudStatements
    {
        SqlOperation GetCreateStatement(EntidadBase entidadDTO);
        SqlOperation GetUpdateStatement(EntidadBase entidadDTO);
        SqlOperation DeleteStatement(EntidadBase entidadDTO);
        SqlOperation GetRetrieveByIdStatement(int Id);
    }
}
