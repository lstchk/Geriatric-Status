﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geriatric_Status
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            this.Size = new Size(1100, 700);
        }

        //Проверка оценок устойчивости и хотьбы на заполненность
        private void checkMotorActivity()
        {
            if (Program.patient.WalkViolationPassed  && Program.patient.OverallResiliencePassed)
            {
                Program.patient.MotorActivitySum = Program.patient.WalkViolation + Program.patient.OverallResilience;
                MessageBox.Show("Оценка двигательной активности: " + Program.patient.MotorActivitySum + " баллов");
            }
        }

        private void checkMalnutrition()
        {
            if(Program.patient.Malnutrition1Passed && Program.patient.Malnutrition2Passed)
            {
                Program.patient.MalnutritionSum = Program.patient.Malnutrition1 + Program.patient.Malnutrition2;
                MessageBox.Show("Оценка риска развития синдрома мальнутриции: " + Program.patient.MalnutritionSum + " баллов");
            }
        }

        private void checkCognitive()
        {      
            MessageBox.Show("Оценка когнитивных способностей: " + Program.patient.CognitiveBal + " баллов");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            NewPatient np = new NewPatient();
            np.ShowDialog();
            Program.patient.Reflesh = false;
            patientDataLabel.Text = Program.patient.Surname + " " + Program.patient.Name + " " + Program.patient.Otchestvo + " " + Program.patient.BirthDate.ToShortDateString();
            //Изначально все лайоуты скрыты
            OverallResilience.Hide();
            WalkViolation.Hide();
            MalnutriciaPart1.Hide();
            MalnutriciaPart2.Hide();
            Cognitive.Hide();
        }

        private void NewPatientButton_Click(object sender, EventArgs e)
        {
            //Вызов окна создания нового пациента
            NewPatient np = new NewPatient();
            np.ShowDialog();
            patientDataLabel.Text = Program.patient.Surname + " " + Program.patient.Name + " " + Program.patient.Otchestvo + " " + Program.patient.BirthDate.ToShortDateString();
            if (Program.patient.Reflesh)
            {
                s1.Text = null;
                s2.Text = null;
                s3.Text = null;
                s4.Text = null;
                s5.Text = null;
                orcb1.SelectedIndex = -1;
                orcb2.SelectedIndex = -1;
                orcb3.SelectedIndex = -1;
                orcb4.SelectedIndex = -1;
                orcb5.SelectedIndex = -1;
                orcb6.SelectedIndex = -1;
                orcb7.SelectedIndex = -1;
                orcb8.SelectedIndex = -1;
                orcb9.SelectedIndex = -1;
                orcb10.SelectedIndex = -1;
                orcb11.SelectedIndex = -1;
                orcb12.SelectedIndex = -1;
                orcb13.SelectedIndex = -1;
                orcb14.SelectedIndex = -1;
                orcb15.SelectedIndex = -1;
                OverallResilience.Hide();

                wvcb12.SelectedIndex = -1;
                wvcb11.SelectedIndex = -1;
                wvcb10.SelectedIndex = -1;
                wvcb9.SelectedIndex = -1;
                wvcb8.SelectedIndex = -1;
                wvcb7.SelectedIndex = -1;
                wvcb6.SelectedIndex = -1;
                wvcb5.SelectedIndex = -1;
                wvcb4.SelectedIndex = -1;
                wvcb3.SelectedIndex = -1;
                wvcb2.SelectedIndex = -1;
                wvcb1.SelectedIndex = -1;
                WalkViolation.Hide();

                mcb6.SelectedIndex = -1;
                mcb5.SelectedIndex = -1;
                mcb4.SelectedIndex = -1;
                mcb3.SelectedIndex = -1;
                mcb2.SelectedIndex = -1;
                mcb1.SelectedIndex = -1;
                MalnutriciaPart1.Hide();

                m2cb12.SelectedIndex = -1;
                m2cb11.SelectedIndex = -1;
                m2cb10.SelectedIndex = -1;
                m2cb9.SelectedIndex = -1;
                m2cb8.SelectedIndex = -1;
                m2cb7.SelectedIndex = -1;
                m2cb6.SelectedIndex = -1;
                m2cb5.SelectedIndex = -1;
                m2cb4.SelectedIndex = -1;
                m2cb3.SelectedIndex = -1;
                m2cb2.SelectedIndex = -1;
                m2cb1.SelectedIndex = -1;
                MalnutriciaPart2.Hide();

                ccb1.SelectedIndex = -1;
                ccb2.SelectedIndex = -1;
                ccb3.SelectedIndex = -1;
                ccb4.SelectedIndex = -1;
                ccb5.SelectedIndex = -1;
                ccb6.SelectedIndex = -1;
                ccb7.SelectedIndex = -1;
                ccb8.SelectedIndex = -1;
                ccb9.SelectedIndex = -1;
                ccb10.SelectedIndex = -1;
                ccb11.SelectedIndex = -1;
                Cognitive.Hide();


                Program.patient.Reflesh = false;
            }
            
        }

        private void ORButton_Click(object sender, EventArgs e)
        {
            OverallResilience.Show();
            WalkViolation.Hide();
            MalnutriciaPart1.Hide();
            MalnutriciaPart2.Hide();
            Cognitive.Hide();
        }

        //Расчет устойчивости
        private void ORSaveButton_Click(object sender, EventArgs e)
        {
            //Проверка всех комбобоксов на заполненность
            if(orcb1.SelectedIndex > -1 &&
                orcb2.SelectedIndex > -1 &&
                orcb3.SelectedIndex > -1 &&
                orcb4.SelectedIndex > -1 &&
                orcb5.SelectedIndex > -1 &&
                orcb6.SelectedIndex > -1 &&
                orcb7.SelectedIndex > -1 &&
                orcb8.SelectedIndex > -1 &&
                orcb9.SelectedIndex > -1 &&
                orcb10.SelectedIndex > -1 &&
                orcb11.SelectedIndex > -1 &&
                orcb12.SelectedIndex > -1 &&
                orcb13.SelectedIndex > -1 &&
                orcb14.SelectedIndex > -1 &&
                orcb15.SelectedIndex > -1  )
            {
                OverallResilience.Hide();

                //Расчет суммы баллов
                Program.patient.OverallResilience =
                    orcb1.SelectedIndex +
                    orcb2.SelectedIndex +
                    orcb3.SelectedIndex +
                    orcb4.SelectedIndex +
                    orcb5.SelectedIndex +
                    orcb6.SelectedIndex +
                    orcb7.SelectedIndex +
                    orcb8.SelectedIndex +
                    orcb9.SelectedIndex +
                    orcb10.SelectedIndex +
                    orcb11.SelectedIndex +
                    orcb12.SelectedIndex +
                    orcb13.SelectedIndex +
                    orcb14.SelectedIndex +
                    orcb15.SelectedIndex;
                Program.patient.OverallResiliencePassed = true;
                if (Program.patient.OverallResilience > 24) Program.patient.OverallResilience = 24;
                MessageBox.Show("Набрано баллов: " + Program.patient.OverallResilience);
                checkMotorActivity();
                s1.Text = Program.patient.OverallResilience.ToString();
            }
            else
            {
                MessageBox.Show("Не все параметры выбраны!");
            }
        }

        private void WVButton_Click(object sender, EventArgs e)
        {
            OverallResilience.Hide();
            WalkViolation.Show();
            MalnutriciaPart1.Hide();
            MalnutriciaPart2.Hide();
            Cognitive.Hide();
        }

        //Двигательная активность
        private void WVSaveButton_Click(object sender, EventArgs e)
        {
            if (wvcb12.SelectedIndex > -1 &&
                wvcb11.SelectedIndex > -1 &&
                wvcb10.SelectedIndex > -1 &&
                wvcb9.SelectedIndex > -1 &&
                wvcb8.SelectedIndex > -1 &&
                wvcb7.SelectedIndex > -1 &&
                wvcb6.SelectedIndex > -1 &&
                wvcb5.SelectedIndex > -1 &&
                wvcb4.SelectedIndex > -1 &&
                wvcb3.SelectedIndex > -1 &&
                wvcb2.SelectedIndex > -1 &&
                wvcb1.SelectedIndex > -1   )
            {
                WalkViolation.Hide();

                Program.patient.WalkViolation =
                    wvcb12.SelectedIndex +
                    wvcb11.SelectedIndex +
                    wvcb10.SelectedIndex +
                    wvcb9.SelectedIndex +
                    wvcb8.SelectedIndex +
                    wvcb7.SelectedIndex +
                    wvcb6.SelectedIndex +
                    wvcb5.SelectedIndex +
                    wvcb4.SelectedIndex +
                    wvcb3.SelectedIndex +
                    wvcb2.SelectedIndex +
                    wvcb1.SelectedIndex;
                Program.patient.WalkViolationPassed = true;
                if (Program.patient.WalkViolation > 16) Program.patient.WalkViolation = 16;
                MessageBox.Show("Набрано баллов: " + Program.patient.WalkViolation);
                s2.Text = Program.patient.WalkViolation.ToString();
                checkMotorActivity();
            }
            else
            {
                MessageBox.Show("Не все параметры выбраны!");
            }
        }

        private void Mbutton_Click(object sender, EventArgs e)
        {
            OverallResilience.Hide();
            WalkViolation.Hide();
            MalnutriciaPart1.Show();
            MalnutriciaPart2.Hide();
            Cognitive.Hide();
        }

        //Мальнутриции 1
        private void MSaveButton_Click(object sender, EventArgs e)
        {
            if (
               mcb6.SelectedIndex > -1 &&
               mcb5.SelectedIndex > -1 &&
               mcb4.SelectedIndex > -1 &&
               mcb3.SelectedIndex > -1 &&
               mcb2.SelectedIndex > -1 &&
               mcb1.SelectedIndex > -1)
            {
                MalnutriciaPart1.Hide();

                Program.patient.Malnutrition1 = 
                    mcb6.SelectedIndex +
                    mcb5.SelectedIndex +
                    mcb4.SelectedIndex +
                    mcb3.SelectedIndex +
                    mcb2.SelectedIndex +
                    mcb1.SelectedIndex;

                //Максимальное количество очков - 14
                if (Program.patient.Malnutrition1 > 14)
                    Program.patient.Malnutrition1 = 14;
              
                MessageBox.Show("Набрано баллов: " + Program.patient.Malnutrition1);

                Program.patient.Malnutrition1Passed = true;
                s3.Text = Program.patient.Malnutrition1.ToString();
                checkMalnutrition();
            }
            else
            {
                MessageBox.Show("Не все параметры выбраны!");
            }
        }

        private void M2Button_Click(object sender, EventArgs e)
        {
            OverallResilience.Hide();
            WalkViolation.Hide();
            MalnutriciaPart1.Hide();
            MalnutriciaPart2.Show();
            Cognitive.Hide();
        }

        //Мальнутриции 2
        private void M2SaveButton_Click(object sender, EventArgs e)
        {
            if (m2cb12.SelectedIndex > -1 &&
               m2cb11.SelectedIndex > -1 &&
               m2cb10.SelectedIndex > -1 &&
               m2cb9.SelectedIndex > -1 &&
               m2cb8.SelectedIndex > -1 &&
               m2cb7.SelectedIndex > -1 &&
               m2cb6.SelectedIndex > -1 &&
               m2cb5.SelectedIndex > -1 &&
               m2cb4.SelectedIndex > -1 &&
               m2cb3.SelectedIndex > -1 &&
               m2cb2.SelectedIndex > -1 &&
               m2cb1.SelectedIndex > -1)
            {
                MalnutriciaPart2.Hide();

                Program.patient.Malnutrition2 =
                    m2cb12.SelectedIndex +
                    m2cb11.SelectedIndex/2 +
                    m2cb10.SelectedIndex/2 +
                    m2cb8.SelectedIndex +
                    m2cb7.SelectedIndex +
                    m2cb6.SelectedIndex/2 +  //0-3 /5
                    m2cb5.SelectedIndex/2 + // 0- 3  |2
                    m2cb4.SelectedIndex +  // 0- 2
                    m2cb3.SelectedIndex + // 0 -1 
                    m2cb2.SelectedIndex + //0 -1
                    m2cb1.SelectedIndex; //0 - 1

                //Распределение очков для этого параметра  0-0.5-1-2
                if (m2cb9.SelectedIndex == 0)
                    Program.patient.Malnutrition2 += 0;
                if (m2cb9.SelectedIndex == 1)
                    Program.patient.Malnutrition2 += 0.5;
                if (m2cb9.SelectedIndex == 2)
                    Program.patient.Malnutrition2 += 1;
                if (m2cb9.SelectedIndex == 3)
                    Program.patient.Malnutrition2 += 2;

                //Максимальное количество очков - 16
                if (Program.patient.Malnutrition2 > 16)
                    Program.patient.Malnutrition2 = 16;

                Program.patient.Malnutrition2Passed = true;

                MessageBox.Show("Набрано баллов: " + Program.patient.Malnutrition2);
                s4.Text = Program.patient.Malnutrition2.ToString();
                checkMalnutrition();
            }
            else
            {
                MessageBox.Show("Не все параметры выбраны!");
            }
        }

        private void CButton_Click(object sender, EventArgs e)
        {
            OverallResilience.Hide();
            WalkViolation.Hide();
            MalnutriciaPart1.Hide();
            MalnutriciaPart2.Hide();
            Cognitive.Show();
        }

        private void CSaveButton_Click(object sender, EventArgs e)
        {
            if (ccb1.SelectedIndex > -1 &&
              ccb2.SelectedIndex > -1 &&
              ccb3.SelectedIndex > -1 &&
              ccb4.SelectedIndex > -1 &&
              ccb5.SelectedIndex > -1 &&
              ccb6.SelectedIndex > -1 &&
              ccb7.SelectedIndex > -1 &&
              ccb8.SelectedIndex > -1 &&
              ccb9.SelectedIndex > -1 &&
              ccb10.SelectedIndex > -1 &&
              ccb11.SelectedIndex > -1)
            {
                Cognitive.Hide();

                Program.patient.CognitiveBal =
                    ccb1.SelectedIndex +
                    ccb2.SelectedIndex +
                    ccb3.SelectedIndex +
                    ccb4.SelectedIndex +
                    ccb5.SelectedIndex + 
                    ccb6.SelectedIndex +
                    ccb7.SelectedIndex + 
                    ccb8.SelectedIndex +
                    ccb8.SelectedIndex +
                    ccb9.SelectedIndex;


                //Максимальное количество очков - 33
                if (Program.patient.CognitiveBal > 33)
                    Program.patient.CognitiveBal = 33;

                Program.patient.CognitivePassed = true;
                s5.Text = Program.patient.CognitiveBal.ToString();
                checkCognitive();
            }
            else
            {
                MessageBox.Show("Не все параметры выбраны!");
            }
        }

        private void AButton_Click(object sender, EventArgs e)
        {
            if (Program.patient.CognitivePassed && Program.patient.Malnutrition1Passed
                && Program.patient.Malnutrition2Passed &&
                Program.patient.OverallResiliencePassed && Program.patient.WalkViolationPassed)
            {
                Analize analize = new Analize();
                analize.ShowDialog();
            }
            else
                MessageBox.Show("Не все тесты выполнены!");
                   
        }
    }
}
