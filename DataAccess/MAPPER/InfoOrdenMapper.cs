using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class InfoOrdenMapper
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
                ProcedureName = ""
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
                ProcedureName = "sp_devolver_orden_de_compra"
            };
            operation.AddIntegerParam("numeroConsecutivo", Id);

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
                IdExamen = int.Parse(Row["idExamen"].ToString()),
                IdUsuario = int.Parse(Row["idUsuario"].ToString()),
                NombreCliente = Row["nombreUsuario"].ToString(),
                Apellido1 = Row["primerApellidoUsuario"].ToString(),
                Apellido2 = Row["segundoApellidoUsuario"].ToString(),
                Telefono = Row["telefonoUsuario"].ToString(),
                NombreLab = Row["nombreLaboratorio"].ToString(),
                CedulaJuridica = Row["cedulaJuridica"].ToString(),
                SubTotal = double.Parse(Row["precio"].ToString()),
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
