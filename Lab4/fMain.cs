using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVLib;
using Lab3;

namespace Lab4
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            gvTVs.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Model";
            column.Name = "Модель";
            gvTVs.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Display";
            column.Name = "Дисплей";
            gvTVs.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Cores";
            column.Name = "Ядра";
            gvTVs.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Resolution";
            column.Name = "Роздільна здатність";
            gvTVs.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Platform";
            column.Name = "Платформа";
            gvTVs.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "HasTuner";
            column.Name = "Тюнер";
            gvTVs.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "HasAI";
            column.Name = "ШІ";
            gvTVs.Columns.Add(column);

            bindSrcTVs.Add(new TV("CoolPlasmaTV", "plasma", 4, "8240x4120", "Android", true, true));
            EventArgs eventArgs = new EventArgs(); OnResize(eventArgs);
        }

        private void fMain_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * toolStripSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0); 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TV tv = new TV();

            fTV ftv = new fTV(tv);
            if(ftv.ShowDialog() == DialogResult.OK)
            {
                bindSrcTVs.Add(tv);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TV tv = (TV)bindSrcTVs.List[bindSrcTVs.Position];

            fTV ftv = new fTV(tv);
            if (ftv.ShowDialog() == DialogResult.OK)
            {
                bindSrcTVs.List[bindSrcTVs.Position] = tv;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис?", "Видалення запису", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { bindSrcTVs.RemoveCurrent(); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
                bindSrcTVs.List.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
