using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    class LaboratorioMapper : ICrudStatements, IObjectMapper
    {
        //Crud
        #region "Crud"
        public SqlOperation DeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO )
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_crear_laboratorio"
            };

            var laboratorio = (Laboratorio)entidadDTO;
            operation.AddVarcharParam("nombreComercial", laboratorio.nombreComercial);
            operation.AddVarcharParam("nombreLaboratorio", laboratorio.nombre);
            operation.AddVarcharParam("cedulaJuridica", laboratorio.cedulaJuridica);
            operation.AddVarcharParam("razonSocial", laboratorio.razonSocial);
            operation.AddVarcharParam("telefono", laboratorio.telefono);
            operation.AddVarcharParam("email", laboratorio.email);
            operation.AddVarcharParam("paginaWeb", laboratorio.paginaWeb);
            operation.AddVarcharParam("direccion", laboratorio.direccion);
            operation.AddVarcharParam("codPostal", laboratorio.apartadoPostal);
            operation.AddIntegerParam("idUsuario", Int32.Parse(laboratorio.idAdmin));

            operation.AddVarcharParam("primerImg", laboratorio.imagen1);
            operation.AddVarcharParam("segundaImg", laboratorio.imagen2);
            operation.AddVarcharParam("terceraImg", laboratorio.imagen3);
            operation.AddVarcharParam("cuartaImg", laboratorio.imagen4);
            operation.AddVarcharParam("quintaImg", laboratorio.imagen5);

            return operation;
        }
        public SqlOperation GetRetieveAllStatement()
        {

            var operation = new SqlOperation
            {
                ProcedureName = "sp_volver_todos_laboratorios"
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
                ProcedureName = "sp_modificar_laboratorio"
            };

            var laboratorio = (Laboratorio)entidadDTO;
            operation.AddIntegerParam("idLaboratorio", laboratorio.idLaboratorio);
            operation.AddVarcharParam("nombreComercial", laboratorio.nombreComercial);
            operation.AddVarcharParam("nombreLaboratorio", laboratorio.nombre);
            operation.AddVarcharParam("cedulaJuridica", laboratorio.cedulaJuridica);
            operation.AddVarcharParam("razonSocial", laboratorio.razonSocial);
            operation.AddVarcharParam("telefono", laboratorio.telefono);
            operation.AddVarcharParam("email", laboratorio.email);
            operation.AddVarcharParam("paginaWeb", laboratorio.paginaWeb);
            operation.AddVarcharParam("direccion", laboratorio.direccion);
            operation.AddVarcharParam("codPostal", laboratorio.apartadoPostal);
            operation.AddIntegerParam("estado", laboratorio.estado);
            operation.AddIntegerParam("idUsuario", Int32.Parse(laboratorio.idAdmin));

            operation.AddVarcharParam("primerImg", laboratorio.imagen1);
            operation.AddVarcharParam("segundaImg", laboratorio.imagen2);
            operation.AddVarcharParam("terceraImg", laboratorio.imagen3);
            operation.AddVarcharParam("cuartaImg", laboratorio.imagen4);
            operation.AddVarcharParam("quintaImg", laboratorio.imagen5);

            return operation; ;
        }
        #endregion
        //ObjectMapper
        #region "Object"

        public EntidadBase BuildObject(Dictionary<string, object> Row)
        {

            var laboratorio = new Laboratorio
            {
                idLaboratorio = Int32.Parse(Row["idLaboratorio"].ToString()),
                nombre = Row["nombreLaboratorio"].ToString(),
                cedulaJuridica = Row["cedulaJuridica"].ToString(),
                nombreComercial = Row["nombreComercial"].ToString(),
                telefono = Row["telefonoLaboratorio"].ToString(),
                razonSocial = Row["razonSocial"].ToString(),
                paginaWeb = Row["paginaWebLaboratorio"].ToString(),
                email = Row["emailLaboratorio"].ToString(),
                apartadoPostal = Row["apartadoPostal"].ToString(),
                direccion = Row["direccionLaboratorio"].ToString(),
                estado = Int32.Parse(Row["estado"].ToString()),
                idAdmin = Row["nombreAdmin"].ToString(),
                imagen1 = Row["imagen1"].ToString(),
                imagen2 = Row["imagen2"].ToString(),
                imagen3 = Row["imagen3"].ToString(),
                imagen4 = Row["imagen4"].ToString(),
                imagen5 = Row["imagen5"].ToString()
            };

            return laboratorio;
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
