using BloggUppgift.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggUppgift.Models.Interface;

namespace BloggUppgift.Models
{
    public class DBRepository : IRepository
    {
        public ArchiveBloggViewModel GetAllCategories()
        {
            var model = new ArchiveBloggViewModel();
            using (BloggContext db = new BloggContext())
            {
                model.BloggCategories = db.BloggCategories.ToList();
            }
            return model;
        }
        public void Create(ArchiveBloggViewModel model)
        {
            using (BloggContext db = new BloggContext())
            {
                var blogg = new BloggInfo()
                {
                    CategoryId = model.BloggInfo.CategoryId,
                    Date = DateTime.Now,
                    BloggInput = model.BloggInfo.BloggInput,
                    Heading = model.BloggInfo.Heading
                };
                db.BloggInfo.Add(blogg);
                db.SaveChanges();
            }
        }

        public ArchiveBloggViewModel GetAll()
        {
            var model = new ArchiveBloggViewModel();
            using (BloggContext db = new BloggContext())
            {
                model.BloggCategory.BloggInfo = db.BloggInfo.OrderByDescending(r => r.Date).ToList();
            }
            return model;
        }
        public ArchiveBloggViewModel BloggsBySearchWord(ArchiveBloggViewModel model)
        {
            var list = new List<BloggInfo>();
            using (BloggContext db = new BloggContext())
            {
                model.BloggCategory.BloggInfo = db.BloggInfo.Where(r => r.Heading.StartsWith(model.BloggInfo.Heading))
                    .OrderByDescending(r => r.Date).ToList().ToList();
            }

            return model;
        }

        public ArchiveBloggViewModel BloggsByCategory(ArchiveBloggViewModel model)
        {
            
            var list = new List<BloggInfo>();
            using (BloggContext db = new BloggContext())
            {
                model.BloggCategory.BloggInfo = db.BloggInfo.Where(r => r.CategoryId == model.BloggInfo.CategoryId)
                    .OrderByDescending(r => r.Date).ToList()
                    .ToList();
            }
            return model;
            
        }

        public ArchiveBloggViewModel BloggsByCategoryAndSearchWord(ArchiveBloggViewModel model)
        {
            var list = new List<BloggInfo>();
            using (BloggContext db = new BloggContext())
            {
                model.BloggCategory.BloggInfo = db.BloggInfo.Where(r => r.CategoryId == model.BloggInfo.CategoryId)
                    .Where(r => r.Heading.StartsWith(model.BloggInfo.Heading))
                    .OrderByDescending(r => r.Date).ToList()
                    .ToList();
            }
            return model;
        }

        public ArchiveBloggViewModel GetBloggDetails(int id)
        {
            var model = new ArchiveBloggViewModel();
            using (BloggContext db = new BloggContext())
            {
                model.BloggInfo = db.BloggInfo.FirstOrDefault(r => r.Id == id);

            }
            return model;
        }
    }
}
