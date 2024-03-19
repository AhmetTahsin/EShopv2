using AutoMapper;
using EShop.BLL.DTOs.CoreInterfaces;
using EShop.BLL.DTOs.DTOClasesses;
using EShop.BLL.Handlers.ExpressionHandlers;
using EShop.BLL.ManagerServices.Abstracts;
using EShop.DAL.Repositories.Abstracts;
using EShop.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ManagerServices.Concretes
{
    public class BaseManager<T,U> : IManager<T,U> where T : BaseDTO where U : class,IEntity
    {
        //Interfaceler ile iş yaptıgmız için Bu classta IEntity Kullanmamızda sakınca yok !
        protected IRepository<U> _iRep;
        private readonly IMapper _mapper;
        protected BaseManager(IRepository<U> iRep, IMapper mapper)
        {
            _iRep = iRep;
            _mapper = mapper;
        }
        //Test Edildi
        public void Add(T item) //Todo: Özelleştirilecek kontrol mekanizması !!
        {
            //Mapping => DTO

            var entity = _mapper.Map<U>(item); 
            _iRep.Add(entity);
        }

        //Test Edildi
        public async Task AddAsync(T item)
        {
            var entity = _mapper.Map<U>(item);
            await _iRep.AddAsync(entity);
        }

        //Test Edildi
        public void AddRange(List<T> list)
        {
            List<T> values = new List<T>();

            List<U> entityList = _mapper.Map<List<U>>(list);
            _iRep.AddRange(entityList);

        }
        //Test Edildi
        public async Task AddRangeAsync(List<T> list)
        {
            List<U> entityList = _mapper.Map<List<U>>(list);
            await _iRep.AddRangeAsync(entityList);
        }
        //Test Edildi
        public bool Any(Expression<Func<T, bool>> exp) 
        {
            Expression<Func<U, bool>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, U>(exp);
            return _iRep.Any(newExp);
        }
        //Test Edildi
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            Expression<Func<U, bool>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, U>(exp);
            return await _iRep.AnyAsync(newExp);
        }

        public void Delete(T item)
        {

           var entity = _mapper.Map<U>(item);
            
            if (entity.CreatedDate == default)
            {
                return;
            }
            _iRep.Delete(entity);
        }

        public void DeleteRange(List<T> list)
        {
            List<U> entityList = _mapper.Map<List<U>>(list);
            _iRep.DeleteRange(entityList);
        }

        public string Destroy(T item)
        {
            var entity = _mapper.Map<U>(item);
            //İş akısı önemlidir
            if (entity.Status == ENTITIES.Enums.DataStatus.Deleted)
            {
                _iRep.Destroy(entity);
                return "Veri basarıyla yok edildi";
            }

            return $"Veriyi silemezsiniz cünkü {entity.ID} {entity.Status}   pasif degil";

        }

        public string DestroyRange(List<T> list)
        {

            foreach (T item in list) return Destroy(item);

            return "Silme işleminde sorunla karsılasıldı lütfen veri durumunun pasif oldugundan emin olunuz";
        }

        public async Task<T> FindAsync(int id)  //Doğru olmayabilir bak !
        {

            U foundEntity = await _iRep.FindAsync(id);
            return _mapper.Map<T>(foundEntity);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {

            Expression<Func<U, bool>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, U>(exp);
            U foundEntity = _iRep.FirstOrDefault(newExp);
            return _mapper.Map<T>(foundEntity);
        }
        //Test Edildi
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            Expression<Func<U, bool>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, U>(exp);
            U foundEntity = await _iRep.FirstOrDefaultAsync(newExp);
            return _mapper.Map<T>(foundEntity);
        }

        public List<T> GetActives()
        {

            List<U> foundEntities = _iRep.GetActives();
            return _mapper.Map<List<T>>(foundEntities);
        }

        public async Task<List<T>> GetActivesAsync()
        {
            List<U> foundEntities = await _iRep.GetActivesAsync();
            return _mapper.Map<List<T>>(foundEntities);
        }

        public List<T> GetAll()
        {
            List<U> foundEntities =  _iRep.GetAll();
            return _mapper.Map<List<T>>(foundEntities);
        }

        public List<T> GetModifieds()
        {
            List<U> foundEntities =  _iRep.GetModifieds();
            return _mapper.Map<List<T>>(foundEntities);
        }

        public List<T> GetPassives()
        {
            List<U> foundEntities =  _iRep.GetPassives();
            return _mapper.Map<List<T>>(foundEntities);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            Expression<Func<U, object>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, U>(exp);
            return _iRep.Select(newExp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            Expression<Func<U, X >> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, U, X>(exp);
            return _iRep.Select(newExp);

        }

        public async Task UpdateAsync(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            U entity = _mapper.Map<U>(item);
            await _iRep.UpdateAsync(entity);
        }

        public async Task UpdateRangeAsync(List<T> list)
        {
            List<U> foundEntities = _mapper.Map<List<U>>(list);
            await _iRep.UpdateRangeAsync(foundEntities);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            Expression<Func<U, bool>> newExp = ExpressionVisitorHelper.ReplaceVisitor<T, U>(exp);
            List<U> foundEntities = _iRep.Where(newExp);
            return _mapper.Map<List<T>>(foundEntities);
        }
    }
}
