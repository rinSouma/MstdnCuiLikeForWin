﻿using Mastonet;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using System;

namespace MstdnCUILike {
    class MediaEditClass {
        private MastodonClient client;
        public MediaEditClass(ref MastodonClient client) {
            this.client = client;
        }

        enum Flg{
            None = 0,
            Source = 1,
            Status = 2
        }

        // メディアアップロード処理
        public async Task<IEnumerable<int>> UploadMedia(List<string> pathList) {
            List<int> idList = new List<int>();
            if(pathList.Count >= 5) {
                throw new Exception("投稿できる画像は４つまで");
            }
            foreach (var path in pathList) {
                var fileName = Path.GetFileName(path);
                try {
                    var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    var attatch = await client.UploadMedia(fs, fileName);
                    fs.Dispose();

                    if (attatch == null) {
                        throw new Exception("画像のアップロードに失敗");
                    }

                    idList.Add(attatch.Id);
                } catch (Exception ex) {
                    throw ex;
                }
            }
            return idList;
        }

        // コマンド解析処理
        public async Task<MediaClass> AnalysisCommand(string command) {
            List<string> pathList = new List<string>();
            MediaClass mc = new MediaClass();
            Flg flg = Flg.None;

            TextFieldParser parser = new TextFieldParser(new MemoryStream(Encoding.UTF8.GetBytes(command)));
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(" ");
            mc.sensitive = false;
            var data = parser.ReadFields();
            foreach(var param in data) {
                if(param == DefaultValues.CMD_IMAGE) {
                    continue;
                }
                
                if(param == DefaultValues.IMAGE_CMD_NSFW) {
                    mc.sensitive = true;
                    continue;
                }

                if(param == DefaultValues.IMAGE_CMD_SOURCE) {
                    flg = Flg.Source;
                    continue;
                }
                if (param == DefaultValues.IMAGE_CMD_STATUS) {
                    flg = Flg.Status;
                    continue;
                }
                switch (flg) {
                    case Flg.Source:
                        pathList.Add(param);
                        break;
                    case Flg.Status:
                        mc.status = param;
                        break;
                }
            }
            // メディアアップロード
            try {
                mc.mediaId = await UploadMedia(pathList);
            } catch (Exception ex) {
                throw ex;
            }
            return mc;
        }
    }
}
