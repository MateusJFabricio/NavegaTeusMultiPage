namespace NavegaTeus
{
    partial class FormMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.flowLayoutPanelSuperior = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnShowControls = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.timerBtnClose = new System.Windows.Forms.Timer(this.components);
            this.timerMouseMonitor = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanelSuperior.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelSuperior
            // 
            this.flowLayoutPanelSuperior.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanelSuperior.Controls.Add(this.btnSetup);
            this.flowLayoutPanelSuperior.Controls.Add(this.btnShowControls);
            this.flowLayoutPanelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelSuperior.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelSuperior.Name = "flowLayoutPanelSuperior";
            this.flowLayoutPanelSuperior.Size = new System.Drawing.Size(1163, 31);
            this.flowLayoutPanelSuperior.TabIndex = 0;
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(3, 3);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(113, 22);
            this.btnSetup.TabIndex = 0;
            this.btnSetup.Text = "Configuração";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnShowControls
            // 
            this.btnShowControls.Location = new System.Drawing.Point(122, 3);
            this.btnShowControls.Name = "btnShowControls";
            this.btnShowControls.Size = new System.Drawing.Size(113, 22);
            this.btnShowControls.TabIndex = 1;
            this.btnShowControls.Text = "Show Controls";
            this.btnShowControls.UseVisualStyleBackColor = true;
            this.btnShowControls.Click += new System.EventHandler(this.btnShowControls_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tableLayoutPanel);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 31);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1163, 490);
            this.panelMain.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1163, 490);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // timerBtnClose
            // 
            this.timerBtnClose.Interval = 1000;
            // 
            // timerMouseMonitor
            // 
            this.timerMouseMonitor.Interval = 600;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 521);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.flowLayoutPanelSuperior);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "NavegaTeus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.flowLayoutPanelSuperior.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSuperior;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Timer timerBtnClose;
        private System.Windows.Forms.Timer timerMouseMonitor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnShowControls;
    }
}

