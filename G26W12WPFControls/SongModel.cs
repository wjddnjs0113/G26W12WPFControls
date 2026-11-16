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

    // 마지막 글자에 종성이 있는지 판별 (한글만 가능, 그 외 문자는 false 반환)
    public static bool HasJongsung(string str) {
        if (string.IsNullOrEmpty(str))
            return false;

        char last = str[^1]; // 뒤에서 첫 번째 글자

        // 한글 완성형 범위('가': 0xAC00 ~ '힣': 0xD7A3)가 아니면 받침 없음으로 처리
        if (last < 0xAC00 || last > 0xD7A3)
            return false;

        return (last - 44032) % 28 != 0;
    }
}
