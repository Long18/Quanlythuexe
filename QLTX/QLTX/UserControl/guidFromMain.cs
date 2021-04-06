using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLTX
{
    public partial class guidFromMain : DevExpress.XtraEditors.XtraUserControl
    {
        int curentLessonIdCore;
        frmMain module;
        public guidFromMain(frmMain moduleGuide, int lessonCount)
        {
            InitializeComponent();
            module = moduleGuide;
            curentLessonIdCore = 0;
            InitializeNavigator(lessonCount);
        }

        void InitializeNavigator(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.navigator.Buttons.Add(new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", GetResourceImage(), 0, DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", false, -1, true, null, true, i == curentLessonIdCore, true, null, null, 1, false, false));
            }
        }

        public string LabelText
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public int CurrentLessonIndex
        {
            get { return curentLessonIdCore; }
        }

        Image GetResourceImage()
        {
            return QLTX.Properties.Resources.vector_car as Image;
        }

        private void OnNavigatorButtonChecked(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            curentLessonIdCore = navigator.Buttons.IndexOf(e.Button);
            //module.SetLesson(curentLessonIdCore);
        }
        private void OnSkipButtonClick(object sender, EventArgs e)
        {
            //module.EndTutorial();
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            curentLessonIdCore--;
            if (curentLessonIdCore < 0)
            {
                curentLessonIdCore = navigator.Buttons.Count - 1;
            }
            navigator.Buttons[curentLessonIdCore].Properties.Checked = true;
        }

        private void OnNextButtonClick(object sender, EventArgs e)
        {
            curentLessonIdCore++;
            if (curentLessonIdCore > navigator.Buttons.Count - 1)
            {
                curentLessonIdCore = 0;
            }
            navigator.Buttons[curentLessonIdCore].Properties.Checked = true;
        }
    }
}
