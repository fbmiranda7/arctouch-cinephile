﻿using ArcTouch.Cinephile.Entity;
using ArcTouch.Cinephile.Services.TMDb;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace ArcTouch.Cinephile.Services
{
    /// <summary>
    /// TMDb API provider implementation
    /// </summary>
    public class TMDbProvider : IMovieProvider
    {
        private const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        private const string BASE_URL = "https://api.themoviedb.org/3/{0}?api_key={1}";

        public Genre[] Genres { get; private set; }

        private class Calls
        {
            public const string Upcoming = "movie/upcoming";
            public const string GenreList = "genre/movie/list";
        }

        public TMDbProvider()
        {
            InitializeProvider();
        }

        public async Task InitializeProvider()
        {
            string url = FormatUrl(Calls.GenreList);

            GenresResult result = await Request<GenresResult>(url);

            Genres = result.Genres;
        }

        public async Task<IEnumerable<Movie>> FetchUpcoming(int page = 1)
        {
            string url = FormatUrl(Calls.Upcoming, "&page=" + page);

            Result result = await Request<Result>(url);

            UpdateRelativePaths(result.Results);

            return result.Results;
        }

        /// <summary>
        /// Generic method for a request and json deserialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<T> Request<T>(string url)
        {
            HttpClient client = new HttpClient();

            try
            { 
                var call = await client.GetAsync(url);

                if (call.IsSuccessStatusCode)
                {
                    string response = await call.Content.ReadAsStringAsync();

                    T result = JsonConvert.DeserializeObject<T>(response);

                    return result;
                }
                else
                {
                    throw new Exception("Error: " + call.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error has ocurred, please try again later.", ex);
            }
        }

        /// <summary>
        /// Fixes relative paths so that the ui can use the url seamlessly
        /// </summary>
        /// <param name="results"></param>
        private void UpdateRelativePaths(Movie[] results)
        {
            foreach(Movie movie in results)
            {
                movie.BackdropPath = "https://image.tmdb.org/t/p/w780" + movie.BackdropPath;
                movie.PosterPath = "https://image.tmdb.org/t/p/w500" + movie.PosterPath;
            }
        }

        private string FormatUrl(string call, string additionalParameters = "")
        {
            return string.Format(BASE_URL, call, API_KEY) + additionalParameters;
        }

        public async Task<IEnumerable<Movie>> Search(string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetGenres(int[] genreIds)
        {
            if (Genres == null || Genres.Length == 0)
                InitializeProvider().Wait();

            return Genres.Where(g => genreIds.Contains(g.Id));
        }
    }
}