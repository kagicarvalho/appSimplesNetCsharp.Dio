using System;
using Dio.Series.Enums;

namespace Dio.Series.Model
{
    public class Serie : EntityBase
    {
        public Serie(int id, string title, string description, Gender gender, int year)
        {
            Id = id;
            Title = title;
            Description = description;
            Genero = gender;
            Year = year;
            Excluded = false;
        }

        private string Title { get; set; }
        private string Description { get; set; }
        private Gender Genero { get; set; }
        private int Year { get; set; }
        private bool Excluded { get; set; }


        public override string ToString()
        {
            string retorno = "";

            retorno += $"Título: {this.Title} \r\n";
            retorno += $"Descrição: {this.Description} \r\n";
            retorno += $"Gênero: {this.Genero} \r\n";
            retorno += $"Ano de lançamento: {this.Year} \r\n";

            return retorno;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public bool ReturnExcluded()
        {
            return this.Excluded;
        }

        public void DeleteSerie()
        {
            this.Excluded = true;
        }

    }
}