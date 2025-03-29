using NavegaTeus.Database;
using NavegaTeus.Database.DTO;
using NavegaTeus.Views;
using System;
using System.Windows.Forms;

namespace NavegaTeus
{
    public partial class FormMain : Form
    {
       
        public FormMain()
        {
            InitializeComponent();
            DatabaseController.Initialize();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            ConfiguraLayout();
        }

        private void ConfiguraLayout()
        {

            //Fecha todos os forms
            foreach (Control ctrl in tableLayoutPanel.Controls)
            {
                var form = ctrl.Controls[0] as Form;
                form.Close();
                form.Dispose();
            }

            //Remove o layout
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.ColumnCount = 1;

            var pages = PagesDTO.PagesGetAll();

            // Adicionar uma nova coluna
            int lines = pages.Count > 1 ? 2 : 1;
            // Adicionar uma nova linha
            if (lines == 2)
            {
                tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50)); // Altura automática
            }

            int columnsUp = (int)Math.Ceiling((double)pages.Count / tableLayoutPanel.RowCount);
            int columnsDown = pages.Count - columnsUp;

            for (int i = 0; i < columnsUp - 1; i++)
            {
                tableLayoutPanel.ColumnCount++;
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            }

            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles[i].SizeType = SizeType.Percent;
                tableLayoutPanel.ColumnStyles[i].Width = 100 / tableLayoutPanel.ColumnCount;
            }

            for (int i = 0; i < columnsUp; i++)
            {
                var formPage = new FormPage(pages[i]);
                formPage.TopLevel = false;
                var panel = new Panel();
                panel.Name = "pnlPage";
                panel.Dock = DockStyle.Fill;
                panel.Controls.Add(formPage);
                panel.Resize += pnlPanel_Resize;
                tableLayoutPanel.Controls.Add(panel, i, 0);
                formPage.Show();
                formPage.WindowState = FormWindowState.Normal;
                formPage.Size = panel.Size;
            }

            for (int i = 0; i < columnsDown; i++)
            {
                var formPage = new FormPage(pages[columnsUp + i]);
                formPage.TopLevel = false;
                var panel = new Panel();
                panel.Name = "pnlPage";
                panel.Dock = DockStyle.Fill;
                panel.Controls.Add(formPage);
                panel.Resize += pnlPanel_Resize;
                tableLayoutPanel.Controls.Add(panel, i, 1);
                formPage.Show();
                formPage.WindowState = FormWindowState.Normal;
                formPage.Size = panel.Size;
            }

        }

        private void pnlPanel_Resize(object sender, EventArgs e)
        {
            var panel = (Panel)sender;
            var form =(Form)panel.Controls[0];
            form.WindowState = FormWindowState.Normal;
            form.Size = panel.Size;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            new FormInicializacao().ShowDialog();
            ConfiguraLayout();

        }

        private void btnShowControls_Click(object sender, EventArgs e)
        {
            foreach(var ctrl in tableLayoutPanel.Controls)
            {
                var form = (ctrl as Panel).Controls[0] as FormPage;
                form.ShowControls();
            }
        }
    }
}
