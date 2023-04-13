using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common
{
    public class PaginatedInputModel
    {
        public IEnumerable<SortingUtility.SortingParams> SortingParams { get; set; }    
        public IEnumerable<FilterUtility.FilterParams> FilterParams { get; set; }
        public IEnumerable<string> GroupingColumns { get; set; } = null;
        public int pageNumber = 1;
        public int PageNumber { get { return pageNumber; } set { if (value > 1) pageNumber = value; } }

        private int pageSize = 25;
        public int PageSize { get { return pageSize; } set { if (value > 1) pageSize = value; } }
    }
}
