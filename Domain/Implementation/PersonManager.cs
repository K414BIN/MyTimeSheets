using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTimeSheets.Data.Interfaces;
using MyTimeSheets.Domain.Interfaces;
using MyTimeSheets.Models;
using MyTimeSheets.Models.Dto;

namespace MyTimeSheets.Domain.Implementation
{
    public class PersonManager : IPersonManager
    {
         private readonly IPersonRepo _personRepo;

        public  PersonManager ( IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }
        
         Person IPersonManager.GetItem(int id)
        {
           return _personRepo.GetOne(id);
        }

        IEnumerable<Person> IPersonManager.GetItems()
        {
               return _personRepo.GetAll();
        }

        int IPersonManager.Create(PersonCreateRequest item)
        {
           var rnd = new Random();
           var result = new Person()
             {
                Id = rnd.Next(51,100),
                FirstName =item.FirstName,
                LastName =item.LastName,
                Email =item.Email,
                Company =item.Company,
                Age =   item.Age
             };
          _personRepo.Add (result);
           return result.Id;
        }

        void IPersonManager.Update(int id, PersonCreateRequest item)
        {
          var result = new Person
             {
                Id = id,
                FirstName =item.FirstName,
                LastName =item.LastName,
                Email =item.Email,
                Company =item.Company,
                Age =   item.Age
             };
                   _personRepo.Update( result);
        }

        void IPersonManager.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
    
}
