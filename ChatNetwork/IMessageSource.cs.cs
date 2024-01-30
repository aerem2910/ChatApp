using ChatCommon;

namespace ChatNetwork
{
    public interface IMessageSource<T>
    {
        void Send(Message message, T toAddr);
        Message Receive(ref T fromAddr);
        T CreateNewT();
        T CopyT(T t);
    }

    public interface IMessageSourceClient<T>
    {
        void Send(Message message, T toAddr);
        Message Receive(ref T fromAddr);
        T CreateNewT();
        T GetServer();
    }
}
