using Android.App;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using System.IO;
using Android.Views;
using Android.Content;
using Android.Runtime;
using Android.Preferences;
using System;
using AndroidEnvironment = Android.OS.Environment;

/// <summary>
/// 権限・他画面呼び出しサンプルアプリ
/// </summary>
namespace AuthoritySample
{
    [Activity(Label = "AuthoritySample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        /// <summary>設定画面へのリクエストコード</summary>
        private const int PREF_REQUEST_CODE = 0;

        /// <summary>
        /// 初期化時イベント
        /// </summary>
        /// <see cref="Activity.OnCreate(Bundle)"/>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // レイアウトを関連付ける。
            this.SetContentView(Resource.Layout.Main);

            // 初期化する。
            this.Initialize();
        }

        /// <see cref="Activity.OnCreateOptionsMenu(IMenu)"/>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // 作成したメニューを関連付ける。
            this.MenuInflater.Inflate(Resource.Xml.Menu, menu);

            return true;
        }

        /// <see cref="Activity.OnOptionsItemSelected(IMenuItem)"/>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                // 設定が選択された場合
                case Resource.Id.settings:
                    // 設定画面を起動する。
                    this.StartActivityForResult(typeof(PreferenceActivity), PREF_REQUEST_CODE);
                    break;
            }

            return true;
        }

        /// <see cref="Activity.OnActivityResult(int, Result, Intent)"/>
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            // 設定画面から遷移している場合
            if (PREF_REQUEST_CODE == requestCode)
            {
                // 表示状態を初期化する。
                InitializeDisplay();
            }
        }

        /// <summary>
        /// 出力ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void OutButton_Click(object sender, System.EventArgs e)
        {
            TextView telNumberView = this.FindViewById<TextView>(Resource.Id.telNumber);
            // ファイルに表示番号を書き込む。
            this.WriteExternalStorage(string.Format("{0}: [{1}]", DateTime.Now.ToString(), telNumberView.Text));

            // Toastを表示する。
            Toast.MakeText(this, this.GetExternalFilePath(), ToastLength.Long).Show();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Initialize()
        {
            // イベントを関連付ける。
            Button outButton = this.FindViewById<Button>(Resource.Id.buttonOut);
            outButton.Click += OutButton_Click;

            // 表示状態を初期化する。
            this.InitializeDisplay();
        }

        /// <summary>
        /// 表示初期化処理
        /// </summary>
        private void InitializeDisplay()
        {
            // 共通設定を取得する。
            ISharedPreferences pref = PreferenceManager.GetDefaultSharedPreferences(this);

            bool validTelNumber = pref.GetBoolean(this.GetString(Resource.String.ShowNumber), true);
            TextView telNumberView = this.FindViewById<TextView>(Resource.Id.telNumber);
            Button outButton = this.FindViewById<Button>(Resource.Id.buttonOut);
            // 電話番号表示が有効な場合
            if (validTelNumber)
            {
                telNumberView.Text = this.GetTelNumber();
                outButton.Enabled = true;
            }
            // 電話番号表示が無効な場合
            else
            {
                // 外部ファイルから読み込んだ内容を表示する。
                telNumberView.Text = this.ReadByExternalStorage();
                outButton.Enabled = false;
            }
        }

        /// <summary>
        /// 電話番号を取得する。
        /// </summary>
        /// <returns>電話番号</returns>
        private string GetTelNumber()
        {
            TelephonyManager tm = this.GetSystemService(Activity.TelephonyService) as TelephonyManager;
            // 電話番号を取得する。
            return tm.Line1Number;
        }

        /// <summary>
        /// ストレージからファイルを読み込む。
        /// </summary>
        /// <returns>ファイル内容</returns>
        private string ReadByExternalStorage()
        {
            // ファイルパスを取得する。
            string filePath = this.GetExternalFilePath();
            string fileContents = null;

            if (File.Exists(filePath))
            {
                // ファイル内容をすべて読み込む。
                fileContents = File.ReadAllText(filePath);
            }

            return fileContents;
        }

        /// <summary>
        /// 外部ストレージ上のファイルにコンテンツを保存する。
        /// </summary>
        /// <param name="contents">保存コンテンツ</param>
        private void WriteExternalStorage(string contents)
        {
            // ファイルパスを取得する。
            string filePath = this.GetExternalFilePath();

            // ファイルに保存する。
            File.WriteAllText(filePath, contents);
        }

        /// <summary>
        /// 外部ストレージに保存するファイルパスを取得する。
        /// </summary>
        /// <returns>ファイルパス</returns>
        private string GetExternalFilePath()
        {
            string dirPath = AndroidEnvironment.ExternalStorageDirectory.AbsolutePath;

            return Path.Combine(dirPath, "AuthoritySample.txt");
        }
    }
}

