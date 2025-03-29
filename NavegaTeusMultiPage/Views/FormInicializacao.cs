using IWshRuntimeLibrary;
using NavegaTeus.Database.DTO;
using NavegaTeus.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegaTeus
{
    public partial class FormInicializacao : Form
    {
        public FormInicializacao()
        {
            InitializeComponent();
            ConfiguraComponentes();
        }

        private void ConfiguraComponentes()
        {
            dataGridView.Rows.Clear();
            foreach (var page in PagesDTO.PagesGetAll())
            {
                InsertPageDataGridView(page);
            }
        }

        private void InsertPageDataGridView(PagesModel page)
        {
            dataGridView.Rows.Add(page.Id, page.IndexPosition, page.URL, page.AutoUpdate, page.UpdateFrequency, page.LastUpdate);
        }
        private void CreateShortcut()
        {
            string link = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "//" + Application.ProductName + ".lnk";
            var shell = new WshShell();
            var shortcut = shell.CreateShortcut(link) as IWshShortcut;
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Save();

            MessageBox.Show("Atalho criado. " + Environment.NewLine +
                "Agora este software iniciará com o Windows." + Environment.NewLine +
                "Use o Gerenciador de Tarefas para remover esta configuracao");
        }

        private void toolStripButtonInitWithWindows_Click(object sender, EventArgs e)
        {
            CreateShortcut();
        }

        private void toolStripButtonAtualizar_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            foreach (var page in PagesDTO.PagesGetAll())
            {
                InsertPageDataGridView(page);
            }
        }

        private void toolStripButtonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.CurrentCell != null)
                {
                    dataGridView.EndEdit(); // Finaliza a edição da célula ativa
                }

                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit); // Confirma a edição
                dataGridView.Refresh(); // Atualiza a exibição dos dados

                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    dataGridView.Rows[i].Selected = false;
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Empty;

                    PagesModel pageResult;
                    if (dataGridView.Rows[i].Cells["ID"].Value == null) //Novo registro
                    {
                        PagesModel pageModel = new PagesModel();
                        pageModel.URL = (string)dataGridView.Rows[i].Cells["URL"].Value;
                        pageModel.LastUpdate = new DateTime();

                        if (dataGridView.Rows[i].Cells["IndexPosition"].Value == null)
                        {
                            pageModel.IndexPosition = 0;
                        }
                        else
                        {
                            pageModel.IndexPosition = int.Parse((string)dataGridView.Rows[i].Cells["IndexPosition"].Value);
                        }

                        if (dataGridView.Rows[i].Cells["UpdateFrequency"].Value == null)
                        {
                            pageModel.UpdateFrequency = TimeSpan.Zero;
                        }
                        else
                        {
                            pageModel.UpdateFrequency = TimeSpan.Parse((string)dataGridView.Rows[i].Cells["UpdateFrequency"].Value);
                        }

                        if (dataGridView.Rows[i].Cells["AutoUpdate"].Value != null)
                            pageModel.AutoUpdate = (bool)dataGridView.Rows[i].Cells["AutoUpdate"].Value;

                        pageResult = PagesDTO.PagesInsert(pageModel);
                    }
                    else
                    {
                        //Atualiza registro
                        var pageModel = PagesDTO.PagesGetById((int)dataGridView.Rows[i].Cells["ID"].Value);
                        pageModel.URL = (string)dataGridView.Rows[i].Cells["Url"].Value;
                        if (dataGridView.Rows[i].Cells["AutoUpdate"].Value != null)
                            pageModel.AutoUpdate = (bool)dataGridView.Rows[i].Cells["AutoUpdate"].Value;

                        if (dataGridView.Rows[i].Cells["IndexPosition"].Value is int)
                        {
                            pageModel.IndexPosition = (int)dataGridView.Rows[i].Cells["IndexPosition"].Value;
                        }
                        else
                        {
                            if (dataGridView.Rows[i].Cells["IndexPosition"].Value == null)
                            {
                                pageModel.IndexPosition = 0;
                            }
                            else
                            {
                                pageModel.IndexPosition = int.Parse((string)dataGridView.Rows[i].Cells["IndexPosition"].Value);
                            }
                        }

                        if (dataGridView.Rows[i].Cells["UpdateFrequency"].Value is TimeSpan)
                        {
                            pageModel.UpdateFrequency = (TimeSpan)dataGridView.Rows[i].Cells["UpdateFrequency"].Value;
                        }
                        else
                        {
                            if (dataGridView.Rows[i].Cells["UpdateFrequency"].Value == null)
                            {
                                pageModel.UpdateFrequency = TimeSpan.Zero;
                            }
                            else
                            {
                                pageModel.UpdateFrequency = TimeSpan.Parse((string)dataGridView.Rows[i].Cells["UpdateFrequency"].Value);
                            }
                        }

                        pageResult = PagesDTO.PageUpdate(pageModel);

                    }

                    UpdateDataPage(pageResult, i);
                }

                dataGridView.Rows.Clear();
                foreach (var page in PagesDTO.PagesGetAll())
                {
                    InsertPageDataGridView(page);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro: " + ex.Message);
            }
        }
        private void UpdateDataPage(PagesModel page, int index)
        {
            dataGridView.Rows[index].Cells["Id"].Value = page.Id;
            dataGridView.Rows[index].Cells["Url"].Value = page.URL;
            dataGridView.Rows[index].Cells["IndexPosition"].Value = page.IndexPosition;
            dataGridView.Rows[index].Cells["UpdateFrequency"].Value = page.UpdateFrequency;
            dataGridView.Rows[index].Cells["LastUpdate"].Value = page.LastUpdate;
            dataGridView.Rows[index].Cells["AutoUpdate"].Value = page.AutoUpdate;
        }

        private void toolStripButtonRemover_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                if (dataGridView.SelectedRows.Count > 0 || dataGridView.SelectedCells.Count > 0)
                {
                    if (dataGridView.SelectedCells.Count > 0)
                    {
                        dataGridView.Rows[dataGridView.SelectedCells[0].RowIndex].Selected = true;
                    }


                    if (dataGridView.SelectedRows[0].Cells["Id"].Value != null)
                    {
                        var page = PagesDTO.PagesGetById((int)dataGridView.SelectedRows[0].Cells["Id"].Value);
                        if (page != null)
                        {
                            PagesDTO.PagesDeleteById(page);
                            dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
                        }
                    }
                }
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].Name == "UpdateFrequency")
            {
                if (dataGridView.CurrentCell.EditedFormattedValue != null)
                {
                    TimeSpan timeSpan;
                    if (TimeSpan.TryParse((string)dataGridView.CurrentCell.Value, out timeSpan))
                    {
                        dataGridView.CurrentCell.Value = timeSpan.ToString();
                    }
                    else
                    {
                        dataGridView.CurrentCell.Value = "00:01:00";
                    }

                    dataGridView.EndEdit();
                }
            }
        }
    }
}
