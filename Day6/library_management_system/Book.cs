using System;
using Microsoft.VisualBasic;

namespace library_management_system;

public class Book
{
    #region Fields
    string _title;
    string _author;
    int _numPages;
    DateTime _dueDate;
    DateTime _returnedDate;

    #endregion

    public Book()
    {
        _title = "Unknown";
        _author = "Mr. Unknown";
        _numPages = 10;
        _dueDate = new DateTime(2024, 1, 11);
        _returnedDate = new DateTime(2024, 1, 11);

    }
    public Book(string title, string author, int numPages, DateTime dueDate, DateTime returnedDate)
    {

        _title = title;
        _author = author;
        _numPages = numPages;
        _dueDate = dueDate;
        _returnedDate = returnedDate;

    }
    public double AveragePagesReadPerDay(int daysToRead)
    {
        return _numPages / daysToRead;

    }
    public double CalculateLateFee(double dailyLateFeeRate)
    {
         int daysLate = (_returnedDate - _dueDate).Days;

        return daysLate * dailyLateFeeRate;
        
    }
}
