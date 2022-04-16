#if UNITY_IOS
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;

namespace YabbiAds.Editor
{
    public class IOSPostProcessBuild
    {
        private const string Description =
            "Your data will be used to provide you a better and personalized ad experience.";

        [PostProcessBuild(0)]
        public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuildProject)
        {
            if (buildTarget != BuildTarget.iOS) return;
            var plistPath = pathToBuildProject + "/Info.plist";
            var plist = new PlistDocument();
            plist.ReadFromFile(plistPath);

            plist.ReadFromString(File.ReadAllText(plistPath));
            var root = plist.root;

            // Set the description key-value in the plist:
            root.SetString("NSUserTrackingUsageDescription", Description);

            // Set the description key-value in the plist:
            root.SetString("NSLocationWhenInUseUsageDescription", Description);

            // Save changes to the plist:
            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}
#endif