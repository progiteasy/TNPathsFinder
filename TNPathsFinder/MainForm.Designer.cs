
namespace TNPathsFinder
{
    partial class MainForm
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
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiLoadTransportRoutesListFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.gbTransportRoutes = new System.Windows.Forms.GroupBox();
            this.tbTransportRoutes = new System.Windows.Forms.TextBox();
            this.gbMinPathsInTransportNetworkFinding = new System.Windows.Forms.GroupBox();
            this.gbDepartureTime = new System.Windows.Forms.GroupBox();
            this.dtpDepartureTime = new System.Windows.Forms.DateTimePicker();
            this.gbMinTotalCostPaths = new System.Windows.Forms.GroupBox();
            this.tbMinTotalCostPaths = new System.Windows.Forms.TextBox();
            this.gbDestinationTransportStop = new System.Windows.Forms.GroupBox();
            this.cbDestinationTransportStops = new System.Windows.Forms.ComboBox();
            this.gbSourceTransportStop = new System.Windows.Forms.GroupBox();
            this.cbSourceTransportStops = new System.Windows.Forms.ComboBox();
            this.gbMinTotalTimePaths = new System.Windows.Forms.GroupBox();
            this.tbMinTotalTimePaths = new System.Windows.Forms.TextBox();
            this.bFindMinPathsInTransportNetwork = new System.Windows.Forms.Button();
            this.ofdTransportRoutesFileToReadSelectionDialog = new System.Windows.Forms.OpenFileDialog();
            this.msMainMenu.SuspendLayout();
            this.gbTransportRoutes.SuspendLayout();
            this.gbMinPathsInTransportNetworkFinding.SuspendLayout();
            this.gbDepartureTime.SuspendLayout();
            this.gbMinTotalCostPaths.SuspendLayout();
            this.gbDestinationTransportStop.SuspendLayout();
            this.gbSourceTransportStop.SuspendLayout();
            this.gbMinTotalTimePaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadTransportRoutesListFromFile});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(882, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // tsmiLoadTransportRoutesListFromFile
            // 
            this.tsmiLoadTransportRoutesListFromFile.Name = "tsmiLoadTransportRoutesListFromFile";
            this.tsmiLoadTransportRoutesListFromFile.Size = new System.Drawing.Size(189, 20);
            this.tsmiLoadTransportRoutesListFromFile.Text = "Загрузить маршруты из файла";
            this.tsmiLoadTransportRoutesListFromFile.Click += new System.EventHandler(this.tsmiLoadTransportRoutesListFromFile_Click);
            // 
            // gbTransportRoutes
            // 
            this.gbTransportRoutes.Controls.Add(this.tbTransportRoutes);
            this.gbTransportRoutes.Location = new System.Drawing.Point(12, 27);
            this.gbTransportRoutes.Name = "gbTransportRoutes";
            this.gbTransportRoutes.Size = new System.Drawing.Size(300, 400);
            this.gbTransportRoutes.TabIndex = 1;
            this.gbTransportRoutes.TabStop = false;
            this.gbTransportRoutes.Text = "Маршруты общественного транспорта";
            // 
            // tbTransportRoutes
            // 
            this.tbTransportRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTransportRoutes.Location = new System.Drawing.Point(3, 16);
            this.tbTransportRoutes.Multiline = true;
            this.tbTransportRoutes.Name = "tbTransportRoutes";
            this.tbTransportRoutes.ReadOnly = true;
            this.tbTransportRoutes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTransportRoutes.Size = new System.Drawing.Size(294, 381);
            this.tbTransportRoutes.TabIndex = 2;
            // 
            // gbMinPathsInTransportNetworkFinding
            // 
            this.gbMinPathsInTransportNetworkFinding.Controls.Add(this.gbDepartureTime);
            this.gbMinPathsInTransportNetworkFinding.Controls.Add(this.gbMinTotalCostPaths);
            this.gbMinPathsInTransportNetworkFinding.Controls.Add(this.gbDestinationTransportStop);
            this.gbMinPathsInTransportNetworkFinding.Controls.Add(this.gbSourceTransportStop);
            this.gbMinPathsInTransportNetworkFinding.Controls.Add(this.gbMinTotalTimePaths);
            this.gbMinPathsInTransportNetworkFinding.Controls.Add(this.bFindMinPathsInTransportNetwork);
            this.gbMinPathsInTransportNetworkFinding.Enabled = false;
            this.gbMinPathsInTransportNetworkFinding.Location = new System.Drawing.Point(318, 27);
            this.gbMinPathsInTransportNetworkFinding.Name = "gbMinPathsInTransportNetworkFinding";
            this.gbMinPathsInTransportNetworkFinding.Size = new System.Drawing.Size(552, 400);
            this.gbMinPathsInTransportNetworkFinding.TabIndex = 3;
            this.gbMinPathsInTransportNetworkFinding.TabStop = false;
            this.gbMinPathsInTransportNetworkFinding.Text = "Поиск минимальных путей";
            // 
            // gbDepartureTime
            // 
            this.gbDepartureTime.Controls.Add(this.dtpDepartureTime);
            this.gbDepartureTime.Location = new System.Drawing.Point(318, 16);
            this.gbDepartureTime.Name = "gbDepartureTime";
            this.gbDepartureTime.Size = new System.Drawing.Size(122, 44);
            this.gbDepartureTime.TabIndex = 8;
            this.gbDepartureTime.TabStop = false;
            this.gbDepartureTime.Text = "Время отправления";
            // 
            // dtpDepartureTime
            // 
            this.dtpDepartureTime.CustomFormat = "HH:mm";
            this.dtpDepartureTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepartureTime.Location = new System.Drawing.Point(3, 16);
            this.dtpDepartureTime.Name = "dtpDepartureTime";
            this.dtpDepartureTime.ShowUpDown = true;
            this.dtpDepartureTime.Size = new System.Drawing.Size(116, 20);
            this.dtpDepartureTime.TabIndex = 9;
            // 
            // gbMinTotalCostPaths
            // 
            this.gbMinTotalCostPaths.Controls.Add(this.tbMinTotalCostPaths);
            this.gbMinTotalCostPaths.Location = new System.Drawing.Point(6, 233);
            this.gbMinTotalCostPaths.Name = "gbMinTotalCostPaths";
            this.gbMinTotalCostPaths.Size = new System.Drawing.Size(540, 161);
            this.gbMinTotalCostPaths.TabIndex = 13;
            this.gbMinTotalCostPaths.TabStop = false;
            this.gbMinTotalCostPaths.Text = "Пути с минимальной стоимостью проезда";
            // 
            // tbMinTotalCostPaths
            // 
            this.tbMinTotalCostPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMinTotalCostPaths.Location = new System.Drawing.Point(3, 16);
            this.tbMinTotalCostPaths.Multiline = true;
            this.tbMinTotalCostPaths.Name = "tbMinTotalCostPaths";
            this.tbMinTotalCostPaths.ReadOnly = true;
            this.tbMinTotalCostPaths.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMinTotalCostPaths.Size = new System.Drawing.Size(534, 142);
            this.tbMinTotalCostPaths.TabIndex = 14;
            this.tbMinTotalCostPaths.WordWrap = false;
            // 
            // gbDestinationTransportStop
            // 
            this.gbDestinationTransportStop.Controls.Add(this.cbDestinationTransportStops);
            this.gbDestinationTransportStop.Location = new System.Drawing.Point(162, 16);
            this.gbDestinationTransportStop.Name = "gbDestinationTransportStop";
            this.gbDestinationTransportStop.Size = new System.Drawing.Size(150, 44);
            this.gbDestinationTransportStop.TabIndex = 6;
            this.gbDestinationTransportStop.TabStop = false;
            this.gbDestinationTransportStop.Text = "Конечная остановка";
            // 
            // cbDestinationTransportStops
            // 
            this.cbDestinationTransportStops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDestinationTransportStops.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationTransportStops.FormattingEnabled = true;
            this.cbDestinationTransportStops.Location = new System.Drawing.Point(3, 16);
            this.cbDestinationTransportStops.Name = "cbDestinationTransportStops";
            this.cbDestinationTransportStops.Size = new System.Drawing.Size(144, 21);
            this.cbDestinationTransportStops.TabIndex = 7;
            // 
            // gbSourceTransportStop
            // 
            this.gbSourceTransportStop.Controls.Add(this.cbSourceTransportStops);
            this.gbSourceTransportStop.Location = new System.Drawing.Point(6, 16);
            this.gbSourceTransportStop.Name = "gbSourceTransportStop";
            this.gbSourceTransportStop.Size = new System.Drawing.Size(150, 44);
            this.gbSourceTransportStop.TabIndex = 4;
            this.gbSourceTransportStop.TabStop = false;
            this.gbSourceTransportStop.Text = "Начальная остановка";
            // 
            // cbSourceTransportStops
            // 
            this.cbSourceTransportStops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSourceTransportStops.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceTransportStops.FormattingEnabled = true;
            this.cbSourceTransportStops.Location = new System.Drawing.Point(3, 16);
            this.cbSourceTransportStops.Name = "cbSourceTransportStops";
            this.cbSourceTransportStops.Size = new System.Drawing.Size(144, 21);
            this.cbSourceTransportStops.TabIndex = 5;
            // 
            // gbMinTotalTimePaths
            // 
            this.gbMinTotalTimePaths.Controls.Add(this.tbMinTotalTimePaths);
            this.gbMinTotalTimePaths.Location = new System.Drawing.Point(6, 66);
            this.gbMinTotalTimePaths.Name = "gbMinTotalTimePaths";
            this.gbMinTotalTimePaths.Size = new System.Drawing.Size(540, 161);
            this.gbMinTotalTimePaths.TabIndex = 11;
            this.gbMinTotalTimePaths.TabStop = false;
            this.gbMinTotalTimePaths.Text = "Пути с минимальным временем поездки";
            // 
            // tbMinTotalTimePaths
            // 
            this.tbMinTotalTimePaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMinTotalTimePaths.Location = new System.Drawing.Point(3, 16);
            this.tbMinTotalTimePaths.Multiline = true;
            this.tbMinTotalTimePaths.Name = "tbMinTotalTimePaths";
            this.tbMinTotalTimePaths.ReadOnly = true;
            this.tbMinTotalTimePaths.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMinTotalTimePaths.Size = new System.Drawing.Size(534, 142);
            this.tbMinTotalTimePaths.TabIndex = 12;
            this.tbMinTotalTimePaths.WordWrap = false;
            // 
            // bFindMinPathsInTransportNetwork
            // 
            this.bFindMinPathsInTransportNetwork.Location = new System.Drawing.Point(446, 16);
            this.bFindMinPathsInTransportNetwork.Name = "bFindMinPathsInTransportNetwork";
            this.bFindMinPathsInTransportNetwork.Size = new System.Drawing.Size(100, 44);
            this.bFindMinPathsInTransportNetwork.TabIndex = 10;
            this.bFindMinPathsInTransportNetwork.Text = "Найти";
            this.bFindMinPathsInTransportNetwork.UseVisualStyleBackColor = true;
            this.bFindMinPathsInTransportNetwork.Click += new System.EventHandler(this.bFindMinPathsInTransportNetwork_Click);
            // 
            // ofdTransportRoutesFileToReadSelectionDialog
            // 
            this.ofdTransportRoutesFileToReadSelectionDialog.Filter = "Текстовые файлы|*.txt";
            this.ofdTransportRoutesFileToReadSelectionDialog.Title = "Выберите файл для чтения";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 439);
            this.Controls.Add(this.gbMinPathsInTransportNetworkFinding);
            this.Controls.Add(this.gbTransportRoutes);
            this.Controls.Add(this.msMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "TNPathsFinder";
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.gbTransportRoutes.ResumeLayout(false);
            this.gbTransportRoutes.PerformLayout();
            this.gbMinPathsInTransportNetworkFinding.ResumeLayout(false);
            this.gbDepartureTime.ResumeLayout(false);
            this.gbMinTotalCostPaths.ResumeLayout(false);
            this.gbMinTotalCostPaths.PerformLayout();
            this.gbDestinationTransportStop.ResumeLayout(false);
            this.gbSourceTransportStop.ResumeLayout(false);
            this.gbMinTotalTimePaths.ResumeLayout(false);
            this.gbMinTotalTimePaths.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadTransportRoutesListFromFile;
        private System.Windows.Forms.GroupBox gbTransportRoutes;
        private System.Windows.Forms.TextBox tbTransportRoutes;
        private System.Windows.Forms.GroupBox gbMinPathsInTransportNetworkFinding;
        private System.Windows.Forms.GroupBox gbMinTotalCostPaths;
        private System.Windows.Forms.TextBox tbMinTotalCostPaths;
        private System.Windows.Forms.DateTimePicker dtpDepartureTime;
        private System.Windows.Forms.Button bFindMinPathsInTransportNetwork;
        private System.Windows.Forms.GroupBox gbMinTotalTimePaths;
        private System.Windows.Forms.TextBox tbMinTotalTimePaths;
        private System.Windows.Forms.GroupBox gbDepartureTime;
        private System.Windows.Forms.GroupBox gbDestinationTransportStop;
        private System.Windows.Forms.ComboBox cbDestinationTransportStops;
        private System.Windows.Forms.GroupBox gbSourceTransportStop;
        private System.Windows.Forms.ComboBox cbSourceTransportStops;
        private System.Windows.Forms.OpenFileDialog ofdTransportRoutesFileToReadSelectionDialog;
    }
}

