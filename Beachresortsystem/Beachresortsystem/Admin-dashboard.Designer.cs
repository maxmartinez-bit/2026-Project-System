namespace Beachresortsystem
{
    partial class Admin_dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_dashboard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGuests = new System.Windows.Forms.Label();
            this.lblReservations = new System.Windows.Forms.Label();
            this.lblRooms = new System.Windows.Forms.Label();
            this.panel3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblGuestsCount = new System.Windows.Forms.Label();
            this.panel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblReservationCount = new System.Windows.Forms.Label();
            this.panel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblRoomsCount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDarkMode = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnLogout = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMaintenance = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnReports = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnstaff = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnServices = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnRooms = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2GradientButton();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMain.AutoSize = true;
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.lblGuests);
            this.panelMain.Controls.Add(this.lblReservations);
            this.panelMain.Controls.Add(this.lblRooms);
            this.panelMain.Controls.Add(this.panel3);
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.panelSidebar);
            this.panelMain.Controls.Add(this.chart1);
            this.panelMain.Location = new System.Drawing.Point(12, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1267, 721);
            this.panelMain.TabIndex = 0;
            // 
            // lblGuests
            // 
            this.lblGuests.AutoSize = true;
            this.lblGuests.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuests.Location = new System.Drawing.Point(1021, 203);
            this.lblGuests.Name = "lblGuests";
            this.lblGuests.Size = new System.Drawing.Size(85, 31);
            this.lblGuests.TabIndex = 36;
            this.lblGuests.Text = "Guests";
            // 
            // lblReservations
            // 
            this.lblReservations.AutoSize = true;
            this.lblReservations.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservations.Location = new System.Drawing.Point(728, 203);
            this.lblReservations.Name = "lblReservations";
            this.lblReservations.Size = new System.Drawing.Size(150, 31);
            this.lblReservations.TabIndex = 35;
            this.lblReservations.Text = "Reservations";
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRooms.Location = new System.Drawing.Point(493, 203);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(87, 31);
            this.lblRooms.TabIndex = 0;
            this.lblRooms.Text = "Rooms";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lblGuestsCount);
            this.panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel3.Location = new System.Drawing.Point(962, 83);
            this.panel3.Name = "panel3";
            this.panel3.Radius = 15;
            this.panel3.ShadowColor = System.Drawing.Color.Black;
            this.panel3.Size = new System.Drawing.Size(198, 117);
            this.panel3.TabIndex = 34;
            // 
            // lblGuestsCount
            // 
            this.lblGuestsCount.AutoSize = true;
            this.lblGuestsCount.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestsCount.ForeColor = System.Drawing.Color.White;
            this.lblGuestsCount.Location = new System.Drawing.Point(78, 32);
            this.lblGuestsCount.Name = "lblGuestsCount";
            this.lblGuestsCount.Size = new System.Drawing.Size(54, 62);
            this.lblGuestsCount.TabIndex = 37;
            this.lblGuestsCount.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lblReservationCount);
            this.panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Location = new System.Drawing.Point(701, 83);
            this.panel2.Name = "panel2";
            this.panel2.Radius = 15;
            this.panel2.ShadowColor = System.Drawing.Color.Black;
            this.panel2.Size = new System.Drawing.Size(198, 117);
            this.panel2.TabIndex = 34;
            // 
            // lblReservationCount
            // 
            this.lblReservationCount.AutoSize = true;
            this.lblReservationCount.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationCount.ForeColor = System.Drawing.Color.White;
            this.lblReservationCount.Location = new System.Drawing.Point(71, 32);
            this.lblReservationCount.Name = "lblReservationCount";
            this.lblReservationCount.Size = new System.Drawing.Size(54, 62);
            this.lblReservationCount.TabIndex = 1;
            this.lblReservationCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblRoomsCount);
            this.panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(438, 83);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 15;
            this.panel1.ShadowColor = System.Drawing.Color.Black;
            this.panel1.Size = new System.Drawing.Size(198, 117);
            this.panel1.TabIndex = 33;
            // 
            // lblRoomsCount
            // 
            this.lblRoomsCount.AutoSize = true;
            this.lblRoomsCount.Location = new System.Drawing.Point(69, 32);
            this.lblRoomsCount.Name = "lblRoomsCount";
            this.lblRoomsCount.Size = new System.Drawing.Size(54, 62);
            this.lblRoomsCount.TabIndex = 0;
            this.lblRoomsCount.Text = "0";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(410, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(356, 45);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.Text = "Dashboard Overview";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.Transparent;
            this.panelSidebar.BorderRadius = 25;
            this.panelSidebar.Controls.Add(this.guna2PictureBox3);
            this.panelSidebar.Controls.Add(this.panelContainer);
            this.panelSidebar.Controls.Add(this.label2);
            this.panelSidebar.Controls.Add(this.label1);
            this.panelSidebar.Controls.Add(this.btnDarkMode);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.guna2PictureBox2);
            this.panelSidebar.Controls.Add(this.guna2PictureBox1);
            this.panelSidebar.Controls.Add(this.btnMaintenance);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnstaff);
            this.panelSidebar.Controls.Add(this.btnServices);
            this.panelSidebar.Controls.Add(this.btnRooms);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(404, 721);
            this.panelSidebar.TabIndex = 27;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.guna2PictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox3.Image")));
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(122, 633);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(35, 32);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 34;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.UseTransparentBackground = true;
            // 
            // panelContainer
            // 
            this.panelContainer.Location = new System.Drawing.Point(407, 3);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(857, 702);
            this.panelContainer.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(117, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 32;
            this.label2.Text = "Admin (Maxii)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(110, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 38);
            this.label1.TabIndex = 31;
            this.label1.Text = "Manage Resort";
            // 
            // btnDarkMode
            // 
            this.btnDarkMode.AllowDrop = true;
            this.btnDarkMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDarkMode.BorderRadius = 15;
            this.btnDarkMode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDarkMode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDarkMode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDarkMode.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDarkMode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDarkMode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDarkMode.ForeColor = System.Drawing.Color.White;
            this.btnDarkMode.Location = new System.Drawing.Point(108, 622);
            this.btnDarkMode.Name = "btnDarkMode";
            this.btnDarkMode.Size = new System.Drawing.Size(189, 57);
            this.btnDarkMode.TabIndex = 30;
            this.btnDarkMode.Text = "Dark Mood";
            this.btnDarkMode.Click += new System.EventHandler(this.btnDarkMood_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BorderRadius = 15;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(108, 529);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(189, 57);
            this.btnLogout.TabIndex = 29;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.BackgroundImage")));
            this.guna2PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(72, 101);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(39, 25);
            this.guna2PictureBox2.TabIndex = 28;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.BackgroundImage")));
            this.guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(64, 27);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(47, 37);
            this.guna2PictureBox1.TabIndex = 26;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.BorderRadius = 15;
            this.btnMaintenance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMaintenance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMaintenance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaintenance.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaintenance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMaintenance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnMaintenance.Location = new System.Drawing.Point(108, 466);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(189, 57);
            this.btnMaintenance.TabIndex = 24;
            this.btnMaintenance.Text = "Maintenance";
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // btnReports
            // 
            this.btnReports.BorderRadius = 15;
            this.btnReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReports.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(108, 403);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(189, 57);
            this.btnReports.TabIndex = 23;
            this.btnReports.Text = "Reports";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnstaff
            // 
            this.btnstaff.BorderRadius = 15;
            this.btnstaff.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnstaff.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnstaff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnstaff.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnstaff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnstaff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnstaff.ForeColor = System.Drawing.Color.White;
            this.btnstaff.Location = new System.Drawing.Point(108, 342);
            this.btnstaff.Name = "btnstaff";
            this.btnstaff.Size = new System.Drawing.Size(189, 57);
            this.btnstaff.TabIndex = 22;
            this.btnstaff.Text = "Staff Management";
            this.btnstaff.Click += new System.EventHandler(this.btnstaff_Click);
            // 
            // btnServices
            // 
            this.btnServices.BorderRadius = 15;
            this.btnServices.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnServices.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnServices.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnServices.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnServices.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnServices.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnServices.ForeColor = System.Drawing.Color.White;
            this.btnServices.Location = new System.Drawing.Point(108, 279);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(189, 57);
            this.btnServices.TabIndex = 21;
            this.btnServices.Text = "Services";
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click_1);
            // 
            // btnRooms
            // 
            this.btnRooms.BorderRadius = 15;
            this.btnRooms.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRooms.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRooms.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRooms.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRooms.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRooms.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRooms.ForeColor = System.Drawing.Color.White;
            this.btnRooms.Location = new System.Drawing.Point(108, 216);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(189, 57);
            this.btnRooms.TabIndex = 20;
            this.btnRooms.Text = "Rooms";
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Animated = true;
            this.btnDashboard.BorderRadius = 15;
            this.btnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(172)))), ((int)(((byte)(254)))));
            this.btnDashboard.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(78)))), ((int)(((byte)(202)))));
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(108, 153);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(189, 57);
            this.btnDashboard.TabIndex = 19;
            this.btnDashboard.Text = "Dashboard";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(427, 246);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(837, 472);
            this.chart1.TabIndex = 22;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // Admin_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1291, 729);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin_dashboard";
            this.Text = "Admin_dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Admin_dashboard_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2Panel panelSidebar;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton btnDarkMode;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogout;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton btnMaintenance;
        private Guna.UI2.WinForms.Guna2GradientButton btnReports;
        private Guna.UI2.WinForms.Guna2GradientButton btnstaff;
        private Guna.UI2.WinForms.Guna2GradientButton btnServices;
        private Guna.UI2.WinForms.Guna2GradientButton btnRooms;
        private Guna.UI2.WinForms.Guna2GradientButton btnDashboard;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContainer;
        private Guna.UI2.WinForms.Guna2ShadowPanel panel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel panel3;
        private Guna.UI2.WinForms.Guna2ShadowPanel panel2;
        private System.Windows.Forms.Label lblGuests;
        private System.Windows.Forms.Label lblReservations;
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.Label lblGuestsCount;
        private System.Windows.Forms.Label lblReservationCount;
        private System.Windows.Forms.Label lblRoomsCount;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
    }
}