using DataAccess.CRUD;
using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class ExamenInfoLabMapper : ICrudStatements, IObjectMapper
    {
        

        public SqlOperation DeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByIdStatement(int IdLab)
        {

            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_Examen"
            };
            operation.AddIntegerParam("idLab", IdLab);

            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_devolverExamenes"

            };

            return operation;
        }

        public EntidadBase BuildObject(Dictionary<string, object> Row)
        {
            var examen = new Examen ()
            {
                idExamen = Int32.Parse(Row["idExamen"].ToString()),
                nombreExamen = Row["nombreExamen"].ToString(),
                estadoExamen = bool.Parse(Row["estadoExamen"].ToString()),
                descripcionExamen = Row["descripcionExamen"].ToString(),
                precioExamen = Double.Parse(Row["precioExamen"].ToString()),
                tipoExamen = Row["nombreTipoExamen"].ToString(),


            };
            return examen;
        }

        public List<EntidadBase> BuildObject(List<Dictionary<string, object>> ListRow)
        {
            var listResults = new List<EntidadBase>();

            foreach (var row in ListRow)
            {
                var usuarios = BuildObject(row);
                listResults.Add(usuarios);

            }
            return listResults;
        }

        
    }
}
