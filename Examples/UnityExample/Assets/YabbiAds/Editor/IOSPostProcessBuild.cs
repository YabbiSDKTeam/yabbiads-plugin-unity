#if UNITY_IOS
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;

namespace YabbiAds.Editor
{
    public class IOSPostProcessBuild
    {
        private const string _description =
            "Your data will be used to provide you a better and personalized ad experience.";

        [PostProcessBuild(0)]
        public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuildProject)
        {
            if (buildTarget == BuildTarget.iOS)
            {
                string plistPath = pathToBuildProject + "/Info.plist";
                PlistDocument plist = new PlistDocument();
                plist.ReadFromFile(plistPath);

                plist.ReadFromString(File.ReadAllText(plistPath));
                PlistElementDict root = plist.root;

                // Set the description key-value in the plist:
                root.SetString("NSUserTrackingUsageDescription", _description);

                // Set the description key-value in the plist:
                root.SetString("NSLocationWhenInUseUsageDescription", _description);

                // Save changes to the plist:
                File.WriteAllText(plistPath, plist.WriteToString());
            }
        }
    }
}
#endif