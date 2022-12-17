using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class CitasMapper : ICrudStatements, IObjectMapper
    {
        //Crud
        #region "Crud"
        public SqlOperation DeleteStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_canelar_CitasCliente"
            };
            var cita = (Citas)entidadDTO;
            operation.AddIntegerParam("idCita", cita.idCitas);


            return operation; 
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
                ProcedureName = "sp_devolver_clientesCitasLab"
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
            operation.AddDoubleParam("porcentajeNuevo", porcentaje.porcentaje);


            return operation; ;
        }
        #endregion
        //ObjectMapper
        #region "Object"

        public EntidadBase BuildObject(Dictionary<string, object> Row)
        {

            var cita = new Citas
            {
                idCitas = Int32.Parse( Row["idCita"].ToString()),
                usuario = Row["nombreUsuario"].ToString() + " "+ Row["primerApellidoUsuario"].ToString() + " " + Row["segundoApellidoUsuario"].ToString(),
                email = Row["emailUsuario"].ToString(),
                telefono = Row["telefonoUsuario"].ToString(),
                horario = Row["horario"].ToString(),
                nombreExamen = Row["nombreExamen"].ToString(),
            };

            return cita;
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
