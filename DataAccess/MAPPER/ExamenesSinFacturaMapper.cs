using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class ExamenesSinFacturaMapper : ICrudStatements, IObjectMapper
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
                ProcedureName = "sp_crear_cita_Cliente"
            };
            var datos = (ExamenesSinFactura)entidadDTO;
            operation.AddIntegerParam("idCita", datos.idCita);
            operation.AddIntegerParam("idFactura", datos.idFactura);
            operation.AddIntegerParam("idExamenOrden", datos.idExamenOrden);


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
                ProcedureName = "sp_devolver_ExamenesCliente"
            };
            operation.AddIntegerParam("idCliente", Id);

            return operation;
        }
        public SqlOperation GetRetrieveByIdStatementCita(int Id)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_CitasCliente"
            };
            operation.AddIntegerParam("idCliente", Id);

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


            return operation;
        }
        #endregion
        //ObjectMapper
        #region "Object"

        public EntidadBase BuildObject(Dictionary<string, object> Row)
        {

            var datos = new ExamenesSinFactura
            {
                idFactura = Int32.Parse(Row["numeroConsecutivo"].ToString()),
                nombreLab = Row["nombreComercial"].ToString(),
                fechaEmision = Row["fechaEmision"].ToString(),
                idLaboratorio = Int32.Parse(Row["idLaboratorio"].ToString()),
                nombreExamen = Row["nombreExamen"].ToString(),
                idExamenOrden= Int32.Parse(Row["idExamenOrden"].ToString()),
            };

            return datos;
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

        public EntidadBase BuildObject2(Dictionary<string, object> Row)
        {

            var datos = new ExamenesSinFactura
            {
                idFactura = Int32.Parse(Row["numeroConsecutivo"].ToString()),
                nombreLab = Row["nombreComercial"].ToString(),
                fechaEmision = Row["horario"].ToString(),
                idLaboratorio = Int32.Parse(Row["idLaboratorio"].ToString()),
                nombreExamen = Row["nombreExamen"].ToString(),
                idCita = Int32.Parse(Row["idCita"].ToString()),
            };

            return datos;
        }
        public List<EntidadBase> BuildObject2(List<Dictionary<string, object>> ListRow)
        {
            var listResult = new List<EntidadBase>();

            foreach (var row in ListRow)
            {
                var pedido = BuildObject2(row);
                listResult.Add(pedido);
            }
            return listResult;
        }


        #endregion
    }
}
