using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementTests.DataAccess.Repositories
{
    [TestClass]
    public class RepositoryTests
    {
        private const string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=library;Trusted_Connection=True;";

        [TestMethod]
        public void GenresRepository_GetListTest()
        {
            var genresRepository = new GenresRepository(_connectionString);
            var expected = new List<Genre>()
            {
                new Genre() {Id = 1, Name = "Genre_1"},
                new Genre() {Id = 2, Name = "Genre_2"},
                new Genre() {Id = 3, Name = "Genre_3"},
                new Genre() {Id = 4, Name = "Genre_4"},
                new Genre() {Id = 5, Name = "Genre_5"}
            };
            var actual = genresRepository.GetList();
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        [TestMethod]
        public void GenresRepository_GetByIdTest()
        {
            var genresRepository = new GenresRepository(_connectionString);
            var expected = new Genre() { Id = 2, Name = "Genre_2" };
            var actual = genresRepository.GetById(2);
            Assert.AreEqual(expected.Name, actual.Name);
        }

        [TestMethod]
        public void GenresRepository_CreateTest()
        {
            var genresRepository = new GenresRepository(_connectionString);
            var expected = new Genre() { Name = "Genre_6" };
            genresRepository.Create(expected);
            var actual = genresRepository.GetList().Last();
            Assert.AreEqual(expected.Name, actual.Name);
            genresRepository.Delete(actual.Id);
        }

        [TestMethod]
        public void GenresRepository_UpdateTest()
        {
            var genresRepository = new GenresRepository(_connectionString);
            var genre = genresRepository.GetById(1);
            var expected = new Genre() { Id = 1, Name = "Genre_23" };
            genresRepository.Update(expected);
            var actual = genresRepository.GetById(1);
            Assert.AreEqual(expected.Name, actual.Name);
            genresRepository.Update(genre);
        }

        [TestMethod]
        public void GenresRepository_DeleteTest()
        {
            var genresRepository = new GenresRepository(_connectionString);
            var expected = genresRepository.GetList().Count;
            var genre = new Genre() {Name = "Genre_80" };
            genresRepository.Create(genre);
            genresRepository.Delete(genresRepository.GetList().Last().Id);
            var actual = genresRepository.GetList().Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
