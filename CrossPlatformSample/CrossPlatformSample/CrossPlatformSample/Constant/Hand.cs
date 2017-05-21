using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformSample.Constant
{
    /// <summary>
    /// じゃんけんの手
    /// </summary>
    public enum Hand : int
    {
        /// <summary>初期値</summary>
        None = -1,
        /// <summary>グー</summary>
        Rock = 0,
        /// <summary>チョキ</summary>
        Scissors = 1,
        /// <summary>パー</summary>
        Paper = 2
    }
}
