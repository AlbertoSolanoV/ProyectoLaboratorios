﻿using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
  public  class RegistroUsuarioLabMapper : ICrudStatements, IObjectMapper
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
                ProcedureName = "sp_registrar_usuario_lab"

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
            operation.AddIntegerParam("idLab", registroUsuario.idLab);

            return operation;
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
            var operation = new SqlOperation
            {
                ProcedureName = "sp_devolver_Usuario"
            };
            operation.AddIntegerParam("idUsuario", Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "sp_modificar_usuario"
            };

            var usuario = (Usuario)entidadDTO;

            operation.AddIntegerParam("idUsuario", usuario.id);
            operation.AddVarcharParam("identificacionUsuario", usuario.identificacionUsuario);
            operation.AddVarcharParam("nombreUsuario", usuario.nombreUsuario);
            operation.AddVarcharParam("primerApellidoUsuario", usuario.primerApellido);
            operation.AddVarcharParam("segundoApellidoUsuario", usuario.segundoApellido);
            operation.AddVarcharParam("emailUsuario", usuario.emailUsuario);
            operation.AddVarcharParam("telefonoUsuario", usuario.telefonoUsuario);
            operation.AddVarcharParam("fotoPerfilUsuario", usuario.fotoPerfilUsuario);

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
                idRolUsuario = Int32.Parse(row["idRolUsuario"].ToString()),
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
