using System;

namespace DIOFLIX
{
    public class Program
    {
        static SeriesRepository seriesRepository = new SeriesRepository();
        static MovieRepository movieRepository = new MovieRepository();
        public static void Main(string[] args)
        {
            string select = Select();
            while (select.ToUpper() != "X")
            {
                switch (select)
                {
                    case "1":
                        SelectMovie();
                        break;
                    case "2":
                        SelectSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                select = Select();
            }

            Console.WriteLine("Obrigada por utilizar nossos serviços!");
            Console.ReadLine();
        }


        private static void SelectMovie()
        {
            string movieOptions = MovieOptions();
            while (movieOptions.ToUpper() != "X")
            {
                switch (movieOptions)
                {
                    case "1":
                        MoviesList();
                        break;
                    case "2":
                        AddNewMovie();
                        break;
                    case "3":
                        UpdateMovies();
                        break;
                    case "4":
                        DeleteMovies();
                        break;
                    case "5":
                        GetMoviesById();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                movieOptions = MovieOptions();
            }
        }

        private static void MoviesList()
        {
            Console.WriteLine("Listar Filmes");

            var movieList = movieRepository.MovieList();

            if (movieList.Count == 0)
            {
                Console.WriteLine("Nenhum filme encontrado.");
                return;
            }

            foreach (var movie in movieList)
            {
                var deletedMovie = movie.returnDeleted();
                Console.WriteLine("#ID {0}: - {1} {2}", movie.returnId(), movie.returnTitle(), (deletedMovie ? "*Excluído*" : ""));
            }
        }

        private static void GetMoviesById()
        {
            Console.Write("Digite o id do filme: ");
            int movieIndex = int.Parse(Console.ReadLine());

            var movie = movieRepository.GetMovieById(movieIndex);

            Console.WriteLine(movie);
        }

        private static void AddNewMovie()
        {
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genres), i));
            }
            Console.Write("Digite o Genêro entre as opções acima: ");
            int genreOption = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do filme: ");
            string titleOption = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento do filme: ");
            int yearOption = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do filme: ");
            string descriptionOption = Console.ReadLine();

            Movie newMovie = new Movie(id: movieRepository.NextMovieId(),
            genre: (Genres)genreOption,
            title: titleOption,
            year: yearOption,
            description: descriptionOption);

            movieRepository.AddMovie(newMovie);
        }

        private static void UpdateMovies()
        {
            Console.Write("Digite o id do filme: ");
            int movieIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genres), i));
            }
            Console.Write("Digite o Genêro entre as opções acima: ");
            int genreOption = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do filme: ");
            string titleOption = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento do filme: ");
            int yearOption = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do filme: ");
            string descriptionOption = Console.ReadLine();

            Movie updateMovie = new Movie(id: movieIndex,
                                        genre: (Genres)genreOption,
                                        title: titleOption,
                                        year: yearOption,
                                        description: descriptionOption);

            movieRepository.UpdateMovie(movieIndex, updateMovie);
        }

        private static void DeleteMovies()
        {
            Console.Write("Digite o id do filme: ");
            int movieIndex = int.Parse(Console.ReadLine());

            movieRepository.DeleteMovie(movieIndex);
        }





        private static void SelectSeries()
        {
            string seriesOptions = SeriesOptions();
            while (seriesOptions.ToUpper() != "X")
            {
                switch (seriesOptions)
                {
                    case "1":
                        SeriesList();
                        break;
                    case "2":
                        AddNewSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        GetSeriesById();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                seriesOptions = SeriesOptions();
            }
        }



        private static void SeriesList()
        {
            Console.WriteLine("Listar Séries");

            var seriesList = seriesRepository.SeriesList();

            if (seriesList.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada.");
                return;
            }

            foreach (var series in seriesList)
            {
                var deletedSeries = series.returnDeleted();
                Console.WriteLine("#ID {0}: - {1} {2}", series.returnId(), series.returnTitle(), (deletedSeries ? "*Excluída*" : ""));
            }
        }

        private static void GetSeriesById()
        {
            Console.Write("Digite o id da série: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            var series = seriesRepository.GetSeriesByID(seriesIndex);

            Console.WriteLine(series);
        }

        private static void AddNewSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genres), i));
            }
            Console.Write("Digite o Genêro entre as opções acima: ");
            int genreOption = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string titleOption = Console.ReadLine();

            Console.Write("Digite o Ano de início da série: ");
            int yearOption = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string descriptionOption = Console.ReadLine();

            Series newSeries = new Series(id: seriesRepository.NextSeriesId(),
            genre: (Genres)genreOption,
            title: titleOption,
            year: yearOption,
            description: descriptionOption);

            seriesRepository.AddSeries(newSeries);
        }

        private static void UpdateSeries()
        {
            Console.Write("Digite o id da série: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genres), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int genreOption = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string titleOption = Console.ReadLine();

            Console.Write("Digite o Ano de início da série: ");
            int yearOption = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string descriptionOption = Console.ReadLine();

            Series updateSeries = new Series(id: seriesIndex,
                                        genre: (Genres)genreOption,
                                        title: titleOption,
                                        year: yearOption,
                                        description: descriptionOption);

            seriesRepository.UpdateSeries(seriesIndex, updateSeries);
        }

        private static void DeleteSeries()
        {
            Console.Write("Digite o id da série: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            seriesRepository.DeleteSeries(seriesIndex);
        }


        private static string Select()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindx ao DIOFLIX!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Filmes");
            Console.WriteLine("2- Séries");
            Console.WriteLine();

            string select = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return select;
        }

        private static string MovieOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Filmes");
            Console.WriteLine("2- Inserir Novo Filme");
            Console.WriteLine("3- Atualizar Filme");
            Console.WriteLine("4- Excluir Filme");
            Console.WriteLine("5- Visualizar Filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar");
            Console.WriteLine();

            string moviesOptions = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return moviesOptions;
        }
        private static string SeriesOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar");
            Console.WriteLine();

            string seriesOptions = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return seriesOptions;
        }

    }
}