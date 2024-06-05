using System;
using BaixarVideo.Class;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using System.IO;

var youtube = new YoutubeClient();

TratamentoDeTexto tratamento = new TratamentoDeTexto();

Console.Clear();

Console.WriteLine("Digite a Url do video:");

var videoUrl = Console.ReadLine();

var video = await youtube.Videos.GetAsync(videoUrl);

var Title = video.Title;

var Titulo = tratamento.Titulo(Title);

var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoUrl);

var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

var downloadPath = @"C:\Users\Alexa\Downloads\Videos";
if (!Directory.Exists(downloadPath))
{
    Directory.CreateDirectory(downloadPath);
}

var filePath = Path.Combine(downloadPath, $"{Titulo}.{streamInfo.Container}");

await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);

Console.WriteLine($"{Titulo} baixado com sucesso e salvo em {downloadPath}!!!");