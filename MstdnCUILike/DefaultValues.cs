using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstdnCUILike {
    class DefaultValues {
        public const int MAX_CHARS = 500;
        public const int SCROLL_SUB = 20;
        public const string MSG_OK = "OK";
        public const string MSG_CANCEL = "Cancel";

        public const string FST_SETTING_MSG = "初期設定をしてください";
        public const string ERR_SETTING_MSG = "初期設定を見直してください";

        public const string STATUS_SUCCESS_MSG = "成功";
        public const string STATUS_ERROR_MSG = "失敗";
        public const string STATUS_NULL_MSG = "空文字はＮＧ";
        public const string STATUS_OVER_MSG = "ちょっと文字数多すぎるんちゃう？";

        public const string DIALOG_TITLE_CONFILM = "確認";
        public const string DIALOG_MSG_COMMIT = "設定を保存します";
        public const string DIALOG_MSG_CANCEL = "設定を保存せずに戻ります";
        public const string DIALOG_MSG_CREAR = "編集中の設定をクリアします";

        public const string MSTDN_HOST = "mstdn-workers.com";
        public const string MSTDN_AUTHPATH = "/api/v1/apps";
        public const string MSTDN_TOKENPATH = "/oauth/token";
        public const string MSTDN_TOOTPATH = "/api/v1/statuses";
        public const string MSTDN_STMLTLPATH = "/api/v1/streaming/public";
        public const string MSTDN_IMGPATH = "/media";
        public const string MSTDN_SCOPE = "read write";

        public const string CMD_SETTING = ":setting";
        public const string CMD_END = ":exit";

        public const string STREAM_TAG = "tag";
        public const string STREAM_BR = "<br />";

        public const string MSG_OPPAI = "おっぱい";
        public const string MSG_MER = "マー";
    }
}
