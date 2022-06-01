# YabbiAds Unity Plugin

## Руководство по Интеграции

Версия релиза **1.1.0** | Дата релиза **31.05.2022**


> Минимальные требования:
>
>* Используйте Unity 2018.3+ версии.
>
>* Используйте Android API level 19 (Android OS 4.4) и выше.
>
>* Используйте iOS 12.0 и выше.
>
>* Используйте XCode 13 или выше.

## Демо приложение
Используйте наше [демо приложение](https://github.com/YabbiSDKTeam/yabbiads-unity-demo) в качестве примера.


## Оглавление
* [Шаг 1. Установка SDK](#Шаг-1.-Установка-SDK)
    * [1.1 Скачайте Плагин](1.1-Скачайте-Плагин)
    * [1.2 Установите Плагин](1.2-Установите-Плагин)
* [Шаг 2. Подготовка Приложения](#Шаг-2.-Подготовка-Приложения)
    * [2.1 Настройки для Android платформы](#2.1-Настройки-для-Android-платформы)
        * [2.1.1 Обновите Версию Gradle Плагина](#2.1.1-Обновите-Версию-Gradle)
        * [2.1.2 Настройка-External-Dependency-Manager](#2.1.2-Настройка-External-Dependency-Manager)
        * [2.1.3 Настройка AndroidManifest.xml](#2.1.3-Настройка-AndroidManifest.xml)
        * [2.1.4 Запрос геолокации пользователя](#2.1.4-Запрос-геолокации-пользователя)
    * [2.2 Настройки для iOS платформы](#2.2-Настройки-для-iOS-платформы)
        * [2.2.1 Настройка Info.plist](#2.2.1-Настройка-Info.plist)
* [Шаг 3. Инициализация SDK](#Шаг-3.-Инициализация-SDK)
    * [3.1 Добавьте пространства имен](#3.1-Добавьте-пространства-имен)
    * [3.2 Добавьте код в метод Start() главного скрипта MonoBehavior](#3.2-Добавьте-код-в-метод-Start()-главного-скрипта-MonoBehavior)
* [Шаг 4. Настройка типов рекламы](#Шаг-4.-Настройка-типов-рекламы)

## Шаг 1. Установка SDK

### 1.1 Скачайте Плагин
Загрузите **YabbiAds Unity Plugin 1.0.0**. Он включает в себя последнии версии Android и IOS Yabbi SDK.

### 1.2 Установите Плагин
Чтобы импортировать в проект YabbiAds Unity Plugin, дважды щелкните по YabbiAds-Unity-Plugin-1.0.0.unitypackage файлу, или перейдите в **Assets** → **Import Package** → **Custom Package**. В открывшемся окне, нажмите на кнопку **Import**, оставив все файлы выделенными.

## Шаг 2. Подготовка Приложения
### 2.1 Настройки для Android платформы
#### 2.1.1 Обновите Версию Gradle

Подготовьте Gradle сборки для Android 11
>
>В Android 11 изменился способ запроса приложений и взаимодействия с другими.
приложениями, установленными пользователем на устройстве.
По этой причине убедитесь, что вы используете версию Gradle,
которая соответствует одной из перечисленных [здесь](https://developer.android.com/studio/releases/gradle-plugin#4-0-0).

#### 2.1.2 Настройка External Dependency Manager

External Dependency Manager уже включен в плагин.
Для разрешения конфликтов зависимостей в вашем приложении выполните следующие шаги:

1. После импорта плагина в редакторе Unity выберите File → Build Settings → Android.
2. Добавьте флаг Custom Gradle Template для Unity 2018.4 - Unity 2019.2 версий или Custom Main Gradle Template для Unity 2019.3 или выше (Build Settings → Player Settings → Publishing settings).
3. Добавьте флаг Custom Launcher Gradle Template (Build Settings → Player Settings → Publishing settings).
4. Включите настройку - "Patch mainTemplate.gradle" (Assets → External Dependency Manager → Android Resolver → Settings).
5. Включите настройку - "Use Jetifier" (Assets → External Dependency Manager → Android Resolver → Settings).
6. Затем выберите Assets → External Dependency Manager → Android Resolver и нажмите Resolve или Force Resolve.
7. Добавьте следующий код в launcherTemplate.gradle
```gradle
android {
   
    // другие настройки
        
    defaultConfig {
        
        // другие настройки
          
        multiDexEnabled true
    }
}
```
8. Модули, которые необходимы для работы будут импортированы в mainTemplate.gradle вашего проекта.

#### 2.1.3 Настройка AndroidManifest.xml

Мы различаем 2 типа разрешений: обязательные разрешения, без которых SDK не может работать, и дополнительные, необходимые для улучшения таргетинга.

Это обязательные разрешения:

```xml
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
<uses-permission android:name="android.permission.INTERNET" />
```
Это дополнительные разрешения:

```xml
<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />
<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" /> 
```

Добавьте все обязательные разрешения в **AndroidManifest.xml** вашего проекта.
Если вы хотите использовать какие-либо дополнительные разрешения, добавьте их после обязательных разрешений.

#### 2.1.4 Запрос геолокации пользователя
Для эффективного таргетирования рекламы SDK собирает данные геолокации.
Начиная с Android 6.0 (API level 23) для доступа к геолокации требуется разрешение пользователя. Для предоставления разрешений на Android платформе мы рекомендуем использовать плагин [UnityAndroidRuntimePermissions](https://github.com/yasirkula/UnityAndroidRuntimePermissions), который позволяет получать результат от пользователь синхронным кодом.

> iOS SDK запрашивает геолокацию автоматически, и не требует изменений в коде.

### 2.2 Настройки для iOS платформы


#### 2.2.1 Настройка Info.plist
Следующие ключи помогут улучшить таргетинг рекламы:

**NSUserTrackingUsageDescription** - Начиная с iOS 14 использование IDFA требует разрешения от пользователя. Добавление описания поможет объяснить пользователю необходимость данного разрешения.

**NSLocationWhenInUseUsageDescription** - Необходимо добавлять если в вашем приложении можно использовать данные геолокации.


## Шаг 3. Инициализация SDK
Перед тем, как начать загрузку рекламы, вам необходимо инициализировать SDK следующим образом:

### 3.1 Добавьте пространства имен

```c#
using YabbiAds.Api;
using YabbiAds.Common;
```

### 3.2  Добавьте код в метод `Start()`  главного скрипта `MonoBehavior`
```c#
var configuration = new YabbiConfiguration("YOUR_PUBLISHER_ID", "YOUR_INTERSTITIAL_ID", "YOUR_REWARDED_ID");
Yabbi.Initialize(configuration);
```
1. Замените YOUR_PUBLISHER_KEY на ключ издателя из [личного кабинета](https://mobileadx.ru).
2. Замените YOUR_INTERSTITIAL_ID на ключ соответствующий баннерной рекламе из [личного кабинета](https://mobileadx.ru).
3. Замените YOUR_REWARDED_ID на ключ соответствующий видео с вознаграждением из [личного кабинета](https://mobileadx.ru).


## Шаг 4. Настройка типов рекламы
YabbiAds SDK готов к использованию.  
YabbiAds предоставляет на выбор 2 типа рекламы.
Вы можете ознакомиться с установкой каждого типа в соответствующей документации:

1. [Полноэкранный баннер](docs/INTERSTITIAL_AD_DOC.MD)
2. [Полноэкранный видео баннер](docs/REWARDED_AD_DOC.MD)

## Возможные ошибки

### iOS
1. Ошибка биткода при сборке архива

```
bitcode bundle could not be generated because 'path_to_your_project/build  
/iOS/Frameworks/Plugins/iOS/YabbiAds/YabbiSdk.framework/YabbiSdk'
was built without full bitcode.
```

Чтобы исправить ошибку перейдите в ваш проект(Unity-iPhone) → Build Settings. В пункте Build Options установите значение параметра Enable Bitcode на false.
