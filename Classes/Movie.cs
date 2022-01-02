using System;

namespace DIOFLIX
{
    public class Movie : BaseEntity
    {
        private Genres Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Movie(int id, Genres genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string response = "";
            response += "Gênero: " + this.Genre + Environment.NewLine;
            response += "Título: " + this.Title + Environment.NewLine;
            response += "Descrição: " + this.Description + Environment.NewLine;
            response += "Ano de lançamento: " + this.Year + Environment.NewLine;
            response += "Excluido: " + this.Deleted;
            return response;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }
        public void Delete()
        {
            this.Deleted = true;
        }
        public bool returnDeleted()
        {
            return this.Deleted;
        }
    }
}