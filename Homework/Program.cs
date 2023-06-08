/*

 * ЗАДАНИЕ 1
Ранее в одном из практических заданий вы создавали класс «Журнал». 
Добавьте к уже созданному классу информацию о количестве сотрудников. 
Выполните перегрузку:
+ (для увеличения количества сотрудников на указанную величину), 
— (для уменьшения количества сотрудников на указанную величину), 
== (проверка на равенство количества сотрудников), 
< и > (проверка на меньше или больше количества сотрудников), 
!= и Equals. 
Используйте механизм свойств для полей класса.


 * ЗАДАНИЕ 2
Ранее в одном из практических заданий вы создавали класс «Магазин». 
Добавьте к уже созданному классу информацию о площади магазина. 
Выполните перегрузку: 
+ (для увеличения площади магазина на указанную величину), 
— (для уменьшения площади магазина на указанную величину), 
== (проверка на равенство площадей магазинов), 
< и > (проверка на меньше или больше площади магазина), 
!= и Equals. 
Используйте механизм свойств для полей класса.


 * ЗАДАНИЕ 3
Создайте приложение «Список книг для прочтения». 
Приложение должно позволять добавлять книги в список, удалять книги из списка, проверять есть ли книга в списке, и т. д. 
Используйте механизм свойств, перегрузки операторов, индексаторов.
 
 
 */


using System;
using System.Runtime.CompilerServices;
using static Homework.Program;

namespace Homework
{
    internal class Program
    {
        /* ЗАДАНИЕ 1
        Ранее в одном из практических заданий вы создавали класс «Журнал». 
        Добавьте к уже созданному классу информацию о количестве сотрудников. 
        Выполните перегрузку:
        + (для увеличения количества сотрудников на указанную величину), 
        — (для уменьшения количества сотрудников на указанную величину), 
        == (проверка на равенство количества сотрудников), 
        < и > (проверка на меньше или больше количества сотрудников), 
        != и Equals. 
        Используйте механизм свойств для полей класса. */

        public class Journal
        {
            private string name;
            private DateOnly dateFoundation;
            private string description;
            private int telephone;
            private string email;

            public ushort employeesNum { get; set; }


            public Journal() : this("new journal", DateOnly.MinValue, "just new journal", 100000, "newjournal@email.com", 0) { }
            public Journal(string name, DateOnly dateFoundation, string description, int telephone, string email, ushort employeesNum)
            {
                this.name = name;
                this.dateFoundation = dateFoundation;
                this.description = description;
                this.telephone = telephone;
                this.email = email;

                this.employeesNum = employeesNum;
            }


            // ОПЕРАТОР+
            public static Journal operator+ (Journal j, ushort num)
            {
                return new Journal(j.name, j.dateFoundation, j.description, j.telephone, j.email, (ushort) (j.employeesNum + num)); // не понял прикола, почему без (ushort) ошибку выдаёт
            }

