using System;
using System.Collections.Generic;
using Dio.Series.Interfaces;
using Dio.Series.Model;

namespace Dio.Series.Repository
{
    public class RepositorySerie : ISerie
    {
        private List<Serie> listSeries = new List<Serie>();
        
        public void Add(Serie entity)
        {
            listSeries.Add(entity);
        }

        public void Delete(int id)
        {
            listSeries[id].DeleteSerie();
        }

        public List<Serie> GetAll()
        {
            return listSeries;
        }

        public Serie GetById(int id)
        {
            return listSeries[id];
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public void Update(int id, Serie entity)
        {
            listSeries[id] = entity;
        }
    }
}