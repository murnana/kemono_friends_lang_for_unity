namespace KemonoFriendsLang
{
    using System.Text;

    /// <summary>
    /// コンパイラ
    /// </summary>
    public sealed class Compiler : Brainfuck.ICompiler
    {
        public string nxt { get { return "たのしー！"; } }          // ポインタを右へ移動
        public string inc { get { return "たーのしー！"; } }         // ポインタの指す値を1増やす
        public string prv { get { return "すごーい！"; } }          // ポインタを左へ移動
        public string dec { get { return "すっごーい！"; } }        // ポインタの指す値を1減らす
        public string opn { get { return "うわー！"; } }            // ポインタの指す値が0なら 対応するCLSまでジャンプする
        public string cls { get { return "わーい！"; } }            // ポインタの指す値が0ではいなら 対応するOPNまでジャンプする
        public string put { get { return "なにこれなにこれ！"; } }  // ポインタの指す値を出力する
        public string get { get { return "おもしろーい！"; } }      // 入力から1バイト読み込む

        /// <summary>
        /// Output ASCII char
        /// </summary>
        /// <param name="value">ASCII code</param>
        /// <returns></returns>
        public string なにこれなにこれ(byte value)
        {
            var encoding = Encoding.ASCII;
            return encoding.GetString(new byte[] { value });
        }
    }
}