using System;
using System.Collections.Generic;
using DIOFLIX.Interfaces;

namespace DIOFLIX
{
    public class MovieRepository : IRepositoryMovie<Movie>
    {
        
        private List<Movie> movieList = new List<Movie>();

        public void UpdateMovie(int id, Movie entity)
        {
            movieList[id] = entity;
        }

        public void DeleteMovie(int id)
        {
            movieList[id].Delete();
        }
        public void AddMovie(Movie entity)
        {
            movieList.Add(entity);
        }
       
        public List<Movie> MovieList()
        {
            return movieList;
        }

        public int NextMovieId()
        {
            return movieList.Count;
        }

        public Movie GetMovieById(int id)
        {
            return movieList[id];
        }

    }
}