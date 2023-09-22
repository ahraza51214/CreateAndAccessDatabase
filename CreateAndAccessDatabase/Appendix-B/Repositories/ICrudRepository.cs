using System;

namespace CreateAndAccessDatabase.AppendixB.Repositories;

internal interface ICrudRepository<T, TKey>
{
    List<T> GetAll();
    T GetById(TKey id);
    T Add(T entity);
    T Update(T entity);
    void Delete(TKey id);
}