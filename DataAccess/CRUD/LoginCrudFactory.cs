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
    public class LoginCrudFactory : CrudFactory
    {
        private LoginMapper mapper;
        public LoginCrudFactory() : base()
        {
            mapper = new LoginMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override string CreateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveByTd<T>(int id)
        {
            var list = new List<T>();
            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByIdStatement(id));
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

        public Usuario RetrieveByTdLogin<Usuario>(string pCorreo)
        {
            var list = new List<Usuario>();
            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByIdStatementLogin(pCorreo));
            var dic = new Dictionary<String, object>();

            if (listResult.Count > 0)
            {
                var objPedido = mapper.BuildObject(listResult);
                foreach (var c in objPedido)
                {
                    list.Add((Usuario)Convert.ChangeType(c, typeof(Usuario)));
                }
            }
            else
            {
                return default(Usuario);
            }
            
                return list[0];

        }

        public override void Update(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override string UpdateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
