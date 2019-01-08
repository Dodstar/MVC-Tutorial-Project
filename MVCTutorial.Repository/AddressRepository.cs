using MVCTutorial.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTutorial.Repository
{

    public class AddressRepository : BaseRepository<Department>
    {
        public AddressRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}