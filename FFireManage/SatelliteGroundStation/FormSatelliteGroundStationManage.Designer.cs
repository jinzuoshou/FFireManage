namespace FFireManage.SatelliteGroundStation
{
    partial class FormSatelliteGroundStationManage
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pagerControl1 = new FFireManage.Controls.PagerControl1();
            this.navigationControl1 = new FFireManage.Controls.NavigationControl();
            this.SuspendLayout();
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
            this.listView1.Location = new System.Drawing.Point(0, 41);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(922, 399);
            this.listView1.TabIndex = 34;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "卫星地面站名称";
            this.columnHeader2.Width = 132;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "所属县局";
            this.columnHeader3.Width = 86;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "管理员";
            this.columnHeader6.Width = 129;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "经度";
            this.columnHeader4.Width = 97;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "纬度";
            this.columnHeader5.Width = 294;
            // 
            // pagerControl1
            // 
            this.pagerControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerControl1.Location = new System.Drawing.Point(0, 440);
            this.pagerControl1.Margin = new System.Windows.Forms.Padding(3, 16, 3, 16);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.NMax = 0;
            this.pagerControl1.PageCount = 0;
            this.pagerControl1.PageCurrent = 0;
            this.pagerControl1.PageSize = 20;
            this.pagerControl1.Size = new System.Drawing.Size(922, 35);
            this.pagerControl1.TabIndex = 35;
            // 
            // navigationControl1
            // 
            this.navigationControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationControl1.Location = new System.Drawing.Point(0, 0);
            this.navigationControl1.Margin = new System.Windows.Forms.Padding(3, 67, 3, 67);
            this.navigationControl1.Name = "navigationControl1";
            this.navigationControl1.Size = new System.Drawing.Size(922, 41);
            this.navigationControl1.TabIndex = 33;
            // 
            // FormSatelliteGroundStationManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 475);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pagerControl1);
            this.Controls.Add(this.navigationControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSatelliteGroundStationManage";
            this.Text = "卫星地面站点";
            this.Load += new System.EventHandler(this.FormFireForestBeltManage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private Controls.PagerControl1 pagerControl1;
        private Controls.NavigationControl navigationControl1;
    }
}