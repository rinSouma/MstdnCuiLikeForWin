using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstdnCUILike {
    class MediaClass {
        private string _status;
        public string status{
            get { return this._status; }
            set {
                this._status = value;
                if(this._status == string.Empty) {
                    this._status = DefaultValues.MSG_SPACE;
                }
            }
        }
        public IEnumerable<int> mediaId { get; set; }
        public bool sensitive { get; set; }
        public string spoiler;

        public MediaClass() {
            // 空白だとメッセージなしトゥートできなかったん
            this.status = DefaultValues.MSG_SPACE;
            this.sensitive = false;
            this.spoiler = string.Empty;
        }
    }
}
