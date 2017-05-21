using Android.App;
using Android.OS;
using Android.Preferences;

namespace AuthoritySample
{
    [Activity(Label = "PrefActivity")]
    public class PrefFragment : PreferenceFragment
    {
        /// <summary>
        /// 初期化時イベント
        /// </summary>
        /// <param name="bundle"></param>
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AddPreferencesFromResource(Resource.Xml.Preferences);
        }
    }
}