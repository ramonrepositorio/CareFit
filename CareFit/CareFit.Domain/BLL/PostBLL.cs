using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public enum PostTypes
    {
        PeoplePost = 1,
        TrainningChangePost = 2

    }
    public class PostBLL : BaseBLL
    {
        public List<Repository.PessoaPosts> GetTimelinePosts(long peopleId)
        {
            List<Repository.PessoaPosts> posts = (from pa in _ctx.PessoaAmigos
                                                  join pp in _ctx.PessoaPosts
                                                      on pa.PessoaAmigoId equals pp.PessoaId
                                                  where pa.PessoaId == peopleId
                                                  orderby pp.DataPost descending
                                                  select pp).Take(20).ToList();

            //Include não funciona se mencionado no join mesmo mudando a tabela pp para o from o Include não funciona utilizando o codigo abaixo as propriedades foram carregadas...
            foreach (var post in posts)
            {
                _ctx.Entry(post).Reference("PessoaPostTipos").Load();
                _ctx.Entry(post).Reference("Pessoas").Load();
                _ctx.Entry(post.Pessoas).Reference("Imagens").Load();
            }
            
            var selfPosts = (from pp in _ctx.PessoaPosts.Include("Pessoas").Include("PessoaPostTipos").Include("Pessoas.Imagens")
                             where pp.PessoaId == peopleId                             
                             orderby pp.DataPost descending
                             select pp).Take(10).ToList();


            if (posts != null)
            {
                if (selfPosts != null)
                {
                    posts.AddRange(selfPosts);
                }
            }
            else
            {
                return selfPosts;
            }

            return posts;
        }

        public void Save(Repository.PessoaPosts post)
        {
            if (post.ID == 0)
            {
                _ctx.Entry(post).State = System.Data.EntityState.Added;
            }
            else
            {
                _ctx.PessoaPosts.Attach(post);
                _ctx.Entry(post).State = System.Data.EntityState.Modified;
            }
            _ctx.SaveChanges();
        }
    }
}
