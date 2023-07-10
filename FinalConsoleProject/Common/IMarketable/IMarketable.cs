using FinalConsoleProject.Common.Base.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.IMarketable
{
    public interface IMarketable
    {
        public void Sales();
        public void Products();
        public void AddSale();
        public void RemoveProductFromSale();
        public void DeleteSale();
        public void ShowSaleByDateRange();
        public void ShowSaleByDate();//yyyy|mm|dd
        public void ShowSaleByPriceRange();
        public void ShowSaleById();
        public void AddNewProduct();
        public void ChangeInfoOfProductById();
        public void ShowProductOfCategoryByCategory();
        public void ShowProductsByPriceRange();
        public void ShowProductsByName();

        


    }
}
