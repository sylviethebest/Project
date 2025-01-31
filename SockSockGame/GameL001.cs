﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SockSockGame
{
    class GameL001
    {
        //Form1의 요소들에 접근하기 위해 객체 생성
        static Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();

        //랜덤번호 뽑기 위한 랜덤객체
        static Random rand = new Random();

        //이미지박스 카테고리(주로 미니게임내에 사용되는 객체들에 이용)
        public PictureBox Image1 = new PictureBox();

        //Lable 게임 제목 
        public Label lblGameName = new Label();

        int clear = 0;

        private void play()
        {
            while (true)
            {
                Thread.Sleep(700);
                int i = rand.Next(6);
                if (form.InvokeRequired)
                {
                    form.Invoke(new MethodInvoker(delegate ()
                    {
                        switch (i)
                        {
                            case 0:
                                Image1.Location = new Point(15, 231);
                                break;
                            case 1:
                                Image1.Location = new Point(336, 231);
                                break;
                            case 2:
                                Image1.Location = new Point(658, 231);
                                break;
                            case 3:
                                Image1.Location = new Point(15, 477);
                                break;
                            case 4:
                                Image1.Location = new Point(336, 477);
                                break;
                            case 5:
                                Image1.Location = new Point(336, 477);
                                break;
                        }
                    }));
                }
            }
        }

        public void Game_L001()
        {
            form.thrG = new Thread(new ThreadStart(play));
            form.thrOn = true; 
            //초반 화면 정리 및 배치
            form.Visible_Game_Start();
            form.pnlMain.Controls.Add(lblGameName);
            form.pnlMain.Controls.Add(Image1);
            form.BG1();

            lblGameName.Visible = true;
            lblGameName.BackColor = System.Drawing.Color.Transparent;
            lblGameName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            lblGameName.Text = "두더지 잡기";
            lblGameName.Location = new Point(190, 124);
            lblGameName.Size = new System.Drawing.Size(610, 101);
            lblGameName.ForeColor = System.Drawing.Color.Cyan;
            lblGameName.Font = new System.Drawing.Font("휴먼둥근헤드라인", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            Image1.Location = new System.Drawing.Point(15, 231);
            Image1.Size = new System.Drawing.Size(301, 230);
            Image1.Image = Properties.Resources.Duduge;
            Image1.BackColor = System.Drawing.Color.Transparent;
            Image1.SizeMode = PictureBoxSizeMode.StretchImage;

            clear = 5;
            Image1.Click += Image_Click;

            form.thrG.IsBackground = true;
            form.thrG.Start();
        }

        private void Image_Click(object sender, EventArgs e)
        {
            clear--;
            System.Media.SoundPlayer soundPlayer1;

            soundPlayer1 = new System.Media.SoundPlayer(Properties.Resources.Bbong);
            soundPlayer1.Stop();
            soundPlayer1.Play();

            if (clear == 0)
            {
                //종료구간
                Image1.Visible = false;
                lblGameName.Visible = false;
                form.thrOn = false;
                form.Next_Game();
            }
            else
            {
                int i = rand.Next(6);
                switch (i)
                {
                    case 0:
                        Image1.Location = new Point(15, 231);
                        break;
                    case 1:
                        Image1.Location = new Point(336, 231);
                        break;
                    case 2:
                        Image1.Location = new Point(658, 231);
                        break;
                    case 3:
                        Image1.Location = new Point(15, 477);
                        break;
                    case 4:
                        Image1.Location = new Point(336, 477);
                        break;
                    case 5:
                        Image1.Location = new Point(336, 477);
                        break;
                }
            }

        }
    }
}
