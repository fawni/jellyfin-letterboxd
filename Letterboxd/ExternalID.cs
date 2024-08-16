using MediaBrowser.Controller.Entities.Movies;
using MediaBrowser.Controller.LiveTv;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.Providers;

namespace Letterboxd
{
    /// <summary>
    /// External id for a Letterboxd movie.
    /// </summary>
    public class ExternalID : IExternalId
    {
        /// <inheritdoc />
        public string ProviderName => Plugin.Instance!.Configuration.LinkName;

        /// <inheritdoc />
        public string Key => MetadataProvider.Tmdb.ToString();

        /// <inheritdoc />
        public ExternalIdMediaType? Type => ExternalIdMediaType.Movie;

        /// <inheritdoc />
        public string UrlFormatString => "https://letterboxd.com/tmdb/{0}";

        /// <inheritdoc />
        public bool Supports(IHasProviderIds item)
        {
            if (item is LiveTvProgram tvProgram && tvProgram.IsMovie)
            {
                return true;
            }

            return item is Movie;
        }
    }
}
