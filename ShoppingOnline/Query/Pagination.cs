using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingOnline.Query
{
    public class Pagination<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Pagination(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 3 ? 3 : pageSize;
        }

        public IEnumerable<T> Paged(IEnumerable<T> data)
        {
            return data.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}