using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class GenericPaginationListDto<T>
    {
        public List<T> Datas { get; set; }
        public int TotalPageNumber { get; set; }
    }
}
