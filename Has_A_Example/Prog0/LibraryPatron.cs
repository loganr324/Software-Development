// Program 0
// Starting Point

// File: LibraryPatron.cs
// This file creates a simple LibraryPatron class capable of tracking
// the patron's name and ID.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class LibraryPatron
{
    private string _patronName; // Name of the patron
    private string _patronID;   // ID of the patron

    // Precondition:  None
    // Postcondition: The patron has been initialized with the specified name
    //                and ID
    public LibraryPatron(string name, string id)
    {
        PatronName = name;
        PatronID = id;
    }

    public string PatronName
    {
        // Precondition:  None
        // Postcondition: The patron's name has been returned
        get
        {
            return _patronName;
        }

        // Precondition:  None
        // Postcondition: The patron's name has been set to the specified value
        set
        {
            if (string.IsNullOrEmpty(value.Trim())) //Validation: checks if the trimmed value is null or is an
                //empty string
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, "A name must be entered"); //Throws an exception if the passed argument is null or empty
            }

            _patronName = value.Trim(); //assigns the value to _patronName
        }
    }

    public string PatronID
    {
        // Precondition:  None
        // Postcondition: The patron's ID has been returned
        get
        {
            return _patronID;
        }

        // Precondition:  None
        // Postcondition: The patron's ID has been set to the specified value
        set
        {
            if (string.IsNullOrEmpty(value.Trim())) //Validation: checks if the value is null or empty
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, "An ID must be entered"); //Throws an exception if the passed argument is null or empty
            }

            _patronName = value.Trim(); //Assigns the value to _patronName
        }
    }

    // Precondition:  None
    // Postcondition: A string is returned presenting the libary patron's data on
    //                separate lines
    public override string ToString()
    {
        string NL = Environment.NewLine; // NewLine shortcut

        return $"Name: {PatronName}{NL}ID: {PatronID}";
    }

}

