using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class OrdenDeCompraMapper : ICrudStatements, IObjectMapper
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
                ProcedureName = "sp_crear_orden"
            };

            var ordenDeCompra = (OrdenDeCompra)entidadDTO;
            operation.AddIntegerParam("idUsuario", ordenDeCompra.IdUsuario);
            return operation;
        }
        public SqlOperation GetRetieveAllStatement()
        {

            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_todas_ordenes"
            };

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int Id)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_ultima_orden"
            };
            operation.AddIntegerParam("idUsuario", Id);

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

            var ordenDeCompra = new OrdenDeCompra()
            {
                NumeroConsecutivo = int.Parse(Row["numeroConsecutivo"].ToString()),
                //IdExamen = int.Parse(Row["idExamen"].ToString()),
                IdUsuario = int.Parse(Row["idUsuario"].ToString())
                /*NombreCliente = Row["nombreUsuario"].ToString(),
                Cantidad = int.Parse(Row["cantidad"].ToString()),
                SubTotal = double.Parse(Row["subTotal"].ToString()),
                IVA = double.Parse(Row["IVA"].ToString()),
                Descuento = double.Parse(Row["descuento"].ToString()),
                Total = double.Parse(Row["total"].ToString()),
                Telefono = Row["telefonoUsuario"].ToString(),
                CedulaJuridica = Row["cedulaJuridica"].ToString()*/
            };

            return ordenDeCompra;
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
