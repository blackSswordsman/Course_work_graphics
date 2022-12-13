namespace GSC_Lr4
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.clearBtn = new System.Windows.Forms.Button();
            this.selectBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showColor = new System.Windows.Forms.Panel();
            this.colorBtn = new System.Windows.Forms.Button();
            this.starBtn = new System.Windows.Forms.Button();
            this.RhombBtn = new System.Windows.Forms.Button();
            this.segmentBtn = new System.Windows.Forms.Button();
            this.splineBtn = new System.Windows.Forms.Button();
            this.TMOCmbBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RotateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ReflectBtn = new System.Windows.Forms.Button();
            this.ScaleBtn = new System.Windows.Forms.Button();
            this.ExecuteTMO = new System.Windows.Forms.Button();
            this.TMO_Mode = new System.Windows.Forms.CheckBox();
            this.EnlargeBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(13, 6);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(100, 28);
            this.clearBtn.TabIndex = 7;
            this.clearBtn.Text = "Очистить";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // selectBtn
            // 
            this.selectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectBtn.Location = new System.Drawing.Point(1628, 455);
            this.selectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(164, 41);
            this.selectBtn.TabIndex = 5;
            this.selectBtn.Text = "Выбрать";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.HelpRequest += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.showColor);
            this.panel1.Controls.Add(this.colorBtn);
            this.panel1.Controls.Add(this.starBtn);
            this.panel1.Controls.Add(this.RhombBtn);
            this.panel1.Controls.Add(this.segmentBtn);
            this.panel1.Controls.Add(this.splineBtn);
            this.panel1.Location = new System.Drawing.Point(1611, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 406);
            this.panel1.TabIndex = 13;
            // 
            // showColor
            // 
            this.showColor.Location = new System.Drawing.Point(26, 171);
            this.showColor.Name = "showColor";
            this.showColor.Size = new System.Drawing.Size(128, 31);
            this.showColor.TabIndex = 13;
            // 
            // colorBtn
            // 
            this.colorBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.colorBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.colorBtn.Image = global::GSC_LR4.Properties.Resources.Screenshot_62;
            this.colorBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.colorBtn.Location = new System.Drawing.Point(26, 24);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(121, 123);
            this.colorBtn.TabIndex = 8;
            this.colorBtn.Text = "Выбрать \r\nцвет";
            this.colorBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.colorBtn.UseVisualStyleBackColor = false;
            this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
            // 
            // starBtn
            // 
            this.starBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.starBtn.Image = global::GSC_LR4.Properties.Resources.FivePointStar;
            this.starBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.starBtn.Location = new System.Drawing.Point(26, 230);
            this.starBtn.Name = "starBtn";
            this.starBtn.Size = new System.Drawing.Size(65, 53);
            this.starBtn.TabIndex = 9;
            this.starBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.starBtn.UseVisualStyleBackColor = false;
            this.starBtn.Click += new System.EventHandler(this.starBtn_Click);
            // 
            // RhombBtn
            // 
            this.RhombBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RhombBtn.Image = global::GSC_LR4.Properties.Resources.Diamond;
            this.RhombBtn.Location = new System.Drawing.Point(106, 230);
            this.RhombBtn.Name = "RhombBtn";
            this.RhombBtn.Size = new System.Drawing.Size(63, 53);
            this.RhombBtn.TabIndex = 10;
            this.RhombBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RhombBtn.UseVisualStyleBackColor = false;
            this.RhombBtn.Click += new System.EventHandler(this.RhombBtn_Click);
            // 
            // segmentBtn
            // 
            this.segmentBtn.BackColor = System.Drawing.SystemColors.Control;
            this.segmentBtn.Image = global::GSC_LR4.Properties.Resources.Отрезки2w300;
            this.segmentBtn.Location = new System.Drawing.Point(27, 289);
            this.segmentBtn.Name = "segmentBtn";
            this.segmentBtn.Size = new System.Drawing.Size(64, 52);
            this.segmentBtn.TabIndex = 12;
            this.segmentBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.segmentBtn.UseVisualStyleBackColor = false;
            // 
            // splineBtn
            // 
            this.splineBtn.BackColor = System.Drawing.SystemColors.Control;
            this.splineBtn.Image = global::GSC_LR4.Properties.Resources.Screenshot_72;
            this.splineBtn.Location = new System.Drawing.Point(112, 289);
            this.splineBtn.Name = "splineBtn";
            this.splineBtn.Size = new System.Drawing.Size(57, 52);
            this.splineBtn.TabIndex = 11;
            this.splineBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.splineBtn.UseVisualStyleBackColor = false;
            // 
            // TMOCmbBox
            // 
            this.TMOCmbBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TMOCmbBox.FormattingEnabled = true;
            this.TMOCmbBox.Items.AddRange(new object[] {
            "Симметрическая разность",
            "Разность"});
            this.TMOCmbBox.Location = new System.Drawing.Point(1522, 826);
            this.TMOCmbBox.Name = "TMOCmbBox";
            this.TMOCmbBox.Size = new System.Drawing.Size(185, 24);
            this.TMOCmbBox.TabIndex = 15;
            this.TMOCmbBox.Text = "Выбор ТМО";
            this.TMOCmbBox.SelectedIndexChanged += new System.EventHandler(this.TMOCmbBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(8, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1580, 754);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // RotateBtn
            // 
            this.RotateBtn.Location = new System.Drawing.Point(1609, 515);
            this.RotateBtn.Name = "RotateBtn";
            this.RotateBtn.Size = new System.Drawing.Size(107, 30);
            this.RotateBtn.TabIndex = 16;
            this.RotateBtn.Text = "Повернуть";
            this.RotateBtn.UseVisualStyleBackColor = true;
            this.RotateBtn.Click += new System.EventHandler(this.RotateBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(1203, 818);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(105, 35);
            this.DeleteBtn.TabIndex = 17;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // ReflectBtn
            // 
            this.ReflectBtn.Location = new System.Drawing.Point(1609, 560);
            this.ReflectBtn.Name = "ReflectBtn";
            this.ReflectBtn.Size = new System.Drawing.Size(107, 32);
            this.ReflectBtn.TabIndex = 18;
            this.ReflectBtn.Text = "Отразить";
            this.ReflectBtn.UseVisualStyleBackColor = true;
            this.ReflectBtn.Click += new System.EventHandler(this.ReflectBtn_Click);
            // 
            // ScaleBtn
            // 
            this.ScaleBtn.Location = new System.Drawing.Point(1609, 609);
            this.ScaleBtn.Name = "ScaleBtn";
            this.ScaleBtn.Size = new System.Drawing.Size(107, 34);
            this.ScaleBtn.TabIndex = 19;
            this.ScaleBtn.Text = "Масштаб";
            this.ScaleBtn.UseVisualStyleBackColor = true;
            this.ScaleBtn.Click += new System.EventHandler(this.ScaleBtn_Click);
            // 
            // ExecuteTMO
            // 
            this.ExecuteTMO.Location = new System.Drawing.Point(1611, 785);
            this.ExecuteTMO.Name = "ExecuteTMO";
            this.ExecuteTMO.Size = new System.Drawing.Size(136, 35);
            this.ExecuteTMO.TabIndex = 21;
            this.ExecuteTMO.Text = "Выполнить ТМО";
            this.ExecuteTMO.UseVisualStyleBackColor = true;
            this.ExecuteTMO.Click += new System.EventHandler(this.ExecuteTMO_Click);
            // 
            // TMO_Mode
            // 
            this.TMO_Mode.AutoSize = true;
            this.TMO_Mode.Location = new System.Drawing.Point(1356, 826);
            this.TMO_Mode.Name = "TMO_Mode";
            this.TMO_Mode.Size = new System.Drawing.Size(108, 21);
            this.TMO_Mode.TabIndex = 22;
            this.TMO_Mode.Text = "Режим ТМО";
            this.TMO_Mode.UseVisualStyleBackColor = true;
            this.TMO_Mode.CheckedChanged += new System.EventHandler(this.TMO_Mode_CheckedChanged);
            // 
            // EnlargeBtn
            // 
            this.EnlargeBtn.Location = new System.Drawing.Point(1609, 663);
            this.EnlargeBtn.Name = "EnlargeBtn";
            this.EnlargeBtn.Size = new System.Drawing.Size(75, 23);
            this.EnlargeBtn.TabIndex = 23;
            this.EnlargeBtn.Text = "+";
            this.EnlargeBtn.UseVisualStyleBackColor = true;
            this.EnlargeBtn.Click += new System.EventHandler(this.EnlargeBtn_Click);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.Location = new System.Drawing.Point(1717, 663);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(75, 23);
            this.MinimizeBtn.TabIndex = 24;
            this.MinimizeBtn.Text = "-";
            this.MinimizeBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1840, 870);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.EnlargeBtn);
            this.Controls.Add(this.TMO_Mode);
            this.Controls.Add(this.ExecuteTMO);
            this.Controls.Add(this.ScaleBtn);
            this.Controls.Add(this.ReflectBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.RotateBtn);
            this.Controls.Add(this.TMOCmbBox);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button starBtn;
        private System.Windows.Forms.Button RhombBtn;
        private System.Windows.Forms.Button splineBtn;
        private System.Windows.Forms.Button segmentBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox TMOCmbBox;
        private System.Windows.Forms.Panel showColor;
        private System.Windows.Forms.Button RotateBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button ReflectBtn;
        private System.Windows.Forms.Button ScaleBtn;
        private System.Windows.Forms.Button ExecuteTMO;
        private System.Windows.Forms.CheckBox TMO_Mode;
        private System.Windows.Forms.Button EnlargeBtn;
        private System.Windows.Forms.Button MinimizeBtn;
    }
}

