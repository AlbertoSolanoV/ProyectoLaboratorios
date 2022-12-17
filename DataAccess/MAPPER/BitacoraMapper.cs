using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class BitacoraMapper : ICrudStatements, IObjectMapper
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
                ProcedureName = "sp_devolver_laboratorio"
            };
            operation.AddIntegerParam("idUsuario", Id);

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
            operation.AddDoubleParam("porcentajeNuevo", porcentaje.porcentaje);


            return operation; ;
        }
        #endregion
        //ObjectMapper
        #region "Object"

        public EntidadBase BuildObject(Dictionary<string, object> Row)
        {

            var bitacora = new Bitacora
            {
                accion = Row["accion"].ToString(),
                fecha = Row["fecha"].ToString(),
                nombreUsuario = Row["nombreUsuario"].ToString()+ " " + Row["primerApellidoUsuario"].ToString() + " "+ Row["segundoApellidoUsuario"].ToString(),
                primerApellido = Row["primerApellidoUsuario"].ToString(),
                segundoApellido = Row["segundoApellidoUsuario"].ToString(),
                nombreRol = Row["nombreRol"].ToString()
            };

            return bitacora;
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
