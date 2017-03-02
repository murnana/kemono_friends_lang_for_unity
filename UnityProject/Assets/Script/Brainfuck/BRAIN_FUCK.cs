namespace Brainfuck
{
    using System;

    public enum BRAIN_FUCK
    {
        NXT,    // ポインタを右へ移動
        INC,    // ポインタの指す値を1増やす
        PRV,    // ポインタを左へ移動
        DEC,    // ポインタの指す値を1減らす
        OPN,    // ポインタの指す値が0なら 対応するCLSまでジャンプする
        CLS,    // ポインタの指す値が0ではいなら 対応するOPNまでジャンプする
        PUT,    // ポインタの指す値を出力する
        GET     // 入力から1バイト読み込む
    }

    public static class BRAIN_FUCK_CONST
    {
        public static readonly int MAX = Enum.GetNames(typeof(BRAIN_FUCK)).Length;
    }
}