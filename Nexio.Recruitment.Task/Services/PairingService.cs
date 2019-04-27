using Nexio.Recruitment.Task.Models.ViewModels;
using Nexio.Recruitment.Task.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;

namespace Nexio.Recruitment.Task.Services
{
    /// <summary>
    /// Klasa obsługująca logikę zadanego zadania, Posiada metodę sprawdzającą dopasowanie.
    /// </summary>
    public class PairingService : IPairingService
    {
        private PersonViewModel _woman;
        private PersonViewModel _man;
        private List<Func<bool>> _tests;
        public PairingService()
        {
            _tests = new List<Func<bool>>
            {
                SameEyeColor,
                HeightCompare,
                AgeDifference
            };
        }

        public bool DoTheyMatch(PersonViewModel woman, PersonViewModel man)
        {
            _woman = woman;
            _man = man;
            int counter = 0;
            foreach (Func<bool> test in _tests)
            {
                if (test.Invoke())
                {
                    counter++;
                }
            }
            if (counter >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SameEyeColor()
        {
            if (_man.EyeColor == _woman.EyeColor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool HeightCompare()
        {
            if (_man.Height - 10 > _woman.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool AgeDifference()
        {
            DateTime now = DateTime.Today;
            int ageMan = now.Year - _man.BirthDate.Year;
            int ageWoman = now.Year - _woman.BirthDate.Year;
            if (Math.Abs(ageMan - ageWoman) < 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}