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
    public class ExamenInfoLabCrudFactory : CrudFactory
    {

        private ExamenInfoLabMapper mapper;

        public ExamenInfoLabCrudFactory() : base()
        {
            mapper = new ExamenInfoLabMapper();
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
            var list = new List<T>();
            var lisResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveAllStatement());

            var dicc = new Dictionary<string, object>();
            if (lisResult.Count > 0)
            {
                var objUsuarios = mapper.BuildObject(lisResult);
                foreach (var c in objUsuarios)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));

                }
            }
            return list;
        }



        public override T RetrieveByTd<T>(int idExamen)
        {
            var list = new List<T>();
            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByIdStatement(idExamen));
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

        public List<T>  RetrieveByTdAll<T>(int idExamen)
        {
            var list = new List<T>();
            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByIdStatement(idExamen));
            var dic = new Dictionary<String, object>();

            if (listResult.Count >= 0)
            {
                var objPedido = mapper.BuildObject(listResult);
                foreach (var c in objPedido)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }

            }

            return list;
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
