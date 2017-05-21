using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

/// <summary>
/// 権限・他画面呼び出しサンプルアプリ
/// </summary>
namespace AuthoritySample
{
    [Activity(Label = "PreferenceActivity")]
    public class PreferenceActivity : Activity
    {
        /// <summary>
        /// 初期化時イベント
        /// </summary>
        /// <see cref="Activity.OnCreate(Bundle)"/>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // レイアウトを関連付ける。
            SetContentView(Resource.Layout.Preference);
        }
    }
}