using UnityEngine;
using System.Collections;

namespace Me.Yabbi.Ads
{
    public interface IAdEvents
    {
        void onLoad();
        void onFail(string error);
        void onShow();
        void onClose();
        void onComplete();
    }
}
