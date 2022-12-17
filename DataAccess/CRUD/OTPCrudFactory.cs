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
    public class OTPCrudFactory : CrudFactoryOTP
    {
        private OTPMapper mapper;
        public OTPCrudFactory() : base()
        {
            mapper = new OTPMapper();
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


        public override T RetrieveByTdCorreo<T>(string correo)
        {
            var list = new List<T>();
            var listResult = dao.ExecuteProcedureWithQuery(mapper.GetRetrieveByIdStatementLogin(correo));
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
            throw new NotImplementedException();
        }

        public override string UpdateRespuesta(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
