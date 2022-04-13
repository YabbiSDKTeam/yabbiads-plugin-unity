namespace YabbiAds.Unity.Common
{
    public interface IEventListener
    {
        void onLoad(); //метод вызывается когда рекламный контент был успешно загружен
        void onFail(string error); //вызывается при происхождении ошибки препятствующей загрузке рекламы
        void onShow(); //вызывается в момент показа рекламы пользователю
        void onComplete(); //вызывается в VideoAdContainer в момент окончания видео, в случае rewarded типа видео можно награждать пользователя по этому событию
        void onClose(); //вызывается при закрытии пользователем рекламного окна
    }
}