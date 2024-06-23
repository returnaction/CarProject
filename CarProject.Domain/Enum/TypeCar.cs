using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Легкий Автомобиль")]
        PassangerCar = 0,
        [Display(Name = "Седан")]
        Sedan = 1,
        [Display(Name = "Хэтчбэк")]
        HatchBack = 2,
        [Display(Name = "Минивэн")]
        Minivan = 3,
        [Display(Name = "Спортивная машина")]
        SportCar = 4,
        [Display(Name = "Внедорожник")]
        Sub = 5

    }
}
