using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Reports.Models;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CommonService
    {
        private readonly IRepository<Book> _booksRepository;
        private readonly IRepository<Subscriber> _subscribersRepository;
        private readonly IRepository<Order> _ordersRepository;
        private readonly IRepository<BooksInOrder> _booksInOrdersRepository;
        private readonly IRepository<Author> _authorsRepository;
        private readonly IRepository<Genre> _genresRepository;
        private readonly IMapper _mapper;
        public CommonService(IRepository<Book> booksRepository, IRepository<Subscriber> subscribersRepository, 
            IRepository<Order> ordersRepository, IRepository<BooksInOrder> booksInOrdersRepository,
            IRepository<Author> authorsRepository, IRepository<Genre> genresRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _subscribersRepository = subscribersRepository;
            _booksInOrdersRepository = booksInOrdersRepository;
            _ordersRepository = ordersRepository;
            _authorsRepository = authorsRepository;
            _genresRepository = genresRepository;
            _mapper = mapper;
        }

        public List<BookReportModel> OrdersByBooksCount()
        {
            var ordersByBooksCount = _booksInOrdersRepository.GetList().GroupBy(o => o.BookId).Select(g => new BookReportModel
            {
                Book = _mapper.Map<BookDto>(_booksRepository.GetById(g.Key)),
                Count = g.Count()
            }).ToList();
            return ordersByBooksCount;
        }
        public AuthorDto GetMostPopularAuthor()
        {
            var ordersGroup = _mapper.Map<List<BooksInOrderDto>>(_booksInOrdersRepository.GetList()).GroupBy(o => o.BookId);
            var books = ordersGroup.Select(g => _mapper.Map<BookDto>(_booksRepository.GetById(g.Key)));
            var authorsGroup = ordersGroup.Join(books, g => g.Key, b => b.Id, (g, b) => new { AuthorId = b.AuthorId, Count = g.Count() })
                .GroupBy(g => g.AuthorId).Select(g => new { AuthorId = g.Key, Count = g.Select(p => p.Count).Sum() });
            var maxCount = authorsGroup.Max(a => a.Count);
            return _mapper.Map<AuthorDto>(_authorsRepository.GetById(authorsGroup.First(a => a.Count == maxCount).AuthorId));
        }

        public SubscriberDto GetMostReadingSubscriber()
        {
            var ordersGroup = _booksInOrdersRepository.GetList().GroupBy(o => o.OrderId);
            var orders = ordersGroup.Select(g => _ordersRepository.GetById(g.Key));
            var subscribersGroup = ordersGroup.Join(orders, g => g.Key, o => o.Id, (g, o) => new { SubscriberId = o.SubscriberId, Count = g.Count() })
                .GroupBy(g => g.SubscriberId).Select(g => new { SubscriberId = g.Key, Count = g.Select(s => s.Count).Sum() });
            var maxCount = subscribersGroup.Max(s => s.Count);
            return _mapper.Map<SubscriberDto>(_subscribersRepository.GetById(subscribersGroup.First(s => s.Count == maxCount).SubscriberId));
        }

        public GenreDto GetMostPopularGenre()
        {
            var ordersGroup = _booksInOrdersRepository.GetList().GroupBy(o => o.BookId);
            var books = ordersGroup.Select(g => _booksRepository.GetById(g.Key));
            var genresGroup = ordersGroup.Join(books, g => g.Key, b => b.Id, (g, b) => new { GenreId = b.GenreId, Count = g.Count() })
                .GroupBy(g => g.GenreId).Select(g => new { GenreId = g.Key, Count = g.Select(p => p.Count).Sum() });
            var maxCount = genresGroup.Max(g => g.Count);
            return _mapper.Map<GenreDto>(_genresRepository.GetById(genresGroup.First(g => g.Count == maxCount).GenreId));
        }
    }
}
