using UniRx;
using GameDevelopment.Common.Datas;
using UnityEngine;
using UnityEngine.UI;

public class OfficeNameUI : NewBehaviour
{
    /// <summary>
    /// メッセージテキスト
    /// </summary>
    [SerializeField]
    private Text _messageText = default;

    /// <summary>
    /// 文字入力用フィールド
    /// </summary>
    [SerializeField]
    private InputField _inputField = default;

    /// <summary>
    /// オフィス作成決定ボタン
    /// </summary>
    [SerializeField]
    private Button _okButton = default;

    private void Start()
    {
        //// 文字の入力が終了したら...
        //// 
        //_inputField
        //    .OnEndEditAsObservable()
        //    .Subscribe(_ => Debug.Log(_inputField.text))
        //    .AddTo(this);

        GameInfo.Load();
        GameInfo.User.CreateCompany("うんこ");
        _messageText.text = "名前を入力してください。";

        // OKボタンが押され...
        // オフィス名が入力されていたら...
        // オフィスを作成する。
        _okButton
            .OnClickAsObservable()
            .Where(_ => IsCreateOffice())
            .Subscribe(_ => CreateOffice())
            .AddTo(this);
    }

    /// <summary>
    /// オフィスを作成できるか？
    /// </summary>
    /// <remarks>
    /// TRUE:  オフィスを作成出来る
    /// FALSE: オフィスを作成出来ない
    /// </remarks>
    /// <returns></returns>
    private bool IsCreateOffice()
    {
        // 名前が入力されていないならfalse
        // 同じ名前のオフィスがあるならfalse
        if (_inputField.text == string.Empty) { return false; }
        foreach(var office in GameInfo.User.Company.Offices)
        {
            if(office.Name == _inputField.text)
            {
                _messageText.text = "同じ名前のオフィスがあります\n" +
                                    "違う名前に変更してください。";
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// オフィス作成
    /// </summary>
    private void CreateOffice()
    {
        // オフィス作成
        // 社員を生成
        GameInfo.User.Company.CreateOffice(_inputField.text);
        for(int i = 0; i < 1; i++)
        {
            GameInfo.User.Company.CurrentOffice.CreateEmployees(0);
        }

        SceneFadeManager.Instance.Transition(SceneName.Company);
        Destroy(this.gameObject);
    }
}
