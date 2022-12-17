using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
        public abstract class CrudFactoryOTP
        {

            protected SqlDao dao;
            public abstract void Create(EntidadBase entityDTO);
            public abstract string CreateRespuesta(EntidadBase entityDTO);
            public abstract void Update(EntidadBase entityDTO);
            public abstract string UpdateRespuesta(EntidadBase entityDTO);
            public abstract void Delete(EntidadBase entityDTO);
            public abstract List<T> RetrieveAll<T>();
            public abstract T RetrieveByTdCorreo<T>(string pCorreo);
        }
}
