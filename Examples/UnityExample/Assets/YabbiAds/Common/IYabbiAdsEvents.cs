namespace YabbiAds.Common
{
    public interface IEventListener
    {
        void OnLoad(); //метод вызывается когда рекламный контент был успешно загружен
        void OnFail(string error); //вызывается при происхождении ошибки препятствующей загрузке рекламы
        void OnShow(); //вызывается в момент показа рекламы пользователю
        void OnComplete(); //вызывается в VideoAdContainer в момент окончания видео, в случае rewarded типа видео можно награждать пользователя по этому событию
        void OnClose(); //вызывается при закрытии пользователем рекламного окна
    }
}