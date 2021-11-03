using Ketabkhana.Models.EF;
using Ketabkhana.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class BookRepo
    {
        static KetabkhanaEntities db;
        static BookRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static void Add(Book a, string username)
        {
            var s = (from sh in db.Shops
                    where sh.username == username
                    select sh).FirstOrDefault();

            Book b = new Book();
            b = a;
            b.shopId = s.id;

            db.Books.Add(b);
            db.SaveChanges();

        }

        public static Book Get(int id)
        {
            var book = (from b in db.Books
                        where b.id == id
                        select b).FirstOrDefault();

            return book;

        }

        public static List<BookModel> AllBooks()
        {
            var books = new List<BookModel>();

            foreach(var book in db.Books)
            {
                BookModel bm = new BookModel()
                {
                    id = book.id,
                    bookTitle = book.bookTitle,
                    author = book.author,
                    publisher = book.publisher,
                    edition = book.edition,
                    price = book.price,
                    shopId = book.shopId,
                    quantity = book.quantity,
                    thumbnail = book.thumbnail
                };

                books.Add(bm);
            }
            return books;
        }

        public static List<BookModel> SrcBooks(string bt)
        {
            var src = (from b in db.Books
                        where b.bookTitle == bt
                        select b);

            var books = new List<BookModel>();

            foreach (var book in src)
            {
                BookModel bm = new BookModel()
                {
                    id = book.id,
                    bookTitle = book.bookTitle,
                    author = book.author,
                    publisher = book.publisher,
                    edition = book.edition,
                    price = book.price,
                    shopId = book.shopId,
                    quantity = book.quantity,
                    thumbnail = book.thumbnail
                };

                books.Add(bm);
            }
            return books;
        }


        public static List<BookModel> MyBooks(string username)
        {
            var myShop = (from s in db.Shops
                          where s.username == username
                          select s).FirstOrDefault();

            var myBooks = from a in db.Books
                          where a.shopId == myShop.id
                          select a;


            var books = new List<BookModel>();

            foreach (var b in myBooks)
            {
                BookModel bm = new BookModel()
                {
                    id = b.id,
                    bookTitle = b.bookTitle,
                    author = b.author,
                    publisher = b.publisher,
                    edition = b.edition,
                    price = b.price,
                    shopId = b.shopId,
                    quantity = b.quantity,
                    thumbnail = b.thumbnail
                };

                books.Add(bm);
            }
            return books;
        }


        public static void Edit(Book a)
        {
            Book book = (from ad in db.Books
                         where ad.id == a.id
                                 select ad).FirstOrDefault();

            db.Entry(book).CurrentValues.SetValues(a);
            db.SaveChanges();

        }


        public static void Delete(Book a)
        {
            Book book = (from ad in db.Books
                         where ad.id == a.id
                                 select ad).FirstOrDefault();

            db.Books.Remove(book);
            db.SaveChanges();

        }
    }
}