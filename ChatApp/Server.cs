using ChatCommon;
using ChatNetwork;
using System;
using System.Collections.Generic;

namespace ChatApp
{
    public class Server<T>
    {
        private Dictionary<String, T> clients = new Dictionary<string, T>();

        private IMessageSource<T> messageSource;

        public Server(IMessageSource<T> source)
        {
            messageSource = source;
        }

        private void Register(Message message, T fromep)
        {
            Console.WriteLine("Message Register, name = " + message.FromName);
            clients.Add(message.FromName, fromep);


            // Добавьте сохранение пользователя в базу данных здесь
        }

        private void ConfirmMessageReceived(int? id)
        {
            Console.WriteLine("Message confirmation id=" + id);

            // Обновите статус сообщения в базе данных здесь
        }

        private void RelyMessage(Message message)
        {
            int? id = null;
            if (clients.TryGetValue(message.ToName, out T ep))
            {
                // Добавьте отправку сообщения клиенту с помощью messageSource.Send() здесь
                Console.WriteLine($"Message Relied, from = {message.FromName} to = {message.ToName}");
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
            }
        }

        private void ProcessMessage(Message message, T fromep)
        {
            Console.WriteLine($"Получено сообщение от {message.FromName} для {message.ToName} с командой {message.Command}:");
            Console.WriteLine(message.Text);


            if (message.Command == Command.Register)
            {
                Register(message, messageSource.CopyT(fromep));

            }
            if (message.Command == Command.Confirmation)
            {
                Console.WriteLine("Confirmation receiver");
                ConfirmMessageReceived(message.Id);
            }
            if (message.Command == Command.Message)
            {
                RelyMessage(message);
            }
        }

        private bool work = true;
        public void Stop()
        {
            work = false;
        }

        public void Work()
        {

            Console.WriteLine("NetMQ сервер ожидает сообщений...");

            while (work)
            {

                try
                {

                    T remoteEndPoint = messageSource.CreateNewT();
                    var message = messageSource.Receive(ref remoteEndPoint);

                    if (message == null)
                        return;

                    ProcessMessage(message, remoteEndPoint);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при обработке сообщения: " + ex.Message);
                }
            }

        }
    }
}
