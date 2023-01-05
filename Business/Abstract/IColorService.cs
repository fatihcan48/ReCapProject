using Core.Utilities.Abstract;
using Core.Utilities.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
        IDataResult<Color> GetById(byte colorId);
    }
}
