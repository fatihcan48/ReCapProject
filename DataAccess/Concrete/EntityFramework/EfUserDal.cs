using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from u in context.UserOperationClaims
                             join o in context.OperationClaims on
                             u.OperationClaimId equals o.Id
                             where u.UserId == user.UserId
                             select new OperationClaim { Id=o.Id, Name=o.Name};
                   
                return result.ToList();
            }
        }
    }
}