            // ОПЕРАТОР-
            public static Journal operator -(Journal j, ushort num)
            {
                try
                {
                    if (j.employeesNum < num)
                    {
                        throw new OverflowException("ОШИБКА: сотрудников не может быть меньше нуля!");
                    }
                    j.employeesNum -= num;
                }

                catch (OverflowException oe)
                {
                    Console.Write(oe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return new Journal(j.name, j.dateFoundation, j.description, j.telephone, j.email, j.employeesNum);
            }

            // ОПЕРАТОР==
            public static bool operator ==(Journal firstJ, Journal secondJ)
            {
                return firstJ.employeesNum == secondJ.employeesNum;
            }

            // ОПЕРАТОР!=
            public static bool operator !=(Journal firstJ, Journal secondJ)
            {
                return firstJ.employeesNum != secondJ.employeesNum;
            }

            // ОПЕРАТОР<
            public static bool operator <(Journal firstJ, Journal secondJ)
            {
                return firstJ.employeesNum < secondJ.employeesNum;
            }

            // ОПЕРАТОР>
            public static bool operator >(Journal firstJ, Journal secondJ)
            {
                return firstJ.employeesNum > secondJ.employeesNum;
            }

            // EQUALS
            public static bool Equals(Journal firstJ, Journal secondJ)
            {
                return firstJ.employeesNum == secondJ.employeesNum;
            }


            public override string ToString()
            {
                return $"Название: {this.name}\n" +
                    $"Год основания: {this.dateFoundation}\n" +
                    $"Описание: {this.description}\n" +
                    $"Номер телефона: {this.telephone}\n" +
                    $"Электронная почта: {this.email}\n" +
                    $"Кол-во сотрудников: {this.email}";
            }  


        }


        /* ЗАДАНИЕ 2
        Ранее в одном из практических заданий вы создавали класс «Магазин». 
        Добавьте к уже созданному классу информацию о площади магазина. 
        Выполните перегрузку: 
        + (для увеличения площади магазина на указанную величину), 
        — (для уменьшения площади магазина на указанную величину), 
        == (проверка на равенство площадей магазинов), 
        < и > (проверка на меньше или больше площади магазина), 
        != и Equals. 
        Используйте механизм свойств для полей класса. */

        public class Shop
        {
            private string name;
            private string address;
            private string description;
            private int telephone;
            private string email;

            public float area { get; set; }

            public Shop() : this("new shop", "city, st. street, 00", "just new shop", 111000, "newshop@email.com", 0) { }
            public Shop(string name, string address, string description, int telephone, string email, float area)
            {
                this.name = name;
                this.address = address;
                this.description = description;
                this.telephone = telephone;
                this.email = email;

                this.area = area;
            }


            // ОПЕРАТОР+
            public static Shop operator +(Shop j, ushort num)
            {
                return new Shop(j.name, j.address, j.description, j.telephone, j.email, (ushort)(j.area + num)); // не понял прикола, почему без (ushort) ошибку выдаёт
            }

            // ОПЕРАТОР-
            public static Shop operator -(Shop s, ushort num)
            {
                try
                {
                    if (s.area < num)
                    {
                        throw new OverflowException("ОШИБКА: площадь не может быть меньше нуля! ");
                    }
                    s.area -= num;
                }

                catch (OverflowException oe) 
                { 
                    Console.Write(oe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return new Shop(s.name, s.address, s.description, s.telephone, s.email, s.area);
            }

            // ОПЕРАТОР==
            public static bool operator ==(Shop firstS, Shop secondS)
            {
                return firstS.area == secondS.area;
            }

            // ОПЕРАТОР!=
            public static bool operator !=(Shop firstS, Shop secondS)
            {
                return firstS.area != secondS.area;
            }

            // ОПЕРАТОР<
            public static bool operator <(Shop firstS, Shop secondS)
            {
                return firstS.area < secondS.area;
            }

            // ОПЕРАТОР>
            public static bool operator >(Shop firstS, Shop secondS)
            {
                return firstS.area > secondS.area;
            }

            // EQUALS
            public static bool Equals(Shop firstS, Shop secondS)
            {
                return firstS.area == secondS.area;
            }


            public override string ToString()
            {
                return $"Название: {this.name}\n" +
                    $"Адрес: {this.address}\n" +
                    $"Описание: {this.description}\n" +
                    $"Номер телефона: {this.telephone}\n" +
                    $"Электронная почта: {this.email}\n" +
                    $"Площадь: {this.area}";
            }
        }




        /* ЗАДАНИЕ 3
        Создайте приложение «Список книг для прочтения». 
        Приложение должно позволять добавлять книги в список, удалять книги из списка, проверять есть ли книга в списке, и т. д. 
        Используйте механизм свойств, перегрузки операторов, индексаторов. */

        public class Book
        {
            private string title; // название книги

            public Book(string title)
            {
                this.title = title;
            }

            public override bool Equals(object obj)
            {
                if (obj != null)
                {
                    if (obj is Book) 
                    { 
                        return this.title == obj.ToString();
                    }

                    if (obj is string)
                    {
                        return this.title == obj as string;
                    }
                }
                throw new ArgumentException();
            }

            public override string ToString()
            {
                return this.title;
            }
        }


        public class ListOfBooks
        {
            private uint length;
            private Book[] books;

            public ListOfBooks()
            {
                this.length = 0;
                this.books = null;
            }

            public ListOfBooks(uint length, Book[] books)
            {
                this.length = length;
                this.books = books;
            }

            public static ListOfBooks operator+ (ListOfBooks lb, Book b)
            {
                try
                {
                    if (!lb.Equals(b))
                    {
                        Book[] newBooks = new Book[lb.length + 1];
                        for (int i = 0; i < lb.length; ++i)
                        {
                            newBooks[i] = lb.books[i];
                        }
                        newBooks[lb.length] = b;

                        return new ListOfBooks((uint) newBooks.Length, newBooks);
                    }

                    throw new Exception($"ОШИБКА: книга \"{b}\" уже находится в списке!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return lb;
                }
            }


            public static ListOfBooks operator- (ListOfBooks lb, Book b)
            {
                try
                {
                    if (lb.Equals(b))
                    {
                        Book[] newBooks = new Book[lb.length - 1];
                        for (int i = 0, j = 0; i < lb.books.Length; ++i)
                        {
                            //Console.Write($"{lb.books[i]}");
                            if (!lb.books[i].Equals(b))
                            {
                                //Console.WriteLine($" != {b}");
                                newBooks[j] = lb.books[i];
                                ++j;
                            }
                        }
                        return new ListOfBooks((uint) newBooks.Length, newBooks);
                    }

                    throw new Exception($"ОШИБКА: книги \"{b}\" нет в списке!");
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return lb;
                }
            }


            public override bool Equals(object obj)
            {
                if (obj != null)
                {
                    if (obj is ListOfBooks)
                    {
                        ListOfBooks lb = obj as ListOfBooks;
                        if (lb.length == this.length)
                        {
                            for (int i = 0; i < this.length - 1; ++i)
                            {
                                if (this.books[i] == lb.books[i])
                                {
                                    return true;
                                }
                            }
                        }
                    }

                    if (obj is Book)
                    {
                        Book book = obj as Book;
                        foreach (Book b in this.books)
                        {
                            if (b.Equals(book))
                            {
                                return true;
                            }
                        }
                    }

                    if (obj is string)
                    {
                        string title = obj as string;
                        foreach (Book b in this.books)
                        {
                            if (b.Equals(title))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            public void Print()
            {
                if (this.books.Length > 0)
                {
                    for (int i = 0; i < this.length; ++i)
                    {
                        Console.WriteLine($"{i + 1}. {this.books[i]}");
                    }
                    return;
                }
                Console.WriteLine("Список книг пуст!");
            }
        }


        static void Main(string[] args)
        {
            // ЗАДАНИЕ 1
            //Journal firstJournal = new Journal("Перыый Журнал", new DateOnly(2001, 11, 1), "Просто перый журнал" , 111111 , "firstJournal@ebox.net", 20);
            //Journal secondJournal = new Journal("Второй Журнал", new DateOnly(2001, 12, 1), "Просто второй журнал", 222222, "secondJournal@ebox.net", 40);

            ////Console.WriteLine($"ПЕРВЫЙ ЖУРНАЛ: \n{firstJournal}\n");
            ////Console.WriteLine($"ВТОРОЙ ЖУРНАЛ: \n{secondJournal}\n");


            //Console.WriteLine($"Журнал ({firstJournal.employeesNum}) + 2: {(firstJournal + 2).employeesNum}");
            //Console.WriteLine($"Журнал ({firstJournal.employeesNum}) - 3: {(firstJournal - 3).employeesNum}");
            //Console.WriteLine($"Журнал ({firstJournal.employeesNum}) - 100: {(firstJournal - 100).employeesNum}\n");

            //Console.WriteLine($"Первый журнал ({firstJournal.employeesNum}) == Второй журнал ({secondJournal.employeesNum}): {firstJournal == secondJournal}");
            //Console.WriteLine($"Первый журнал ({firstJournal.employeesNum}) != Второй журнал({secondJournal.employeesNum}): {firstJournal != secondJournal}\n");

            //Console.WriteLine($"Первый журнал ({firstJournal.employeesNum}) < Второй журнал ({secondJournal.employeesNum}): {firstJournal < secondJournal}");
            //Console.WriteLine($"Первый журнал ({firstJournal.employeesNum}) > Второй журнал ({secondJournal.employeesNum}): {firstJournal > secondJournal}\n");

            //Console.WriteLine($"Первый журнал ({firstJournal.employeesNum}).Equals(Второй журнал ({secondJournal.employeesNum})): {firstJournal.Equals(secondJournal)}\n\n\n");



            // ЗАДАНИЕ 2
            //Shop firstShop = new Shop("Перыый Магазин", "FirstCity, st. FirstStreet, 1", "Просто перый магазин", 111111, "firstShop@ebox.net", 15);
            //Shop secondShop = new Shop("Второй Магазин", "SecondCity, st. SecondStreet, 2", "Просто второй магазин", 222222, "secondShop@ebox.net", 8);

            ////Console.WriteLine($"ПЕРВЫЙ МАГАЗНИ: \n{firstShop}\n");
            ////Console.WriteLine($"ВТОРОЙ МАГАЗИН: \n{secondShop}\n");


            //Console.WriteLine($"Магазин ({firstShop.area}) + 5: {(firstShop + 5).area}");
            //Console.WriteLine($"Магазин ({firstShop.area}) - 15: {(firstShop - 15).area}");
            //Console.WriteLine($"Магазин ({firstShop.area}) - 7: {(firstShop - 7).area}\n");

            //Console.WriteLine($"Первый магазин ({firstShop.area}) == Второй магазин ({secondShop.area}): {firstShop == secondShop}");
            //Console.WriteLine($"Первый магазин ({firstShop.area}) != Второй магазин ({secondShop.area}): {firstShop != secondShop}\n");

            //Console.WriteLine($"Первый магазин ({firstShop.area}) < Второй магазин ({secondShop.area}): {firstShop < secondShop}");
            //Console.WriteLine($"Первый магазин ({firstShop.area}) > Второй магазин ({secondShop.area}): {firstShop > secondShop}\n");

            //Console.WriteLine($"Первый магазин ({firstShop.area}).Equals(Второй магазин ({secondShop.area})): {firstShop.Equals(secondShop)}\n\n\n");



            // ЗАДАНИЕ 3
            Book firstBook = new Book("FirstBook");
            Book secondBook = new Book("SecondBook");
            Book thirdBook = new Book("ThirdBook");

            ListOfBooks listOfBooks = new ListOfBooks(3, new Book[] { firstBook, secondBook, thirdBook });

            Console.WriteLine("ИСХОДНЫЙ СПИСОК КНИГ: "); listOfBooks.Print(); Console.WriteLine();


            // оператор +
            listOfBooks += new Book("FourthBook");
            listOfBooks += new Book("FirstBook"); // попытка добавить книгу, которая уже есть в списке
            Console.WriteLine("СПИСОК КНИГ + FourthBook: "); listOfBooks.Print(); Console.WriteLine();


            // оператор -
            listOfBooks -= new Book("FirstBook");
            listOfBooks -= new Book("Book"); // попытка удалить книгу, которой нет в списке
            Console.WriteLine("СПИСОК КНИГ - FirstBook: "); listOfBooks.Print(); Console.WriteLine();

            //listOfBooks -= new Book("SecondBook");
            //Console.WriteLine("СПИСОК КНИГ - SecondBook: "); listOfBooks.Print(); Console.WriteLine();

            //listOfBooks -= new Book("ThirdBook");
            //Console.WriteLine("СПИСОК КНИГ - ThirdBook: "); listOfBooks.Print(); Console.WriteLine();

            //listOfBooks -= new Book("FourthBook");
            //Console.WriteLine("СПИСОК КНИГ - FourthBook: "); listOfBooks.Print(); Console.WriteLine();


            // оператор Equals
            Console.WriteLine(listOfBooks.Equals("Book") == true ? "Книга есть в списке." : "Книги нет в списке.");
            Console.WriteLine(listOfBooks.Equals(new Book("FirstBook")) == true ? "Книга есть в списке." : "Книги нет в списке.");
            Console.WriteLine(listOfBooks.Equals("SecondBook") == true ? "Книга есть в списке." : "Книги нет в списке.");
            Console.WriteLine(listOfBooks.Equals(new Book("ThirdBook")) == true ? "Книга есть в списке." : "Книги нет в списке.");
            Console.WriteLine(listOfBooks.Equals("FourthBook") == true ? "Книга есть в списке." : "Книги нет в списке.");




        }
    }
}