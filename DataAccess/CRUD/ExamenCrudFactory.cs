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
    public class ExamenCrudFactory : CrudFactory
    {
        private ExamenMapper mapper;

        public ExamenCrudFactory() : base()
        {
            mapper = new ExamenMapper();
            dao = SqlDao.GetInstance();
        }
        public override string CreateRespuesta(EntidadBase entityDTO)
        {
            return "";
        }
        public  void CreateRespuestaE(EntidadBase entityDTO)
        {
            var pedido = (Examen)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(pedido);

            dao.ExecuteProcedure(sqlOperation);

        }
        public override void Delete(EntidadBase entityDTO)
        {
            var pedido = (Examen)entityDTO;
            var sqlOperation = mapper.DeleteStatement(pedido);

            dao.ExecuteProcedure(sqlOperation);
        }

        public void modificarExamen(EntidadBase entityDTO)
        {
            var pedido = (Examen)entityDTO;
            pedido.estadoExamen = true;
            var sqlOperation = mapper.GetUpdateStatement(pedido);

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

        public List<T> RetrieveAllCliente<T>(int id)
        {
            var list = new List<T>();

            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByIdStatement(id));
            var dic = new Dictionary<String, object>();

            if (listResult.Count > 0)
            {
                var objPedido = mapper.BuildObjectExaClien(listResult);
                foreach (var c in objPedido)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));

                }
            }

            return list;
        }
        public List<T> RetrieveAllUsuario<T>(int id)
        {
            var list = new List<T>();

            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByIdStatementUsu(id));
            var dic = new Dictionary<String, object>();

            if (listResult.Count > 0)
            {
                var objPedido = mapper.BuildObjectExaUsu(listResult);
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
            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByIdStatementExa(id));
            var dic = new Dictionary<String, object>();

            if (listResult.Count >= 0)
            {
                var objPedido = mapper.BuildObjectExaUsu(listResult);
                foreach (var c in objPedido)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return list[0];
        }

        public override void Update(EntidadBase entityDTO)
        {
            var pedido = (Examen)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(pedido);

            dao.ExecuteProcedure(sqlOperation);
        }
        public override void Create(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override string UpdateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}