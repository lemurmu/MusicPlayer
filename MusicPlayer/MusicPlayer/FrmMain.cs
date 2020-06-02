using DevExpress.XtraBars.Docking2010;
using MusicPlayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace MusicPlayer
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
            PlayerOne();
        }

        private string fileFolder = "music";

        private void PlayerOne()
        {
            string[] musicfiles = Directory.GetFiles(fileFolder, "*.mp3");
            IWMPPlaylist playList = mediaPlayer.playlistCollection.newPlaylist("MyPlayList"); //新建列表
            foreach (var musciFile in musicfiles)
            {
                IWMPMedia media = mediaPlayer.newMedia(musciFile);
                playList.appendItem(media);
            }

            mediaPlayer.currentPlaylist = playList;
            mediaPlayer.Ctlcontrols.play();    //开始播放


        }

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            string tag = btn.Tag as string;
            switch (tag)
            {
                case "pre":
                    mediaPlayer.Ctlcontrols.previous();
                    break;
                case "next":
                    mediaPlayer.Ctlcontrols.next();
                    break;
                case "pause":
                    mediaPlayer.Ctlcontrols.pause();
                    btn.ImageOptions.Image = Resources.play_32x32;
                    btn.Tag = "start";
                    break;
                case "start":
                    mediaPlayer.Ctlcontrols.play();
                    btn.ImageOptions.Image = Resources.pause_32x32;
                    btn.Tag = "pause";
                    break;
                default:
                    break;
            }
        }
    }
}
