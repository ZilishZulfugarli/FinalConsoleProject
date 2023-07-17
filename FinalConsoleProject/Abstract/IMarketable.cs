using FinalConsoleProject.Common.Base.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Abstract
{
    public interface IMarketable
    {
        #region Product Methods
        public void AddProduct(string name, decimal price, int number, string category);
        public void UptadeProduct(int id, string name, decimal price, int number, string category);
        public void DeleteProduct(int ProductId);
        public List<Products> ShowAllProducts();
        public void ShowProductsByCategory(string category);
        public void FindByPriceRange(decimal startprice, decimal endprice);
        public void FindProductByName(string name);

        #endregion

        #region Sale Methods
        public int AddSale(int SaleItemNumber);
        public void ReturnSaleİtem(int id, int SaleItemID, int reversenumber);
        public void DeleteSaleById(int id);
        public List<Sales> ShowAllSales();
        public void ShowSaleByDateRange(DateTime date1, DateTime date2);
        public void ShowSaleByPriceRange(decimal price1, decimal price2);
        public void ShowSaleByDate(DateTime date);
        public void ShowSaleById(int id);

        #endregion
    }
}
