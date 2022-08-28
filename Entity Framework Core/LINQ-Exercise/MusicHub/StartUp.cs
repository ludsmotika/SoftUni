namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            Album[] albums = context.Albums.Where(x => x.ProducerId.Value == producerId).ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (Album album in albums.OrderByDescending(x => x.Price))
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {album.Producer.Name}");
                sb.AppendLine($"-Songs:");
                Song[] songs = album.Songs.OrderByDescending(x => x.Name).ThenBy(x => x.Writer.Name).ToArray();
                int number = 1;
                foreach (Song song in songs)
                {
                    sb.AppendLine($"---#{number++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer.Name}");
                }
                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }
            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            Song[] songs = context.Songs.ToArray().Where(x =>x.Duration.TotalSeconds> duration).ToArray();
            StringBuilder sb = new StringBuilder();

            int number = 1;
            foreach (Song song in songs.OrderBy(x => x.Name).ThenBy(x => x.Writer.Name).ThenBy(x => x.SongPerformers.First()))
            {
                sb.AppendLine($"-Song #{number++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.Writer.Name}");
                sb.AppendLine($"---Performer: {song.SongPerformers.First().Performer.FirstName+" "+ song.SongPerformers.First().Performer.LastName} ");
                sb.AppendLine($"---AlbumProducer: {song.Album.Producer.Name}");
                sb.AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().Trim();
        }
    }
}
