using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using EntityState = System.Data.Entity.EntityState;

namespace WEBCAMIHER.Models
{
    //public enum order { one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 9 };

    /// <summary>
    /// Métodos genéricos para todos los repositorios
    /// </summary>
    
    public interface IContentRepository
    {
        List<Content> getContents(string section);
        List<Picture> getPicture(string Id);
        Content addContent(string section, string title, string text);

        void AmendContent(string contentID, string title, string text);
        void addPicture(Picture picture);

    }
    //public class ContentModel:IContentRepository
    //{
    //   public List<Content> getContents(string section)
    //    {
            
    //        using (DAL dal = new DAL())
    //        {
    //            return dal.DBContent.Where(S => S.Section.Contains(section)).OrderBy(S=>S.Order).ToList();
    //        }

    //    }
    //   public List<Picture> getPicture(string Id) 
    //    {
           
    //        using (DAL dal = new DAL())
    //        {
    //            return dal.DBPicture.Where(S => S.Content_Id.Contains(Id)).ToList();
    //        }
    //    }
    //   public Content addContent(string section,string title , string text)
    //   {
    //       RamdomID c = new RamdomID();
           
    //       Content newcontent = new Content();
    //       newcontent.Id = c.RandomString(8);
    //       newcontent.Section = section;
    //       newcontent.Title = title;
    //       newcontent.Text = text;
           
    //       using (DAL dal = new DAL())
    //       {
    //           if (dal.DBContent != null)
    //           {
    //               newcontent.Order = dal.DBContent.Where(S => S.Section.Contains(section)).Count();

    //           }
    //           else newcontent.Order = 0;
    //           dal.DBContent.Add(newcontent);
    //           dal.SaveChanges();
    //       }
    //       return newcontent;
    //   }
    //   public void AmendContent(string contentID, string title, string text)
    //   {
    //       //using (DAL dal = new DAL())
    //       //{
    //       //    Content editContent;
    //       //    editContent = dal.DBContent.Single(S => S.Id.Contains(contentID));
    //       //    editContent.Title = title;
    //       //    editContent.Text = text;
    //       //    dal.SaveChanges();
   
    //       //}
    //   }
    //   public void addPicture(Picture picture)
    //   {
    //       //using (DAL dal = new DAL())
    //       //{

    //       //    dal.DBPicture.Add(picture);
    //       //    dal.SaveChanges();

    //       //}
    //   }

    //}
    public class CamiherContex:DbContext
        
    {
        public DbSet<Content> DBContent { get; set; }
        public DbSet<Picture> DBPicture{get; set;}

        public CamiherContex()
            : base("myConnName")
        {
 
            
        }

        
    
    }

    public class Content {

        [Key]
        [Required]
        public string Id { get; set; }
        public string Section { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        private int order { get; set; }
        public int Order { get { return order; } set { order = value; Class = getClassNameByOrder(value); } }

        public string Class { get; set; }
        private string getClassNameByOrder(int order)
        {
            string[] classes = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
            return classes[order];
        }
    }

    public class Picture
    {

        [Key]
        [Required]
        public string Id { get; set; }
        public string Content_Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ImageMimeType { get; set; }
        public byte[] ImageData { get; set; }

    }
    class RamdomID
    {
        public string RandomString(int length, string allowedChars = "ABCDEFZ0123456789")
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

            const int byteSize = 0x100;
            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
            if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

            // Guid.NewGuid and System.Random are not particularly random. By using a
            // cryptographically-secure random number generator, the caller is always
            // protected, regardless of use.
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        // Divide the byte into allowedCharSet-sized groups. If the
                        // random value falls into the last group and the last group is
                        // too small to choose from the entire allowedCharSet, ignore
                        // the value in order to avoid biasing the result.
                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                    }
                }
                return result.ToString();
            }
        }
    }
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal CamiherContex context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(CamiherContex context)
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
        private String[] Pages = { "","Nuestros Servicios", "Viviendas","Contacto","Maquinaria" };
        public String[] pages
        {
            get { return Pages; }
            set { Pages = value; }
        }

        private CamiherContex context = new CamiherContex();
        private GenericRepository<Content> contentRepository;
        private GenericRepository<Picture> pictureRepository;

        public GenericRepository<Content> ContentRepository
        {
            get
            {

                if (this.contentRepository == null)
                {
                    this.contentRepository = new GenericRepository<Content>(context);
                }
                return contentRepository;
            }
        }

        public GenericRepository<Picture> PictureRepository
        {
            get
            {

                if (this.pictureRepository == null)
                {
                    this.pictureRepository = new GenericRepository<Picture>(context);
                }
                return pictureRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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