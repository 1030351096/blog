using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webCore.common
{
    public class paging
    {
        /// <summary>
        /// 关键字
        /// </summary>
        [MaxLength(50,ErrorMessage ="标题最多为50个字")]
        public string keyword { get; set; }
        /// <summary>
        /// 类型id
        /// </summary>
        [Range(1,200,ErrorMessage ="类型参数类型有误")]
        public int ? type_id { get; set; }
        /// <summary>
        /// 是否公开
        /// </summary>
        public bool ? lookno { get; set; }

        /// <summary>
        ///当前页     The current page number contained in this page of result set
        /// </summary>
        public long pageindex { get; set; }

        /// <summary>
        ///总页数     The total number of pages in the full result set
        /// </summary>
        public long TotalPages { get; set; }

        /// <summary>
        /// 总条数    The total number of records in the full result set
        /// </summary>
        public long TotalItems { get; set; }

        /// <summary>
        /// 每页显示记录数    The number of items per page
        /// </summary>
        [Range(1,50,ErrorMessage ="pageindex参数有误")]
        public long pagesizi { get; set; }
    }
}
