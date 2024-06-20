using System.ComponentModel.Design;
using AngleSharp.Dom;
using VideoClass;

Console.Clear();

Console.WriteLine("Selecione oque voce quer fazer\n");

Console.WriteLine("1 - Baixar video\n2 - Baixar audio\n3 - Baixar musicas de playlist");

Console.Write(": ");

var select = Convert.ToInt32(Console.ReadLine());

Console.Clear();

if (select == 1 || select == 2)
{ Console.Write("Cole o link do video youtube: "); }

else if (select == 3)
{ Console.Write("Cole o link da playlist do youtube: "); }

else
{ Console.WriteLine("Opção invalida"); throw Exception(); }

Exception Exception()
{ throw new NotImplementedException(); }

var recebendoUrl = Console.ReadLine();

if (select == 3) { Console.Write("Escolha o nome da playlist: "); }

#pragma warning disable CS8604 
var download = new YoutubeDownload(recebendoUrl);

switch (select)
{
    case 1:
        await download.BaixarVideoDoYoutube();
        break;

    case 2:
        await download.BaixarAudioDoYoutube();
        break;

    case 3:
        await download.BaixarAudiosDePlaylist(Console.ReadLine());
        break;

    default:
        break;
}
