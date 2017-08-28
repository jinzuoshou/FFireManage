using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace FFireManage.Controls
{
    public partial class CoordinatesInputControl2 : UserControl
    {
        private double longitude;
        private double latitude;

        /// <summary>
        /// 控制所返回的经度值
        /// </summary>
        public double Longitude
        {
            get
            {
                this.UpdateValue();
                return longitude;
            }
            set
            {
                if (this.longitude != value)
                {
                    this.longitude = value;
                    this.UpdateShow();
                }
            }
        }

        /// <summary>
        /// 控件所返回的纬度值
        /// </summary>
        public double Latitude
        {
            get
            {
                this.UpdateValue();
                return latitude;
            }
            set
            {
                if (this.latitude != value)
                {
                    this.latitude = value;
                    this.UpdateShow();
                }
            }
        }

        public CoordinatesInputControl2()
        {
            InitializeComponent();
        }

        private void rbtDegree_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtDegree.Checked)
            {
                this.panDegreeMinutes.Visible = false;
                this.panDegreeMinutesSeconds.Visible = false;

                this.panDegree.Visible = true;
            }

        }

        private void rbtDegreeMinutes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtDegreeMinutes.Checked)
            {
                this.panDegree.Visible = false;
                this.panDegreeMinutesSeconds.Visible = false;

                this.panDegreeMinutes.Visible = true;
            }
        }

        private void rbtDegreeMinutesSeconds_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtDegreeMinutesSeconds.Checked)
            {
                this.panDegree.Visible = false;
                this.panDegreeMinutes.Visible = false;

                this.panDegreeMinutesSeconds.Visible = true;
            }
        }

        public void UpdateValue()
        {
            //try
            //{
            //    if (this.rbtDegree.Checked == true)
            //    {
            //        this.longitude = Math.Round(Convert.ToDouble(tbxLongitudeDegree1.Text), 7);
            //        this.latitude = Math.Round(Convert.ToDouble(tbxLatitudeDegree1.Text), 7);

            //    }
            //    else if (this.rbtDegreeMinutes.Checked == true)
            //    {
            //        this.longitude = Math.Round(Convert.ToDouble(tbxLongitudeDegree2.Text) + Convert.ToDouble(tbxLongitudeMinutes2.Text) / 60, 7);
            //        this.latitude = Math.Round(Convert.ToDouble(tbxLatitudeDegree2.Text) + Convert.ToDouble(tbxLatitudeMinutes2.Text) / 60, 7);

            //    }
            //    else if (this.rbtDegreeMinutesSeconds.Checked == true)
            //    {
            //        this.longitude = Math.Round(Convert.ToDouble(tbxLongitudeDegree3.Text) + Convert.ToDouble(tbxLongitudeMinutes3.Text) / 60 + Convert.ToDouble(tbxLongitudeSeconds3.Text) / 60 / 60, 7);
            //        this.latitude = Math.Round(Convert.ToDouble(tbxLatitudeDegree3.Text) + Convert.ToDouble(tbxLatitudeMinutes3.Text) / 60 + Convert.ToDouble(tbxLatitudeSeconds3.Text) / 60 / 60, 7);
            //    }
            //}
            //catch (Exception)
            //{
            //}

            try
            {
                if (this.rbtDegree.Checked == true)
                {
                    this.longitude = Convert.ToDouble(tbxLongitudeDegree1.Text);
                    this.latitude = Convert.ToDouble(tbxLatitudeDegree1.Text);

                }
                else if (this.rbtDegreeMinutes.Checked == true)
                {
                    this.longitude = Convert.ToDouble(tbxLongitudeDegree2.Text) + Convert.ToDouble(tbxLongitudeMinutes2.Text) / 60;
                    this.latitude = Convert.ToDouble(tbxLatitudeDegree2.Text) + Convert.ToDouble(tbxLatitudeMinutes2.Text) / 60;

                }
                else if (this.rbtDegreeMinutesSeconds.Checked == true)
                {
                    this.longitude = Convert.ToDouble(tbxLongitudeDegree3.Text) + Convert.ToDouble(tbxLongitudeMinutes3.Text) / 60 + Convert.ToDouble(tbxLongitudeSeconds3.Text) / 60 / 60;
                    this.latitude = Convert.ToDouble(tbxLatitudeDegree3.Text) + Convert.ToDouble(tbxLatitudeMinutes3.Text) / 60 + Convert.ToDouble(tbxLatitudeSeconds3.Text) / 60 / 60;
                }
            }
            catch (Exception)
            {
            }

        }

        public void UpdateShow()
        {
            //if (rbtDegree.Checked == true)
            //{
            //    tbxLongitudeDegree1.Text = Math.Round(this.longitude, 7).ToString();
            //    tbxLatitudeDegree1.Text = Math.Round(this.latitude, 7).ToString();
            //}
            //else if (rbtDegreeMinutes.Checked == true)
            //{
            //    tbxLongitudeDegree2.Text = ((int)this.longitude).ToString();
            //    tbxLatitudeDegree2.Text = ((int)this.latitude).ToString();

            //    int lenth1 = this.longitude.ToString().IndexOf('.');
            //    if (lenth1 > 0)
            //    {
            //        tbxLongitudeMinutes2.Text = Math.Round(((this.longitude - (int)this.longitude) * 60), 5).ToString();
            //    }
            //    else
            //    {
            //        tbxLongitudeMinutes2.Text = "0";
            //    }

            //    int lenth2 = this.latitude.ToString().IndexOf('.');
            //    if (lenth2 > 0)
            //    {
            //        tbxLatitudeMinutes2.Text = Math.Round(((this.latitude - (int)this.latitude) * 60), 5).ToString();
            //    }
            //    else
            //    {
            //        tbxLatitudeMinutes2.Text = "0";
            //    }
            //}
            //else if (rbtDegreeMinutesSeconds.Checked == true)
            //{
            //    tbxLongitudeDegree3.Text = Convert.ToInt32(Math.Floor(this.longitude)).ToString();
            //    tbxLatitudeDegree3.Text = Convert.ToInt32(Math.Floor(this.latitude)).ToString();

            //    double lon = this.longitude - Math.Floor(this.longitude);
            //    double lat = this.latitude - Math.Floor(this.latitude);

            //    tbxLongitudeMinutes3.Text = ((int)Math.Floor(lon * 60)).ToString();
            //    tbxLatitudeMinutes3.Text = ((int)Math.Floor(lat * 60)).ToString();

            //    double lon_ = lon * 60 - Convert.ToDouble((int)(lon * 60));
            //    double lat_ = lat * 60 - Convert.ToDouble((int)(lat * 60));


            //    tbxLongitudeSeconds3.Text = Math.Round((lon_ * 60), 3).ToString();
            //    tbxLatitudeSeconds3.Text = Math.Round((lat_ * 60), 3).ToString();
            //}

            if (rbtDegree.Checked == true)
            {
                tbxLongitudeDegree1.Text = this.longitude.ToString();
                tbxLatitudeDegree1.Text = this.latitude.ToString();
            }
            else if (rbtDegreeMinutes.Checked == true)
            {
                tbxLongitudeDegree2.Text = ((int)this.longitude).ToString();
                tbxLatitudeDegree2.Text = ((int)this.latitude).ToString();

                int lenth1 = this.longitude.ToString().IndexOf('.');
                if (lenth1 > 0)
                {
                    tbxLongitudeMinutes2.Text = ((this.longitude - (int)this.longitude) * 60).ToString();
                }
                else
                {
                    tbxLongitudeMinutes2.Text = "0";
                }

                int lenth2 = this.latitude.ToString().IndexOf('.');
                if (lenth2 > 0)
                {
                    tbxLatitudeMinutes2.Text = (((this.latitude - (int)this.latitude) * 60)).ToString();
                }
                else
                {
                    tbxLatitudeMinutes2.Text = "0";
                }
            }
            else if (rbtDegreeMinutesSeconds.Checked == true)
            {
                tbxLongitudeDegree3.Text = Convert.ToInt32(Math.Floor(this.longitude)).ToString();
                tbxLatitudeDegree3.Text = Convert.ToInt32(Math.Floor(this.latitude)).ToString();

                double lon = this.longitude - Math.Floor(this.longitude);
                double lat = this.latitude - Math.Floor(this.latitude);

                tbxLongitudeMinutes3.Text = ((int)Math.Floor(lon * 60)).ToString();
                tbxLatitudeMinutes3.Text = ((int)Math.Floor(lat * 60)).ToString();

                double lon_ = lon * 60 - Convert.ToDouble((int)(lon * 60));
                double lat_ = lat * 60 - Convert.ToDouble((int)(lat * 60));


                tbxLongitudeSeconds3.Text = ((lon_ * 60)).ToString();
                tbxLatitudeSeconds3.Text = ((lat_ * 60)).ToString();
            }
        }

        private void CoordinatesInputControl_Load(object sender, EventArgs e)
        {
            if (this.rbtDegree.Checked)
            {
                this.panDegree.Visible = true;
                this.panDegreeMinutes.Visible = false;
                this.panDegreeMinutesSeconds.Visible = false;
            }
            else if (this.rbtDegreeMinutes.Checked)
            {
                this.panDegree.Visible = false;
                this.panDegreeMinutes.Visible = true;
                this.panDegreeMinutesSeconds.Visible = false;
            }
            else if (this.rbtDegreeMinutesSeconds.Checked)
            {
                this.panDegree.Visible = false;
                this.panDegreeMinutes.Visible = false;
                this.panDegreeMinutesSeconds.Visible = true;
            }
        }

        private void panDegreeMinutesSeconds_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.panDegreeMinutesSeconds.Visible)
            //{
            //    this.tbxLongitudeDegree3.Text = Convert.ToInt32(Math.Floor(this.longitude)).ToString();
            //    this.tbxLatitudeDegree3.Text = Convert.ToInt32(Math.Floor(this.latitude)).ToString();

            //    double lon = this.longitude - Math.Floor(this.longitude);
            //    double lat = this.latitude - Math.Floor(this.latitude);

            //    this.tbxLongitudeMinutes3.Text = ((int)Math.Floor(lon * 60)).ToString();
            //    this.tbxLatitudeMinutes3.Text = ((int)Math.Floor(lat * 60)).ToString();

            //    double lon_ = lon * 60 - Convert.ToDouble((int)(lon * 60));
            //    double lat_ = lat * 60 - Convert.ToDouble((int)(lat * 60));


            //    this.tbxLongitudeSeconds3.Text = Math.Round((lon_ * 60), 3).ToString();
            //    this.tbxLatitudeSeconds3.Text = Math.Round((lat_ * 60), 3).ToString();

            //}
            //else
            //{
            //    this.longitude = Math.Round(Convert.ToDouble(tbxLongitudeDegree3.Text) + Convert.ToDouble(tbxLongitudeMinutes3.Text) / 60 + Convert.ToDouble(tbxLongitudeSeconds3.Text) / 60 / 60, 7);
            //    this.latitude = Math.Round(Convert.ToDouble(tbxLatitudeDegree3.Text) + Convert.ToDouble(tbxLatitudeMinutes3.Text) / 60 + Convert.ToDouble(tbxLatitudeSeconds3.Text) / 60 / 60, 7);

            //}

            if (this.panDegreeMinutesSeconds.Visible)
            {
                this.tbxLongitudeDegree3.Text = Convert.ToInt32(Math.Floor(this.longitude)).ToString();
                this.tbxLatitudeDegree3.Text = Convert.ToInt32(Math.Floor(this.latitude)).ToString();

                double lon = this.longitude - Math.Floor(this.longitude);
                double lat = this.latitude - Math.Floor(this.latitude);

                this.tbxLongitudeMinutes3.Text = ((int)Math.Floor(lon * 60)).ToString();
                this.tbxLatitudeMinutes3.Text = ((int)Math.Floor(lat * 60)).ToString();

                double lon_ = lon * 60 - Convert.ToDouble((int)(lon * 60));
                double lat_ = lat * 60 - Convert.ToDouble((int)(lat * 60));


                this.tbxLongitudeSeconds3.Text = ((lon_ * 60)).ToString();
                this.tbxLatitudeSeconds3.Text = ((lat_ * 60)).ToString();

            }
            else
            {
                this.longitude = (Convert.ToDouble(tbxLongitudeDegree3.Text) + Convert.ToDouble(tbxLongitudeMinutes3.Text) / 60 + Convert.ToDouble(tbxLongitudeSeconds3.Text) / 60 / 60);
                this.latitude = (Convert.ToDouble(tbxLatitudeDegree3.Text) + Convert.ToDouble(tbxLatitudeMinutes3.Text) / 60 + Convert.ToDouble(tbxLatitudeSeconds3.Text) / 60 / 60);

            }
        }

        private void panDegreeMinutes_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.panDegreeMinutes.Visible)
            //{
            //    this.tbxLongitudeDegree2.Text = ((int)this.longitude).ToString();
            //    this.tbxLatitudeDegree2.Text = ((int)this.latitude).ToString();

            //    int lenth1 = this.longitude.ToString().IndexOf('.');
            //    if (lenth1 > 0)
            //    {
            //        this.tbxLongitudeMinutes2.Text = Math.Round(((this.longitude - (int)this.longitude) * 60), 5).ToString();
            //    }
            //    else
            //    {
            //        this.tbxLongitudeMinutes2.Text = "0";
            //    }

            //    int lenth2 = this.latitude.ToString().IndexOf('.');
            //    if (lenth2 > 0)
            //    {
            //        this.tbxLatitudeMinutes2.Text = Math.Round(((this.latitude - (int)this.latitude) * 60), 5).ToString();
            //    }
            //    else
            //    {
            //        this.tbxLatitudeMinutes2.Text = "0";
            //    }
            //}
            //else
            //{
            //    this.longitude = Math.Round(Convert.ToDouble(tbxLongitudeDegree2.Text) + Convert.ToDouble(tbxLongitudeMinutes2.Text) / 60, 7);
            //    this.latitude = Math.Round(Convert.ToDouble(tbxLatitudeDegree2.Text) + Convert.ToDouble(tbxLatitudeMinutes2.Text) / 60, 7);
            //}
            if (this.panDegreeMinutes.Visible)
            {
                this.tbxLongitudeDegree2.Text = ((int)this.longitude).ToString();
                this.tbxLatitudeDegree2.Text = ((int)this.latitude).ToString();

                int lenth1 = this.longitude.ToString().IndexOf('.');
                if (lenth1 > 0)
                {
                    this.tbxLongitudeMinutes2.Text = (((this.longitude - (int)this.longitude) * 60)).ToString();
                }
                else
                {
                    this.tbxLongitudeMinutes2.Text = "0";
                }

                int lenth2 = this.latitude.ToString().IndexOf('.');
                if (lenth2 > 0)
                {
                    this.tbxLatitudeMinutes2.Text = (((this.latitude - (int)this.latitude) * 60)).ToString();
                }
                else
                {
                    this.tbxLatitudeMinutes2.Text = "0";
                }
            }
            else
            {
                this.longitude = (Convert.ToDouble(tbxLongitudeDegree2.Text) + Convert.ToDouble(tbxLongitudeMinutes2.Text) / 60);
                this.latitude = (Convert.ToDouble(tbxLatitudeDegree2.Text) + Convert.ToDouble(tbxLatitudeMinutes2.Text) / 60);
            }
        }

        private void panDegree_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.panDegree.Visible)
            //{
            //    this.tbxLongitudeDegree1.Text = Math.Round(this.longitude, 7).ToString();
            //    this.tbxLatitudeDegree1.Text = Math.Round(this.latitude, 7).ToString();
            //}
            //else
            //{
            //    this.longitude = Math.Round(Convert.ToDouble(tbxLongitudeDegree1.Text), 7);
            //    this.latitude = Math.Round(Convert.ToDouble(tbxLatitudeDegree1.Text), 7);
            //}

            if (this.panDegree.Visible)
            {
                this.tbxLongitudeDegree1.Text = this.longitude.ToString();
                this.tbxLatitudeDegree1.Text = this.latitude.ToString();
            }
            else
            {
                this.longitude = Convert.ToDouble(tbxLongitudeDegree1.Text);
                this.latitude = Convert.ToDouble(tbxLatitudeDegree1.Text);
            }
        }

    }
}
