using EShop.BLL.DTOs.CoreInterfaces;
using EShop.BLL.DTOs.DTOClasesses;
using EShop.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ManagerServices.Abstracts
{
    public interface IManager<T,U> where T : class where U : class,IEntity //UI katmanında ICategoryManager ile işlem yapıyoruz IEntity kullansamda probrem olmaz
    {
        List<T> GetAll();
        List<T> GetActives();
        Task<List<T>> GetActivesAsync();
        List<T> GetPassives();
        List<T> GetModifieds();

        //Modify Commands

        void Add(T item);
        Task AddAsync(T item);
        void AddRange(List<T> list);
        Task AddRangeAsync(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        Task UpdateAsync(T item);
        Task UpdateRangeAsync(List<T> list);
        string Destroy(T item);
        string DestroyRange(List<T> list);

        //Linq Commands
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);

        //Find Command
        Task<T> FindAsync(int id);


    }
}
