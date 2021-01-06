using UniRx;
using System;
using System.IO;
using System.Collections.Generic;
//using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Csvのロードを管理するクラス
/// </summary>
public class CsvLoadManager : SingletonMonoBehaviour<CsvLoadManager>
{

    /// <summary>
    /// 全てのダウンロードが完了したか？
    /// </summary>
    /// <remarks>
    /// TRUE:  ダウンロード完了
    /// FALSE: 未完了
    /// </remarks>
    private BoolReactiveProperty _downloadCompletedFlg = new BoolReactiveProperty(false);

    /// <summary>
    /// ダウンロードが終了していたらイベントを発行
    /// </summary>
    public IObservable<Unit> OnDownloadFinished
    {
        get
        {
            // ダウンロードが完了していたら、即イベント発行
            // Observable.Return 値を一つだけ発行したいときに使用
            if (_downloadCompletedFlg.Value) return Observable.Return(Unit.Default);

            // ダウンロード中なら終わったときにイベント発行
            // FirstOrDefault 一番最初に到達したOnNextのみを流してObservableを完了させる
            // AsUnitObservable == Select(_ > Unit.Default)メッセージをUnit型に変換
            return _downloadCompletedFlg.FirstOrDefault(x => !x).AsUnitObservable();
        }
    }

    //private async UniTaskVoid LoadCsvAsync()
    //{
    //    // Resources.LoadでResourcesフォルダのcsvファイル読み込み
    //    // Unityのテキスト読み込み用形式であるTextAssetに変換
    //    // TextAssetのtextを読み込み専用クラスであるStringReaderに格納
    //    List<string[]> csvDatas = new List<string[]>();
    //    TextAsset csvFile = Resources.Load(Path_Employee) as TextAsset;
    //    StringReader reader = new StringReader(csvFile.text);
    //    yield return null;

    //    // , で分割しつつ一行ずつ読み込み
    //    // リストに追加していく
    //    while (reader.Peek() != -1)
    //    {
    //        string line = reader.ReadLine();
    //        csvDatas.Add(line.Split(','));
    //    }

    //    // Levelデータとして格納
    //    // 最初のデータ要素は格納しない、(Level, Skin)などの文字列のため
    //    for (int i = 0; i < csvDatas.Count; i++)
    //    {
    //        if (i == 0) { continue; }
    //        //LevelDataParam param = new LevelDataParam(csvDatas[i]);
    //        //LevelData.List.Add(param);
    //    }

    //    _downloadCompletedFlg.Value = true;
    //}

    /// <summary>
    /// 社員のCsvデータをロードする。
    /// </summary>
    /// <returns></returns>
    private void LoadEmployeeCsvAsync()
    {
        // Resources.LoadでResourcesフォルダのcsvファイル読み込み
        // Unityのテキスト読み込み用形式であるTextAssetに変換
        // TextAssetのtextを読み込み専用クラスであるStringReaderに格納
        List<string[]> csvDatas = new List<string[]>();
        TextAsset csvFile = Resources.Load(PathData.CsvEmployee) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }

        // Levelデータとして格納
        // 最初のデータ要素は格納しない、(Level, Skin)などの文字列のため
        for (int i = 0; i < csvDatas.Count; i++)
        {
            if (i == 0) { continue; }
            //LevelDataParam param = new LevelDataParam(csvDatas[i]);
            //LevelData.List.Add(param);
        }

        _downloadCompletedFlg.Value = true;
    }
}