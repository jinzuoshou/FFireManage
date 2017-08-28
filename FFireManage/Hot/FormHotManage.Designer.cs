namespace FFireManage.Hot
{
    partial class FormHotManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.navigationControl1 = new FFireManage.Controls.NavigationControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pager1 = new FFireManage.Controls.PagerControl1();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_Feedback = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Examine = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationControl1
            // 
            this.navigationControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationControl1.Location = new System.Drawing.Point(0, 0);
            this.navigationControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navigationControl1.Name = "navigationControl1";
            this.navigationControl1.Size = new System.Drawing.Size(986, 44);
            this.navigationControl1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 44);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(986, 486);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "热点编号";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "所属县局";
            this.columnHeader3.Width = 86;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "热点类型";
            this.columnHeader6.Width = 129;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "上报人";
            this.columnHeader4.Width = 97;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "上报时间";
            this.columnHeader5.Width = 294;
            // 
            // pager1
            // 
            this.pager1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pager1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager1.Location = new System.Drawing.Point(0, 530);
            this.pager1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 0;
            this.pager1.PageSize = 20;
            this.pager1.Size = new System.Drawing.Size(986, 30);
            this.pager1.TabIndex = 18;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Feedback,
            this.MenuItem_Examine});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // MenuItem_Feedback
            // 
            this.MenuItem_Feedback.Name = "MenuItem_Feedback";
            this.MenuItem_Feedback.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_Feedback.Text = "热点反馈";
            this.MenuItem_Feedback.Click += new System.EventHandler(this.MenuItem_Feedback_Click);
            // 
            // MenuItem_Examine
            // 
            this.MenuItem_Examine.Name = "MenuItem_Examine";
            this.MenuItem_Examine.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_Examine.Text = "热点审核";
            this.MenuItem_Examine.Click += new System.EventHandler(this.MenuItem_Examine_Click);
            // 
            // FormHotManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 560);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.navigationControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormHotManage";
            this.Text = "热点管理";
            this.Load += new System.EventHandler(this.FormFormHotManage_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NavigationControl navigationControl1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private Controls.PagerControl1 pager1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Feedback;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Examine;
    }
}