using FluentValidation;
using Kaihatsu.CardManager.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.CardManager.FluentValidation;

internal class AuthorizationRequestValidator : AbstractValidator<AuthorizationRequest>
{
    public AuthorizationRequestValidator()
    {
        RuleFor(x => x.Login)
            .NotNull()
            .Length(5, 255)
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotNull()
            .Length(5, 50);
    }
}
