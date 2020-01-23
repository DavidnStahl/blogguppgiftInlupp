using BloggUppgift.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggUppgift.Models.Interface
{

    public interface IRepository
    {
        void Create(ArchiveBloggViewModel model);
        ArchiveBloggViewModel GetAll();
        ArchiveBloggViewModel GetAllCategories();
        ArchiveBloggViewModel GetBloggDetails(int id);
        ArchiveBloggViewModel BloggsBySearchWord(ArchiveBloggViewModel model);
        ArchiveBloggViewModel BloggsByCategory(ArchiveBloggViewModel model);
        ArchiveBloggViewModel BloggsByCategoryAndSearchWord(ArchiveBloggViewModel model);


    }
}
