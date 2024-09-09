using FluentValidation;
using PicApp.ViewModels;

namespace PicApp.Validations
{
    public class LoginValidation: AbstractValidator<LoginViewModel>
    {
        private int min = 4;
        private int max = 8;
        public LoginValidation()
        {
            RuleFor(x => x.Password).NotNull().WithMessage("Pin-код не должен быть пустым")
                                    .Must(x => x.Length >= min && x.Length <= max).WithMessage($"Pin-код должен содержать от {min} до {max} символов.");
        }
    }
}
