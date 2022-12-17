using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class OrdenExamenMapper : ICrudStatements, IObjectMapper
    {
               //Crud
        #region "Crud"
        public SqlOperation DeleteStatement(EntidadBase entidadDTO)
    {
        throw new NotImplementedException();
    }

    public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
    {
        var operation = new SqlOperation()
        {
            ProcedureName = "sp_crear_exa_orden"
        };

        var orden = (OrdenExamen)entidadDTO;
            operation.AddIntegerParam("idExamen", orden.IdExamen);
            operation.AddIntegerParam("idOrdenCompra", orden.IdOrdenCompra);
        return operation;
    }
    public SqlOperation GetRetieveAllStatement()
    {

        var operation = new SqlOperation
        {
            ProcedureName = ""
        };

        return operation;
    }

    public SqlOperation GetRetrieveByIdStatement(int Id)
    {
        var operation = new SqlOperation
        {
            ProcedureName = ""
        };
        operation.AddIntegerParam("", Id);

        return operation;
    }

    public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
    {
        throw new NotImplementedException();
    }
    #endregion
    //ObjectMapper
    #region "Object"

    public EntidadBase BuildObject(Dictionary<string, object> Row)
    {

        var ordenExamen = new OrdenExamen()
        {
            id = int.Parse(Row["idExamenOrden"].ToString()),
            IdExamen = int.Parse(Row["idExamen"].ToString()),
            IdOrdenCompra = int.Parse(Row["idOrdenCompra"].ToString())

        };

        return ordenExamen;
    }

    public List<EntidadBase> BuildObject(List<Dictionary<string, object>> ListRow)
    {
        var listResult = new List<EntidadBase>();

        foreach (var row in ListRow)
        {
            var orden = BuildObject(row);
            listResult.Add(orden);
        }
        return listResult;
    }




    #endregion

    }
}
