using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class ClienteMapper : ICrudStatements, IObjectMapper
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



            return operation;
        }
        public SqlOperation GetRetieveAllStatement()
        {

            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_bitacora"
            };

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int Id)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_clientesLaboratorio"
            };
            operation.AddIntegerParam("idLaboratorio", Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_modificar_porcentajes"
            };
            var porcentaje = (Porcentaje)entidadDTO;
            operation.AddIntegerParam("idPorcentaje", porcentaje.idPorcentaje);



            return operation; ;
        }
        #endregion
        //ObjectMapper
        #region "Object"

        public EntidadBase BuildObject(Dictionary<string, object> Row)
        {

            var cliente = new Cliente
            {
                nombreUsuario = Row["nombreUsuario"].ToString() + " " + Row["primerApellidoUsuario"].ToString() + " " + Row["segundoApellidoUsuario"].ToString(),
                emailUsuario = Row["emailUsuario"].ToString(),
                telefonoUsuario = Row["telefonoUsuario"].ToString()
            };

            return cliente;
        }

        public List<EntidadBase> BuildObject(List<Dictionary<string, object>> ListRow)
        {
            var listResult = new List<EntidadBase>();

            foreach (var row in ListRow)
            {
                var pedido = BuildObject(row);
                listResult.Add(pedido);
            }
            return listResult;
        }




        #endregion
    }
}