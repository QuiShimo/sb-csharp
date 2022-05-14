using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace SB_Homework09
{
    class Program
    {
        private static TelegramBotClient Bot;

        public static async Task Main()
        {
            // считываем токен
            string token = System.IO.File.ReadAllText(@"D:\token.txt");

            Bot = new TelegramBotClient(token);

            var me = await Bot.GetMeAsync();
            Console.Title = me.Username;

            Bot.OnMessage += BotOnMessageReceived;

            Bot.StartReceiving();
            Console.WriteLine($"Начинаем слушать сообщения с @{me.Username}");

            Console.ReadKey();
            Bot.StopReceiving();

        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            string savePath = @"File/" + $"{message.Chat.Id}/";
            CheckFolder(savePath);

            if (message == null)
                return;

            // загрузка файлов на сервер
            if (message.Type != MessageType.Text)
            {
                switch (message.Type)
                {
                    case MessageType.Document:
                        await Bot.SendTextMessageAsync(message.Chat.Id, $"Начинаю загрузку документа...");
                        await DownLoad(message.Document.FileId, savePath + message.Document.FileName, message);
                        break;
                    case MessageType.Voice:
                        await Bot.SendTextMessageAsync(message.Chat.Id, $"Начинаю загрузку голосового сообщения...");
                        await DownLoad(message.Voice.FileId, savePath + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".ogg", message);
                        break;
                    case MessageType.Photo:
                        await Bot.SendTextMessageAsync(message.Chat.Id, $"Начинаю загрузку картинки....");
                        await DownLoad(message.Photo[message.Photo.Length - 1].FileId, savePath + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".png", message);
                        break;
                    default:
                        await Bot.SendTextMessageAsync(message.Chat.Id, $"Это что-то неизвестное. Не буду это загружать.");
                        break;
                }
            }

            // меню команд
            if (message.Type == MessageType.Text)
            {
                switch (message.Text.Split(' ').First())
                {
                    case "/start":
                        await SendHelloMessage(message);
                        break;
                    case "/listfiles":
                        await GetListFile(savePath, message);
                        break;
                    case "/about":
                        await About(message);
                        break;
                    case "/help":
                        await Usage(message);
                        break;
                    default:
                        await isDownload(savePath, message);
                        break;
                }
            }

        }

        /// <summary>
        /// Выгружает файл в чат
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task isDownload(string savePath, Message message)
        {
            if (FindFile(message.Text, savePath))
            {
                await Bot.SendTextMessageAsync(message.Chat.Id, "Файл найден! Начинаю отправку...");

                switch (message.Text.Split(".").Last())
                {
                    case "ogg":
                        await SendVoice(savePath + message.Text, message);
                        break;
                    case "png":
                        await SendPhoto(savePath + message.Text, message);
                        break;
                    default:
                        await SendDocument(savePath + message.Text, message);
                        break;
                }

            }
            else
            {
                await Bot.SendTextMessageAsync(message.Chat.Id, "Файл не найден!");
            }
        }

        /// <summary>
        /// Приветственное сообщение
        /// </summary>
        /// <param name="message">Сообщение</param>
        static async Task SendHelloMessage(Message message)
        {
            var messageText = $"Привет, {message.From.FirstName}!";
            await Bot.SendTextMessageAsync(message.Chat.Id, $"{messageText}");
        }

        /// <summary>
        /// Загрузка файлов на локальный диск
        /// </summary>
        /// <param name="fileId">ID файла</param>
        /// <param name="path">путь сохранения</param>
        static async Task DownLoad(string fileId, string path, Message message)
        {
            var file = await Bot.GetFileAsync(fileId);
            FileStream fs = new FileStream(path, FileMode.Create);
            await Bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();

            fs.Dispose();

            await Bot.SendTextMessageAsync(message.Chat.Id, "Загрузка окончена");
        }

        /// <summary>
        /// Получает список загруженных файлов
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task GetListFile(string path, Message message)
        {

            string[] files = Directory.GetFiles(path);
            string messageText;

            if (files.Length != 0)
            {
                messageText = "Загруженные файлы:\n";
                foreach (string file in files)
                {
                    messageText += file.Split("/")[^1] + "\n";
                }
            }
            else
            {
                messageText = "Загруженных файлов нет";
            }

            await Bot.SendTextMessageAsync(message.Chat.Id, messageText);

        }

        /// <summary>
        /// Отправляет фото пользователю
        /// </summary>
        /// <param name="path"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task SendPhoto(string path, Message message)
        {
            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = path.Split(Path.DirectorySeparatorChar).Last();
            await Bot.SendPhotoAsync(
                chatId: message.Chat.Id,
                photo: new InputOnlineFile(fileStream, fileName),
                caption: "Ваша картинка"
            );
        }

        /// <summary>
        /// Отправляет документ
        /// </summary>
        /// <param name="path"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task SendDocument(string path, Message message)
        {
            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = path.Split(Path.DirectorySeparatorChar).Last();
            await Bot.SendDocumentAsync(
                chatId: message.Chat.Id,
                document: new InputOnlineFile(fileStream, fileName),
                caption: "Ваш документ"
            );
        }

        /// <summary>
        /// Отправялет голосовое сообщение
        /// </summary>
        /// <param name="path"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task SendVoice(string path, Message message)
        {
            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = path.Split(Path.DirectorySeparatorChar).Last();
            await Bot.SendVoiceAsync(
                chatId: message.Chat.Id,
                voice: new InputOnlineFile(fileStream, fileName),
                caption: "Ваше голосовое сообщение"
                );
        }

        /// <summary>
        /// Вывод меню команд
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task Usage(Message message)
        {
            const string usage = "Команды:\n" +
                                    "/start - отправляет приветственное сообщение\n" +
                                    "/listfiles - выводит список загруженных файлов\n" +
                                    "/about - выводит информацию о боте\n" +
                                    "/help - выводит список команд \n" +
                                    "Для загрузки файлов на сервер просто отправь их боту\n" +
                                    "Для загрузки файлов с сервера - введи название документа";
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: usage,
                replyMarkup: new ReplyKeyboardRemove()
            );
        }

        /// <summary>
        /// Выводит информацию о боте
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task About(Message message)
        {
            string messageText = "Бот обладает следующим набором функций:\n" +
                "Принимает сообщения и команды от пользователя.\n" +
                "Сохраняет аудиосообщения, картинки и произвольные файлы.\n" +
                "Позволяет пользователю просмотреть список загруженных файлов.\n" +
                "Позволяет скачать выбранный файл.";
            await Bot.SendTextMessageAsync(message.Chat.Id, messageText);
        }

        /// <summary>
        /// Проверяет создана ли папка для текущего пользователя
        /// </summary>
        /// <param name="path"></param>
        static void CheckFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Ищет указанный файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        static bool FindFile(string fileName, string path)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                if (file.Split("/")[^1] == fileName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
