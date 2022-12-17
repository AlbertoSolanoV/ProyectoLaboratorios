using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public class OTPMapper : ICrudStatements, IObjectMapper
    {
        

        #region Metodos del CRUD
        public SqlOperation DeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_registrar_usuario"

            };

            var registroUsuario = (Usuario)entidadDTO;
            operation.AddVarcharParam("identificacionUsuario", registroUsuario.identificacionUsuario);
            operation.AddVarcharParam("nombreUsuario", registroUsuario.nombreUsuario);
            operation.AddVarcharParam("primerApellidoUsuario", registroUsuario.primerApellido);
            operation.AddVarcharParam("segundoApellidoUsuario", registroUsuario.segundoApellido);
            operation.AddVarcharParam("emailUsuario", registroUsuario.emailUsuario);
            operation.AddVarcharParam("telefonoUsuario", registroUsuario.telefonoUsuario);
            operation.AddVarcharParam("contraseñaUsuario", registroUsuario.contraseñaUsuario);
            operation.AddVarcharParam("fotoPerfilUsuario", registroUsuario.fotoPerfilUsuario);
            operation.AddIntegerParam("idRolUsuario", registroUsuario.idRolUsuario);
            operation.AddVarcharParam("usuarioActivo", registroUsuario.usuarioActivo);
            operation.AddVarcharParam("otpUsuario", registroUsuario.OTPUsuario);

            return operation; ;
        }


        public SqlOperation GetRetrieveAllStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();

        }
        public SqlOperation GetRetrieveByIdStatement(string pCorreo)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_validar_usuario_otp"
            };
            operation.AddVarcharParam("emailUsuario", pCorreo);
            return operation;
        }
        

        public SqlOperation GetRetrieveByIdStatementLogin(string pCorreo)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_validar_usuario"
            };
            operation.AddVarcharParam("emailUsuario", pCorreo);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatementLoginOTP(string pOTP, string pCorreo)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "sp_validar_usuario_otp"
            };
            operation.AddVarcharParam("emailUsuario", pCorreo);
            operation.AddVarcharParam("otpUsuario", pOTP);
            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
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

        public SqlOperation GetRetrieveByIdStatement(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
