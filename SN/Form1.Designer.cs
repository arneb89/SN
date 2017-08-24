namespace SN
{
    partial class Form1
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
            this.plotObsSpectrum = new NPlot.Windows.PlotSurface2D();
            this.btnLoadTemplateSpectrum = new System.Windows.Forms.Button();
            this.btnLoadObservedSpectrum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPolynomsOrder = new System.Windows.Forms.TextBox();
            this.btnNormalize = new System.Windows.Forms.Button();
            this.plotTemplateSpectrum = new NPlot.Windows.PlotSurface2D();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCropLambdaMax = new System.Windows.Forms.TextBox();
            this.txtCropLambdaMin = new System.Windows.Forms.TextBox();
            this.btnShowWholeSpectrum = new System.Windows.Forms.Button();
            this.btnCrop = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCCMask = new System.Windows.Forms.Button();
            this.btnMaskSave = new System.Windows.Forms.Button();
            this.btnMaskOpen = new System.Windows.Forms.Button();
            this.btnDelRange = new System.Windows.Forms.Button();
            this.lbRanges = new System.Windows.Forms.ListBox();
            this.rb_ExcludeMask = new System.Windows.Forms.RadioButton();
            this.rb_IncludeMask = new System.Windows.Forms.RadioButton();
            this.txtHighReject = new System.Windows.Forms.TextBox();
            this.txtNIter = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.txtStdDev = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbFunction = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLowReject = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_NormInterp = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCCProgress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRVStep = new System.Windows.Forms.TextBox();
            this.txtRVUB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCurShift = new System.Windows.Forms.TextBox();
            this.btnShift = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShift = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRVLB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCCFGo = new System.Windows.Forms.Button();
            this.btnSaveNormSpectrum = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadNormSpectrum = new System.Windows.Forms.Button();
            this.txtCCFRes = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotObsSpectrum
            // 
            this.plotObsSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plotObsSpectrum.AutoScaleAutoGeneratedAxes = false;
            this.plotObsSpectrum.AutoScaleTitle = false;
            this.plotObsSpectrum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.plotObsSpectrum.DateTimeToolTip = false;
            this.plotObsSpectrum.Legend = null;
            this.plotObsSpectrum.LegendZOrder = -1;
            this.plotObsSpectrum.Location = new System.Drawing.Point(6, 7);
            this.plotObsSpectrum.Name = "plotObsSpectrum";
            this.plotObsSpectrum.RightMenu = null;
            this.plotObsSpectrum.ShowCoordinates = true;
            this.plotObsSpectrum.Size = new System.Drawing.Size(800, 533);
            this.plotObsSpectrum.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.plotObsSpectrum.TabIndex = 0;
            this.plotObsSpectrum.Text = "plotObsSpectrum";
            this.plotObsSpectrum.Title = "";
            this.plotObsSpectrum.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.plotObsSpectrum.XAxis1 = null;
            this.plotObsSpectrum.XAxis2 = null;
            this.plotObsSpectrum.YAxis1 = null;
            this.plotObsSpectrum.YAxis2 = null;
            // 
            // btnLoadTemplateSpectrum
            // 
            this.btnLoadTemplateSpectrum.Location = new System.Drawing.Point(12, 46);
            this.btnLoadTemplateSpectrum.Name = "btnLoadTemplateSpectrum";
            this.btnLoadTemplateSpectrum.Size = new System.Drawing.Size(135, 28);
            this.btnLoadTemplateSpectrum.TabIndex = 1;
            this.btnLoadTemplateSpectrum.Text = "Load Temp. Spectrum";
            this.btnLoadTemplateSpectrum.UseVisualStyleBackColor = true;
            this.btnLoadTemplateSpectrum.Click += new System.EventHandler(this.btnLoadTemplateSpectrum_Click);
            // 
            // btnLoadObservedSpectrum
            // 
            this.btnLoadObservedSpectrum.Location = new System.Drawing.Point(12, 12);
            this.btnLoadObservedSpectrum.Name = "btnLoadObservedSpectrum";
            this.btnLoadObservedSpectrum.Size = new System.Drawing.Size(135, 28);
            this.btnLoadObservedSpectrum.TabIndex = 2;
            this.btnLoadObservedSpectrum.Text = "Load Obs. Spectrum";
            this.btnLoadObservedSpectrum.UseVisualStyleBackColor = true;
            this.btnLoadObservedSpectrum.Click += new System.EventHandler(this.btnLoadObservedSpectrum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Polynom\'s Order";
            // 
            // txtPolynomsOrder
            // 
            this.txtPolynomsOrder.Location = new System.Drawing.Point(150, 72);
            this.txtPolynomsOrder.Name = "txtPolynomsOrder";
            this.txtPolynomsOrder.Size = new System.Drawing.Size(49, 20);
            this.txtPolynomsOrder.TabIndex = 4;
            this.txtPolynomsOrder.Text = "10";
            // 
            // btnNormalize
            // 
            this.btnNormalize.Location = new System.Drawing.Point(5, 202);
            this.btnNormalize.Name = "btnNormalize";
            this.btnNormalize.Size = new System.Drawing.Size(195, 29);
            this.btnNormalize.TabIndex = 5;
            this.btnNormalize.Text = "Normalize";
            this.btnNormalize.UseVisualStyleBackColor = true;
            this.btnNormalize.Click += new System.EventHandler(this.btnNormalize_Click);
            // 
            // plotTemplateSpectrum
            // 
            this.plotTemplateSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plotTemplateSpectrum.AutoScaleAutoGeneratedAxes = false;
            this.plotTemplateSpectrum.AutoScaleTitle = false;
            this.plotTemplateSpectrum.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotTemplateSpectrum.DateTimeToolTip = false;
            this.plotTemplateSpectrum.Legend = null;
            this.plotTemplateSpectrum.LegendZOrder = -1;
            this.plotTemplateSpectrum.Location = new System.Drawing.Point(6, 35);
            this.plotTemplateSpectrum.Name = "plotTemplateSpectrum";
            this.plotTemplateSpectrum.RightMenu = null;
            this.plotTemplateSpectrum.ShowCoordinates = true;
            this.plotTemplateSpectrum.Size = new System.Drawing.Size(800, 408);
            this.plotTemplateSpectrum.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.plotTemplateSpectrum.TabIndex = 6;
            this.plotTemplateSpectrum.Text = "plotTemplateSpectrum";
            this.plotTemplateSpectrum.Title = "";
            this.plotTemplateSpectrum.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.plotTemplateSpectrum.XAxis1 = null;
            this.plotTemplateSpectrum.XAxis2 = null;
            this.plotTemplateSpectrum.YAxis1 = null;
            this.plotTemplateSpectrum.YAxis2 = null;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(231, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(820, 572);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.plotObsSpectrum);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(812, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 323);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 20);
            this.textBox1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtCropLambdaMax);
            this.tabPage2.Controls.Add(this.txtCropLambdaMin);
            this.tabPage2.Controls.Add(this.btnShowWholeSpectrum);
            this.tabPage2.Controls.Add(this.btnCrop);
            this.tabPage2.Controls.Add(this.plotTemplateSpectrum);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(812, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Analyze";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "lambda";
            // 
            // txtCropLambdaMax
            // 
            this.txtCropLambdaMax.Location = new System.Drawing.Point(340, 8);
            this.txtCropLambdaMax.Name = "txtCropLambdaMax";
            this.txtCropLambdaMax.Size = new System.Drawing.Size(77, 20);
            this.txtCropLambdaMax.TabIndex = 10;
            // 
            // txtCropLambdaMin
            // 
            this.txtCropLambdaMin.Location = new System.Drawing.Point(235, 8);
            this.txtCropLambdaMin.Name = "txtCropLambdaMin";
            this.txtCropLambdaMin.Size = new System.Drawing.Size(77, 20);
            this.txtCropLambdaMin.TabIndex = 9;
            // 
            // btnShowWholeSpectrum
            // 
            this.btnShowWholeSpectrum.Location = new System.Drawing.Point(6, 6);
            this.btnShowWholeSpectrum.Name = "btnShowWholeSpectrum";
            this.btnShowWholeSpectrum.Size = new System.Drawing.Size(75, 23);
            this.btnShowWholeSpectrum.TabIndex = 8;
            this.btnShowWholeSpectrum.Text = "Whole";
            this.btnShowWholeSpectrum.UseVisualStyleBackColor = true;
            this.btnShowWholeSpectrum.Click += new System.EventHandler(this.btnShowWholeSpectrum_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Location = new System.Drawing.Point(87, 6);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(75, 23);
            this.btnCrop.TabIndex = 7;
            this.btnCrop.Text = "Crop";
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCCMask);
            this.groupBox4.Controls.Add(this.btnMaskSave);
            this.groupBox4.Controls.Add(this.btnMaskOpen);
            this.groupBox4.Controls.Add(this.btnDelRange);
            this.groupBox4.Controls.Add(this.lbRanges);
            this.groupBox4.Location = new System.Drawing.Point(12, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 153);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mask";
            // 
            // btnCCMask
            // 
            this.btnCCMask.BackColor = System.Drawing.Color.Tomato;
            this.btnCCMask.Location = new System.Drawing.Point(161, 120);
            this.btnCCMask.Name = "btnCCMask";
            this.btnCCMask.Size = new System.Drawing.Size(46, 23);
            this.btnCCMask.TabIndex = 17;
            this.btnCCMask.Text = "CC";
            this.btnCCMask.UseVisualStyleBackColor = false;
            this.btnCCMask.Click += new System.EventHandler(this.btnCCMask_Click);
            // 
            // btnMaskSave
            // 
            this.btnMaskSave.Location = new System.Drawing.Point(58, 120);
            this.btnMaskSave.Name = "btnMaskSave";
            this.btnMaskSave.Size = new System.Drawing.Size(46, 23);
            this.btnMaskSave.TabIndex = 16;
            this.btnMaskSave.Text = "Save";
            this.btnMaskSave.UseVisualStyleBackColor = true;
            this.btnMaskSave.Click += new System.EventHandler(this.btnMaskSave_Click);
            // 
            // btnMaskOpen
            // 
            this.btnMaskOpen.Location = new System.Drawing.Point(6, 120);
            this.btnMaskOpen.Name = "btnMaskOpen";
            this.btnMaskOpen.Size = new System.Drawing.Size(46, 23);
            this.btnMaskOpen.TabIndex = 15;
            this.btnMaskOpen.Text = "Open";
            this.btnMaskOpen.UseVisualStyleBackColor = true;
            this.btnMaskOpen.Click += new System.EventHandler(this.btnMaskOpen_Click);
            // 
            // btnDelRange
            // 
            this.btnDelRange.Location = new System.Drawing.Point(110, 120);
            this.btnDelRange.Name = "btnDelRange";
            this.btnDelRange.Size = new System.Drawing.Size(46, 23);
            this.btnDelRange.TabIndex = 2;
            this.btnDelRange.Text = "Del";
            this.btnDelRange.UseVisualStyleBackColor = true;
            this.btnDelRange.Click += new System.EventHandler(this.btnDelRange_Click);
            // 
            // lbRanges
            // 
            this.lbRanges.FormattingEnabled = true;
            this.lbRanges.Location = new System.Drawing.Point(6, 19);
            this.lbRanges.Name = "lbRanges";
            this.lbRanges.Size = new System.Drawing.Size(201, 95);
            this.lbRanges.TabIndex = 1;
            // 
            // rb_ExcludeMask
            // 
            this.rb_ExcludeMask.AutoSize = true;
            this.rb_ExcludeMask.Checked = true;
            this.rb_ExcludeMask.Location = new System.Drawing.Point(6, 42);
            this.rb_ExcludeMask.Name = "rb_ExcludeMask";
            this.rb_ExcludeMask.Size = new System.Drawing.Size(63, 17);
            this.rb_ExcludeMask.TabIndex = 14;
            this.rb_ExcludeMask.TabStop = true;
            this.rb_ExcludeMask.Text = "Exclude";
            this.rb_ExcludeMask.UseVisualStyleBackColor = true;
            this.rb_ExcludeMask.CheckedChanged += new System.EventHandler(this.rb_ExcludeMask_CheckedChanged);
            // 
            // rb_IncludeMask
            // 
            this.rb_IncludeMask.AutoSize = true;
            this.rb_IncludeMask.Location = new System.Drawing.Point(6, 19);
            this.rb_IncludeMask.Name = "rb_IncludeMask";
            this.rb_IncludeMask.Size = new System.Drawing.Size(60, 17);
            this.rb_IncludeMask.TabIndex = 13;
            this.rb_IncludeMask.Text = "Include";
            this.rb_IncludeMask.UseVisualStyleBackColor = true;
            this.rb_IncludeMask.CheckedChanged += new System.EventHandler(this.rb_IncludeMask_CheckedChanged);
            // 
            // txtHighReject
            // 
            this.txtHighReject.Location = new System.Drawing.Point(150, 98);
            this.txtHighReject.Name = "txtHighReject";
            this.txtHighReject.Size = new System.Drawing.Size(49, 20);
            this.txtHighReject.TabIndex = 8;
            this.txtHighReject.Text = "3";
            // 
            // txtNIter
            // 
            this.txtNIter.Location = new System.Drawing.Point(150, 150);
            this.txtNIter.Name = "txtNIter";
            this.txtNIter.Size = new System.Drawing.Size(49, 20);
            this.txtNIter.TabIndex = 9;
            this.txtNIter.Text = "2";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(12, 239);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(213, 278);
            this.tabControl2.TabIndex = 13;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.txtStdDev);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.cbFunction);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.txtLowReject);
            this.tabPage4.Controls.Add(this.txtPolynomsOrder);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.txtHighReject);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.txtNIter);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.btnNormalize);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(205, 237);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Approx";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(61, 179);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Norm. Std. Dev.";
            // 
            // txtStdDev
            // 
            this.txtStdDev.Location = new System.Drawing.Point(150, 176);
            this.txtStdDev.Name = "txtStdDev";
            this.txtStdDev.ReadOnly = true;
            this.txtStdDev.Size = new System.Drawing.Size(49, 20);
            this.txtStdDev.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Function";
            // 
            // cbFunction
            // 
            this.cbFunction.FormattingEnabled = true;
            this.cbFunction.Items.AddRange(new object[] {
            "Simple",
            "Chebyshev"});
            this.cbFunction.Location = new System.Drawing.Point(5, 22);
            this.cbFunction.Name = "cbFunction";
            this.cbFunction.Size = new System.Drawing.Size(97, 21);
            this.cbFunction.TabIndex = 13;
            this.cbFunction.Text = "Simple";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_IncludeMask);
            this.groupBox1.Controls.Add(this.rb_ExcludeMask);
            this.groupBox1.Location = new System.Drawing.Point(109, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(90, 63);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mask";
            // 
            // txtLowReject
            // 
            this.txtLowReject.Location = new System.Drawing.Point(150, 124);
            this.txtLowReject.Name = "txtLowReject";
            this.txtLowReject.Size = new System.Drawing.Size(49, 20);
            this.txtLowReject.TabIndex = 14;
            this.txtLowReject.Text = "3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Low Reject [sigma]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Iterations Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "High Reject [sigma]";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btn_NormInterp);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(205, 237);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Interp";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_NormInterp
            // 
            this.btn_NormInterp.Location = new System.Drawing.Point(6, 6);
            this.btn_NormInterp.Name = "btn_NormInterp";
            this.btn_NormInterp.Size = new System.Drawing.Size(193, 29);
            this.btn_NormInterp.TabIndex = 6;
            this.btn_NormInterp.Text = "Normalize";
            this.btn_NormInterp.UseVisualStyleBackColor = true;
            this.btn_NormInterp.Click += new System.EventHandler(this.btn_NormInterp_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtCCFRes);
            this.tabPage6.Controls.Add(this.label13);
            this.tabPage6.Controls.Add(this.txtCCProgress);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.txtRVStep);
            this.tabPage6.Controls.Add(this.txtRVUB);
            this.tabPage6.Controls.Add(this.groupBox2);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Controls.Add(this.txtRVLB);
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.Controls.Add(this.btnCCFGo);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(205, 252);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "RV Shift";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(79, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Progress [%]";
            // 
            // txtCCProgress
            // 
            this.txtCCProgress.Location = new System.Drawing.Point(150, 164);
            this.txtCCProgress.Name = "txtCCProgress";
            this.txtCCProgress.ReadOnly = true;
            this.txtCCProgress.Size = new System.Drawing.Size(46, 20);
            this.txtCCProgress.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(82, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Step [km/s]";
            // 
            // txtRVStep
            // 
            this.txtRVStep.Location = new System.Drawing.Point(150, 138);
            this.txtRVStep.Name = "txtRVStep";
            this.txtRVStep.Size = new System.Drawing.Size(46, 20);
            this.txtRVStep.TabIndex = 16;
            this.txtRVStep.Text = "0,01";
            // 
            // txtRVUB
            // 
            this.txtRVUB.Location = new System.Drawing.Point(150, 112);
            this.txtRVUB.Name = "txtRVUB";
            this.txtRVUB.Size = new System.Drawing.Size(46, 20);
            this.txtRVUB.TabIndex = 15;
            this.txtRVUB.Text = "20";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtCurShift);
            this.groupBox2.Controls.Add(this.btnShift);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtShift);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Constant Shift";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Curent Shift [km/s]";
            // 
            // txtCurShift
            // 
            this.txtCurShift.Location = new System.Drawing.Point(133, 47);
            this.txtCurShift.Name = "txtCurShift";
            this.txtCurShift.ReadOnly = true;
            this.txtCurShift.Size = new System.Drawing.Size(57, 20);
            this.txtCurShift.TabIndex = 19;
            // 
            // btnShift
            // 
            this.btnShift.Location = new System.Drawing.Point(6, 19);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(60, 22);
            this.btnShift.TabIndex = 18;
            this.btnShift.Text = "Shift";
            this.btnShift.UseVisualStyleBackColor = true;
            this.btnShift.Click += new System.EventHandler(this.btnShift_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "RV [km/s]";
            // 
            // txtShift
            // 
            this.txtShift.Location = new System.Drawing.Point(133, 21);
            this.txtShift.Name = "txtShift";
            this.txtShift.Size = new System.Drawing.Size(57, 20);
            this.txtShift.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Upper bound [km/s]";
            // 
            // txtRVLB
            // 
            this.txtRVLB.Location = new System.Drawing.Point(150, 86);
            this.txtRVLB.Name = "txtRVLB";
            this.txtRVLB.Size = new System.Drawing.Size(46, 20);
            this.txtRVLB.TabIndex = 13;
            this.txtRVLB.Text = "-20";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Lower bound [km/s]";
            // 
            // btnCCFGo
            // 
            this.btnCCFGo.Location = new System.Drawing.Point(6, 216);
            this.btnCCFGo.Name = "btnCCFGo";
            this.btnCCFGo.Size = new System.Drawing.Size(194, 28);
            this.btnCCFGo.TabIndex = 13;
            this.btnCCFGo.Text = "Run CCF Analizis";
            this.btnCCFGo.UseVisualStyleBackColor = true;
            this.btnCCFGo.Click += new System.EventHandler(this.btnCCFGo_Click);
            // 
            // btnSaveNormSpectrum
            // 
            this.btnSaveNormSpectrum.Location = new System.Drawing.Point(21, 523);
            this.btnSaveNormSpectrum.Name = "btnSaveNormSpectrum";
            this.btnSaveNormSpectrum.Size = new System.Drawing.Size(195, 30);
            this.btnSaveNormSpectrum.TabIndex = 14;
            this.btnSaveNormSpectrum.Text = "Save Normalized Spectrum";
            this.btnSaveNormSpectrum.UseVisualStyleBackColor = true;
            this.btnSaveNormSpectrum.Click += new System.EventHandler(this.btnSaveNormSpectrum_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 559);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 30);
            this.button1.TabIndex = 15;
            this.button1.Text = "Save Continum";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoadNormSpectrum
            // 
            this.btnLoadNormSpectrum.Location = new System.Drawing.Point(150, 12);
            this.btnLoadNormSpectrum.Name = "btnLoadNormSpectrum";
            this.btnLoadNormSpectrum.Size = new System.Drawing.Size(75, 62);
            this.btnLoadNormSpectrum.TabIndex = 13;
            this.btnLoadNormSpectrum.Text = "Load Norm. Spectrum";
            this.btnLoadNormSpectrum.UseVisualStyleBackColor = true;
            this.btnLoadNormSpectrum.Click += new System.EventHandler(this.btnLoadNormSpectrum_Click);
            // 
            // txtCCFRes
            // 
            this.txtCCFRes.Location = new System.Drawing.Point(6, 190);
            this.txtCCFRes.Name = "txtCCFRes";
            this.txtCCFRes.ReadOnly = true;
            this.txtCCFRes.Size = new System.Drawing.Size(190, 20);
            this.txtCCFRes.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 601);
            this.Controls.Add(this.btnLoadNormSpectrum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnSaveNormSpectrum);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnLoadObservedSpectrum);
            this.Controls.Add(this.btnLoadTemplateSpectrum);
            this.Name = "Form1";
            this.Text = "SN";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NPlot.Windows.PlotSurface2D plotObsSpectrum;
        private System.Windows.Forms.Button btnLoadTemplateSpectrum;
        private System.Windows.Forms.Button btnLoadObservedSpectrum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPolynomsOrder;
        private System.Windows.Forms.Button btnNormalize;
        private NPlot.Windows.PlotSurface2D plotTemplateSpectrum;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtHighReject;
        private System.Windows.Forms.TextBox txtNIter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtShift;
        private System.Windows.Forms.Button btnShowWholeSpectrum;
        private System.Windows.Forms.Button btnCrop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCropLambdaMax;
        private System.Windows.Forms.TextBox txtCropLambdaMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveNormSpectrum;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtLowReject;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbRanges;
        private System.Windows.Forms.Button btnDelRange;
        private System.Windows.Forms.RadioButton rb_IncludeMask;
        private System.Windows.Forms.RadioButton rb_ExcludeMask;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btn_NormInterp;
        private System.Windows.Forms.Button btnMaskSave;
        private System.Windows.Forms.Button btnMaskOpen;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnCCFGo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRVStep;
        private System.Windows.Forms.TextBox txtRVUB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRVLB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbFunction;
        private System.Windows.Forms.Button btnShift;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCurShift;
        private System.Windows.Forms.Button btnLoadNormSpectrum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCCProgress;
        private System.Windows.Forms.Button btnCCMask;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtStdDev;
        private System.Windows.Forms.TextBox txtCCFRes;
    }
}

