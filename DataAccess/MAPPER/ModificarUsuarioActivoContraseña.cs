using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class ModificarUsuarioActivoContraseña : ICrudStatements, IObjectMapper
    {
        #region Metodos del CRUD
        public SqlOperation DeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }


        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_devolverUsuarios"

            };

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int Id)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_modificar_usuario_estado_contraseña"

            };

            var registroUsuario = (Usuario)entidadDTO;
            operation.AddIntegerParam("idUsuario", registroUsuario.id);
            operation.AddVarcharParam("contraseñaUsuario", registroUsuario.contraseñaUsuario);


            return operation;
        }

        #endregion

        #region Metodos del ObjectMapper

        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var usuarios = new Usuario()
            {
                id = Int32.Parse(row["idUsuario"].ToString()),
                identificacionUsuario = row["identificacionUsuario"].ToString(),
                nombreUsuario = row["nombreUsuario"].ToString(),
                primerApellido = row["primerApellidoUsuario"].ToString(),
                segundoApellido = row["segundoApellidoUsuario"].ToString(),
                emailUsuario = row["emailUsuario"].ToString(),
                telefonoUsuario = row["telefonoUsuario"].ToString(),
                fotoPerfilUsuario = row["fotoPerfilUsuario"].ToString(),
                usuarioActivo = row["usuarioActivo"].ToString(),
                nombreRol = row["nombreRol"].ToString(),
                contraseñaUsuario = row["contraseñaUsuario"].ToString(),
                OTPUsuario = row["otpUsuario"].ToString()

            };
            return usuarios;
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
        #endregion

    }
}

