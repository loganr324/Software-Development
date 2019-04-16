using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    class DescendingItemOrder : IComparer<LibraryItem>
    {
        //Precondition: None
        //Postcondition: Reverses natural order, making it descending
        //              when this < item2, return a negative #
        //              when this = item2, return 0 
        //              when this > item2, return a positive #
        public int Compare(LibraryItem item1, LibraryItem item2)
        {
            if (item1 == null && item2 == null) //How to handle both items being null
                return 0;

            if (item1 == null) //How to handle item1 being null
                return -1;

            if (item2 == null) //How to handle item2 being null
                return 1;

            return -1 * item1.CopyrightYear.CompareTo(item2.CopyrightYear); //Reverses natural order, uses CopyrightYear to sort
        }
    }
}
