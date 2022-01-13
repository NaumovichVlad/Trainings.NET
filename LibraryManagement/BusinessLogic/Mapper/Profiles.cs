using AutoMapper;
using BusinessLogic.Dtos;
using DataAccess.Models;

namespace BusinessLogic.Mapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<BooksInOrder, BooksInOrderDto>().ReverseMap();
            CreateMap<EntityBase, EntityBaseDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Subscriber, SubscriberDto>().ReverseMap();
        }
    }
}
