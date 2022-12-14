using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PostRepo : Repo, IRepo<Post, int, Post>
    {
        public Post Add(Post obj)
        {
            db.Posts.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }
        public Post Delete(int id)
        {
            var dbPost = Get(id);
            db.Posts.Remove(dbPost);
            if(db.SaveChanges() > 0)
                return dbPost;
            return null; 
        }

        public List<Post> Get()
        {
            return db.Posts.ToList();
        }

        public Post Get(int id)
        {
            return db.Posts.Find(id);
        }

        public Post Update(Post obj)
        {
            var dbPost = Get(obj.Id);
            db.Entry(dbPost).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }
    }
}
