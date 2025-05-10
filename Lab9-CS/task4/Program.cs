using System;
using System.Collections;

class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public TimeSpan Duration { get; set; }

    public Song(string title, string artist, TimeSpan duration)
    {
        Title = title;
        Artist = artist;
        Duration = duration;
    }

    public override string ToString()
    {
        return $"{Title} - {Artist} ({Duration})";
    }
}

class MusicAlbum
{
    public string AlbumName { get; set; }
    public Hashtable Songs { get; set; }

    public MusicAlbum(string albumName)
    {
        AlbumName = albumName;
        Songs = new Hashtable();
    }

    // Додати пісню
    public void AddSong(Song song)
    {
        if (!Songs.ContainsKey(song.Title))
        {
            Songs[song.Title] = song;
            Console.WriteLine($"Пісня '{song.Title}' додана до альбому '{AlbumName}'.");
        }
        else
        {
            Console.WriteLine($"Пісня '{song.Title}' вже існує в альбомі.");
        }
    }

    // Видалити пісню
    public void RemoveSong(string title)
    {
        if (Songs.ContainsKey(title))
        {
            Songs.Remove(title);
            Console.WriteLine($"Пісня '{title}' видалена з альбому.");
        }
        else
        {
            Console.WriteLine($"Пісня '{title}' не знайдена в альбомі.");
        }
    }

    // Вивести всі пісні альбому
    public void DisplayAlbum()
    {
        Console.WriteLine($"Альбом: {AlbumName}");
        foreach (DictionaryEntry entry in Songs)
        {
            Console.WriteLine(entry.Value);
        }
    }
}

class MusicCatalog
{
    public Hashtable Albums { get; set; }

    public MusicCatalog()
    {
        Albums = new Hashtable();
    }

    // Додати альбом
    public void AddAlbum(MusicAlbum album)
    {
        if (!Albums.ContainsKey(album.AlbumName))
        {
            Albums[album.AlbumName] = album;
            Console.WriteLine($"Альбом '{album.AlbumName}' доданий до каталогу.");
        }
        else
        {
            Console.WriteLine($"Альбом '{album.AlbumName}' вже є в каталозі.");
        }
    }

    // Видалити альбом
    public void RemoveAlbum(string albumName)
    {
        if (Albums.ContainsKey(albumName))
        {
            Albums.Remove(albumName);
            Console.WriteLine($"Альбом '{albumName}' видалений з каталогу.");
        }
        else
        {
            Console.WriteLine($"Альбом '{albumName}' не знайдений в каталозі.");
        }
    }

    // Пошук пісень за виконавцем
    public void SearchByArtist(string artist)
    {
        Console.WriteLine($"Пошук пісень виконавця: {artist}");
        foreach (DictionaryEntry entry in Albums)
        {
            MusicAlbum album = (MusicAlbum)entry.Value;
            foreach (DictionaryEntry songEntry in album.Songs)
            {
                Song song = (Song)songEntry.Value;
                if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Альбом: {album.AlbumName}, Пісня: {song}");
                }
            }
        }
    }

    // Переглянути весь каталог
    public void DisplayCatalog()
    {
        foreach (DictionaryEntry entry in Albums)
        {
            MusicAlbum album = (MusicAlbum)entry.Value;
            album.DisplayAlbum();
        }
    }
}

class Program
{
    static void Main()
    {
        // Створення каталогу
        MusicCatalog catalog = new MusicCatalog();

        // Створення альбомів
        MusicAlbum album1 = new MusicAlbum("Greatest Hits");
        MusicAlbum album2 = new MusicAlbum("Rock Classics");

        // Створення пісень
        Song song1 = new Song("Song 1", "Artist A", new TimeSpan(0, 4, 30));
        Song song2 = new Song("Song 2", "Artist B", new TimeSpan(0, 3, 45));
        Song song3 = new Song("Song 3", "Artist A", new TimeSpan(0, 5, 10));
        Song song4 = new Song("Song 4", "Artist C", new TimeSpan(0, 4, 20));

        // Додавання пісень до альбомів
        album1.AddSong(song1);
        album1.AddSong(song2);
        album2.AddSong(song3);
        album2.AddSong(song4);

        // Додавання альбомів до каталогу
        catalog.AddAlbum(album1);
        catalog.AddAlbum(album2);

        // Перегляд всього каталогу
        catalog.DisplayCatalog();

        // Пошук пісень за виконавцем
        catalog.SearchByArtist("Artist A");

        // Видалення пісні
        album1.RemoveSong("Song 1");

        // Видалення альбому
        catalog.RemoveAlbum("Rock Classics");

        // Перегляд каталогу після змін
        catalog.DisplayCatalog();

        Console.WriteLine("Enter...");
        Console.ReadLine();
    }
}
