using CrossPlatformSample.Command;
using CrossPlatformSample.Constant;
using CrossPlatformSample.IF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrossPlatformSample
{
    /// <summary>
    /// 電話番号ViewModel
    /// </summary>
    public class RockScissorsStoneViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>初期表示メッセージ</summary>
        private string topMessage = null;
        /// <summary>じゃんけん結果</summary>
        private string result = null;

        /// <summary>ボタンクリックコマンド</summary>
        public ICommand RockPaperStoneClick { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RockScissorsStoneViewModel()
        {
            // 初期表示メッセージ設定
            this.topMessage = string.Format(Messages.RESULT_INIT_MESSAGE, Environment.NewLine);
            this.result = string.Format(Messages.READY_MESSAGE, Environment.NewLine);

            // イベント関連付け
            RockPaperStoneClickCommand rockPaperStoneClick = new RockPaperStoneClickCommand();
            rockPaperStoneClick.Executed += RockScissorsStoneClick_Executed;
            this.RockPaperStoneClick = rockPaperStoneClick;
        }

        /// <summary>
        /// 実行後イベント
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void RockScissorsStoneClick_Executed(object sender, string e)
        {
            this.Result = e;

            // 結果をToastで表示する。
            DependencyService.Get<IToast>().Show(e);
        }

        /// <summary>
        /// 初期表示メッセージ
        /// </summary>
        public string TopMessage
        {
            get { return this.topMessage; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.topMessage = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(TopMessage)));
                }
            }
        }
        /// <summary>
        /// じゃんけん結果
        /// </summary>
        public string Result
        {
            get { return this.result; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.result = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Result)));
                }
            }
        }
    }
}
