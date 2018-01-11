using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ssms.DataClasses
{
    class ItemMain
    {
        public int itemID { get; set; }
        public string EPC { get; set; }
        public bool ItemStatus { get; set; }

		//单品仓库信息
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }

		//单品商品信息
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

		//单品条码信息
        public int BarcodeID { get; set; }
        public string BarcodeNumber { get; set; }

		//单品所属厂家信息
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

		//单品类型信息
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }



        public ItemMain()
        {

        }
    }
}
