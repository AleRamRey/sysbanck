using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICustomersDomain
    {
        # region Metodos Sincronos
        bool Insert(Customers customer);

        bool Update(Customers customer);

        bool Delete(string customerid);

        Customers Get(string customerid);

        IEnumerable<Customers> GetAll();

        #endregion


        #region Metodos Asincronos
        Task<bool> InsertAsync(Customers customer);

        Task<bool> UpdateAsync(Customers customer);

        Task<bool> DeleteAsync(string customerid);

        Task<Customers> GetAsync(string customerid);

        Task<IEnumerable<Customers>> GetAllAsync();

        #endregion
    }
}
