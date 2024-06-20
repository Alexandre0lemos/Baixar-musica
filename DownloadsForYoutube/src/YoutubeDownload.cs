using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Svg.Dom;
using BaixarVideo.Class;
using Microsoft.VisualBasic;
using ProjetoFinal.src.link;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace VideoClass
{
    public class YoutubeDownload : Link
    {
        public YoutubeDownload(string url) : base(url)
        { }

        public async Task BaixarVideoDoYoutube()
        {
            var youtube = new YoutubeClient();

            var tratamento = new TratamentoDeTexto();

            Console.Clear();

            Console.WriteLine("Baixando video...\n");

            var video = await youtube.Videos.GetAsync(urlLink);

            var tituloDoVideo = video.Title;

            tituloDoVideo = tratamento.NomeDeMusica(tituloDoVideo);

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(urlLink);

            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            string[] parteDoUsuario = nomeDoComputador.Split('\\');

            var User = parteDoUsuario.Length > 1 ? parteDoUsuario[1] : nomeDoComputador;

            var downloadPath = $"C:/Users/{User}/Downloads/Videos";

            if (!Directory.Exists(downloadPath))
            { Directory.CreateDirectory(downloadPath); }

            var filePath = Path.Combine(downloadPath, $"{tituloDoVideo}.mp4");

            await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);

            Console.WriteLine($"{tituloDoVideo} baixado com sucesso e salvo em {downloadPath}!!!");
        }

        public async Task BaixarAudioDoYoutube()
        {
            var youtube = new YoutubeClient();

            var tratamento = new TratamentoDeTexto();

            Console.Clear();

            Console.WriteLine("Baixando audio...\n");

            var video = await youtube.Videos.GetAsync(urlLink);

            var tituloDoVideo = video.Title;

            tituloDoVideo = tratamento.NomeDeMusica(tituloDoVideo);

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(urlLink);

            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            string[] parteDoUsuario = nomeDoComputador.Split('\\');

            var User = parteDoUsuario.Length > 1 ? parteDoUsuario[1] : nomeDoComputador;

            var downloadPath = $"C:/Users/{User}/Downloads/Audios";

            if (!Directory.Exists(downloadPath))
            { Directory.CreateDirectory(downloadPath); }

            var filePath = Path.Combine(downloadPath, $"{tituloDoVideo}.mp3");

            await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);

            Console.WriteLine($"{tituloDoVideo} baixado com sucesso e salvo em {downloadPath}!!!");
        }

        public async Task BaixarAudiosDePlaylist(string NomePlaylist)
        {
            var youtube = new YoutubeClient();

            var tratamento = new TratamentoDeTexto();

            var nomePlaylist = tratamento.NomeDePasta(NomePlaylist);

            string[] parteDoUsuario = nomeDoComputador.Split('\\');

            var User = parteDoUsuario.Length > 1 ? parteDoUsuario[1] : nomeDoComputador;

            var downloadPath = $"C:/Users/{User}/Downloads/{nomePlaylist}";

            if (!Directory.Exists(downloadPath))
            { Directory.CreateDirectory(downloadPath); }

            Console.Clear();

            Console.WriteLine($"Todas as musicas serão baixadas em {downloadPath}");

            Console.WriteLine("Iniciando downloads...\n");

            await foreach (var i in youtube.Playlists.GetVideosAsync(urlLink))
            {
                var videoUrl = i.Url;

                var video = await youtube.Videos.GetAsync(videoUrl);

                var tituloDoVideo = video.Title;

                tituloDoVideo = tratamento.NomeDeMusica(tituloDoVideo);

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoUrl);

                var filePath = Path.Combine(downloadPath, $"{tituloDoVideo}.mp3");

                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);

                Console.WriteLine($"{tituloDoVideo} baixado com sucesso!!!\n");
            }
        }
    }
}
