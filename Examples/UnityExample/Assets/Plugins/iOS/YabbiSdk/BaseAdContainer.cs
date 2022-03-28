using System;
using System.Runtime.InteropServices;
using UnityEngine;
using AOT;

namespace Me.Yabbi.Ads
{
    public class BaseAdContainer : MonoBehaviour, IAdContainer
    {   
        private const string kIdeError = "Swift not supported in Unity IDE.";

        private IAdEvents adEvents;

        private long hash;


        public  BaseAdContainer(string publisherId, string unitId, long type){
            #if UNITY_IOS && !UNITY_EDITOR
             hash = _createContainer(publisherId,  unitId,  type);
            
            #endif
        }


        #region Declare external C interface

#if UNITY_IOS && !UNITY_EDITOR
           

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            private delegate void _callBackType([MarshalAs(UnmanagedType.LPStr), In] string type, string message);

            [DllImport("__Internal")]
            private static extern long _createContainer(string publisherId, string unitId, long type);
            [DllImport("__Internal")]
            private static extern void _loadContainer([MarshalAs(UnmanagedType.FunctionPtr)] _callBackType callback, long hash);
            [DllImport("__Internal")]
            private static extern void _showContainer([MarshalAs(UnmanagedType.FunctionPtr)] _callBackType callback, long hash);
            [DllImport("__Internal")]
            private static extern void _setAlwaysRequestLocation(bool isEnabled, long hash);
            [DllImport("__Internal")]
            private static extern bool _isLoaded(long hash);
            [DllImport("__Internal")]
            private static extern void _dispose(long hash);
            
            [MonoPInvokeCallback(typeof(_callBackType))]
            private static void _callBackHandler(string type, string message)
            {       
                _callBackAction(type, message);
            }

            private static event Action<string, string> _callBackAction;

#endif

        #endregion

        public void SetAlwaysRequestLocation(bool isEnabled)
        {
            #if UNITY_IOS && !UNITY_EDITOR
                _setAlwaysRequestLocation(isEnabled, hash);
            #endif
        }

       public void Load(IAdEvents events)
       {
           
            adEvents = events;

            #if UNITY_IOS && !UNITY_EDITOR

             _callBackAction = (string type, string message) =>
            {
                switch (type)
                {
                    case "onLoad":
                    adEvents.onLoad();
                        break;
                    case "onShow":
                    adEvents.onShow();
                        break;
                    case "onFail":
                    adEvents.onFail(message);
                        break;
                    case "onClose":
                    adEvents.onClose();
                        break;
                    case "onComplete":
                    adEvents.onComplete();
                        break;
                    case "YabbiAdsException":
                    adEvents.onFail(message);
                        break;
                    default:
                        adEvents.onFail("No case found for " + type + "with message: " + message);
                        break;
                }
            };

             _loadContainer(_callBackHandler, hash);
            #else
            if(adEvents != null){
                adEvents.onFail(kIdeError);
             }
            #endif
       }

        public bool IsLoaded()
        {
            #if UNITY_IOS && !UNITY_EDITOR
            return _isLoaded(hash);
            #else
            return false;
            #endif
        }

        public void Show()
        {
            #if UNITY_IOS && !UNITY_EDITOR
              _showContainer(_callBackHandler, hash);
            #else
            if(adEvents != null){
                adEvents.onFail(kIdeError);
            }
            #endif
        }

        private void OnDestroy() 
        {
            Dispose();
        }

        public void Dispose()
        {
            #if UNITY_IOS && !UNITY_EDITOR
            _dispose(hash);
             #endif
        }
    }
}