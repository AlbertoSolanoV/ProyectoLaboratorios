using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class FacturaMapper : ICrudStatements, IObjectMapper
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
                ProcedureName = "sp_crear_factura"
            };
            var factura = (Factura)entidadDTO;
            operation.AddDoubleParam("total", factura.total);
            operation.AddDoubleParam("subTotal", factura.subTotal);
            operation.AddDoubleParam("IVA", factura.IVA);
            operation.AddDoubleParam("descuentos", factura.descuentos);
            operation.AddIntegerParam("clave", factura.clave);
            operation.AddIntegerParam("idOrdenCompra", factura.idOrdenCompra);
            return operation;
        }
        public SqlOperation GetRetieveAllStatement()
        {

            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_facturas"
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

            var factura = new Factura
            {
                total = Double.Parse(Row["total"].ToString()),
                subTotal = Double.Parse(Row["subTotal"].ToString()),               
                IVA = Double.Parse(Row["IVA"].ToString()),
                descuentos = Double.Parse(Row["descuentos"].ToString()),
                clave = Int32.Parse(Row["clave"].ToString()),
                idOrdenCompra = Int32.Parse(Row["idOrdenCompra"].ToString()),

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
