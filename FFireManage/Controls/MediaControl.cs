using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FFireManage.Utility;
using FFireManage.Model;
using System.Diagnostics;
using FFireManage.Service;

namespace FFireManage.Controls
{
    public partial class MediaControl : UserControl
    {
        #region 字段与属性
        private string t_path = "";
        private List<MediaFile> _mediaFiles = null;
        FormDownloadMediaProcess formProcess = null;
        private ListViewItem currentItem = null;

        private Dictionary<string, object> mediaByteDict = new Dictionary<string, object>();
        public Dictionary<string, object> MediaByteDict
        {
            get
            {
                this.GetMediaFileDict();
                return mediaByteDict;
            }
        }

        public List<MediaFile> MediaFiles
        {
            get 
            {
                return this._mediaFiles; 
            }
            set
            {
                this._mediaFiles = value;
                this.UpdateShowMediaThumbImg(this._mediaFiles);
            }
        }

        public ToolStrip MainToolStrip
        {
            get { return this.toolStrip1; }
        }

        public event EventHandler AddEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler DeleteAllEvent;
        
        #endregion

        #region 构造函数
        public MediaControl()
        {
            InitializeComponent();

            //多媒体临时文件（下载的原媒体和缩略图）
            this.t_path = Application.StartupPath + "\\Temp";
        }
        #endregion

        #region 多媒体操作
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片文件(*.jpg,*.png,*.bmp,*.gif,*.jpeg)|*.jpg;*.png;*.bmp;*.gif;*.jpeg";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    string file = openFileDialog.FileNames[i];
                    string guid = Guid.NewGuid().ToString();

                    string t_file = this.t_path + "\\" + guid + Path.GetFileName(file);

                    using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

