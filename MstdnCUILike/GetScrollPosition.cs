using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MstdnCUILike {
    class GetScrollPosition {
        public enum ScrollBarKind {
            Horizonal = 0x0000,
            Vertical = 0x0001
        }
        [DllImport("USER32.DLL", CharSet = CharSet.Auto)]
        private static extern int GetScrollPos(
            System.IntPtr handle,
            ScrollBarKind kind
        );

        [DllImport("USER32.DLL", CharSet = CharSet.Auto)]
        private static extern bool GetScrollRange(
            System.IntPtr handle,
            ScrollBarKind kind,
            out int iMinimum,
            out int lMaximum
        );

        [DllImport("USER32.DLL")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd, 
            Int32 Msg, 
            Int32 wParam, 
            out Point lParam
        );

        /// <summary>
        /// スクロール位置が先頭かの判定
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static bool IsScrollBarFirst(IntPtr handle, ScrollBarKind kind) {
            int iMinimum = 0;
            int iMaximum = 0;

            if (!GetScrollRange(handle, kind, out iMinimum, out iMaximum)) {
                return false;
            }

            int iPostion = GetScrollPos(handle, kind);

            if (iPostion > iMinimum) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// スクロール位置が末尾かの判定
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static bool IsScrollBarEnd(IntPtr handle, ScrollBarKind kind, int height) {
            int iMinimum = 0;
            int iMaximum = 0;

            if (!GetScrollRange(handle, kind, out iMinimum, out iMaximum)) {
                return false;
            }

            int iPostion = GetScrollPos(handle, kind);

            // 無理やり感あふれる調整方法
            if (iPostion + height + DefaultValues.SCROLL_SUB < iMaximum) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// スクロール位置の取得
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static Point GetPoint(IntPtr handle) {
            Point point = new Point(0, 0);
            SendMessage(handle, 0x04DD, 0, out point);
            return point;
        }

        /// <summary>
        /// スクロール位置の設定
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static void SetPoint(IntPtr handle, Point point) {
            SendMessage(handle, 0x04DE, 0, out point);
        }
    }
}
