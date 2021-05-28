using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTimeSheets.Models;
using MyTimeSheets.Models.Dto;

namespace MyTimeSheets.Domain.Interfaces
{
    public interface IPersonManager
    {
        Person GetFirstName( string name);
        IEnumerable<Person>  GetPages( int fromPage, int toPage);
        Person GetItem(int id);
        IEnumerable<Person> GetItems();
        int Create(PersonCreateRequest item);
        void Update(int id, PersonCreateRequest item);
        void Delete(int id);
    }
}
