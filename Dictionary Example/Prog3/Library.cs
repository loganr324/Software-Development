// Program 5 EC
// CIS 200-01
// Spring 2017
// By: D3508

// This extra credit program replaces the internal lists from Program 3 with dictionary collections
// and adds DateTime functionality

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    [Serializable]
    public class Library
    {
        // Namespace Accessible Data - Use with care
        internal Dictionary<string, LibraryItem> _itemDict = new Dictionary<string, LibraryItem>(); //Dictionary Collection
        //of LibraryItems
        internal Dictionary<string, LibraryPatron> _patronDict = new Dictionary<string, LibraryPatron>(); //Dictionary
        //Collection of LibraryPatrons
        internal Dictionary<string, DateTime> _checkedOut; //Dictionary Collection
        //for DateTimes that LibraryItems were checked out

        // Precondition:  None
        // Postcondition: The library has been created and is empty (no books, no patrons)
        public Library()
        {
            _itemDict = new Dictionary<string, LibraryItem>();
            _patronDict = new Dictionary<string, LibraryPatron>();
            _checkedOut = new Dictionary<string, DateTime>();
        }

        // Precondition:  None
        // Postcondition: A patron has been created with the specified values for name and ID.
        //                The patron has been added to the Library.
        public bool AddPatron(String name, String id)
        {
            if (_patronDict.ContainsKey(id) == false)
            {
                _patronDict.Add(id, new LibraryPatron(name, id));
                return true;
            }
            else
                return false;
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0
        // Postcondition: A library book has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, and author. The item is not checked out.
        //                The book has been added to the Library.
        public bool AddLibraryBook(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, String theAuthor)
        {
            if (_itemDict.ContainsKey(theCallNumber) == false)
            {
                _itemDict.Add(theCallNumber,new LibraryBook(theTitle,thePublisher,theCopyrightYear,theLoanPeriod,
                    theCallNumber,theAuthor));
                return true;
            }
            else
                return false;
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0 and 
        //                theMedium from { DVD, BLURAY, VHS } and theDuration >= 0
        // Postcondition: A library movie has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, duration, director, medium, and rating. The
        //                item is not checked out.
        //                The movie has been added to the Library.
        public bool AddLibraryMovie(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, double theDuration, String theDirector,
            LibraryMediaItem.MediaType theMedium, LibraryMovie.MPAARatings theRating)
        {
            if (_itemDict.ContainsKey(theCallNumber) == false)
            {
                _itemDict.Add(theCallNumber, new LibraryMovie(theTitle, thePublisher, theCopyrightYear, theLoanPeriod,
                    theCallNumber, theDuration, theDirector,theMedium,theRating));
                return true;
            }
            else
                return false;
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0 and 
        //                theMedium from { CD, SACD, VINYL } and theDuration >= 0 and
        //                theNumTracks >= 0
        // Postcondition: A library music item has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, duration, director, medium, and rating. The
        //                item is not checked out.
        //                The music item has been added to the Library.
        public bool AddLibraryMusic(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, double theDuration, String theArtist,
            LibraryMediaItem.MediaType theMedium, int theNumTracks)
        {
            if (_itemDict.ContainsKey(theCallNumber) == false)
            {
                _itemDict.Add(theCallNumber, new LibraryMusic(theTitle, thePublisher, theCopyrightYear, theLoanPeriod,
                    theCallNumber, theDuration, theArtist, theMedium, theNumTracks));
                return true;
            }
            else
                return false;
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0 and
        //                theVolume >= 0 and theNumber >= 0
        // Postcondition: A library journal has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, volume, number, discipline, and editor. The
        //                item is not checked out.
        //                The journal has been added to the Library.
        public bool AddLibraryJournal(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, int theVolume, int theNumber,
            String theDiscipline, String theEditor)
        {
            if (_itemDict.ContainsKey(theCallNumber) == false)
            {
                _itemDict.Add(theCallNumber, new LibraryJournal(theTitle, thePublisher, theCopyrightYear, theLoanPeriod,
                    theCallNumber, theVolume, theNumber, theDiscipline, theEditor));
                return true;
            }
            else
                return false;
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0 and
        //                theVolume >= 0 and theNumber >= 0
        // Postcondition: A library magazine has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, volume, and number. The item is not checked out.
        //                The magazine has been added to the Library.
        public bool AddLibraryMagazine(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, int theVolume, int theNumber)
        {
            if (_itemDict.ContainsKey(theCallNumber) == false)
            {
                _itemDict.Add(theCallNumber, new LibraryMagazine(theTitle, thePublisher, theCopyrightYear, theLoanPeriod,
                    theCallNumber, theVolume, theNumber));
                return true;
            }
            else
                return false;
        }

        // Precondition:  None
        // Postcondition: The number of patrons in the library is returned
        public int GetPatronCount()
        {
            return _patronDict.Count;
        }

        // Precondition:  None
        // Postcondition: The number of items in the library is returned
        public int GetItemCount()
        {
            return _itemDict.Count;
        }

        // Precondition:  0 <= itemIndex < GetItemCount()
        //                0 <= patronIndex < GetPatronCount()
        // Postcondition: The specified item will be checked out by
        //                the specifed patron
        public bool CheckOut(string itemCallNumber, string patronId)
        {
            if (_itemDict.ContainsKey(itemCallNumber) && _patronDict.ContainsKey(patronId))
            {
                if (_itemDict[itemCallNumber].IsCheckedOut() == false)
                {
                    _itemDict[itemCallNumber].CheckOut(_patronDict[patronId]);
                    _checkedOut.Add(itemCallNumber, DateTime.Now.AddDays(-21));
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        // Precondition:  0 <= bookIndex < GetItemCount()
        // Postcondition: The specified book will be returned to shelf
        public decimal ReturnToShelf(string itemCallNumber)
        {
            decimal lateFee = _itemDict[itemCallNumber].CalcLateFee(DateTime.Now.Day - _checkedOut[itemCallNumber].Day -
                        _itemDict[itemCallNumber].LoanPeriod);

            if (_itemDict.ContainsKey(itemCallNumber))
            {
                if (_itemDict[itemCallNumber].IsCheckedOut() == true)
                {
                    _itemDict[itemCallNumber].ReturnToShelf();
                    _checkedOut.Remove(itemCallNumber);
                    return lateFee;
                }
                else return -1;
            }
            else
                return -1;
        }

        // Precondition:  None
        // Postcondition: The number of items checked out from the library is returned
        public int GetCheckedOutCount()
        {
            int checkedOutCount = 0; // Running count of checked out books

            foreach (LibraryItem item in _itemDict.Values)
                if (item.IsCheckedOut())
                    ++checkedOutCount;

            return checkedOutCount;
        }

        // Namespace Helper Method - Use with care
        // Precondition:  None
        // Postcondition: The dictionary of items stored in the library is converted to a list and returned
        internal List<LibraryItem> GetItemsList()
        {
            return _itemDict.Values.ToList();
        }

        // Namespace Helper Method - Use with care
        // Precondition:  None
        // Postcondition: The ddictionary of patrons stored in the library is converted to a list and returned
        internal List<LibraryPatron> GetPatronsList()
        {
            return _patronDict.Values.ToList();
        }

        //Namespace Helper Method
        //Precondition: None
        //Postcondition: The dictionary of check out transactions is returned
        internal Dictionary<string,DateTime> GetCheckedOutTransactions()
        {
            return _checkedOut;
        }

        //Precondition: The PatronForm has returned OK
        //Postcondition: The old patron reference is removed from the dictionary and one with the new information is added
        public void ChangePatronKey(string oldKey, string newKey, LibraryPatron patron)
        {
            _patronDict.Remove(oldKey);
            _patronDict.Add(newKey, patron);
        }

        //Precondition: The BookForm has returned OK
        //Postcondition: The old item reference is removed from the dictionary and one with the new information is added
        public void ChangeItemKey(string oldKey, string newKey, LibraryItem item)
        {
            _itemDict.Remove(oldKey);
            _itemDict.Add(newKey, item);
        }
        
        // Precondition:  None
        // Postcondition: A string is returned presenting the libary in a formatted report
        public override string ToString()
        {
            // Using StringBuilder to show use of a more efficient way than String concatenation
            StringBuilder report = new StringBuilder(); // Will hold report as being built
            string NL = Environment.NewLine; // NewLine shortcut

            report.Append("Library Report\n");
            report.Append($"Number of items stored:      {GetItemCount(),4:d}{NL}");
            report.Append($"Number of items checked out: {GetCheckedOutCount(),4:d}{NL}");
            report.Append($"Number of patrons stored:    {GetPatronCount(),4:d}");

            return report.ToString();
        }
    }
}
