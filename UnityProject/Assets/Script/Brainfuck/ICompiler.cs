namespace Brainfuck
{
    /// <summary>
    /// 解釈する構文
    /// </summary>
    public interface ICompiler
    {
        string nxt { get; }     // ポインタを右へ移動
        string inc { get; }     // ポインタの指す値を1増やす
        string prv { get; }     // ポインタを左へ移動
        string dec { get; }     // ポインタの指す値を1減らす
        string opn { get; }     // ポインタの指す値が0なら 対応するCLSまでジャンプする
        string cls { get; }     // ポインタの指す値が0ではいなら 対応するOPNまでジャンプする
        string put { get; }     // ポインタの指す値を出力する
        string get { get; }     // 入力から1バイト読み込む
    }
}