                    {
                        ImageHelper.CutForSquare(fileStream, t_file, 64, 100);

                        Image image = Image.FromFile(t_file);

                        this.m_LargeImageList.Images.Add(image);

                        ListViewItem new_item = new ListViewItem(Path.GetFileName(file));

                        var into = new MediaFile()
                        {
                            local_file = file,
                            fileName = Path.GetFileName(file)
                        };

                        new_item.Tag = into;
                        new_item.ImageIndex = this.m_LargeImageList.Images.Count - 1;

                        this.listView1.Items.Insert(0, new_item);
                    }
                }
                if (AddEvent != null)
                {
                    AddEvent(this.mediaByteDict, new EventArgs());
                }
            }
            
        }

        private void btnAddAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "音频文件(*.wav,*.mp3)|*.wav;*.mp3";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    string file = openFileDialog.FileNames[i];
                    string guid = Guid.NewGuid().ToString();

                    string t_file = this.t_path + "\\" + guid + Path.GetFileName(file);

                    ListViewItem new_item = new ListViewItem(Path.GetFileName(file));

                    var into = new MediaFile()
                    {
                        local_file = file,
                        fileName = Path.GetFileName(file)
                    };
                    new_item.Tag = into;
                    new_item.ImageIndex = 3;

                    this.listView1.Items.Insert(0, new_item);
                }
                if (AddEvent != null)
                {
                    AddEvent(this.mediaByteDict, new EventArgs());
                }
            }
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "视频文件(*.avi,*.mp4,*.rmvb,*.flv)|*.avi;*.mp4;*.rmvb;*.flv";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    string file = openFileDialog.FileNames[i];
                    string guid = Guid.NewGuid().ToString();

                    string t_file = this.t_path + "\\" + guid + Path.GetFileNameWithoutExtension(file) + ".jpg";
                    VideoHelper.VideoSnapshots(file, t_file, 64, 100);

                    Image image = Image.FromFile(t_file);

                    this.m_LargeImageList.Images.Add(image);

                    ListViewItem new_item = new ListViewItem(Path.GetFileName(file));

                    var into = new MediaFile()
                    {
                        local_file = file,
                        fileName = Path.GetFileName(file)
                    };
                    new_item.Tag = into;
                    new_item.ImageIndex = this.m_LargeImageList.Images.Count - 1;

                    this.listView1.Items.Insert(0, new_item);
                }
            }
            if (AddEvent != null)
            {
                AddEvent(this.mediaByteDict, new EventArgs());
            }
        }

        private void btnDeleteMedias_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            if(this.DeleteAllEvent!=null)
            {
                this.DeleteAllEvent(this.MediaFiles, new EventArgs());
            }
        }
        #endregion

        #region 缩略图下载并显示
        /// <summary>
        /// 下载缩略图并显示
        /// </summary>
        /// <param name="mediaFiles">多媒体列表</param>
        private void UpdateShowMediaThumbImg(List<MediaFile> mediaFiles)
        {
            Task task = new Task(() => 
            {
                this.Invoke(new Action(() =>
                {
                    LoadMediaFilesForThumbImg(mediaFiles,new BaseService());
                }));
            });
            task.Start();
            
        }

        private void LoadMediaFilesForThumbImg(List<MediaFile> mediaFiles,BaseService service)
        {
            LoadTempThumbImgs(mediaFiles);
            for (int i = 0; i < mediaFiles.Count; i++)
            {
                try
                {
                    MediaFile info = mediaFiles[i];
                    /* 如果当type=3，表示为音频类型，不解析 */
                    if (info.fileType == 3)
                        continue;

                    string file = info.fileThumbUrl;

                    string t_file = this.t_path + "\\" + Path.GetFileName(file);

                    ImageHelper.GetWebImage(service.GetHomeUrl() + "/" + file, t_file, UpdateMediaDownloadProgress, LoadMediaItemForThumbImg, info);
                }
                catch 
                {
                    continue;
                }

            }
        }

        /// <summary>
        /// 加载临时缩略图
        /// </summary>
        /// <param name="mediaFiles"></param>
        private void LoadTempThumbImgs(List<MediaFile> mediaFiles)
        {
            for (int i = 0; i < mediaFiles.Count; i++)
            {
                MediaFile info = mediaFiles[i];
                if (mediaFiles[i].fileType == 3)
                {
                    ListViewItem new_item = new ListViewItem(info.fileName);
                    new_item.Tag = info;
                    new_item.ImageIndex = 3;//临时图片]
                    new_item.Name = Path.GetFileName(info.fileUrl);
                    this.listView1.Items.Insert(0, new_item);
                    continue;
                }
                try
                {
                    string file = info.fileThumbUrl;

                    string t_file = this.t_path + "\\" + Path.GetFileName(file);

                    ListViewItem new_item = new ListViewItem(info.fileName);
                    new_item.Tag = info;
                    new_item.ImageIndex = 1;//临时图片
                    new_item.Name = Path.GetFileName(t_file);

                    this.listView1.Items.Insert(0, new_item);
                }
                catch 
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 缩略图下载进度
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="userData"></param>
        private void UpdateMediaDownloadProgress(object filePath, object userData)
        {
            if (filePath == null)
                return;

            string t_file = filePath.ToString();

            ListViewItem new_item = this.listView1.Items[Path.GetFileName(t_file)];
            if (new_item == null)
                return;
            new_item.Text = "已下载 " + userData.ToString() + "%";
        }

        /// <summary>
        /// 下载完成后加载媒体缩略图
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="userData"></param>
        private void LoadMediaItemForThumbImg(object filePath, object userData)
        {
            if (filePath == null)
                return;

            string t_file = filePath.ToString();
            if (!System.IO.File.Exists(t_file))
                return;

            MediaFile info = userData as MediaFile;

            Image image = Image.FromFile(t_file);
            if (image == null)
                return;
            this.m_LargeImageList.Images.Add(image);

            ListViewItem new_item = this.listView1.Items[Path.GetFileName(t_file)];
            new_item.Tag = info;
            new_item.Text = info.fileName;
            new_item.ImageIndex = this.m_LargeImageList.Images.Count - 1;

        }
        #endregion

        #region  原始媒体下载与显示
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.listView1.GetItemAt(e.X, e.Y);
            if (item != null && item.Tag != null && item.Tag is MediaFile)
            {
                MediaFile media = item.Tag as MediaFile;
                if (File.Exists(media.local_file))
                {
                    try
                    {
                        Process.Start(media.local_file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    if (media == null)
                        return;
                    UpdateShowMedia(item);
                }
            }
        }

        /// <summary>
        /// 显示原始媒体
        /// </summary>
        /// <param name="item"></param>
        private void UpdateShowMedia(ListViewItem item)
        {
            Task task = new Task(() =>
            {
                this.Invoke(new Action(() =>
                {
                    LoadShowMedia(item, new BaseService());
                }));
            });
            task.Start();
        } 

        /// <summary>
        /// 加载显示原始媒体
        /// </summary>
        /// <param name="item">ListViewItem项</param>
        /// <param name="service"></param>
        private void LoadShowMedia(ListViewItem item, BaseService service)
        {
            if(item != null && item.Tag != null && item.Tag is MediaFile)
            {
                MediaFile info = item.Tag as MediaFile;

                string file = info.fileUrl;
                string t_file = this.t_path + "\\" + Path.GetFileName(file);
                formProcess = new FormDownloadMediaProcess();
                formProcess.Show();

                ImageHelper.GetWebImage(service.GetHomeUrl() + "/" + file, t_file, formProcess.UpdateMediaDownloadProgress, OpenMediaFile, info);
            }
        }

        /// <summary>
        /// 下载完成后打开媒体文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="userData"></param>
        private void OpenMediaFile(object filePath, object userData)
        {
            if (filePath == null)
                return;

            string t_file = filePath.ToString();
            if (!System.IO.File.Exists(t_file))
                return;
            if (formProcess != null)
                formProcess.Close();
            MediaFile info = userData as MediaFile;
            
            info.local_file = t_file;
            try
            {
                Process.Start(t_file);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "打开多媒体信息提示");
            }

        }
        #endregion

        #region 右键菜单
        /// <summary>
        /// 右键菜单显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                currentItem = this.listView1.GetItemAt(e.X, e.Y);
                if (currentItem == null)
                    return;
                this.contextMenuStrip1.Show(this, e.Location);
            }
        }

        /// <summary>
        /// 添加备注
        /// </summary>
        private void MenuItem_addRemark_Click(object sender, EventArgs e)
        {
            if (currentItem == null)
                return;

            ImageRemarkForm frm = new ImageRemarkForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                currentItem.Text = MediaRemarkEventManageClass.image_sremark;
            }
        }

        /// <summary>
        /// 删除媒体
        /// </summary>
        private void MenuItem_deleteMediaFile_Click(object sender, EventArgs e)
        {
            if (currentItem == null)
                return;
            this.listView1.Items.Remove(currentItem);
            MediaFile mediaFile = currentItem.Tag as MediaFile;
            if (mediaFile != null && string.IsNullOrEmpty(mediaFile.id))
            {
                if (DeleteEvent != null)
                {
                    DeleteEvent(mediaFile, new EventArgs());
                }
            }
        }
        #endregion

        private void GetMediaFileDict()
        {
            for(int i=0; i<this.listView1.Items.Count;i++)
            {
                ListViewItem item = this.listView1.Items[i];
                if(item.Tag != null && item.Tag is MediaFile)
                {
                    MediaFile media = item.Tag as MediaFile;
                    if (media == null)
                        continue;
                    if((media.fileUrl==null || media.fileUrl=="") && (media.local_file!=null || media.local_file!= ""))
                    {
                        if(!mediaByteDict.ContainsKey(media.fileName))
                            //byte[] mediaBytes = ImageHelper.ImgToByteArray(media.local_file);
                            mediaByteDict.Add(media.fileName, media.local_file);
                    }
                }
            }
        }
    }
}
