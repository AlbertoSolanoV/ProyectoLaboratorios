﻿using DataAccess.DAO;
using DataAccess.MAPPER;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class OrdenExamenCrudFactory : CrudFactory
    {
        private OrdenExamenMapper mapper;

        public OrdenExamenCrudFactory() : base()
        {
            mapper = new OrdenExamenMapper();
            dao = SqlDao.GetInstance();
        }
        public override string CreateRespuesta(EntidadBase entityDTO)
        {
            var ordenExamen = (OrdenExamen)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(ordenExamen);

            var Result = dao.ExecuteProcedureRespuesta(sqlOperation);

            return Result;
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var list = new List<T>();

            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetieveAllStatement());
            var dic = new Dictionary<String, object>();

            if (listResult.Count > 0)
            {
                var objOrden = mapper.BuildObject(listResult);
                foreach (var c in objOrden)
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
                var objOrden = mapper.BuildObject(listResult);
                foreach (var c in objOrden)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return list[0];
        }

        public override void Update(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
        public override void Create(EntidadBase entityDTO)
        {
            var ordenExamen = (OrdenExamen)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(ordenExamen);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override string UpdateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
