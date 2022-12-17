using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    class TipoExamenMapper : ICrudStatements, IObjectMapper
    {
        //Crud
        #region "Crud"
        public SqlOperation DeleteStatement(EntidadBase entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_eliminar_TipoExamen"
            };
            var examen = (TipoExamen)entityDTO;
            operation.AddIntegerParam("idTipoExamen", examen.idTipoExamen);

            return operation;
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_crear_TipoExamen"
            };

            var examen = (TipoExamen)entidadDTO;
            operation.AddIntegerParam("idTipoExamen", examen.idTipoExamen);
            operation.AddIntegerParam("idLaboratorio", examen.idLaboratorio);
            operation.AddVarcharParam("nombreTipoExamen", examen.nombreTipoExamen);
            operation.AddVarcharParam("descripcionExamen", examen.descripcionTipoExamen);
            operation.AddDoubleParam("precio", examen.precio);
            operation.AddVarcharParam("parametros", examen.parametros);



            return operation;
        }
        public SqlOperation GetRetieveAllStatement()
        {

            var operation = new SqlOperation
            {
                ProcedureName = "sp_mostrar_TipoExamenes"
            };

            return operation;
        }

        public SqlOperation GetRetrieveAllByIdStatement(int Id)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_TipoExamen"
            };
            operation.AddIntegerParam("idCliente", Id);

            return operation;
        }
        public SqlOperation GetRetrieveByIdStatement(int Id)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolverUn_TipoExamen"
            };
            operation.AddIntegerParam("idTExamen", Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_modificar_TipoExamen"
            };

            var examen = (TipoExamen)entidadDTO;
            operation.AddIntegerParam("idTipoExamen", examen.idTipoExamen);
            operation.AddVarcharParam("nombreTipoExamen", examen.nombreTipoExamen);
            operation.AddVarcharParam("descripcionExamen", examen.descripcionTipoExamen);
            operation.AddDoubleParam("precio", examen.precio);
            operation.AddVarcharParam("parametros", examen.parametros);



            return operation;
        }
        #endregion
        //ObjectMapper
        #region "Object"

        public EntidadBase BuildObject(Dictionary<string, object> Row)
        {

            var examen = new TipoExamen
            {
                idTipoExamen = Int32.Parse(Row["idTipoExamen"].ToString()),
                nombreTipoExamen = Row["nombreTipoExamen"].ToString(),
                descripcionTipoExamen = Row["descripcionExamen"].ToString(),
                precio = Double.Parse(Row["precio"].ToString()),
                parametros = Row["parametros"].ToString(),

            };

            return examen;
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
