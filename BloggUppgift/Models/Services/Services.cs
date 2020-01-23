using BloggUppgift.Models.Interface;
using BloggUppgift.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggUppgift.Models.Services
{
    public class Services
    {
        private static Services instance = null;
        private static readonly Object padlock = new Object();
        private IRepository _repository;

        public static Services Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Services();
                        instance._repository = new DBRepository();
                    }
                    return instance;
                    
                }
            }
        }
       
        public Services()
        {
        }
        public void CreateNewBlogg(ArchiveBloggViewModel model)
        {
            _repository.Create(model);
        }

        public ArchiveBloggViewModel GetAll()
        {
            return _repository.GetAll();
        }
        public ArchiveBloggViewModel GetAllCategories()
        {
            return _repository.GetAllCategories();
        }
        public ArchiveBloggViewModel GetBloggs(ArchiveBloggViewModel model)
        {
            if ((model.BloggInfo.CategoryId == 4 || model.BloggInfo.CategoryId == 0) && model.BloggInfo.Heading == null)
            {
                return _repository.GetAll();
            }
            else if ((model.BloggInfo.CategoryId == 0 || model.BloggInfo.CategoryId == 4) && model.BloggInfo.Heading != null)
            {
                return _repository.BloggsBySearchWord(model);
            }
            else if (model.BloggInfo.CategoryId != 4 && model.BloggInfo.CategoryId != 0 && model.BloggInfo.Heading == null)
            {
                return _repository.BloggsByCategory(model);
            }
            else if (model.BloggInfo.CategoryId != 4 && model.BloggInfo.CategoryId != 0 && model.BloggInfo.Heading != null)
            {
                return _repository.BloggsByCategoryAndSearchWord(model);
            }
            return model;
        }

        public ArchiveBloggViewModel GetBloggDetails(int id)
        {
            return _repository.GetBloggDetails(id);
        }
        
    }
}

