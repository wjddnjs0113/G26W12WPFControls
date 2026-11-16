using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Reflection;

namespace G26W12WPFControls;

public partial class SongViewModel(
    SongModel model
) : ObservableObject {
    [ObservableProperty]
    private string _title = "";

    [ObservableProperty]
    private string _singer = "";

    [ObservableProperty]
    private string _genre = SongModel.GENRES[0];

    [ObservableProperty]
    private string _result = "";

    public ObservableCollection<string> Genres { get; } = [.. SongModel.GENRES];

    [RelayCommand]
    private void AddSong() {
        Song? song = model.AddSong(Title, Singer, Genre);
        if (song is null)
            return;

        string str = $"{song.Singer}{(SongModel.HasJongsung(song.Singer) ? "이" : "가")} 부른 "
            + $"{song.Genre} 장르의 "
            + $"{song.Title}{(SongModel.HasJongsung(song.Title) ? "이" : "가")} 추가됨\n";

        Result = str + Result;
    }
}