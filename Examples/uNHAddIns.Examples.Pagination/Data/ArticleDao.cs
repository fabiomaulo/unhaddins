using System;
using System.Collections.Generic;
using Entities;
using uNhAddIns.NH;
using uNhAddIns.NH.Impl;
using uNhAddIns.Pagination;

namespace Data
{
    public class ArticleDao : AbstractNHibernateDao<Article, Guid>
    {
        public Paginator<Article> GetPaginatorAll()
        {
            return GetPaginator(GetArticleAllQuery());
        }

        public Paginator<Article> GetPaginatorByName(string articleName)
        {
            return GetPaginator(GetArticleNameQuery(articleName));
        }

        public IDetachedQuery GetArticleNameQuery(string articleName)
        {
            DetachedNamedQuery dnq = new DetachedNamedQuery("AllArticlesByName");
            dnq.SetString("value", articleName);
            return dnq;
        }

        public IDetachedQuery GetArticleAllQuery()
        {
            return new DetachedNamedQuery("AllArticles");
        }
    }
}