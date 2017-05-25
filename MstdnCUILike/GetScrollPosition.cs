using System;
using System.Collections.Generic;
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

        /// <summary>
        /// スクロール位置が先頭かの判定
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static bool IsScrollBarFirst(System.IntPtr handle, ScrollBarKind kind) {
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
        public static bool IsScrollBarEnd(System.IntPtr handle, ScrollBarKind kind, int height) {
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
    }
}
