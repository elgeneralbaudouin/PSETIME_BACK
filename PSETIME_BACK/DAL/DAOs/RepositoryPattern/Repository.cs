using Microsoft.EntityFrameworkCore;
using PSETIME_BACK.DAL.Models;
using PSETIME_BACK.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.DAOs.RepositoryPattern
{
    /// <summary>
    /// Implements the generic <see cref="IRepository"/> interface.
    /// </summary>
    /// <typeparam name="T">A class derived from <see cref="BaseEntity" class./></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        //the app context
        private static readonly ApplicationDBContext _ctx = null;


        public static ApplicationDBContext Ctx
        {
            get
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
                return _ctx ?? new ApplicationDBContext(optionsBuilder.Options);
            }
        }

        /// <summary>
        /// Underlying DbSet.
        /// </summary>
        protected DbSet<T> _DbSet;

        /// <summary>
        /// Underlying dbcontext
        /// </summary>
        protected DbContext _DbContext;

        /// <summary>
        /// Underlying queryable
        /// </summary>
        protected IQueryable<T> _Query;

        ///// <summary>
        ///// Injects the DbContext holding DbSet.
        ///// </summary>
        ///// <param name="dataContext"></param>
        public Repository(DbContext dataContext, IQueryable<T> query = null)
        {
            _DbContext = dataContext;
            _DbSet = _DbContext.Set<T>();
            if (query != null)
            {
                _Query = query;
            }
        }

        public void DeleteRange(List<T> entities)
        {
            _DbSet.AddRange(entities);
            foreach (T entity in entities)
                _DbContext.Entry(entity).State = EntityState.Deleted;
            _DbContext.SaveChanges();
        }

        public void DeleteAll()
        {
            List<T> entities = GetAll();
            _DbSet.AddRange(entities);
            foreach (T entity in entities)
                _DbContext.Entry(entity).State = EntityState.Deleted;
            _DbContext.SaveChanges();
        }

        //_________________________________________________________________________________________
        #region IRepository<T> Members

        /// <summary>
        /// Inserts a single entity into the DbSet
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {

            _DbSet.Add(entity);
            _DbContext.Entry(entity).State = EntityState.Added;
            _DbContext.SaveChanges();
        }

        /// <summary>
        /// Inserts Range of entities into the DbSet
        /// </summary>
        /// <param name="entities"></param>
        public void InsertRange(List<T> entities)
        {
            _DbSet.AddRange(entities);
            foreach (T entity in entities)
                _DbContext.Entry(entity).State = EntityState.Added;
            _DbContext.SaveChanges();

        }

        /// <summary>
        /// Returns an entity based on primary key.
        /// </summary>
        /// <param name="id">Primary Key.</param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {

            return _DbSet.Find(id);
        }

        public virtual T GetById(string id)
        {

            return _DbSet.Find(id);
        }

        /// <summary>
        /// Returns an IEnumerable based on the query, order clause and the properties included
        /// </summary>
        /// <param name="query">Link query for filtering.</param>
        /// <param name="orderBy">Link query for sorting.</param>
        /// <param name="includeProperties">Navigation properties seperated by comma for eager loading.</param>
        /// <returns>IEnumerable containing the resulting entity set.</returns>
        public System.Collections.Generic.IEnumerable<T> GetByQuery(Expression<Func<T, bool>> query = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> queryResult = null;
            
            //If there is a query, execute it against the dbset
            if (query != null)
            {
                queryResult = queryResult.Where(query);
            }

            //get the include requests for the navigation properties and add them to the query result
            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                queryResult = queryResult.Include(property);
            }

            //if a sort request is made, order the query accordingly.
            if (orderBy != null)
            {
                return orderBy(queryResult).ToList();
            }
            //if not, return the results as is
            else
            {
                return queryResult.ToList();
            }
        }





        ///order
        public Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderBy(string orderColumn, string orderType)
        {
            Type typeQueryable = typeof(IQueryable<T>);
            ParameterExpression argQueryable = Expression.Parameter(typeQueryable, "p");
            var outerExpression = Expression.Lambda(argQueryable, argQueryable);
            string[] props = orderColumn.Split('.');

            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");

            Expression expr = arg;
            foreach (string prop in props)
            {
                PropertyInfo pi = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            LambdaExpression lambda = Expression.Lambda(expr, arg);
            string methodName = orderType == "asc" ? "OrderBy" : "OrderByDescending";

            MethodCallExpression resultExp =
                Expression.Call(typeof(Queryable), methodName, new Type[] { typeof(T), type }, outerExpression.Body, Expression.Quote(lambda));
            var finalLambda = Expression.Lambda(resultExp, argQueryable);
            return (Func<IQueryable<T>, IOrderedQueryable<T>>)finalLambda.Compile();
        }


        /// <summary>
        /// Returns the first matching entity based on the query.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetFirst(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.First(predicate);
        }

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            if (_DbContext.Entry(entity).State == EntityState.Detached)
            {
                _DbSet.Attach(entity);
            }

            _DbContext.Entry(entity).State = EntityState.Modified;
            _DbContext.SaveChanges();
        }
        public void Detach(T entity)
        {
            _DbContext.Entry(entity).State = EntityState.Detached;
            _DbContext.SaveChanges();

        }

        /// <summary>
        /// Updates an entity by primary key.
        /// </summary>
        /// <param name="id">Primary Key.</param>
        public void UpdateById(int id)
        {
            T entity = _DbSet.Find(id);
            Update(entity);

        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            if (_DbContext.Entry(entity).State == EntityState.Detached)
                _DbSet.Attach(entity);

            _DbSet.Remove(entity);
            _DbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity by primary key.
        /// </summary>
        /// <param name="id">Primary Key.</param>
        public void DeleteByID(int id)
        {
            T entity = _DbSet.Find(id);
            _DbSet.Remove(entity);
        }

        public List<T> GetAll()
        {
            return GetByQuery().ToList<T>();
        }

        public List<T> GetAll(bool active)
        {
            return GetByQuery(t => t.IsActive.Equals(active)).ToList<T>();
        }

        public List<T> WhereUpdated(DateTime date)
        {
            return GetByQuery(t => t.IsActive && t.UpdatedAt.CompareTo(date) > 0).ToList<T>();
        }


        #endregion
    }

}
