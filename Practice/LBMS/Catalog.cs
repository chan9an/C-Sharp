using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LBMS;

public class Catalog<T> where T : Book
{
    private List<T> _items = new List<T>();
    private HashSet<string> _isbnSet = new HashSet<string>();
    private SortedDictionary<string, List<T>> _genreIndex = new SortedDictionary<string, List<T>>();
    public bool AddItem(T item)
    {
        _items.Add(item);

        if (!_genreIndex.ContainsKey(item.Genre))
        {
            _genreIndex[item.Genre] = new List<T>();
            
        }
        _genreIndex[item.Genre].Add(item);
        _isbnSet.Add(item.ISBN);
        return _isbnSet.Contains(item.ISBN);
    }

    public List<T> this[string genre]{
        get{

            return _genreIndex[genre];
        }
    }
    public IEnumerable<T> FindBooks(Func<T, bool> predicate)
    {
        return _items.Where(predicate);
    }

}
