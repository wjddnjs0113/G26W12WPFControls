namespace G26W12WPFControls;

public record Song(string Title, string Singer, string Genre);

public class SongModel {
    public static readonly string[] GENRES = ["발라드", "힙합", "트로트", "댄스", "팝", "기타"];

    private readonly List<Song> _songs = [];
    public List<Song> Songs => _songs;

    public Song? AddSong(string title, string singer, string genre) {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(singer))
            return null;

        Song song = new(title.Trim(), singer.Trim(), genre);
        _songs.Add(song);

        return song;
    }
}