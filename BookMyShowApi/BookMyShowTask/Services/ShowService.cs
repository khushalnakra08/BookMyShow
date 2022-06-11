using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class ShowService : IShowService
    {
        private readonly BookMyShowContext Context;
        public IMapper Mapper;
        public ShowService(BookMyShowContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public Show AddShow(Show show)
        {
            if (show != null)
            {
                Context.Show.Add(show);
                Context.SaveChanges();
                return Mapper.Map<Show>(show);
            }
            return null;
        }

        public Show DeleteShow(int id)
        {
            var show = Context.Show.FirstOrDefault(x => x.Id == id);
            Context.Entry(show).State = EntityState.Deleted;
            Context.SaveChanges();
            return Mapper.Map<Show>(show);
        }

        public Show GetShow(int id)
        {
            var show = Context.Show.FirstOrDefault(x => x.Id == id);
            return Mapper.Map<Show>(show);
        }

        public IEnumerable<Show> GetShowByCinemaHallId(int id)
        {
            var show = Context.Show.Where(x => x.CinemaHallId == id).ToList();
            return Mapper.Map<IEnumerable<Show>>(show);
        }

        public IEnumerable<Show> GetShows()
        {
            var show = Context.Show.ToList();
            return Mapper.Map<IEnumerable<Show>>(show);
        }

        public Show UpdateShow(int id, Show show)
        {
            var showData = Context.Show.Where(model => model.Id == id).FirstOrDefault();
            if (showData != null)
            {
                show.Id = id;
                Context.Entry(showData).CurrentValues.SetValues(show);
                Context.SaveChanges();
            }
            return Mapper.Map<Show>(show);
        }
    }
}
