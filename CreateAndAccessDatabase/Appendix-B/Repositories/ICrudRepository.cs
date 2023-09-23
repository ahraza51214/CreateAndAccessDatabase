using System;

namespace CreateAndAccessDatabase.AppendixB.Repositories
{
    // General repository interface for CRUD (Crate, Update, Read, Delete) handling.
    internal interface ICrudRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}