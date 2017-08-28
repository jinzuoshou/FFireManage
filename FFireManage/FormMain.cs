using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FFireManage.Monitor;
using FFireManage.Hot;
using FFireManage.FireCommand;
using FFireManage.WatchTower;
using FFireManage.RadioStation;
using FFireManage.FireForestBelt;
using FFireManage.Artificiallake;
using FFireManage.DangerousFacilities;
using FFireManage.FireHBrigade;
using FFireManage.FirePBrigade;
using FFireManage.FireImportantUnits;
using FFireManage.FireDocument;

namespace FFireManage
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnUserManage_Click(object sender, EventArgs e)
        {
            FormUserManage pFormUserManage = new FormUserManage();
            pFormUserManage.ShowDialog(this);
        }

        private void btnMonitorManage_Click(object sender, EventArgs e)
        {
            FormMonitorManage pFormMonitorManage = new FormMonitorManage();
            pFormMonitorManage.ShowDialog(this);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
             //DispatcherManager.Instance.Login(GlobeHelper.Instance.User.account, GlobeHelper.Instance.User.password, AppConfigHelper.GetAppConfig("Ip"), AppConfigHelper.GetAppConfig("Ip"), "3D5B0ACB9E6031823CE4E07B90B2E769");
        }

        private void btnAppLicense_Click(object sender, EventArgs e)
        {
            FormAppLicenseManager pFormAppLicenseManager = new FormAppLicenseManager();
            pFormAppLicenseManager.ShowDialog(this);
        }

        private void btnHotManage_Click(object sender, EventArgs e)
        {
            FormHotManage form = new FormHotManage();
            form.ShowDialog(this);
        }


        private void btn_FireCommand_Click(object sender, EventArgs e)
        {
            FormFireCommandManage pFormFireCommandManage = new FormFireCommandManage();
            pFormFireCommandManage.ShowDialog(this);
        }

        private void btn_WatchTower_Click(object sender, EventArgs e)
        {
            FormWatchTowerManage pFormWatchTowerManage = new FormWatchTowerManage();
            pFormWatchTowerManage.ShowDialog(this);
        }

        private void btn_RadioStation_Click(object sender, EventArgs e)
        {
            FormRadioStationManage pFormRadioStationManage = new FormRadioStationManage();
            pFormRadioStationManage.ShowDialog(this);
        }

        private void btn_FireForestBelt_Click(object sender, EventArgs e)
        {
            FormFireForestBeltManage pFormFireForestBeltManage = new FormFireForestBeltManage();
            pFormFireForestBeltManage.ShowDialog(this);
        }

        private void btn_Artificiallake_Click(object sender, EventArgs e)
        {
            FormArtificiallakeManage pFormArtificiallakeManage = new FormArtificiallakeManage();
            pFormArtificiallakeManage.ShowDialog(this);
        }

        private void btn_DangerousFacilities_Click(object sender, EventArgs e)
        {
            FormDFacilitiesManage pFormDFacilitiesManage = new FormDFacilitiesManage();
            pFormDFacilitiesManage.ShowDialog(this);
        }

        private void btn_FireHBigade_Click(object sender, EventArgs e)
        {
            FormFireHBrigadeManage pFormFireHBrigadeManage = new FormFireHBrigadeManage();
            pFormFireHBrigadeManage.ShowDialog(this);
        }

        private void btn_FirePBrigade_Click(object sender, EventArgs e)
        {
            FormFirePBrigadeManage pFormFireHBrigadeManage = new FormFirePBrigadeManage();
            pFormFireHBrigadeManage.ShowDialog(this);
        }

        private void btn_FireImportantUnits_Click(object sender, EventArgs e)
        {
            FormFireImportantUnitsManage pFormFireIUnitsManage = new FormFireImportantUnitsManage();
            pFormFireIUnitsManage.ShowDialog(this);
        }

        private void btn_FireDocument_Click(object sender, EventArgs e)
        {
            FormFireDocumentManage pFormFireDocumentManage = new FormFireDocumentManage();
            pFormFireDocumentManage.ShowDialog(this);
        }
    }
}
