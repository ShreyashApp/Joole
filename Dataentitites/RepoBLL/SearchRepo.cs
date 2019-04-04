using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dataentitites;
using JooleRepo;
using System.Data.Entity;

namespace RepoBLL
{

    public class SearchRepo : ISearchtblCategory, ISearchtblSubCategory
    {

        DbContext Context;

        public SearchRepo(DbContext context)
        {
            this.Context = context;
        }

        private List<tblCategory> CategoriesList => Context.Set<tblCategory>().ToList();
        private List<tblSubCategory> subCategoriesList => Context.Set<tblSubCategory>().ToList();
        public IEnumerable<tblCategory> find(tblCategory v)
        {
            var filteredList = CategoriesList.Where(current => current.Category_Name == v.Category_Name);
            return filteredList;
        }

        public IEnumerable<tblSubCategory> find(tblSubCategory v)
        {
            var filteredList = subCategoriesList.Where(current => current.SubCategory_Name == v.SubCategory_Name);
            return filteredList;
        }

        public void remove(tblCategory entity)
        {
            throw new NotImplementedException();
        }

        public void remove(tblSubCategory entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblCategory> GetList()
        {
            return CategoriesList;
        }

        IEnumerable<tblSubCategory> ISearchtblSubCategory.GetList()
        {
            return subCategoriesList;
        }
    }
}