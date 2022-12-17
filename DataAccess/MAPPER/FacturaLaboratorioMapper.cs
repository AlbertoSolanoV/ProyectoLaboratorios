using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    class FacturaLaboratorioMapper : ICrudStatements, IObjectMapper
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
                ProcedureName = "sp_crear_factura_laboratorio"
            };
            var factura = (FacturaLaboratorio)entidadDTO;
            operation.AddIntegerParam("idLaboratorio", factura.idLaboratorio);
            operation.AddDoubleParam("total", factura.total);
            operation.AddDoubleParam("subTotal", factura.subTotal);
            operation.AddDoubleParam("IVA", factura.IVA);


            return operation;
        }
        public SqlOperation GetRetieveAllStatement()
        {

            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_facturas_laboratorios"
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

            var factura = new FacturaLaboratorio
            {
                mes = Int32.Parse(Row["mes"].ToString()),
                subTotal = Double.Parse(Row["subTotal"].ToString()),
                total = Double.Parse(Row["total"].ToString()),
                IVA = Double.Parse(Row["IVA"].ToString()),
                nombreLaboratorio = Row["nombreComercial"].ToString(),

            };

            return factura;
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
