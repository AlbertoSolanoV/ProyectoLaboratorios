using DataAccess.DAO;
using DataAccess.MAPPER;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class ReinicioContraseñaCrudFactory : CrudFactoryReinicioContraseña
    {

        private ReinicioContraseñaMapper mapper;
        public ReinicioContraseñaCrudFactory() : base()
        {

            mapper = new ReinicioContraseñaMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(EntidadBase entityDTO)
        {
            var registroUsuario = (Usuario)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(registroUsuario);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override string CreateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }


        // metodo para llamar a todos los usuarios de la base de datos
        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
        public override T RetrieveByTdCorreo<T>(string correo)
        {
            var list = new List<T>();
            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByStringStatement(correo));
            var dic = new Dictionary<String, object>();

            if (listResult.Count >= 0)
            {
                var objPedido = mapper.BuildObject(listResult);
                foreach (var c in objPedido)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            try
            {
                return list[0];


            }
            catch (Exception)
            {
                return default(T);
            }


        }

        public override void Update(EntidadBase entityDTO)
        {
            var updateUsuario = (Usuario)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(updateUsuario);
            dao.ExecuteProcedure(sqlOperation);

        }

        public override string UpdateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();

        }
    }
}

