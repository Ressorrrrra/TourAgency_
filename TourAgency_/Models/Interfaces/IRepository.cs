﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Repository;

namespace TourAgency_.Models.Interfaces
{

    public interface IRepository<T> where T : class
    {
        List<T> GetList();
        T GetItem(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);


    }
}
