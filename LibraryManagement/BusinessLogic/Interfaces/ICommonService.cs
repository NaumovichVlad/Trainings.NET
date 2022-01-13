using BusinessLogic.Dtos;

namespace BusinessLogic.Interfaces
{
    public interface ICommonService
    {
        public AuthorDto GetMostPopularAuthor();

        public SubscriberDto GetMostReadingSubscriber();

        public GenreDto GetMostPopularGenre();
    }
}
