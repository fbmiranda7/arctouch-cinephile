using ArcTouch.Cinephile.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTouch.Cinephile.Services
{
    /// <summary>
    /// Defines a generic movie provider and it's methods
    /// </summary>
    public interface IMovieProvider
    {
        /// <summary>
        /// Any initialization task should be implemented here
        /// </summary>
        /// <returns></returns>
        Task InitializeProvider();

        /// <summary>
        /// Fetches upcoming movies from the internal API
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<IEnumerable<Movie>> FetchUpcoming(int page = 0);

        /// <summary>
        /// TODO Search methods
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<Movie>> Search(string query);

        /// <summary>
        /// Returns cached genres from the API using respective ids
        /// </summary>
        /// <param name="genreIds"></param>
        /// <returns></returns>
        IEnumerable<Genre> GetGenres(int[] genreIds);
    }
}
