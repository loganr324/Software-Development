// Program 4
// CIS 200-01
// Due: 4/19/2017
// By: D3508
//This program is meant to test the IComparable and IComparer interfaces with the library hierarchy from Program 1B

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryItems;


public class Program
{
    // Precondition:  None
    // Postcondition: The LibraryItem hierarchy is sorted using the IComparable and IComparer classes
    public static void Main(string[] args)
    {
        List<LibraryItem> libraryItemList = new List<LibraryItem>(); //List of Library Items

        //Two test objects for each of the 5 concrete classes
        LibraryBook book1 = new LibraryBook("    Celia, A Slave    ", "Avon", 1999, 7, "11111111",
            "Melton A. McLaurin");//Title is surrounded by white space to test trim
        LibraryBook book2 = new LibraryBook("Visual C#: How to Program 6th Edition", "Pearson", 2017, 10, "99999999",
            "Deitel");
        LibraryJournal journal1 = new LibraryJournal("Fake Science Monthly", "Nick", 2002, 5, "22222222", 89, 3,
            "Sea Bears and Fairy Tales", "Patrick Star");
        LibraryJournal journal2 = new LibraryJournal("Real Science Monthly", "NASA", 2016, 14, "88888888", 25, 4,
            "Climatology", "Bill Nye");
        LibraryMagazine magazine1 = new LibraryMagazine("Sports Illustrated", "Time", 2016, 7, "33333333", 49, 10);
        LibraryMagazine magazine2 = new LibraryMagazine("Sports Illustrated", "Time", 2017, 10, "77777777", 50, 11);
        LibraryMovie movie1 = new LibraryMovie("Friday", "NLC", 1995, 7, "44444444", 91.0, "F. Gary Gray",
            LibraryMediaItem.MediaType.DVD, LibraryMovie.MPAARatings.R);
        LibraryMovie movie2 = new LibraryMovie("Captain America: Civil War", "Marvel", 2016, 14, "66666666", 147.0,
            "Anthony Russo", LibraryMediaItem.MediaType.BLURAY, LibraryMovie.MPAARatings.PG13);
        LibraryMusic music1 = new LibraryMusic("Album", "Studio", 2015, 2, "55555555", 27.0, "Singer",
            LibraryMediaItem.MediaType.SACD, 7);
        LibraryMusic music2 = new LibraryMusic("Record", "Older Studio", 1987, 5, "00000000", 18.0, "Older Singer",
            LibraryMediaItem.MediaType.VINYL, 4);

        //Adds each of the objects above to the List
        libraryItemList.Add(book1);
        libraryItemList.Add(book2);
        libraryItemList.Add(journal1);
        libraryItemList.Add(journal2);
        libraryItemList.Add(magazine1);
        libraryItemList.Add(magazine2);
        libraryItemList.Add(movie1);
        libraryItemList.Add(movie2);
        libraryItemList.Add(music1);
        libraryItemList.Add(music2);

        Console.Out.WriteLine("Original List of Library Items:");
        Console.WriteLine();
        foreach (LibraryItem item in libraryItemList) //Writes all items to the console
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
        Pause();

        libraryItemList.Sort(); //Sorts the list in ascending natural order
        Console.WriteLine("Sorted List in ascending natural order): ");
        Console.WriteLine();
        foreach(LibraryItem item in libraryItemList) //Writes all items to the console
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
        Pause();

        libraryItemList.Sort(new DescendingItemOrder()); //Sorts using IComparer class DescendingItemOrder
        Console.WriteLine("Sorted List in descending natural order using IComparer: ");
        Console.WriteLine();
        foreach(LibraryItem item in libraryItemList) //Writes all the items to the console
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
        Pause();
    }

    // Precondition:  None
    // Postcondition: Pauses program execution until user presses Enter and
    //                then clears the screen
    public static void Pause()
    {
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        Console.Clear(); // Clear screen
    }
}