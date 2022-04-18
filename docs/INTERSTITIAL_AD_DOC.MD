# Полноэкранный баннер
Баннер показывается пользователю на весь экран, с возможностью закрыть баннер и перейти по рекламной ссылке.

## Инициализация
1. Добавьте пространства имен

```c#
using YabbiAds.Api;
using YabbiAds.Common;
```
2.  Добавьте код в метод `Start()`  главного скрипта `MonoBehavior`
```c#
Yabbi.Initialize("YOUR_PUBLISHER_KEY");
Yabbi.InitializeAd("YOUR_UNIT_ID", YabbiAdsType.Interstitial);
```
3. Замените YOUR_PUBLISHER_KEY на ключ издателя из [личного кабинета](https://mobileadx.ru).
4. Замените YOUR_UNIT_ID на ключ соответствующий баннерной рекламе из [личного кабинета](https://mobileadx.ru).

## Методы обратного вызова
Для работы с рекламой необходимо предоставить класс для передачи событий жизненного цикла рекламного контейнера.
Для инициализации рекламного контейнера выполните следующие действия:
1. Наследуйте Ваш класс от IInterstitialAdListener:
```c#
YourClassName : IInterstitialAdListener;
```
2. Затем вызовите следующий метод:
```c#
Yabbi.SetInterstitialCallbacks(this);
```
4. Теперь вы можете использовать следующие методы в своем коде:
```c#
// Вызывется при загрузке рекламы
public void OnInterstitialLoaded()
{
    print("Interstitial loaded");
}

// Вызывется если при работе рекламы произошла ошибка
public void OnInterstitialFailed(string error)
{
    print("Interstitial failed");
}

// Вызывается при показе рекламы
public void OnInterstitialShown()
{
    print ("Interstitial shown");
}

// Вызывается при закрытии рекламы
public void OnInterstitialClosed()
{
    print("Interstitial closed");
}
```
>Все методы вызываются в потоках Android/iOS.


## Проверка инициализации рекламы
Вы можете проверить статус инициализации перед работы с рекламой.
```c#
Yabbi.IsAdInitialized(YabbiAdsType.Interstitial);
```

## Запрос разрешения геопозиции
Для улучшенного таргетинга YabbiAds требуется доступ к приблизительной геопозиции пользователя. 
Вы можете отключить эту функцию:
```c#
Yabbi.SetAlwaysRequestLocation(YabbiAdsType.Interstitial, false);
```

## Загрузка рекламы
Для загрузки рекламы используйте метод:
```c#
Yabbi.LoadAd(YabbiAdsType.Interstitial);
```

## Проверка загрузки рекламы
Вы можете проверить статус загрузки перед работы с рекламой.
```c#
Yabbi.IsAdLoaded(YabbiAdsType.Interstitial);
```
Рекомендуем всегда проверять статус загрузки рекламы, прежде чем пытаться ее показать.
```c#
if(Yabbi.IsAdLoaded(YabbiAdsType.Interstitial)) {
    Yabbi.ShowAd(YabbiAdsType.Interstitial);
}
```

## Показ рекламы
Для показа рекламы используйте метод:
```c#
Yabbi.ShowAd(YabbiAdsType.Interstitial);
```

## Уничтожение рекламного контейнера
Для уничтожения рекламного контейнера из памяти добавьте следующий код в вашем приложении.
```c#
Yabbi.DestroyAd(YabbiAdsType.Interstitial);
```

>После уничтожение рекламного контейнера, дальнейшее использование его - не возможно.  
>Для повторного использования контейнера вернитесь к пунктну [Инициализация](#инициализация).