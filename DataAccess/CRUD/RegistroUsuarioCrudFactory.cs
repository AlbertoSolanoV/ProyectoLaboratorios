using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.MAPPER;
using DataAccess.DAO;

namespace DataAccess.CRUD
{
    public class RegistroUsuarioCrudFactory : CrudFactory
    {

        private RegistroUsuarioMapper mapper;

        public RegistroUsuarioCrudFactory() : base()
        {

            mapper = new RegistroUsuarioMapper();
            dao= SqlDao.GetInstance();
        }
        public override void Create(EntidadBase entityDTO)
        {
            var registroUsuario=(Usuario)entityDTO;
            var sqlOperation= mapper.GetCreateStatement(registroUsuario);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override string CreateRespuesta(EntidadBase entityDTO)
        {
            var registroUsuario = (Usuario)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(registroUsuario);
            return dao.ExecuteProcedureRespuesta(sqlOperation);
            
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }


        // metodo para llamar a todos los usuarios de la base de datos
        public override List<T> RetrieveAll<T>()
        {
            var list = new List<T>();
            var lisResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveAllStatement());

            var dicc = new Dictionary<string, object>();
            if(lisResult.Count > 0)
            {
                var objUsuarios = mapper.BuildObject(lisResult);
                foreach(var c in objUsuarios)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));

                }
            }
            return list;
        }

        public override T RetrieveByTd<T>(int idUsuario)
        {
            var list = new List<T>();
            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByIdStatement(idUsuario));
            var dic = new Dictionary<String, object>();

            if (listResult.Count >= 0)
            {
                var objPedido = mapper.BuildObject(listResult);
                foreach (var c in objPedido)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }

            }

            return list[0];

        }


        public override void Update(EntidadBase entityDTO)
        {
            var usuarios = (Usuario)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(usuarios);

            dao.ExecuteProcedure(sqlOperation);

        }

        public override string UpdateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();

        }
    }
}
