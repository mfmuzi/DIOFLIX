using System.Collections.Generic;

namespace DIOFLIX.Interfaces
{
    public interface IRepositorySeries<T>
    {
        List<T> SeriesList();
        T GetSeriesByID(int id);
        void AddSeries( T entity);
        void DeleteSeries(int id);
        void UpdateSeries(int id, T entity);
        int NextSeriesId();
      
    }

    public interface IRepositoryMovie<T>
    {
        List<T> MovieList();
        T GetMovieById(int id);
        void AddMovie( T entity);
        void DeleteMovie(int id);
        void UpdateMovie(int id, T entity);
        int NextMovieId();
    }
}