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
    public class TipoExamenCrudFactory : CrudFactory
    {
        private TipoExamenMapper mapper;

        public TipoExamenCrudFactory() : base()
        {
            mapper = new TipoExamenMapper();
            dao = SqlDao.GetInstance();
        }


        public  void CreateRespuestaT(EntidadBase entityDTO)
        {
            var pedido = (TipoExamen)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(pedido);

            dao.ExecuteProcedure(sqlOperation);


        }


        public void modificarTExamen(EntidadBase entityDTO)
        {
            var pedido = (TipoExamen)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(pedido);

            dao.ExecuteProcedure(sqlOperation);

        }


        public override void Delete(EntidadBase entityDTO)
        {
            var pedido = (TipoExamen)entityDTO;
            var sqlOperation = mapper.DeleteStatement(pedido);

            dao.ExecuteProcedure(sqlOperation);
        }


        public override List<T> RetrieveAll<T>()
        {
            var list = new List<T>();

            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetieveAllStatement());
            var dic = new Dictionary<String, object>();

            if (listResult.Count > 0)
            {
                var objPedido = mapper.BuildObject(listResult);
                foreach (var c in objPedido)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));

                }
            }

            return list;
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


        public List<T> devolverTipoExamenes<T>(int id)
        {
            var list = new List<T>();
            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveAllByIdStatement(id));
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
        public override void Create(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override string UpdateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override string CreateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}