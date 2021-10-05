namespace KinectQuizDesktop
{
    partial class FormMain
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
            this.labelName = new System.Windows.Forms.Label();
            this.pictureFish = new System.Windows.Forms.PictureBox();
            this.pictureButterfly = new System.Windows.Forms.PictureBox();
            this.pictureCar = new System.Windows.Forms.PictureBox();
            this.pictureBall = new System.Windows.Forms.PictureBox();
            this.pictureIcecream = new System.Windows.Forms.PictureBox();
            this.pictureApple = new System.Windows.Forms.PictureBox();
            this.buttonGB = new System.Windows.Forms.Button();
            this.buttonIT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureButterfly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcecream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureApple)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(105, 143);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(101, 31);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Ready!";
            // 
            // pictureFish
            // 
            this.pictureFish.Image = global::KinectQuizDesktop.Properties.Resources.Fish;
            this.pictureFish.Location = new System.Drawing.Point(477, 12);
            this.pictureFish.Name = "pictureFish";
            this.pictureFish.Size = new System.Drawing.Size(87, 87);
            this.pictureFish.TabIndex = 5;
            this.pictureFish.TabStop = false;
            // 
            // pictureButterfly
            // 
            this.pictureButterfly.Image = global::KinectQuizDesktop.Properties.Resources.Butterfly;
            this.pictureButterfly.Location = new System.Drawing.Point(384, 12);
            this.pictureButterfly.Name = "pictureButterfly";
            this.pictureButterfly.Size = new System.Drawing.Size(87, 87);
            this.pictureButterfly.TabIndex = 4;
            this.pictureButterfly.TabStop = false;
            // 
            // pictureCar
            // 
            this.pictureCar.Image = global::KinectQuizDesktop.Properties.Resources.Car;
            this.pictureCar.Location = new System.Drawing.Point(291, 12);
            this.pictureCar.Name = "pictureCar";
            this.pictureCar.Size = new System.Drawing.Size(87, 87);
            this.pictureCar.TabIndex = 3;
            this.pictureCar.TabStop = false;
            // 
            // pictureBall
            // 
            this.pictureBall.Image = global::KinectQuizDesktop.Properties.Resources.Ball;
            this.pictureBall.Location = new System.Drawing.Point(198, 12);
            this.pictureBall.Name = "pictureBall";
            this.pictureBall.Size = new System.Drawing.Size(87, 87);
            this.pictureBall.TabIndex = 2;
            this.pictureBall.TabStop = false;
            // 
            // pictureIcecream
            // 
            this.pictureIcecream.Image = global::KinectQuizDesktop.Properties.Resources.Ice_cream;
            this.pictureIcecream.Location = new System.Drawing.Point(105, 12);
            this.pictureIcecream.Name = "pictureIcecream";
            this.pictureIcecream.Size = new System.Drawing.Size(87, 87);
            this.pictureIcecream.TabIndex = 1;
            this.pictureIcecream.TabStop = false;
            // 
            // pictureApple
            // 
            this.pictureApple.Image = global::KinectQuizDesktop.Properties.Resources.Apple;
            this.pictureApple.Location = new System.Drawing.Point(12, 12);
            this.pictureApple.Name = "pictureApple";
            this.pictureApple.Size = new System.Drawing.Size(87, 87);
            this.pictureApple.TabIndex = 0;
            this.pictureApple.TabStop = false;
            // 
            // buttonGB
            // 
            this.buttonGB.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGB.Image = global::KinectQuizDesktop.Properties.Resources.uk;
            this.buttonGB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGB.Location = new System.Drawing.Point(120, 233);
            this.buttonGB.Name = "buttonGB";
            this.buttonGB.Size = new System.Drawing.Size(127, 44);
            this.buttonGB.TabIndex = 7;
            this.buttonGB.Text = "English";
            this.buttonGB.UseVisualStyleBackColor = false;
            this.buttonGB.Click += new System.EventHandler(this.buttonGB_Click);
            // 
            // buttonIT
            // 
            this.buttonIT.Image = global::KinectQuizDesktop.Properties.Resources.italy;
            this.buttonIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIT.Location = new System.Drawing.Point(311, 233);
            this.buttonIT.Name = "buttonIT";
            this.buttonIT.Size = new System.Drawing.Size(127, 44);
            this.buttonIT.TabIndex = 8;
            this.buttonIT.Text = "Italian";
            this.buttonIT.UseVisualStyleBackColor = true;
            this.buttonIT.Click += new System.EventHandler(this.buttonIT_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 319);
            this.Controls.Add(this.buttonIT);
            this.Controls.Add(this.buttonGB);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureFish);
            this.Controls.Add(this.pictureButterfly);
            this.Controls.Add(this.pictureCar);
            this.Controls.Add(this.pictureBall);
            this.Controls.Add(this.pictureIcecream);
            this.Controls.Add(this.pictureApple);
            this.Name = "FormMain";
            this.Text = "Kinect Sensor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureFish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureButterfly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcecream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureApple)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureApple;
        private System.Windows.Forms.PictureBox pictureIcecream;
        private System.Windows.Forms.PictureBox pictureBall;
        private System.Windows.Forms.PictureBox pictureCar;
        private System.Windows.Forms.PictureBox pictureButterfly;
        private System.Windows.Forms.PictureBox pictureFish;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonGB;
        private System.Windows.Forms.Button buttonIT;
    }
}

