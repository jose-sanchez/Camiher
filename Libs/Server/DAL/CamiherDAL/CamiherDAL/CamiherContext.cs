using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.DAL.CamiherDAL
{
    public class CamiherContext : DbContext
    {
        public CamiherContext()
            : base("CamiherDBConnectionString")
        {
            Database.SetInitializer<CamiherContext>(new DropCreateDatabaseIfModelChanges<CamiherContext>());
        }

        public String Connection = String.Empty; 
        public DbSet<ProductsSet> Products { get; set; }
        public DbSet<ProductTranslations> ProductTranslations { get; set; }
        public DbSet<SaleSet> Sales { get; set; }
        public DbSet<ProductImageSet> ProductImages { get; set; }
        public DbSet<ProvidersSet> Providers { get; set; }
        public DbSet<CompradorSet> Compradors { get; set; }
        public DbSet<ClientSet> Clients { get; set; }
        public DbSet<NotificationSet> Notifications { get; set; }
    }

    public class GenericRepository<TEntity> where TEntity : class
    {
        internal CamiherContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(CamiherContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
    public class UnitOfWork : IDisposable
    {

        private readonly CamiherContext _context = new CamiherContext();
        private GenericRepository<ProductsSet> _productRepository;

        public GenericRepository<ProductsSet> ProductRepository
        {
            get
            {

                if (this._productRepository == null)
                {
                    this._productRepository = new GenericRepository<ProductsSet>(_context);
                }
                return _productRepository;
            }
        }

        private GenericRepository<ProductTranslations> _translationRepository;

        public GenericRepository<ProductTranslations> ProductTranslationsRepository
        {
            get
            {

                if (this._translationRepository == null)
                {
                    this._translationRepository = new GenericRepository<ProductTranslations>(_context);
                }
                return _translationRepository;
            }
        }

        private GenericRepository<ProductImageSet> _productImageRepository;

        public GenericRepository<ProductImageSet> ProductImageRepository
        {
            get
            {

                if (this._productImageRepository == null)
                {
                    this._productImageRepository = new GenericRepository<ProductImageSet>(_context);
                }
                return _productImageRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
