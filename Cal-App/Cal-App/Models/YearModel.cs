﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cal_App.Models
{
    public class YearModel : BaseModel
    {
        private int number = DateTime.Now.Year;
        private int isLeap;
        private MonthModel[] items;

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (this.number != value)
                {
                    this.number = value;
                    this.OnPropertyChanged("Number");
                }

            }
        }

        public int IsLeap
        {
            get
            {
                return isLeap;
            }

            set
            {
                if (this.isLeap != value)
                {
                    this.isLeap = value;
                    this.OnPropertyChanged("IsLeap");
                }

            }
        }

        public MonthModel[] Items1
        {
            get
            {
                return items;
            }

            set
            {
                if (items != value)
                {
                    items = value;
                    this.OnPropertyChanged("Items1");
                }

            }
        }
        public YearModel(int year, bool showHolidays)
        {
            this.items = new MonthModel[12] {
                new MonthModel(1, year, showHolidays),
                new MonthModel(2, year, showHolidays),
                new MonthModel(3, year, showHolidays),
                new MonthModel(4, year, showHolidays),
                new MonthModel(5, year, showHolidays),
                new MonthModel(6, year, showHolidays),
                new MonthModel(7, year, showHolidays),
                new MonthModel(8, year, showHolidays),
                new MonthModel(9, year, showHolidays),
                new MonthModel(10, year, showHolidays),
                new MonthModel(11, year, showHolidays),
                new MonthModel(12, year, showHolidays)
            };
        }


    }
}