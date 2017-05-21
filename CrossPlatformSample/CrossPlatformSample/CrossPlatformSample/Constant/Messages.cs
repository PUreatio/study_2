using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformSample.Constant
{
    /// <summary>
    /// メッセージ
    /// </summary>
    public class Messages
    {
        /// <summary>初期表示メッセージ</summary>
        public const string READY_MESSAGE = "さいしょはグー！{0}じゃんけん・・・・・";
        /// <summary>結果初期表示メッセージ</summary>
        public const string RESULT_INIT_MESSAGE = "じゃんけんしよう！{0}じゃんけんしよう！";
        /// <summary>自分が出す手</summary>
        public const string OWN_HAND_FORMAT = "あなたの手：{0}";
        /// <summary>相手が出す手</summary>
        public const string OPPONENT_HAND_FORMAT = "相手の手：{0}";
        /// <summary>結果メッセージ</summary>
        public const string RESULT_FORMAT = "{0}{1}{2}{3}{4}！";

        /// <summary>グー</summary>
        public const string HAND_ROCK = "グー";
        /// <summary>チョキ</summary>
        public const string HAND_SCISSORS = "チョキ";
        /// <summary>パー</summary>
        public const string HAND_PAPRE = "パー";

        /// <summary>あなたの勝ち！</summary>
        public const string WIN = "あなたの勝ち！";
        /// <summary>あなたの負け！</summary>
        public const string LOSE = "あなたの負け！";
        /// <summary>あいこ！</summary>
        public const string DRAW = "あいこ！";
    }
}
