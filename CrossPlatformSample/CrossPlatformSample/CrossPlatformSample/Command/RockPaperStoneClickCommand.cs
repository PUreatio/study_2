using CrossPlatformSample.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrossPlatformSample.Command
{
    /// <summary>
    /// じゃんけんボタンクリックコマンド
    /// </summary>
    public class RockPaperStoneClickCommand : ICommand
    {
        /// <summary>実行可否判定変更イベント</summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>実行後イベント</summary>
        public event EventHandler<string> Executed;

        /// <summary>
        /// 実行可能判定
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>実行可否判定</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// コマンド実行
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        public void Execute(object parameter)
        {
            Hand ownHand = (Hand)Enum.Parse(typeof(Hand), parameter.ToString());
            // 自分の出した手に対応するメッセージを取得する。
            string ownHandMessage = this.GetHandMessage(Messages.OWN_HAND_FORMAT, ownHand);

            string resultMessage = null;
            // 相手の手と勝負結果を取得する。
            switch (ownHand)
            {
                case Hand.Rock:
                    resultMessage = this.GetGameResultMessage(Hand.Scissors, Hand.Paper, ownHandMessage);
                    break;
                case Hand.Scissors:
                    resultMessage = this.GetGameResultMessage(Hand.Paper, Hand.Rock, ownHandMessage);
                    break;
                case Hand.Paper:
                    resultMessage = this.GetGameResultMessage(Hand.Rock, Hand.Scissors, ownHandMessage);
                    break;
            }

            // 結果を表示する。
            Executed(this, resultMessage);
        }

        /// <summary>
        /// 自分の出した手を取得する。
        /// </summary>
        /// <param name="format"メッセージフォーマット
        /// <param name="hand">じゃんけんの手</param>
        /// <returns>手に対応したメッセージ</returns>
        private string GetHandMessage(string format, Hand hand)
        {
            string handMessage = null;

            switch (hand)
            {
                // グーの場合
                case Hand.Rock:
                    handMessage = string.Format(format, Messages.HAND_ROCK);
                    break;
                // チョキの場合
                case Hand.Scissors:
                    handMessage = string.Format(format, Messages.HAND_SCISSORS);
                    break;
                // パーの場合
                case Hand.Paper:
                    handMessage = string.Format(format, Messages.HAND_PAPRE);
                    break;
            }

            return handMessage;
        }

        /// <summary>
        /// 勝負判定し、結果メッセージを取得する。
        /// </summary>
        /// <param name="winHand">相手が出せば自分が勝つ手</param>
        /// <param name="looseHand">相手が出せば自分が負ける手</param>
        /// <param name="ownHandMessage">自分が出した手に対応するメッセージ</param>
        /// <returns>結果メッセージ</returns>
        private string GetGameResultMessage(Hand winHand, Hand looseHand, string ownHandMessage)
        {
            // 相手の手を取得する。
            Tuple<Hand, string> opponentHand = this.GetOpponentHand();
            string gameResultMessage = Messages.DRAW;

            // 相手が勝ちな場合
            if (opponentHand.Item1 == winHand)
            {
                gameResultMessage = Messages.WIN;
            }
            // 相手が負けな場合
            else if (opponentHand.Item1 == looseHand)
            {
                gameResultMessage = Messages.LOSE;
            }

            string resultMessage = string.Format(Messages.RESULT_FORMAT, ownHandMessage,
                Environment.NewLine, opponentHand.Item2, Environment.NewLine,
                gameResultMessage);
            return resultMessage;
        }

        /// <summary>
        /// 相手の出した手を取得する。
        /// </summary>
        /// <returns>相手の手</returns>
        private Tuple<Hand, string> GetOpponentHand()
        {
            // 乱数を生成する。
            Random rnd = new Random();
            int iRnd = rnd.Next(3);

            // 乱数から相手の手を取得する。
            Hand opponentHand = (Hand)Enum.Parse(typeof(Hand), iRnd.ToString());
            string opponentHandMessage = this.GetHandMessage(Messages.OPPONENT_HAND_FORMAT, opponentHand);

            Tuple<Hand, string> opponentHandTuple = Tuple.Create<Hand, string>(opponentHand, opponentHandMessage);
            return opponentHandTuple;
        }
    }
}
