using System.Collections.Generic;
using Data;
using Entities;
using uNhAddIns.Pagination;

namespace Services
{
    public class ArticleServices
    {
        private ArticleDao repo = new ArticleDao();

        public Paginator<Article> GetPaginatorAll()
        {
           return  repo.GetPaginatorAll();
        }

        public Paginator<Article> GetPaginatorBy(string name)
        {
            return repo.GetPaginatorByName(name);
        }
    }
}
