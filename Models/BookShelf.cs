using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf_Blazor.Models
{
    public static class BookShelf
    {
        private static Blazored.LocalStorage.ISyncLocalStorageService localStorage;

        public static List<Book>? books{
            get { return localStorage.GetItem<List<Book>>("Books"); }
        }

        public static bool saveAsFinished(Book book){
            Console.WriteLine("aaaaaaa");
            try{
                var booksOnShelf = BookShelf.books;
                if(booksOnShelf == null){
                    booksOnShelf = new List<Book>();
                }
                if(!book.isOnShelf()){
                    book.DateAddToShelf = DateTime.Now;
                }else{
                    book = booksOnShelf.Single(x=>x.key == book.key);
                }
                book.bookStatus = Enum.BookStatus.Finished;
                book.DateFinished = DateTime.Now;
                booksOnShelf.Add(book);
                localStorage.SetItem("Books", books);
                return true;
            }catch (Exception e){
                throw e;
            }
        }
        public static bool saveAsWish(Book book){
            try{

                if(!book.isOnShelf()){
                    book.DateAddToShelf = DateTime.Now;
                }else{
                    book = books.Single(x=>x.key == book.key);
                }
                book.bookStatus = Enum.BookStatus.Wished;
                books.Add(book);
                localStorage.SetItem("Books", books);
                return true;
            }catch{
                return false;
            }
        }
        public static bool saveAsReading(Book book){
            try{
                if(!book.isOnShelf()){
                    book.DateAddToShelf = DateTime.Now;
                }else{
                    book = books.Single(x=>x.key == book.key);
                }
                book.bookStatus = Enum.BookStatus.Reading;
                books.Add(book);
                localStorage.SetItem("Books", books);
                return true;
            }catch{
                return false;
            }
        }
        public static bool saveAsTBR(Book book){
            try{
                if(!book.isOnShelf()){
                    book.DateAddToShelf = DateTime.Now;
                }else{
                    book = books.Single(x=>x.key == book.key);
                }
                book.bookStatus = Enum.BookStatus.TBR;
                books.Add(book);
                localStorage.SetItem("Books", books);
                return true;
            }catch{
                return false;
            }
        }
    }
}
