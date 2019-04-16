// Program 0
// Starting Point

// File: LibraryBook.cs
// This file creates a simple LibraryBook class capable of tracking
// the book's title, author, publisher, copyright year, call number,
// and checked out status.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class LibraryBook
{
    public const int DEFAULT_YEAR = 2016; // Default copyright year

    private string _title;      // The book's title
    private string _author;     // The book's author
    private string _publisher;  // The book's publisher
    private int _copyrightYear; // The book's year of copyright
    private string _callNumber; // The book's call number in the library
    private bool _checkedOut;   // The book's checked out status

    // Precondition:  theCopyrightYear >= 0
    // Postcondition: The library book has been initialized with the specified
    //                values for title, author, publisher, copyright year, and
    //                call number. The book is not checked out.
    public LibraryBook(string theTitle, string theAuthor, string thePublisher,
        int theCopyrightYear, string theCallNumber)
    {
        Title = theTitle;
        Author = theAuthor;
        Publisher = thePublisher;
        CopyrightYear = theCopyrightYear;
        CallNumber = theCallNumber;

        ReturnToShelf(); // Make sure book is not checked out
    }

    public string Title
    {
        // Precondition:  None
        // Postcondition: The title has been returned
        get
        {
            return _title;
        }

        // Precondition:  None
        // Postcondition: The title has been set to the specified value
        set
        {
            if (string.IsNullOrEmpty(value.Trim())) //Validation to check if the trimmed value is null or empty
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, "A title must be entered"); //Throws an exception if the passed argument is null or empty
            }

            _title = value.Trim(); //Assigns the value to _title
        }
    }

    public string Author
    {
        // Precondition:  None
        // Postcondition: The author has been returned
        get
        {
            return _author;
        }

        // Precondition:  None
        // Postcondition: The author has been set to the specified value
        set
        {
            _author = value;
        }
    }

    public string Publisher
    {
        // Precondition:  None
        // Postcondition: The publisher has been returned
        get
        {
            return _publisher;
        }

        // Precondition:  None
        // Postcondition: The publisher has been set to the specified value
        set
        {
            _publisher = value;
        }
    }

    public int CopyrightYear
    {
        // Precondition:  None
        // Postcondition: The copyright year has been returned
        get
        {
            return _copyrightYear;
        }

        // Precondition:  value >= 0
        // Postcondition: The copyright year has been set to the specified value
        set
        {
            if (value >= 0)
                _copyrightYear = value;
            else
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, "A valid year must be entered");
        }
    }

    public string CallNumber
    {
        // Precondition:  None
        // Postcondition: The call number has been returned
        get
        {
            return _callNumber;
        }

        // Precondition:  None
        // Postcondition: The call number has been set to the specified value
        set
        {
            if (string.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, "A valid Call Number must be entered");
            }

            _callNumber = value.Trim();
        }
    }

    //Read-only property returning a LibraryPatron reference
    public LibraryPatron Patron
    {
        get
        {
            if (IsCheckedOut() == true) //Valdiates whether or not the book has been checked out by executing the method
                //IsCheckedOut()
            {
                return ; //This is where I need assistance: I'm not sure what should be returned
            }
            else
            {
                return null;
            }
        }
    }

    // Precondition:  None
    // Postcondition: The book is checked out
    public void CheckOut(LibraryPatron patron) //Accepts a LibraryPatron object as a parameter
    {
        _checkedOut = true;
    }

    // Precondition:  None
    // Postcondition: The book is not checked out
    public void ReturnToShelf()
    {
        _checkedOut = false;
        //I'm confused about the way to dissociate the patron object from the book
    }

    // Precondition:  None
    // Postcondition: true is returned if the book is checked out,
    //                otherwise false is returned
    public bool IsCheckedOut()
    {
        return _checkedOut;
    }

    // Precondition:  None
    // Postcondition: A string is returned presenting the libary book's data on
    //                separate lines
    public override string ToString()
    {
        return "Title: " + Title + System.Environment.NewLine +
            "Author: " + Author + System.Environment.NewLine +
            "Publisher: " + Publisher + System.Environment.NewLine +
            "Copyright: " + CopyrightYear.ToString("D4") + System.Environment.NewLine +
            "Checked Out by: " + IsCheckedOut().ToString();
    }
}
