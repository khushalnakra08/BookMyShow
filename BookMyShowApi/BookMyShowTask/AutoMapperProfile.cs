using AutoMapper;
using BookMyShowTask.DTO;
using BookMyShowTask.Models;
namespace BookMyShowTask
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<Cinema, CinemaDTO>().ReverseMap();
            CreateMap<CinemaHall, CinemaHallDTO>().ReverseMap();
            CreateMap<CinemaSeat, CinemaSeatDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Seat, SeatDTO>().ReverseMap();
            CreateMap<Show, ShowDTO>().ReverseMap();
            CreateMap<UserDetail, UserDetailDTO>().ReverseMap();
        }
    }
}
