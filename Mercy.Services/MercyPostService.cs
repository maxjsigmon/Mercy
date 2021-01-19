using Mercy.Data;
using Mercy.Models;
using Mercy.Models.Mercy_Post;
using Mercy.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercy.Services
{
    public class MercyPostService
    {
        private readonly Guid _userID;

        public MercyPostService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new MercyPost()
                {
                    OwnerID = _userID,
                    Title = model.Title,
                    Description = model.Description,
                    DateOfNeed = model.DateOfNeed,
                    TimeOfNeed = model.TimeOfNeed,
                    WorkOfMercy = model.WorkOfMercy

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPost()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    Title = e.Title,
                                    Description = e.Description,
                                    DateOfNeed = e.DateOfNeed,
                                    TimeOfNeed = e.TimeOfNeed,
                                    WorkOfMercy = e.WorkOfMercy,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public PostDetail GetPostByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostID == id && e.OwnerID == _userID);
                return
                    new PostDetail
                    {
                        OwnerID = entity.OwnerID,
                        PostID = entity.PostID,
                        Description = entity.Description,
                        WorkOfMercy = entity.WorkOfMercy,
                        DateOfNeed = entity.DateOfNeed,
                        TimeOfNeed = entity.TimeOfNeed,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateNote(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostID == model.PostID && e.OwnerID == _userID);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.WorkOfMercy = model.WorkOfMercy;
                entity.DateOfNeed = model.DateOfNeed;
                entity.TimeOfNeed = model.TimeOfNeed;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostID == postID && e.OwnerID == _userID);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
