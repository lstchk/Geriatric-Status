﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geriatric_Status
{
    class Patient
    {
        private DateTime birthDate; //Дата рождения (изменяется на NewPatient)

        private string name; //Имя пациента

        private string surname; //Фамилия пациента

        private string otchestvo; //Отчество пациента

        private int overallResilience; //Оценка устойчивости

        private bool overallResiliencePassed = false;

        private int walkViolation; //Оценка хотьбы

        private bool walkViolationPassed = false;

        private int motorActivitySum; //Сумма баллов оценок устойчивости и хотьбы

        private int malnutrition1; // Результат оценки риска развития синдрома мальнутриции 1 часть

        private bool malnutrition1Passed = false;

        private double malnutrition2; // Результат оценки риска развития синдрома мальнутриции 2 часть

        private bool malnutrition2Passed = false;

        private double malnutritionSum; //Сумма баллов тестов мальнутриции

        private int cognitiveBal; //Баллы за тест когнитивности

        private bool cognitivePassed; 

        private double status; //Итоговый расчет статуса

        private bool reflesh = false; //Нужно для проверки и обновления форм

        private string gender; //Пол

        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Otchestvo { get => otchestvo; set => otchestvo = value; }
        public int OverallResilience { get => overallResilience; set => overallResilience = value; }
        public int WalkViolation { get => walkViolation; set => walkViolation = value; }
        public bool WalkViolationPassed { get => walkViolationPassed; set => walkViolationPassed = value; }
        public bool OverallResiliencePassed { get => overallResiliencePassed; set => overallResiliencePassed = value; }
        public int MotorActivitySum { get => motorActivitySum; set => motorActivitySum = value; }
        public int Malnutrition1 { get => malnutrition1; set => malnutrition1 = value; }
        public bool Malnutrition1Passed { get => malnutrition1Passed; set => malnutrition1Passed = value; }
        public double Malnutrition2 { get => malnutrition2; set => malnutrition2 = value; }
        public bool Malnutrition2Passed { get => malnutrition2Passed; set => malnutrition2Passed = value; }
        public double MalnutritionSum { get => malnutritionSum; set => malnutritionSum = value; }
        public int CognitiveBal { get => cognitiveBal; set => cognitiveBal = value; }
        public bool CognitivePassed { get => cognitivePassed; set => cognitivePassed = value; }
        public double Status { get => status; set => status = value; }
        public bool Reflesh { get => reflesh; set => reflesh = value; }
        public string Gender { get => gender; set => gender = value; }
    }
}
