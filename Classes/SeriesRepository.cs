using System;
using System.Collections.Generic;
using DIOFLIX.Interfaces;

namespace DIOFLIX
{
    public class SeriesRepository : IRepositorySeries<Series>
    {
        private List<Series> seriesList = new List<Series>();
        public void UpdateSeries(int id, Series entity)
        {
            seriesList[id] = entity;
        }

        public void DeleteSeries(int id)
        {
            seriesList[id].Delete();
        }

        public void AddSeries(Series entity)
        {
            seriesList.Add(entity);
        }

        public List<Series> SeriesList()
        {
            return seriesList;
        }

        public int NextSeriesId()
        {
            return seriesList.Count;
        }

        public Series GetSeriesByID(int id)
        {
            return seriesList[id];
        }
        
    }
}