namespace QLTX
{
    partial class ucVehicle
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVehicle));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions4 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.xETHUEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTXDataSet = new QLTX.QLTXDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAXE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridleMALX = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.bindLoaiXe = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridcolMaLX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridcolTenLX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENXE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKIEUXE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbKieuXe = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colBIENSOXE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIAXE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHINHANH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnThemAnh = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.windowsUIButtonPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.txtVehicleName = new System.Windows.Forms.TextBox();
            this.xETHUETableAdapter = new QLTX.QLTXDataSetTableAdapters.XETHUETableAdapter();
            this.loaixeTableAdapter1 = new QLTX.QLTXDataSetTableAdapters.LOAIXETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xETHUEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTXDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridleMALX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindLoaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKieuXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThemAnh)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.xETHUEBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbKieuXe,
            this.btnThemAnh,
            this.gridleMALX});
            this.gridControl.Size = new System.Drawing.Size(869, 503);
            this.gridControl.TabIndex = 75;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xETHUEBindingSource
            // 
            this.xETHUEBindingSource.DataMember = "XETHUE";
            this.xETHUEBindingSource.DataSource = this.qLTXDataSet;
            // 
            // qLTXDataSet
            // 
            this.qLTXDataSet.DataSetName = "QLTXDataSet";
            this.qLTXDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAXE,
            this.colMALX,
            this.colTENXE,
            this.colKIEUXE,
            this.colBIENSOXE,
            this.colGIAXE,
            this.colHINHANH});
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridView1_RowDeleted);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            // 
            // colMAXE
            // 
            this.colMAXE.FieldName = "MAXE";
            this.colMAXE.Name = "colMAXE";
            // 
            // colMALX
            // 
            this.colMALX.Caption = "Loại Xe";
            this.colMALX.ColumnEdit = this.gridleMALX;
            this.colMALX.FieldName = "MALX";
            this.colMALX.Name = "colMALX";
            this.colMALX.Visible = true;
            this.colMALX.VisibleIndex = 2;
            // 
            // gridleMALX
            // 
            this.gridleMALX.AutoHeight = false;
            this.gridleMALX.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridleMALX.DataSource = this.bindLoaiXe;
            this.gridleMALX.DisplayMember = "TENLX";
            this.gridleMALX.Name = "gridleMALX";
            this.gridleMALX.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.gridleMALX.ValueMember = "MALX";
            // 
            // bindLoaiXe
            // 
            this.bindLoaiXe.DataMember = "LOAIXE";
            this.bindLoaiXe.DataSource = this.qLTXDataSet;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridcolMaLX,
            this.gridcolTenLX});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridcolMaLX
            // 
            this.gridcolMaLX.Caption = "Mã Loại Xe";
            this.gridcolMaLX.FieldName = "MALX";
            this.gridcolMaLX.Name = "gridcolMaLX";
            this.gridcolMaLX.Visible = true;
            this.gridcolMaLX.VisibleIndex = 0;
            // 
            // gridcolTenLX
            // 
            this.gridcolTenLX.Caption = "Tên Loại Xe";
            this.gridcolTenLX.FieldName = "TENLX";
            this.gridcolTenLX.Name = "gridcolTenLX";
            this.gridcolTenLX.Visible = true;
            this.gridcolTenLX.VisibleIndex = 1;
            // 
            // colTENXE
            // 
            this.colTENXE.Caption = "Tên Xe";
            this.colTENXE.FieldName = "TENXE";
            this.colTENXE.Name = "colTENXE";
            this.colTENXE.Visible = true;
            this.colTENXE.VisibleIndex = 1;
            // 
            // colKIEUXE
            // 
            this.colKIEUXE.Caption = "Kiểu Xe";
            this.colKIEUXE.ColumnEdit = this.cmbKieuXe;
            this.colKIEUXE.FieldName = "KIEUXE";
            this.colKIEUXE.Name = "colKIEUXE";
            this.colKIEUXE.Visible = true;
            this.colKIEUXE.VisibleIndex = 3;
            // 
            // cmbKieuXe
            // 
            this.cmbKieuXe.AutoHeight = false;
            this.cmbKieuXe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKieuXe.Name = "cmbKieuXe";
            // 
            // colBIENSOXE
            // 
            this.colBIENSOXE.Caption = "Biển Số Xe";
            this.colBIENSOXE.FieldName = "BIENSOXE";
            this.colBIENSOXE.Name = "colBIENSOXE";
            this.colBIENSOXE.Visible = true;
            this.colBIENSOXE.VisibleIndex = 4;
            // 
            // colGIAXE
            // 
            this.colGIAXE.Caption = "Giá Xe";
            this.colGIAXE.DisplayFormat.FormatString = "#,#";
            this.colGIAXE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGIAXE.FieldName = "GIAXE";
            this.colGIAXE.Name = "colGIAXE";
            this.colGIAXE.Visible = true;
            this.colGIAXE.VisibleIndex = 5;
            // 
            // colHINHANH
            // 
            this.colHINHANH.Caption = "Hình Ảnh";
            this.colHINHANH.ColumnEdit = this.btnThemAnh;
            this.colHINHANH.FieldName = "HINHANH";
            this.colHINHANH.Name = "colHINHANH";
            this.colHINHANH.Visible = true;
            this.colHINHANH.VisibleIndex = 6;
            // 
            // btnThemAnh
            // 
            this.btnThemAnh.AutoHeight = false;
            this.btnThemAnh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.SpinUp)});
            this.btnThemAnh.Name = "btnThemAnh";
            this.btnThemAnh.Click += new System.EventHandler(this.btnThemAnh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.windowsUIButtonPanel);
            this.panel1.Controls.Add(this.gridControl);
            this.panel1.Controls.Add(this.txtVehicleName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 503);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(707, 387);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // windowsUIButtonPanel
            // 
            this.windowsUIButtonPanel.AppearanceButton.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanel.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Normal.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanel.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            windowsUIButtonImageOptions1.ImageUri.Uri = "Preview;Size32x32;GrayScaled";
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            windowsUIButtonImageOptions2.ImageUri.Uri = "Edit/Delete;Size32x32;GrayScaled";
            windowsUIButtonImageOptions3.ImageUri.Uri = "Refresh;Size32x32;GrayScaled";
            windowsUIButtonImageOptions4.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions4.SvgImage")));
            this.windowsUIButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Xe Thuê", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Delete", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Refresh", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Add", true, windowsUIButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel.EnableImageTransparency = true;
            this.windowsUIButtonPanel.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel.Location = new System.Drawing.Point(0, 443);
            this.windowsUIButtonPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.windowsUIButtonPanel.MaximumSize = new System.Drawing.Size(0, 60);
            this.windowsUIButtonPanel.MinimumSize = new System.Drawing.Size(60, 60);
            this.windowsUIButtonPanel.Name = "windowsUIButtonPanel";
            this.windowsUIButtonPanel.Size = new System.Drawing.Size(869, 60);
            this.windowsUIButtonPanel.TabIndex = 76;
            this.windowsUIButtonPanel.Text = "windowsUIButtonPanel";
            this.windowsUIButtonPanel.UseButtonBackgroundImages = false;
            this.windowsUIButtonPanel.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel_ButtonClick);
            // 
            // txtVehicleName
            // 
            this.txtVehicleName.Location = new System.Drawing.Point(65, 344);
            this.txtVehicleName.Name = "txtVehicleName";
            this.txtVehicleName.Size = new System.Drawing.Size(337, 21);
            this.txtVehicleName.TabIndex = 74;
            // 
            // xETHUETableAdapter
            // 
            this.xETHUETableAdapter.ClearBeforeFill = true;
            // 
            // loaixeTableAdapter1
            // 
            this.loaixeTableAdapter1.ClearBeforeFill = true;
            // 
            // ucVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucVehicle";
            this.Size = new System.Drawing.Size(869, 503);
            this.Load += new System.EventHandler(this.ucVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xETHUEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTXDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridleMALX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindLoaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKieuXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThemAnh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource xETHUEBindingSource;
        private QLTXDataSet qLTXDataSet;
        private QLTXDataSetTableAdapters.XETHUETableAdapter xETHUETableAdapter;
        private System.Windows.Forms.TextBox txtVehicleName;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAXE;
        private DevExpress.XtraGrid.Columns.GridColumn colMALX;
        private DevExpress.XtraGrid.Columns.GridColumn colTENXE;
        private DevExpress.XtraGrid.Columns.GridColumn colKIEUXE;
        private DevExpress.XtraGrid.Columns.GridColumn colBIENSOXE;
        private DevExpress.XtraGrid.Columns.GridColumn colGIAXE;
        private DevExpress.XtraGrid.Columns.GridColumn colHINHANH;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbKieuXe;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnThemAnh;
        private QLTXDataSetTableAdapters.LOAIXETableAdapter loaixeTableAdapter1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit gridleMALX;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private System.Windows.Forms.BindingSource bindLoaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gridcolMaLX;
        private DevExpress.XtraGrid.Columns.GridColumn gridcolTenLX;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel;
    }
}
