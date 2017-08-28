namespace FFireManage.Controls
{
    partial class MediaControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaControl));
            this.listView1 = new System.Windows.Forms.ListView();
            this.m_LargeImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_addRemark = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_deleteMediaFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddImage = new System.Windows.Forms.ToolStripButton();
            this.btnAddAudio = new System.Windows.Forms.ToolStripButton();
            this.btnAddVideo = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteMedias = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.m_LargeImageList;
            this.listView1.Location = new System.Drawing.Point(0, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(671, 405);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // m_LargeImageList
            // 
            this.m_LargeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_LargeImageList.ImageStream")));
            this.m_LargeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_LargeImageList.Images.SetKeyName(0, "btnAdd.png");
            this.m_LargeImageList.Images.SetKeyName(1, "download_blue.png");
            this.m_LargeImageList.Images.SetKeyName(2, "loading_throbber.png");
            this.m_LargeImageList.Images.SetKeyName(3, "MediaThumbnail.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddImage,
            this.btnAddAudio,
            this.btnAddVideo,
            this.toolStripSeparator1,
            this.btnDeleteMedias});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(671, 27);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_addRemark,
            this.MenuItem_deleteMediaFile});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // MenuItem_addRemark
            // 
            this.MenuItem_addRemark.Name = "MenuItem_addRemark";
            this.MenuItem_addRemark.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_addRemark.Text = "添加备注";
            this.MenuItem_addRemark.Click += new System.EventHandler(this.MenuItem_addRemark_Click);
            // 
            // MenuItem_deleteMediaFile
            // 
            this.MenuItem_deleteMediaFile.Name = "MenuItem_deleteMediaFile";
            this.MenuItem_deleteMediaFile.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_deleteMediaFile.Text = "删除媒体文件";
            this.MenuItem_deleteMediaFile.Click += new System.EventHandler(this.MenuItem_deleteMediaFile_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Image = global::FFireManage.Properties.Resources.image24;
            this.btnAddImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(80, 24);
            this.btnAddImage.Text = "添加图片";
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnAddAudio
            // 
            this.btnAddAudio.Image = global::FFireManage.Properties.Resources.audio24;
            this.btnAddAudio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAudio.Name = "btnAddAudio";
            this.btnAddAudio.Size = new System.Drawing.Size(80, 24);
            this.btnAddAudio.Text = "添加音频";
            this.btnAddAudio.Click += new System.EventHandler(this.btnAddAudio_Click);
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.Image = global::FFireManage.Properties.Resources.video24;
            this.btnAddVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(80, 24);
            this.btnAddVideo.Text = "添加视频";
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            // 
            // btnDeleteMedias
            // 
            this.btnDeleteMedias.Image = global::FFireManage.Properties.Resources.deleteMedias24;
            this.btnDeleteMedias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteMedias.Name = "btnDeleteMedias";
            this.btnDeleteMedias.Size = new System.Drawing.Size(104, 24);
            this.btnDeleteMedias.Text = "移除所有媒体";
            this.btnDeleteMedias.Click += new System.EventHandler(this.btnDeleteMedias_Click);
            // 
            // MediaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MediaControl";
            this.Size = new System.Drawing.Size(671, 432);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddImage;
        private System.Windows.Forms.ToolStripButton btnAddAudio;
        private System.Windows.Forms.ToolStripButton btnAddVideo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDeleteMedias;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_addRemark;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_deleteMediaFile;
        private System.Windows.Forms.ImageList m_LargeImageList;
    }
}
