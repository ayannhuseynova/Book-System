using BookSystem.ConsoleApp.Structure;
using Helper;
using System;
using System.Linq;
using System.Text;

namespace BookSystem.ConsoleApp
{
    class Program
    {
        enum Gender
        {
            Male,
            Female
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

        lmain:
            int m = MainMenu();

            switch (m)
            {
                case 1: //author menu
                    {
                        Author[] authors = new Author[0];
                        Console.Clear();

                    lauthor:
                        int a = AuthorMenu();

                        switch (a)
                        {
                            case 0:
                                {
                                    Console.Clear();
                                    goto lmain;
                                    break;
                                }
                            case 1: //add author
                                {
                                    Gender MEnum = Gender.Male;
                                    string Male = Convert.ToString(MEnum);

                                    Gender FEnum = Gender.Female;
                                    string Female = Convert.ToString(FEnum);

                                    Console.Clear();
                                    string NewAuthor = Help.ReadText("Type in the name and surname for the new Author: ", 1);
                                    string AuthorCountry = Help.ReadText("Type in the Author's country: ", 3);

                                lgender:
                                    string AuthorGender = Help.ReadText("Type in the Author's gender (Male, Female): ", 3);

                                    if (AuthorGender == Male)
                                    {
                                        AuthorGender = "He";

                                        Array.Resize(ref authors, authors.Length + 1);
                                        authors[authors.Length - 1] = new Author(NewAuthor, AuthorCountry, AuthorGender);

                                        Console.Clear();
                                        goto lauthor;
                                    }
                                    else if (AuthorGender == Female)
                                    {
                                        AuthorGender = "She";

                                        Array.Resize(ref authors, authors.Length + 1);
                                        authors[authors.Length - 1] = new Author(NewAuthor, AuthorCountry, AuthorGender);

                                        Console.Clear();
                                        goto lauthor;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Choose EITHER Male or a Female!");
                                        goto lgender;
                                    }

                                    Console.Clear();
                                    break;
                                }
                            case 2: //edit
                                {
                                    int AuthorID = Help.Read("Author's ID: ");
                                    int IDIndex = Array.FindIndex(authors, a => a.AuthorID == AuthorID);

                                    if (IDIndex == -1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"There is no author in {AuthorID} - th place!");
                                    }
                                    else
                                    {
                                        int Choice = Help.Read("--------------------------------------------- \nWhat do you want to change?\n --------------------------------------------- \n" +
                                            "Name / Surname(Type in 1), \nCounrty(Type in 2), \nGender(Type in 3), \n" +
                                            "Change Everything(Type in 0): ");

                                        switch (Choice)
                                        {
                                            case 1:
                                                {
                                                    string AuthorNS = Help.ReadText("New Name and Surname: ", 1);
                                                    authors[IDIndex].NameSurname = AuthorNS;

                                                    Console.Clear();
                                                    goto lauthor;
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    string AuthorCountry = Help.ReadText("New Country: ", 1);
                                                    authors[IDIndex].Country = AuthorCountry;

                                                    Console.Clear();
                                                    goto lauthor;
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    string AuthorGender = Help.ReadText("New Gender (Male, Female): ", 1);
                                                    authors[IDIndex].Gender = AuthorGender;

                                                    Console.Clear();
                                                    goto lauthor;
                                                    break;
                                                }
                                            case 0:
                                                {
                                                    string AuthorNS = Help.ReadText("New Name and Surname: ", 1);
                                                    authors[IDIndex].NameSurname = AuthorNS;

                                                    string AuthorCountry = Help.ReadText("New Country: ", 1);
                                                    authors[IDIndex].Country = AuthorCountry;

                                                    string AuthorGender = Help.ReadText("New Gender (Male, Female): ", 1);
                                                    authors[IDIndex].Gender = AuthorGender;

                                                    Console.Clear();
                                                    goto lauthor;
                                                    break;
                                                }
                                        }

                                    }
                                    break;
                                }
                            case 3: //delete
                                {
                                    int AuthorID = Help.Read("Enter the number of an author whom you want to remove: ");
                                    int IDIndex = Array.FindIndex(authors, a => a.AuthorID == AuthorID);

                                    if (IDIndex == -1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"There is no author with {AuthorID} number!");
                                    }
                                    else
                                    {
                                        for (int i = IDIndex; i < authors.Length - 1; i++)
                                        {
                                            authors[IDIndex] = authors[IDIndex + 1];
                                            Array.Resize(ref authors, authors.Length - 1);
                                        }
                                    }
                                    Console.Clear();
                                    goto lauthor;

                                    break;
                                }
                            case 4: //selection
                                {
                                    Console.Clear();
                                    foreach (Author author in authors)
                                    {
                                        Console.WriteLine(author);
                                    }
                                    goto lauthor;
                                }
                                break;
                            case 5: //filtering
                                {
                                    int num = 1;
                                    string find = Help.ReadText("Type in the name which is going to get filtered\n" +
                                        "You can filter by | Author Name: ", 1);
                                    foreach (Author author in authors)
                                    {
                                        if (author.NameSurname.StartsWith(find))
                                        {
                                            Console.WriteLine("--------------------------------");
                                            Console.WriteLine(author);
                                            goto lauthor;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{num++}. Not in here!");
                                        }
                                    }

                                    break;
                                }
                        }
                        break;
                    }
                case 2: //book menu
                    {
                        Console.Clear();
                        Book[] books = new Book[0];
                    lbook:
                        int b = BookMenu();

                        switch (b)
                        {
                            case 0: //main menu
                                {
                                    Console.Clear();
                                    goto lmain;
                                    break;
                                }
                            case 1: //add book
                                {
                                    Console.Clear();
                                    string NewBook = Help.ReadText("Enter the name of the Book: ", 2);
                                    string BookAuthor = Help.ReadText("Enter the Author of the book: ", 3);
                                    int BookPage = Help.Read("Enter total count of pages: ");
                                    int BookPrice = Help.Read("Enter the price for this book ");

                                lbarcode:

                                    int BookBarcode = Help.Read("Enter the Barcode (8 digits) of this book: ");

                                    if (BookBarcode.ToString().Length != 8)
                                    {
                                        Console.WriteLine("Barcode can only contain 8 digits. Try again!");
                                        goto lbarcode;
                                    }
                                    else
                                    {
                                        Array.Resize(ref books, books.Length + 1);
                                        books[books.Length - 1] = new Book(NewBook, BookAuthor, BookPage, BookPrice, BookBarcode);
                                    }

                                    Console.Clear();
                                    goto lbook;
                                    break;
                                }
                            case 2: //edit
                                {
                                    int BookNumber = Help.Read("Book ID: ");
                                    int BookID = Array.FindIndex(books, b => b.NumberOnShelf == BookNumber);

                                    if (BookID == -1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"There is not any book on {BookNumber} numbered shelf");
                                    }
                                    else
                                    {
                                        int Choice = Help.Read("-----------------------------\nWhat do you want to change?\n-----------------------------\n" +
                                        "Book Name (Type in 1), \nAuthor (Type in 2), \nPage Count (Type in 3), \nPrice (Type in 4), \nBarcode(Type in 5), \nAll (Type in 0): ");

                                        switch (Choice)
                                        {
                                            case 1:
                                                {
                                                    string BookName = Help.ReadText("Enter the new Name for the Book: ", 2);
                                                    books[BookID].Name = BookName;

                                                    Console.Clear();
                                                    goto lbook;
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    string BookAuthor = Help.ReadText("Enter the new Author for the Book: ", 2);
                                                    books[BookID].Author = BookAuthor;

                                                    Console.Clear();
                                                    goto lbook;
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    int BookPage = Help.Read("Enter the new Page Count for the Book: ");
                                                    books[BookID].PageCount = BookPage;

                                                    Console.Clear();
                                                    goto lbook;
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    int BookPrice = Help.Read("Enter the new Price for the Book: ");
                                                    books[BookID].Price = BookPrice;

                                                    Console.Clear();
                                                    goto lbook;
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    int BookBarcode = Help.Read("Enter the new Barcode for the Book: ");
                                                    books[BookID].Barcode = BookBarcode;

                                                    Console.Clear();
                                                    goto lbook;
                                                    break;
                                                }
                                            case 0:
                                                {
                                                    string BookName = Help.ReadText("Enter the new Name for the Book: ", 2);
                                                    books[BookID].Name = BookName;

                                                    string BookAuthor = Help.ReadText("Enter the new Author for the Book: ", 2);
                                                    books[BookID].Author = BookAuthor;

                                                    int BookPage = Help.Read("Enter the new Page Count for the Book: ");
                                                    books[BookID].PageCount = BookPage;

                                                    int BookPrice = Help.Read("Enter the new Price for the Book: ");
                                                    books[BookID].Price = BookPrice;

                                                    int BookBarcode = Help.Read("Enter the new Barcode for the Book: ");
                                                    books[BookID].Barcode = BookBarcode;

                                                    Console.Clear();
                                                    goto lbook;
                                                    break;
                                                }
                                        }
                                    }
                                    break;
                                }
                            case 3: //delete
                                {
                                    int Number = Help.Read("Enter the Number of the Shelf to Delete the Book: ");
                                    int BookID = Array.FindIndex(books, b => b.NumberOnShelf == Number);

                                    if (BookID == -1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"There is no book on {Number} numbered shelf!");
                                    }
                                    else
                                    {
                                        for (int i = BookID; i < books.Length - 1; i++)
                                        {
                                            books[BookID] = books[BookID + 1];
                                            Array.Resize(ref books, books.Length - 1);
                                        }
                                        Console.Clear();
                                        goto lbook;
                                    }
                                    break;
                                }
                            case 4: //select
                                {
                                    Console.Clear();
                                    foreach (Book book in books)
                                    {
                                        Console.WriteLine(book);
                                    }
                                    goto lbook;
                                }
                                break;
                            case 5: //filter
                                {
                                    int num = 1;
                                    string find = Help.ReadText("Type in the text (or a word) which is going to get filtered\n" +
                                    "You can filter by | Book Name, Author Name: ", 1);
                                    foreach (Book book in books)
                                    {
                                        if (book.Name.StartsWith(find) || book.Author.StartsWith(find))
                                        {
                                            Console.WriteLine("--------------------------------");
                                            Console.WriteLine(book);
                                            goto lbook;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{num++}. Not in here!");
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
            static int MainMenu()
            {
                Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                Console.WriteLine("-----Welcome to the Main Menu-----");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Press one of the following numbers");
                Console.WriteLine("");
                Console.WriteLine("1. Author Menu");
                Console.WriteLine("2. Book Menu");
                Console.WriteLine("");

                int Open = Help.Read("Select one: ");
                Console.WriteLine("");
                return Open;
            }
            static int AuthorMenu()
            {
                Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                Console.WriteLine("-  Author Menu  -");
                Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Select All");
                Console.WriteLine("5. Filter");
                Console.WriteLine("");
                Console.WriteLine("0. Main Menu");
                Console.WriteLine("");

                int Author = Help.Read("Select one: ");
                Console.WriteLine("");
                return Author;
            }
            static int BookMenu()
            {
                Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                Console.WriteLine("-   Book Menu   -");
                Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Select All");
                Console.WriteLine("5. Filter");
                Console.WriteLine("");
                Console.WriteLine("0. Main Menu");
                Console.WriteLine("");

                int Book = Help.Read("Select one: ");
                return Book;
            }
        }
    }
}