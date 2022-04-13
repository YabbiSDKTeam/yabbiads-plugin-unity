using System;

public interface IAdEvents
{
    void onLoad(); //метод вызывается когда рекламный контент был успешно загружен
    void onFail(string error); //вызывается при происхождении ошибки препятствующей загрузке рекламы
    void onShow(); //вызывается в момент показа рекламы пользователю
    void onComplete(); //вызывается в VideoAdContainer в момент окончания видео, в случае rewarded типа видео можно награждать пользователя по этому событию
    void onClose(); //вызывается при закрытии пользователем рекламного окна
}


public interface IAdMobEvents
{
    //void onLoad(object sender, EventArgs args); //метод вызывается когда рекламный контент был успешно загружен
    void onFail(object sender, EventArgs args); //вызывается при происхождении ошибки препятствующей загрузке рекламы
    // void onShow(object sender, EventArgs args); //вызывается в момент показа рекламы пользователю
    void onComplete(object sender, EventArgs args); //вызывается в VideoAdContainer в момент окончания видео, в случае rewarded типа видео можно награждать пользователя по этому событию
    void onClose(object sender, EventArgs args); //вызывается при закрытии пользователем рекламного окна
}
