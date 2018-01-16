using Demo.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Demo.Data
{
    public class DemoEfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        public DemoEfRepository()
            : this(new DemoObjectContext())
        {
        }

        public DemoEfRepository(IDbContext context)
        {
            this._context = context;
        }

        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var message = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
            {
                foreach (var error in validationErrors.ValidationErrors)
                {
                    message += string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
                }
            }

            return message;
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    return _entities = _context.Set<T>();
                }

                return _entities;
            }
        }


        public virtual T GetById(object key)
        {
            return this.Entities.Find(key);
        }

        public virtual void Create(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException exc)
            {
                throw new Exception(GetFullErrorText(exc), exc);
            }
        }

        public virtual void Create(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }

                this._context.AutoDetectChangesEnabled = false;

                foreach (var entity in entities)
                {
                    this.Entities.Add(entity);
                }

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException exc)
            {
                throw new Exception(GetFullErrorText(exc), exc);
            }
            finally
            {
                this._context.AutoDetectChangesEnabled = true;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException exc)
            {
                throw new Exception(GetFullErrorText(exc), exc);
            }
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException exc)
            {
                throw new Exception(GetFullErrorText(exc), exc);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException exc)
            {
                throw new Exception(GetFullErrorText(exc), exc);
            }
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }

                this._context.AutoDetectChangesEnabled = false;
                foreach (var entity in entities)
                {
                    this.Entities.Remove(entity);
                }

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException exc)
            {
                throw new Exception(GetFullErrorText(exc), exc);
            }
            finally
            {
                this._context.AutoDetectChangesEnabled = true;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }
    }
}
