using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    class ExamenMapper : ICrudStatements, IObjectMapper
    {
        //Crud
        #region "Crud"
        public SqlOperation DeleteStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_eliminar_Examen"
            };
            var examen = (Examen)entidadDTO;
            operation.AddIntegerParam("idExamen", examen.idExamen);

            return operation;
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_crear_Examen"
            };

            var examen = (Examen)entidadDTO;
            operation.AddVarcharParam("nombreExamen", examen.nombreExamen);
            operation.AddIntegerParam("idTipoExamen", examen.idTipoExamen);
            operation.AddBoolParam("estadoExamen",examen.estadoExamen);
            operation.AddVarcharParam("parametros", examen.parametros);
            operation.AddIntegerParam("idLaboratorio", examen.idlaboratorio);
            operation.AddVarcharParam("descripcionExamen", examen.descripcionExamen);
            operation.AddDoubleParam("precio", examen.precioExamen);
            operation.AddVarcharParam("valores", examen.valores);


            return operation;
        }
        public SqlOperation GetRetieveAllStatement()
        {

            var operation = new SqlOperation
            {
                ProcedureName = "sp_mostrar_examenes"
            };

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int Id)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_mostrar_ExamenCliente"
            };
            operation.AddIntegerParam("idLaboratorio", Id);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatementUsu(int Id)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_DevolverExamenUsuario"
            };
            operation.AddIntegerParam("idCliente", Id);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatementExa(int Id)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_mostrar_UnExamen"
            };
            operation.AddIntegerParam("idCita", Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_modificar_Examen"
            };

            var examen = (Examen)entidadDTO;
            operation.AddIntegerParam("idExamen", examen.idExamen);
            operation.AddVarcharParam("nombreExamen", examen.nombreExamen);
            operation.AddVarcharParam("descripcionExamen", examen.descripcionExamen);
            operation.AddVarcharParam("valores", examen.valores);
            operation.AddBoolParam("estadoExamen", examen.estadoExamen);



            return operation;
        }
        #endregion
        //ObjectMapper
        #region "Object"

        public EntidadBase BuildObject(Dictionary<string, object> Row)
        {

            var examen = new Examen
            {
                idExamen = Int32.Parse(Row["idExamen"].ToString()),
                nombreExamen = Row["nombreExamen"].ToString(),
                estadoExamen = bool.Parse(Row["estadoExamen"].ToString()),
                precioExamen = Double.Parse(Row["precioExamen"].ToString()),
                idTipoExamen = Int32.Parse(Row["idTipoExamen"].ToString()),
                idlaboratorio = Int32.Parse(Row["idLaboratorio"].ToString()),
                descripcionExamen = Row["descripcionExamen"].ToString(),
                parametros = Row["parametros"].ToString(),
                valores = Row["valores"].ToString()
            };

            return examen;
        }
        public EntidadBase BuildObjectExamenUsu(Dictionary<string, object> Row)
        {

            var examen = new ExamenCliente
            { 
                idCita = Int32.Parse(Row["idCita"].ToString()),
                nombreUsuario = Row["nombreUsuario"].ToString(),
                idlaboratorio = Int32.Parse(Row["idLaboratorio"].ToString()),
                idExamen = Int32.Parse(Row["idExamen"].ToString()),
                nombreExamen = Row["nombreExamen"].ToString(),
                horario = DateTime.Parse(Row["horario"].ToString()),
                parametros = Row["parametros"].ToString(),
                valores = Row["valores"].ToString(),
                descripcionExamen = Row["descripcionExamen"].ToString(),
                precioExamen = Double.Parse(Row["precioExamen"].ToString()),
                estadoExamen = bool.Parse(Row["estadoExamen"].ToString())
            };

            return examen;
        }

        public EntidadBase BuildObjectExamenCliente(Dictionary<string, object> Row)
        {

            var examen = new ExamenCliente
            {
                nombreExamen = Row["nombreExamen"].ToString(),
                precioExamen = Double.Parse(Row["precioExamen"].ToString()),
                idExamen = Int32.Parse(Row["idExamen"].ToString()),
                idCita = Int32.Parse(Row["idCita"].ToString()),
                idlaboratorio = Int32.Parse(Row["idLaboratorio"].ToString()),
                descripcionExamen = Row["descripcionExamen"].ToString(),
                parametros = Row["parametros"].ToString(),
                valores = Row["valores"].ToString(),
                nombreUsuario = Row["nombreUsuario"].ToString(),
                horario = DateTime.Parse(Row["horario"].ToString()),
                estadoExamen = bool.Parse(Row["estadoExamen"].ToString())
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
        public List<EntidadBase> BuildObjectExaUsu(List<Dictionary<string, object>> ListRow)
        {
            var listResult = new List<EntidadBase>();

            foreach (var row in ListRow)
            {
                var pedido = BuildObjectExamenUsu(row);
                listResult.Add(pedido);
            }
            return listResult;
        }
        public List<EntidadBase> BuildObjectExaClien(List<Dictionary<string, object>> ListRow)
        {
            var listResult = new List<EntidadBase>();

            foreach (var row in ListRow)
            {
                var pedido = BuildObjectExamenCliente(row);
                listResult.Add(pedido);
            }
            return listResult;
        }




        #endregion
    }
}
