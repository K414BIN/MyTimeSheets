using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTimeSheets.Models;

namespace MyTimeSheets.Data.Interfaces
{
    public interface IPersonRepo : IRepository<Person>
    {
      IEnumerable<Person> GetPages(int fromPage, int toPage);
    }
}
