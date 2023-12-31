﻿using ErrorOr;
using MediatR;
using Identity.Src.Application.Authentication.DTOs;

namespace Identity.Src.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password, DateOnly BirthDate) : IRequest<ErrorOr<Created>>;


