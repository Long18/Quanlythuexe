namespace QLTX
{
    partial class guidFromMain
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
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.skipButton = new DevExpress.XtraEditors.SimpleButton();
            this.nextButton = new DevExpress.XtraEditors.SimpleButton();
            this.backButton = new DevExpress.XtraEditors.SimpleButton();
            this.navigator = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.nextItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.backItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.shipItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.navigatorItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptyItem = new DevExpress.XtraLayout.EmptySpaceItem();
            this.labelItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigatorItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptyItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelItem)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.label);
            this.layoutControl.Controls.Add(this.skipButton);
            this.layoutControl.Controls.Add(this.nextButton);
            this.layoutControl.Controls.Add(this.backButton);
            this.layoutControl.Controls.Add(this.navigator);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(535, 109, 697, 350);
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(234, 148);
            this.layoutControl.TabIndex = 1;
            this.layoutControl.Text = "layoutControl1";
            // 
            // label
            // 
            this.label.Appearance.Options.UseTextOptions = true;
            this.label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.label.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label.Location = new System.Drawing.Point(12, 12);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(210, 74);
            this.label.StyleController = this.layoutControl;
            this.label.TabIndex = 0;
            this.label.Text = "Empty";
            // 
            // skipButton
            // 
            this.skipButton.Location = new System.Drawing.Point(12, 114);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(46, 22);
            this.skipButton.StyleController = this.layoutControl;
            this.skipButton.TabIndex = 7;
            this.skipButton.Text = "Skip";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(176, 114);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(46, 22);
            this.nextButton.StyleController = this.layoutControl;
            this.nextButton.TabIndex = 6;
            this.nextButton.Text = "Next";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(126, 114);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(46, 22);
            this.backButton.StyleController = this.layoutControl;
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            // 
            // navigator
            // 
            this.navigator.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.Gray;
            this.navigator.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.navigator.AppearanceButton.Normal.ForeColor = System.Drawing.Color.Silver;
            this.navigator.AppearanceButton.Normal.Options.UseForeColor = true;
            this.navigator.AppearanceButton.Pressed.BackColor = System.Drawing.Color.Gray;
            this.navigator.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.navigator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.navigator.ButtonInterval = 5;
            this.navigator.Location = new System.Drawing.Point(12, 90);
            this.navigator.Name = "navigator";
            this.navigator.Size = new System.Drawing.Size(210, 20);
            this.navigator.TabIndex = 4;
            this.navigator.Text = "windowsUIButtonPanel1";
            this.navigator.UseButtonBackgroundImages = false;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.nextItem,
            this.backItem,
            this.shipItem,
            this.navigatorItem,
            this.emptyItem,
            this.labelItem});
            this.layoutControlGroup.Name = "Root";
            this.layoutControlGroup.Size = new System.Drawing.Size(234, 148);
            this.layoutControlGroup.TextVisible = false;
            // 
            // nextItem
            // 
            this.nextItem.Control = this.nextButton;
            this.nextItem.Location = new System.Drawing.Point(164, 102);
            this.nextItem.MaxSize = new System.Drawing.Size(50, 26);
            this.nextItem.MinSize = new System.Drawing.Size(50, 26);
            this.nextItem.Name = "nextItem";
            this.nextItem.Size = new System.Drawing.Size(50, 26);
            this.nextItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.nextItem.TextSize = new System.Drawing.Size(0, 0);
            this.nextItem.TextVisible = false;
            // 
            // backItem
            // 
            this.backItem.Control = this.backButton;
            this.backItem.Location = new System.Drawing.Point(114, 102);
            this.backItem.MaxSize = new System.Drawing.Size(50, 26);
            this.backItem.MinSize = new System.Drawing.Size(50, 26);
            this.backItem.Name = "backItem";
            this.backItem.Size = new System.Drawing.Size(50, 26);
            this.backItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.backItem.TextSize = new System.Drawing.Size(0, 0);
            this.backItem.TextVisible = false;
            // 
            // shipItem
            // 
            this.shipItem.Control = this.skipButton;
            this.shipItem.Location = new System.Drawing.Point(0, 102);
            this.shipItem.MaxSize = new System.Drawing.Size(50, 26);
            this.shipItem.MinSize = new System.Drawing.Size(50, 26);
            this.shipItem.Name = "shipItem";
            this.shipItem.Size = new System.Drawing.Size(50, 26);
            this.shipItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.shipItem.TextSize = new System.Drawing.Size(0, 0);
            this.shipItem.TextVisible = false;
            // 
            // navigatorItem
            // 
            this.navigatorItem.Control = this.navigator;
            this.navigatorItem.Location = new System.Drawing.Point(0, 78);
            this.navigatorItem.MaxSize = new System.Drawing.Size(0, 24);
            this.navigatorItem.MinSize = new System.Drawing.Size(1, 24);
            this.navigatorItem.Name = "navigatorItem";
            this.navigatorItem.Size = new System.Drawing.Size(214, 24);
            this.navigatorItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.navigatorItem.TextSize = new System.Drawing.Size(0, 0);
            this.navigatorItem.TextVisible = false;
            // 
            // emptyItem
            // 
            this.emptyItem.AllowHotTrack = false;
            this.emptyItem.Location = new System.Drawing.Point(50, 102);
            this.emptyItem.Name = "emptyItem";
            this.emptyItem.Size = new System.Drawing.Size(64, 26);
            this.emptyItem.TextSize = new System.Drawing.Size(0, 0);
            // 
            // labelItem
            // 
            this.labelItem.Control = this.label;
            this.labelItem.Location = new System.Drawing.Point(0, 0);
            this.labelItem.MinSize = new System.Drawing.Size(14, 17);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(214, 78);
            this.labelItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.labelItem.TextSize = new System.Drawing.Size(0, 0);
            this.labelItem.TextVisible = false;
            // 
            // GuideFlyoutPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "GuideFlyoutPanel";
            this.Size = new System.Drawing.Size(234, 148);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigatorItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptyItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.LabelControl label;
        private DevExpress.XtraEditors.SimpleButton skipButton;
        private DevExpress.XtraEditors.SimpleButton nextButton;
        private DevExpress.XtraEditors.SimpleButton backButton;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel navigator;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem nextItem;
        private DevExpress.XtraLayout.LayoutControlItem backItem;
        private DevExpress.XtraLayout.LayoutControlItem shipItem;
        private DevExpress.XtraLayout.LayoutControlItem navigatorItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptyItem;
        private DevExpress.XtraLayout.LayoutControlItem labelItem;
    }
}
