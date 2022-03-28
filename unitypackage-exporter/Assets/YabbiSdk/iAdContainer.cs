using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me.Yabbi.Ads
{
    public interface IAdContainer {
        void SetAlwaysRequestLocation(bool isEnabled);
        void Load(IAdEvents adEvents);
        bool IsLoaded();
        void Show();
    }
}