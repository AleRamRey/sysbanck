using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Infraestructura.Interface
{
    public interface ICustomersRepository  
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
