using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using FFmpeg.AutoGen;

Console.Clear();

Console.Write("Url do video: ");
string url = Console.ReadLine();


var youtube = new YoutubeClient();

var videoId = VideoId.Parse(url);

var video = await youtube.Videos.GetAsync(videoId);

var invalidCharsRegex = new Regex($"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]");

var cleanTitle = invalidCharsRegex.Replace(video.Title, "_");

var outputFileName = $"{cleanTitle}.mp3";

var downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

var outputPath = Path.Combine(downloadsPath, @"C:\Users\Alexa\Downloads\Musicas", outputFileName);

if (!string.IsNullOrEmpty(outputPath))
{ Directory.CreateDirectory(Path.GetDirectoryName(outputPath)); }

try
{
    using (var outputFile = File.OpenWrite(outputPath))
    {
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);

        var audioStreamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

        using (var inputStream = await youtube.Videos.Streams.GetAsync(audioStreamInfo))
        { await inputStream.CopyToAsync(outputFile); }

        Console.WriteLine($"Download completo. Salvado em: {outputPath}");
    }
}
catch (Exception ex)
{ Console.WriteLine($"Falha no download: {ex.Message}"); }
