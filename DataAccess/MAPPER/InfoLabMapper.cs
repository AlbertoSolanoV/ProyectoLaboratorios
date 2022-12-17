using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class InfoLabMapper : ICrudStatements, IObjectMapper
    {
       

        public SqlOperation DeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByIdStatement(int idLaboratorio)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_InfoLab"
            };
            operation.AddIntegerParam("idLaboratorio", idLaboratorio);

            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

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
                idAdmin = Row["idUsuario"].ToString(),
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
    }
}
